using Plugin.Toast;
using SeedShare.Models;
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
    public partial class UserAddPage : ContentPage
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public UserAddPage()
        {
            InitializeComponent();
        }
        

        private async void UserSave_Button_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                var uname = newUser.Text.ToLower();
                var pword = newPassword.Text.ToLower();
                await DBService.AddUser(uname, pword);
                await Shell.Current.GoToAsync("..");
            }
            catch
            {
                CrossToastPopUp.Current.ShowToastMessage("There was an error saving the data, please try again");
            }
        }
    }
}