using System;
using System.ComponentModel.DataAnnotations;

namespace nadya_asp_rest_test1.Models
{
    public class Driver
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string phone_number { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}