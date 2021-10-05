using SeedShare.Services;
using System;
using SeedShare.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using Map = Xamarin.Essentials.Map;
using Plugin.Toast;

namespace SeedShare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(LibraryId), nameof(LibraryId))]
    public partial class LibraryDetailsPage : ContentPage
    {
        
        public int LibraryId { get; set; }
                
        public LibraryDetailsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            int.TryParse(LibraryId.ToString(), out var result);

            BindingContext = await DBService.GetLibrary(result);
        }

        private new async Task Navigation()
        {            
            var placemark = new Placemark
            {
                Thoroughfare = libraryStreet.Text,
                Locality = libraryCity.Text,
                AdminArea = libraryState.Text,
                PostalCode = zipCode.Text,
                CountryName = "United States"
            };

            var options = new MapLaunchOptions { Name = locationName.Text };

            try
            {
                await Map.OpenAsync(placemark, options);
            }
            catch
            {
                CrossToastPopUp.Current.ShowToastMessage("There was a problem opening your map");
            }
        }

        
        private async void MapButton_Clicked(object sender, EventArgs e)
        {
            
            await Navigation();
                      

        }

        private async void EditLibraryButtonDetailsPage_Clicked(object sender, EventArgs e)
        {            

         
            var libraryId = await DBService.GetLibrary(LibraryId);

            var existingLibrary = await DBService.db.Table<Libraries>().FirstOrDefaultAsync(c => c.libraryId == LibraryId);
            {
                existingLibrary.libraryName = locationName.Text.ToUpperInvariant();
                existingLibrary.libraryStreet = libraryStreet.Text.ToUpperInvariant();
                existingLibrary.libraryCity = libraryCity.Text.ToUpperInvariant();
                existingLibrary.libraryState = libraryState.Text.ToUpperInvariant();
                existingLibrary.libraryZip = zipCode.Text.ToUpperInvariant();
                existingLibrary.libraryPhone = libraryPhone.Text.ToUpperInvariant();
                existingLibrary.libraryHours = libraryHours.Text.ToUpperInvariant();
                existingLibrary.publicLibraryUrl = libraryWebsite.Text.ToUpperInvariant();
            }
            
            await DBService.db.UpdateAsync(existingLibrary);
            await Shell.Current.GoToAsync("..");

        }

        private async void DeleteLibrary_Clicked(object sender, EventArgs e)
        {
            var libraryId = await DBService.GetLibrary(LibraryId);

            await DBService.db.DeleteAsync(libraryId);
            await Shell.Current.GoToAsync("..");
        }
    }
}