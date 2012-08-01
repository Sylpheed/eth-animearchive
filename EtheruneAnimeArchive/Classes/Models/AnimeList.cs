using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtheruneAnimeArchive.Classes.Models
{
    class AnimeList
    {
        protected List<Anime> animeList;

        #region Fetch Methods
        public bool HasAnime(int myAnimeListId)
        {
            return (GetAnime(myAnimeListId) != null);
        }

        public bool HasAnime(Anime anime)
        {
            return (GetAnime(anime.MyAnimeListId) != null);
        }

        public Anime GetAnime(int malId)
        {
            foreach (Anime anime in animeList)
            {
                if (anime.MyAnimeListId == malId)
                {
                    return anime;
                }
            }

            return null;
        }

        public Anime GetAnime(string title)
        {
            return null;
        }

        public List<Anime> AllAnime { get { return animeList; } }

        #endregion

    }
}
