using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spend_It.Models.LocationViewModels
{
    public class SavedLocationIndexData
    {
        public IEnumerable<SavedLocationLineItem> SavedLocationLineItems { get; set; }
    }
}
