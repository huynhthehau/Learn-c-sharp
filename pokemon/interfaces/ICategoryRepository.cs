using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pokemon.models;

namespace pokemon.interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoryExist(int id);
        bool Save();
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
    }
}