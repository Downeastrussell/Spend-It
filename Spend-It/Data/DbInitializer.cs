using Microsoft.EntityFrameworkCore;
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

            // Look for any Cities.
            if (context.Cities.Any() || context.LocationTypes.Any() || context.PaymentType.Any())
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
        }
    }
}
