using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coffee.Models
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int PetID { get; set; }
       
        public string Description { get; set; } = "I'am very kindfull pet, and I'll so happy, if you bring me home";

        public DateTime PublishingTime { get; set; }
    }
}
