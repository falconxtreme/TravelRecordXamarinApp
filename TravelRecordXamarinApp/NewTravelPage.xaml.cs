using System;
using System.Collections.Generic;
using SQLite;
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

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Post post = new Post()
            {
                Experience = experienceEntry.Text
            };

            int rows=0;
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
        }
    }
}
