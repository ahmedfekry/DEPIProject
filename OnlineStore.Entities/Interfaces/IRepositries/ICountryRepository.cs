using OnlineStore.Entities.Models.GeneralLookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Entities.Interfaces.IRepositries
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> getAllCountries();
    }
}
