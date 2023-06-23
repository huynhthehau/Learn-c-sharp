using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon.models;

namespace pokemon.interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
    }
}