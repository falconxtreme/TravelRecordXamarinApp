﻿using System;
using SQLite;
namespace TravelRecordXamarinApp.Model
{
    public class Post
    {
        public Post()
        {
        }

        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        //public int Id { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }

        public string VenueName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Distance { get; set; }

        public string UserId { get; set; }
    }
}
