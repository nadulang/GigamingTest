using System;
using Npgsql;
using nadya_asp_rest_test1.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

public interface IDependency
{
    int Create(Customer user);
    List<Customer> Read();
    Customer GetById(int id);
    int Delete(int id);
    int Update([FromBody]JsonPatchDocument<Customer> user, int id);
}

public class Dependency : IDependency
{
    NpgsqlConnection _connection;

    public Dependency(NpgsqlConnection connection)
    {
        _connection = connection;
        _connection.Open();
    }

    public int Create(Customer user)
    {
        var command = _connection.CreateCommand();
        command.CommandText = "INSERT INTO \"Customer\" (full_name, username, email, phone_number) VALUES (@full_name, @username, @email, @phone_number) RETURNING id";

        command.Parameters.AddWithValue("@full_name", user.Full_name);
        command.Parameters.AddWithValue("@username", user.Username);
        command.Parameters.AddWithValue("@email", user.Email);
        command.Parameters.AddWithValue("@phone_number", user.Phone_Number);

        command.Prepare();

        var result = command.ExecuteScalar();
        _connection.Close();

        return (int)result;

    }

    public List<Customer> Read()
    {
        var command = _connection.CreateCommand();
        command.CommandText = "SELECT * FROM \"Customers\"";

        var result = command.ExecuteReader();
        var UserCustomers = new List<Customer>();
        while (result.Read())
                UserCustomers.Add(new Customer() { Id = (int)result[0], Full_name = (string)result[1], Username = (string)result[2], Email = (string)result[3], Phone_Number = (string)result[4]});
            _connection.Close();
            return UserCustomers;
    }

    public Customer GetById(int id)
    {
        var command = _connection.CreateCommand();
        command.CommandText = $"SELECT * FROM \"Customer\" WHERE id={id}";
        // command.Parameters.AddWithValue("@id", id);
        var result = command.ExecuteReader();
        result.Read();
        var UserCustomers = new Customer()
        { Id = (int)result[0], Full_name = (string)result[1], Username = (string)result[2], Email = (string)result[3], Phone_Number = (string)result[4] };
            _connection.Close();
        
        return UserCustomers;

    }

    public int Delete(int id)
    {
        var command = _connection.CreateCommand();

        command.CommandText = $"DELETE FROM \"Customer\" WHERE id={id}";

        // command.Parameters.AddWithValue("@id", user.Id);

        var result = command.ExecuteNonQuery();
        _connection.Close();
        return (int)result;
    }

    public int Update([FromBody]JsonPatchDocument<Customer> user, int id)
    {
        var command = _connection.CreateCommand();
        var users = GetById(id);
        _connection.Open();
        user.ApplyTo(users);

        command.CommandText = $"UPDATE \"Customer\" SET (full_name, username, email, phone_number) = (@full_name, @username, @email, @phone_number) WHERE id={id}";
        command.Parameters.AddWithValue("@full_name", users.Full_name);
        command.Parameters.AddWithValue("@username", users.Username);
        command.Parameters.AddWithValue("@email", users.Email);
        command.Parameters.AddWithValue("@phone_number", users.Phone_Number);
        
        var result = command.ExecuteNonQuery();
        _connection.Close();

        return result;

    }
}