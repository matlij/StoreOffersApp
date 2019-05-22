using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppLocator.Models
{
    public class Settings
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public double StoreOfferRadius { get; set; }
        public int SearchOfferIntervalSeconds { get; set; }
    }
}
