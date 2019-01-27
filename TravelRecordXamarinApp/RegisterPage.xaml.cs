using System;
using System.Collections.Generic;
using TravelRecordXamarinApp.Model;
using Xamarin.Forms;

namespace TravelRecordXamarinApp
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(passwordEntry.Text) && passwordEntry.Text == confirmPasswordEntry.Text)
            {
                //We can register the user
                User user = new User()
                {
                    Email= emailEntry.Text,
                    Password = passwordEntry.Text
                };

                await App.MobileService.GetTable<User>().InsertAsync(user);
                //await DisplayAlert("Success", "The user has created successfully!", "Ok");
            }
            else
            {
                await DisplayAlert("Error", "Passwords don't match", "Ok");
            }
        }
    }
}
