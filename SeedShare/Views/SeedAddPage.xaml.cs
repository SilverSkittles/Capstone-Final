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
    public partial class SeedAddPage : ContentPage
    {
        public string SeedId { get; set; }
        public string seedName { get; set; }
        public string packetQuantity { get; set; }
        public string location { get; set; }


        public SeedAddPage()
        {
            InitializeComponent();            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            int.TryParse(SeedId, out var result);

            BindingContext = await DBService.GetSeed(result);
        }

        private async void SeedSave_Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var seedName = newSeedName.Text.ToUpperInvariant();
                var packetQuantity = newSeedQuantity.Text.ToUpperInvariant();
                var location = newSeedLocation.Text.ToUpperInvariant();
                await DBService.AddSeed(seedName, packetQuantity, location);
                await Shell.Current.GoToAsync("..");
            }
            catch
            {
                CrossToastPopUp.Current.ShowToastMessage("There was an error saving the data, please try again");
            }
        }
    }
}