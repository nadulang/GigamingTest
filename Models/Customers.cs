using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace nadya_asp_rest_test1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Full_name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}