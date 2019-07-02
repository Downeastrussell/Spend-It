﻿using Microsoft.EntityFrameworkCore;
using Spend_It.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spend_It.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any join table.
            if (context.PaymentTypeLocations.Any())
            {
                return;   // DB has been seeded
            }

            var city = new City[]
            {
            new City{CityName="Huntington" },
            new City{CityName="Charleston" },
            new City{CityName="New York" },
            new City{CityName="Los Angeles" },
            new City{CityName="Chicago" },
            new City{CityName="Wheeling" },

            };
            foreach (City s in city)
            {
                context.Cities.Add(s);
            }
            context.SaveChanges();

            var locationType = new LocationType[]
            {
            new LocationType{LocationTypeName="Bar"},
            new LocationType{LocationTypeName="Restaurant"},
            new LocationType{LocationTypeName="Grocery"},
            new LocationType{LocationTypeName="Retail Outlet"},
            new LocationType{LocationTypeName="Entertainment"},
            new LocationType{LocationTypeName="Lodging"},
            new LocationType{LocationTypeName="Other, please specify in description"},


            };
            foreach (LocationType c in locationType)
            {
                context.LocationTypes.Add(c);
            }
            context.SaveChanges();

            var paymentType = new PaymentType[]
            {
            new PaymentType{PaymentTypeName="Bitcoin", PaymentTypeTicker="BTC"},
            new PaymentType{PaymentTypeName="Ethereum", PaymentTypeTicker="ETH"},
            new PaymentType{PaymentTypeName="Bitcoin Cash", PaymentTypeTicker="BCH"},
            new PaymentType{PaymentTypeName="Bitcoin Satoshi's Vision", PaymentTypeTicker="BSV"},
            new PaymentType{PaymentTypeName="Ripple", PaymentTypeTicker="XRP"},
            new PaymentType{PaymentTypeName="Zcash", PaymentTypeTicker="ZEC"},
            };
            foreach (PaymentType e in paymentType)
            {
                context.PaymentType.Add(e);
            }
            context.SaveChanges();

            var locations = new Location[]
            {
                new Location{DateCreated = DateTime.Parse("2012-09-01"), Description = "test1 seed location", LocationName = "Test1 Establishment", StreetAddress = "1 test db", UserId = "5ff79f06-8539-452b-916c-fc8eef723fad", CityId = 1, LocationTypeId = 1 },
                new Location{DateCreated = DateTime.Parse("2012-09-01"), Description = "test2 seed location", LocationName = "Test2 Establishment", StreetAddress = "2 test db", UserId = "5ff79f06-8539-452b-916c-fc8eef723fad", CityId = 1, LocationTypeId = 1 },
                new Location{DateCreated = DateTime.Parse("2012-09-01"), Description = "test3 seed location", LocationName = "Test3 Establishment", StreetAddress = "3 test db", UserId = "5ff79f06-8539-452b-916c-fc8eef723fad", CityId = 1, LocationTypeId = 1 }
            };
            foreach (Location e in locations)
            {
                context.Locations.Add(e);
            }
            context.SaveChanges();


            var paymentLocation = new PaymentTypeLocation[]

            {
                new PaymentTypeLocation {
                    PaymentTypeId = 2,
                    LocationId = 2
                    },
                new PaymentTypeLocation {
                    PaymentTypeId = 1,
                    LocationId = 2
                    },
                new PaymentTypeLocation {
                    PaymentTypeId = 3,
                    LocationId = 3
                    },

            };

            foreach (PaymentTypeLocation ci in paymentLocation)
            {
                context.PaymentTypeLocations.Add(ci);
            }
            context.SaveChanges();

        }  
    }
}
