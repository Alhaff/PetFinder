using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffee.Models
{
    public class PetShelter
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }
    }
}
