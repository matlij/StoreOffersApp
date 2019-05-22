using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppLocator.Interfaces.Utilities
{
    public interface IGeoLocator
    {
        Task<Location> GetLocationAsync();
    }
}
