using System;
using Plugin.Geolocator;
using SQLite;
using TravelRecordXamarinApp.Logic;
using TravelRecordXamarinApp.Model;
using Xamarin.Forms;

namespace TravelRecordXamarinApp
{
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var selectedVenue = venueListView.SelectedItem as Venue;
                Category firstCategory = null;
                if (selectedVenue.categories != null && selectedVenue.categories.Count > 0)
                    firstCategory = selectedVenue.categories[0];
                Post post = new Post()
                {
                    Experience = experienceEntry.Text,
                    CategoryId = firstCategory.id,
                    CategoryName = firstCategory.name,
                    Address = selectedVenue.location.address,
                    Distance = selectedVenue.location.distance,
                    Latitude = selectedVenue.location.lat,
                    Longitude = selectedVenue.location.lng,
                    VenueName = selectedVenue.name,
                    UserId = App.user.Id
                };

                int rows = 0;

                /*
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Post>();
                    rows = conn.Insert(post);
                }

                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience succesfully inserted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
                }
                */

                await App.MobileService.GetTable<Post>().InsertAsync(post);
                await DisplayAlert("Success", "Experience succesfully inserted", "Ok");
            }
            catch (NullReferenceException nre)
            {
                await DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Failure", "Experience failed to be inserted", "Ok");
            }

        }
    }
}
