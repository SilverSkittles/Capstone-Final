using System;
using MvvmHelpers;
using SeedShare.Services;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace SeedShare.ViewModels
{
    [QueryProperty(nameof(Name), nameof(Name))]
    public class EditSeedViewModel : BaseViewModel
    {

        string name, quantity, location;
        int seedId;

        public int SeedId { get => seedId; set => SetProperty(ref seedId, value, propertyName: "Seed ID"); }
        public string Name { get => name; set => SetProperty(ref name, value, propertyName: "Seed Type"); }
        public string Quantity { get => quantity; set => SetProperty(ref quantity, value, propertyName: "How many total packets of this seed type are at this location?"); }
        public string Location { get => location; set => SetProperty(ref location, value, propertyName: "Library Name"); }
        public AsyncCommand SaveCommand { get; }

        public EditSeedViewModel()
        {
            Title = "Edit A Seed";
            SaveCommand = new AsyncCommand(Save);
        }

        public async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(quantity) || string.IsNullOrWhiteSpace(location))
            {
                return;
            }
            var seed = await DBService.GetSeed(seedId);
            await DBService.EditSeed(seed, name, quantity, location); //saves data to database 
            await Shell.Current.GoToAsync(".."); //pop current page off the stack and returns to previous view
        }

    }
}

