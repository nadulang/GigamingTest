using System;
using System.ComponentModel.DataAnnotations;

namespace nadya_asp_rest_test1.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }

         public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}