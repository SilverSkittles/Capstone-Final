using Plugin.Toast;
using SeedShare.Services;
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
    public partial class SeedEditPage : ContentPage
    {

        public int SeedId { get; set; }
        public string seedName { get; set; }
        public string packetQuantity { get; set; }
        public string location { get; set; }


        public SeedEditPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            int.TryParse(SeedId.ToString(), out var result);

            BindingContext = await DBService.GetSeed(result);
        }

        private async void SeedEdit_Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var seedId = await DBService.GetSeed(SeedId);
                var seedName = editSeedName.Text.ToUpperInvariant();
                var packetQuantity = editSeedQuantity.Text.ToUpperInvariant();
                var location = editSeedLocation.Text.ToUpperInvariant();
                await DBService.EditSeed(seedId, seedName, packetQuantity, location);
                await Shell.Current.GoToAsync("..");
            }
            catch
            {
                CrossToastPopUp.Current.ShowToastMessage("There was an error saving the data, please try again");
            }
        }
    }
}