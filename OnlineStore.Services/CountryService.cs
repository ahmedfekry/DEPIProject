using OnlineStore.Entities.Interfaces.IRepositries;
using OnlineStore.Entities.Models.GeneralLookups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services
{
    public class CountryService
    {
        public CountryService(ICountryRepository countryRepository)
        {
            CountryRepository = countryRepository;
        }

        public ICountryRepository CountryRepository { get; }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await CountryRepository.getAllCountries();
        }
    }
}
