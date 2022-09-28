using System.Collections.Generic;
using System.Linq;
using ApiDevInHouse.Characters;

namespace ApiDevInHouse.Repositories
{
    public interface ICharacterRepository
    {
        IQueryable<ICharacter> GetCharacters();

        IEnumerable<ICharacter> GetCharacters(params int[] ids);

        ICharacter GetHero(Episode episode);

        IEnumerable<ISearchResult> Search(string text);
    }
}
