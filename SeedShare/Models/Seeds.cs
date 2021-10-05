using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeedShare.Models
{
    public class Seeds
    {
        [PrimaryKey, AutoIncrement]
        public int seedId { get; set; }
        public string seedName { get; set; }
        public string packetQuantity { get; set; }
        public string location { get; set; }
        
    }
}
