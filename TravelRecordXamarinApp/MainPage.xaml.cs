using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordXamarinApp.Model;
using Xamarin.Forms;

namespace TravelRecordXamarinApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("TravelRecordXamarinApp.Assets.Images.plane.png", assembly);
        }

        async void LoginButton_Clicked(object sender, System.EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(emailEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(passwordEntry.Text);

            if (isEmailEmpty || isPasswordEmpty)
            {
                //aqui va el codigo de campos inválidos
                await DisplayAlert("Error", "Email and Passwords can't be empty!", "Ok");
            }
            else
            {
                var user = (await App.MobileService.GetTable<User>().Where(u => u.Email == emailEntry.Text).ToListAsync()).FirstOrDefault();

                if (user != null)
                {
                    App.user = user;
                    if (user.Password == passwordEntry.Text)
                    {
                        await Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Passwords isn't correct!", "Ok");
                    }
                }
                else
                {
                    await DisplayAlert("Error", "The email doesn't exist!", "Ok");
                }

            }
        }

        private void registerUserButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }

}
