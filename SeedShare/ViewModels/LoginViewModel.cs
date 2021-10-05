using MvvmHelpers;
using MvvmHelpers.Commands;
using SeedShare.Services;
using SeedShare.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Command = Xamarin.Forms.Command;

namespace SeedShare.ViewModels
{
    [QueryProperty(nameof(Name), nameof(Name))]
    public class LoginViewModel : BaseViewModel
    {
        string name, password, active;
        public Command LoginCommand { get; }

        public string Name { get => name; set => SetProperty(ref name, value, propertyName: "User Name"); }
        public string Password { get => password; set => SetProperty(ref password, value, propertyName: "Password"); }        
        public AsyncCommand SaveCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            Title = "Please log in";
            SaveCommand = new AsyncCommand(Save);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        public async Task Save()
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                return;
            }
            await DBService.AddUser(name, password); //saves data to database
            await Shell.Current.GoToAsync(".."); //pop current page off the stack and returns to previous view
        }

        
    }
}
