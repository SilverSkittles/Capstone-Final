using MvvmHelpers;
using SeedShare.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace SeedShare.ViewModels
{
    [QueryProperty(nameof(Name), nameof(Name))]
    public class EditLibraryViewModel : BaseViewModel
    {

        string name, street, city, state, zip, phone, hours, url;
        int libraryId;
        public int LibraryId { get => libraryId; set => SetProperty(ref libraryId, value, propertyName: "Library ID"); }
        public string Name { get => name; set => SetProperty(ref name, value, propertyName: "Library Name"); }
        public string Street { get => street; set => SetProperty(ref street, value, propertyName: "Address"); }
        public string City { get => city; set => SetProperty(ref city, value, propertyName: "Address"); }
        public string State { get => state; set => SetProperty(ref state, value, propertyName: "Address"); }
        public string Zip { get => zip; set => SetProperty(ref zip, value, propertyName: "Address"); }
        public string Phone { get => phone; set => SetProperty(ref phone, value, propertyName: "Phone, enter 000-000-0000 if not a public library"); }
        public string Hours { get => hours; set => SetProperty(ref hours, value, propertyName: "Hours"); }
        public string URL { get => url; set => SetProperty(ref url, value, propertyName: "Website, enter NA if not a public library"); }
        public AsyncCommand SaveCommand { get; }

        public EditLibraryViewModel()
        {
            Title = "Edit Library";
            SaveCommand = new AsyncCommand(Save);
        }


        public async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(street)
                || string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(state)
                || string.IsNullOrWhiteSpace(zip) || string.IsNullOrWhiteSpace(phone)
                || string.IsNullOrWhiteSpace(hours) || string.IsNullOrWhiteSpace(url))
            {
                return;
            }

            var currentLibrary = await DBService.GetLibrary(libraryId);
            await DBService.EditLibrary(currentLibrary, name, street, city, state, zip, phone, hours, url); //saves data to database
            await Shell.Current.GoToAsync(".."); //pop current page off the stack and returns to previous view
        }

    }
}
