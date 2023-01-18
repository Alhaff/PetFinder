using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffee.Models
{
    public class PetType
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string TypeName { get; set; }   
    }
}
