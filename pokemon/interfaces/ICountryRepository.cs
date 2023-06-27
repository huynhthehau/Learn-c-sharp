using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon.models;

namespace pokemon.interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersByCountry(int countryId);
        bool CountryExists(int id);

    }
}