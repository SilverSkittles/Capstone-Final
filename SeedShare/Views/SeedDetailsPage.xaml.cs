using Plugin.Toast;
using SeedShare.Models;
using SeedShare.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeedShare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(SeedId), nameof(SeedId))]
    public partial class SeedDetailsPage : ContentPage
    {
        public int SeedId { get; set; }
        public SeedDetailsPage()
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

                var seedId = await DBService.GetSeed(SeedId);

                var existingSeed = await DBService.db.Table<Seeds>().FirstOrDefaultAsync(c => c.seedId == SeedId);
                {
                    existingSeed.seedName = editSeedName.Text.ToUpperInvariant();
                    existingSeed.packetQuantity = editSeedNumber.Text.ToUpperInvariant();
                    existingSeed.location = editSeedLocation.Text.ToUpperInvariant();
                    
                }

            await DBService.db.UpdateAsync(existingSeed);
            await Shell.Current.GoToAsync("..");
        }

        private async void DeleteSeed_Clicked(object sender, EventArgs e)
        {
            var seedId = await DBService.GetSeed(SeedId);
            await DBService.db.DeleteAsync(seedId);
            await Shell.Current.GoToAsync("..");
        }
    }
}