using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffee.Models
{
    public class Pet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int ShelterID { get; set; }
        public int PetTypeID { get; set; }
        public string PetName { get; set; } = "Meow";

        public string Gender { get; set; }
        public string ImagePath { get; set; } = "DefaultPet.jpg";
        public int Age { get; set; } = 1;
    }
}
