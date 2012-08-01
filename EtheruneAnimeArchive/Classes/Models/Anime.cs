using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtheruneAnimeArchive.Classes.Models
{
    class Anime
    {
        public int Id { get; set; }
        public int MyAnimeListId { get; set; }
        public string Synopsis { get; set; }
        public AnimeType Type { get; set; }
        public int Rank { get; set; }
        public int PopularityRank { get; set; }
        public string ImageUrl { get; set; }
        public int Episodes { get; set; }
        public AirStatus AirStatus { get; set; }
        public string Title { get; set; }
        public string TitleJapanese { get; set; }
        public string TitleEnglish { get; set; }
        public string Classification { get; set; }
        public List<string> Genres { get; set; }
        public List<string> Tags { get; set; }
        public List<int> RelatedAnimes { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateEnded { get; set; }
        public float MembersScore { get; set; }
        public int MembersCount { get; set; }
        public int FavoritedCount { get; set; }

        public UserAnimeStatus UserStatus { get; set; }

        public Anime()
        {
            this.Genres = new List<string>();
            this.Tags = new List<string>();
            this.RelatedAnimes = new List<int>();
        }

    }


    enum AnimeType : byte
    {
        Empty,
        TV,
        OVA,
        Special,
        Movie,
        ONA,
        Doujin
    }

    enum AirStatus : byte
    {
        Empty,
        Aired,
        OnGoing,
        Upcoming,
        Ditched
    }

    enum Season : byte
    {
        Empty,
        Spring,
        Summer,
        Fall,
        Winter
    }


    struct Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
