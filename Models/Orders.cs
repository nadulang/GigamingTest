using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace nadya_asp_rest_test1.Models
{
    public class Order
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int driver_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    
    }

    // public enum Status
    // {
    //     Ok, Cancel
    // }

    // public class MyClass
    // {
    //     Status privateObj;

    //     public MyClass()
    //     {

    //     }
    //     public Status EnumProperty
    //     {
    //         get
    //         {
    //             return privateObj;
    //         }
    //         set 
    //         {
    //             privateObj = value;
    //         }
    //     }

    // }

    // public class MainClass
    // {
    //     public MainClass()
    //     {
    //         Status obj = new Status();
    //         // obj.EnumProperty = Status.Ok;
    //     }
    // }
}