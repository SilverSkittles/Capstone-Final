using Xamarin.Forms;
using MvvmHelpers;
using SeedShare.Views;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SeedShare.Models
{
    public class Libraries
    {
        [PrimaryKey, AutoIncrement]
        public int libraryId { get; set; }
        public string libraryName { get; set; }
        public string libraryStreet { get; set; }
        public string libraryCity { get; set; }
        public string libraryState { get; set; }
        public string libraryZip { get; set; }
        public string libraryPhone { get; set; }
        public string libraryHours { get; set; }
        public string publicLibraryUrl { get; set; }
        
        public string libraryLocation => libraryStreet + " " + libraryCity + " " + libraryState + " " + libraryZip;

    }
}
