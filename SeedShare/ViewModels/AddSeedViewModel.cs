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

    public class AddSeedViewModel : BaseViewModel
    {

        string name, quantity, location;
        public string Name { get => name; set => SetProperty(ref name, value, propertyName: "Seed Type"); }
        public string Quantity { get => quantity; set => SetProperty(ref quantity, value, propertyName: "How many total packets of this seed type are at this location?"); }
        public string Location { get => location; set => SetProperty(ref location, value, propertyName: "Library Address");}        
        public AsyncCommand SaveCommand { get; }

        public AddSeedViewModel()
        {
            Title = "Add A Seed";
            SaveCommand = new AsyncCommand(Save);
        }

        public async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(quantity) || string.IsNullOrWhiteSpace(location))
            {
                return;
            }
            await DBService.AddSeed(name, quantity, location); //saves data to database
            await Shell.Current.GoToAsync(".."); //pop current page off the stack and returns to previous view
        }

    }        
}