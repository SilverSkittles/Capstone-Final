using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SeedShare.Models
{
    public class UserData
    {
        [PrimaryKey, AutoIncrement]
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool active { get; set; }

    }
}
