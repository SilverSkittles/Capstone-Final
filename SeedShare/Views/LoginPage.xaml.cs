using Plugin.Toast;
using SeedShare.Services;
using SeedShare.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeedShare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        public string UserId { get; set; }
        public LoginPage()
        {
            InitializeComponent();

            DBService.Init();
        }

        

        private async void Login_Button_Clicked(object sender, EventArgs e)
        {
            
            var uname = enteredname.Text.ToString();
            var pword = enteredPassword.Text.ToString();
            var isValid = false;

            try
            {
                if (!string.IsNullOrEmpty(uname))
                {
                    if (!string.IsNullOrEmpty(pword))
                    {
                        isValid = await DBService.CheckUser(uname, pword);

                        if (isValid == true)
                        {
                            await Shell.Current.GoToAsync($"//{nameof(LibrariesPage)}"); //absolute route erases back stack instead of adding item to the stack

                        }
                        else
                        {
                            CrossToastPopUp.Current.ShowToastMessage("Please enter a valid username and password");
                        }
                    }
                    else
                    {
                        CrossToastPopUp.Current.ShowToastMessage("Password is empty");
                    }
                }
                else
                {
                    CrossToastPopUp.Current.ShowToastMessage("Username is empty");
                }
            }
            catch
            {
                CrossToastPopUp.Current.ShowToastMessage("There was an error, please try again");
            }

        }

        //private async void Login_Button_Clicked(object sender, EventArgs e)
        //{

        //    var uname = enteredname.Text;
        //    var pword = enteredPassword.Text;
        //    var isValid = false;

        //    if (!string.IsNullOrEmpty(uname))
        //    {
        //        if (!string.IsNullOrEmpty(pword))
        //        {
        //            isValid = await DBService.CheckUser(uname, pword);

        //            if (isValid == true)
        //            {
        //                await Shell.Current.GoToAsync($"//{nameof(LibrariesPage)}"); //absolute route erases back stack instead of adding item to the stack

        //            }
        //            else
        //            {
        //                CrossToastPopUp.Current.ShowToastMessage("Please enter a valid username and password");
        //            }
        //        }
        //        else
        //        {
        //            CrossToastPopUp.Current.ShowToastMessage("Password is empty");
        //        }
        //    }
        //    else
        //    {
        //        CrossToastPopUp.Current.ShowToastMessage("Username is empty");
        //    }
        //}

        private async void Register_Tapped(object sender, EventArgs e)
        {            
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}/{nameof(UserAddPage)}"); 
        }
    }
}