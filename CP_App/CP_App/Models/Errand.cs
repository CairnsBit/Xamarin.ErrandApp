using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CP_App.Models
{
    public class Errand
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
