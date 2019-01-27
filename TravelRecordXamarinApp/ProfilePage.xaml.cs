using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordXamarinApp.Model;
using Xamarin.Forms;
using System.Linq;

namespace TravelRecordXamarinApp
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var postTable = conn.Table<Post>().ToList();

                var categories = (from p in postTable
                                  where p.CategoryId!=null
                                  orderby p.CategoryId
                                  select p.CategoryName).Distinct().ToList();

                var categories2 = postTable.OrderBy(p => p.CategoryId).Select(p=> p.CategoryName).Distinct().ToList();

                Dictionary<string, int> categoriesCount = new Dictionary<string, int>();

                foreach(var category in categories)
                {
                    var count = (from post in postTable
                                 where post.CategoryName == category
                                 select post).ToList().Count;

                    var count2 = postTable.Where(p => p.CategoryName == category).ToList().Count;

                    categoriesCount.Add(category, count);
                }

                categoriesListView.ItemsSource = categoriesCount;

                postCountLabel.Text = postTable.Count.ToString();
            }
        }
    }
}
