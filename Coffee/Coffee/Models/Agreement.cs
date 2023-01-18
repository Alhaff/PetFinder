using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Coffee.Models;

namespace Coffee.Models
{
    public class Agreement
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int UserID { get; set; }
        public string ContactPhone { get; set; }
        public int PetID { get; set; }
        public DateTime orderTime { get; set; }

    }
}
