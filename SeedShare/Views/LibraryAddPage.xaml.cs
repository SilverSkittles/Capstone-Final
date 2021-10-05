using Plugin.Toast;
using SeedShare.Models;
using SeedShare.Services;
using SeedShare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeedShare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryAddPage : ContentPage
    {
        public string libraryName { get; set; }
        public string libraryStreet { get; set; }
        public string libraryCity { get; set; }
        public string libraryState { get; set; }
        public string libraryZip { get; set; }
        public string libraryPhone { get; set; }
        public string libraryHours { get; set; }
        public string publicLibraryUrl { get; set; }
        public LibraryAddPage()
        {
            InitializeComponent();

        }       
               

        private async void LibrarySave_Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var libraryName = newLibraryName.Text.ToUpperInvariant();
                var libraryStreet = newLibraryStreet.Text.ToUpperInvariant().ToString();
                var libraryCity = newLibraryCity.Text.ToUpperInvariant();
                var libraryState = newLibraryState.Text.ToUpperInvariant();
                var libraryZip = newLibraryZip.Text.ToUpperInvariant().ToString();
                var libraryPhone = newLibraryPhone.Text.ToUpperInvariant().ToString();
                var libraryHours = newLibraryHours.Text.ToUpperInvariant().ToString();
                var libraryWebsite = newLibraryWebsite.Text.ToUpperInvariant();
                await DBService.AddLibrary(libraryName, libraryStreet, libraryCity, libraryState, libraryZip, libraryPhone, libraryHours, libraryWebsite);
                await Shell.Current.GoToAsync("..");
            }
            catch
            {
                CrossToastPopUp.Current.ShowToastMessage("There was an error saving the data, please try again");
            }            
        }
    }
}