using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Coffee.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public int Balance { get; set; }
        public int SpecialCount { get; set; }
        public Boolean SpecialEnabled { get; set; }


    }
}
