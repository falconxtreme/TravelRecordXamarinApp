using System;
using SQLite;
namespace TravelRecordXamarinApp.Model
{
    public class Post
    {
        public Post()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }
    }
}
