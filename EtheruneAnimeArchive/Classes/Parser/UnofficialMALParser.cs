using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using EtheruneAnimeArchive.Classes.Models;

namespace EtheruneAnimeArchive.Classes.Parser
{
    class UnofficialMALParser : IAnimeXMLParser
    {
        public List<Anime> GetAnimeList(XmlNode rootNode)
        {
            List<Anime> list = new List<Anime>();

            XmlNodeList animeNodes = rootNode.SelectNodes("//anime");

            foreach (XmlNode animeNode in animeNodes)
            {
                Anime anime = GetAnime(animeNode);
                if (anime != null)
                {
                    list.Add(anime);
                }
            }

            return list;
        }

        public List<Anime> GetArchiveList(XmlNode rootNode)
        {
            return null;
        }

        public Anime GetAnime(XmlNode animeNode)
        {
            if (animeNode.Name == "anime")
            {
                Anime anime = new Anime();

                anime.Title = animeNode["title"].InnerText;
                anime.Synopsis = animeNode["synopsis"].InnerText;
                anime.Type = GetAnimeType(animeNode["type"].InnerText);
                anime.ImageUrl = animeNode["image_url"].InnerText;
                anime.AirStatus = GetAirStatus(animeNode["status"].InnerText);
                anime.Classification = animeNode["classification"].InnerText;

                try
                {
                    anime.TitleEnglish = animeNode["english_title"].InnerText;
                }
                catch
                {
                    anime.TitleEnglish = "";
                }

                try
                {
                    anime.TitleJapanese = animeNode["japanese_title"].InnerText;
                }
                catch
                {
                    anime.TitleJapanese = "";
                }
                

                //anime.MyAnimeListId = Int32.Parse(animeNode["id"].InnerText);
                //anime.Episodes = Int32.Parse(animeNode["episodes"].InnerText);
                //anime.Rank = Int32.Parse(animeNode["rank"].InnerText);
                //anime.PopularityRank = Int32.Parse(animeNode["popularity_rank"].InnerText);
                //anime.MembersScore = float.Parse(animeNode["members_score"].InnerText);
                //anime.MembersCount = Int32.Parse(animeNode["members_count"].InnerText);
                //anime.FavoritedCount = Int32.Parse(animeNode["favorited_count"].InnerText);

                // Parse numerical types
                int malId = 0;
                int episodes = 0;
                int rank = 0;
                int popularityRank = 0;
                int memberScore = 0;
                int memberCount = 0;
                int favoritedCount = 0;

                int.TryParse(animeNode["id"].InnerText,out malId);
                int.TryParse(animeNode["episodes"].InnerText, out episodes);
                int.TryParse(animeNode["rank"].InnerText, out rank);
                int.TryParse(animeNode["popularity_rank"].InnerText, out popularityRank);
                int.TryParse(animeNode["members_score"].InnerText, out memberScore);
                int.TryParse(animeNode["members_count"].InnerText, out memberCount);
                int.TryParse(animeNode["favorited_count"].InnerText, out favoritedCount);

                anime.MyAnimeListId = malId;
                anime.Episodes = episodes;
                anime.Rank = rank;
                anime.PopularityRank = popularityRank;
                anime.MembersScore = memberScore;
                anime.MembersCount = memberCount;
                anime.FavoritedCount = favoritedCount;

                // Get genre
                XmlNodeList genreList = animeNode.SelectNodes("//genre");
                foreach (XmlNode genreNode in genreList)
                {
                    anime.Genres.Add(genreNode.InnerText);
                }

                // Get tags
                XmlNodeList tagList = animeNode.SelectNodes("//tag");
                foreach (XmlNode tagNode in tagList)
                {
                    anime.Genres.Add(tagNode.InnerText);
                }

                // Build User's Watch Status
                UserAnimeStatus userStatus = new UserAnimeStatus();
                userStatus.Status = GetWatchStatus(animeNode["watched_status"].InnerText);
                int userScore = 0;
                int userEpisode = 0;
                int.TryParse(animeNode["score"].InnerText, out userScore);
                int.TryParse(animeNode["watched_episodes"].InnerText, out userEpisode);
                userStatus.Score = userScore;
                userStatus.Episode = userEpisode;


                anime.UserStatus = userStatus;
 

                return anime;
            }
            

            return null;
        }

        public AnimeType GetAnimeType(string type)
        {
            if (type == null)
            {
                return AnimeType.Empty;
            }

            switch (type)
            {
                case "TV":
                    return AnimeType.TV;

                case "OVA":
                    return AnimeType.OVA;

                case "Special":
                    return AnimeType.Special;

                case "Movie":
                    return AnimeType.Movie;

                case "ONA":
                    return AnimeType.ONA;

                default:
                    return AnimeType.Doujin;
            }
            
        }

        public AirStatus GetAirStatus(string status)
        {
            if (status == null)
            {
                return AirStatus.Empty;
            }

            switch (status)
            {
                case "finished airing":
                    return AirStatus.Aired;

                case "currently airing":
                    return AirStatus.OnGoing;

                case "not yet aired":
                    return AirStatus.Upcoming;

                default:
                    return AirStatus.Empty;
            }

        }

        public WatchStatus GetWatchStatus(string status)
        {
            if (status == null)
            {
                return WatchStatus.Empty;
            }

            switch (status)
            {
                case "completed":
                    return WatchStatus.Completed;

                case "watching":
                    return WatchStatus.Watching;

                case "on-hold":
                    return WatchStatus.OnHold;

                case "plan to watch":
                    return WatchStatus.PlanToWatch;

                case "dropped":
                    return WatchStatus.Dropped;

                default:
                    return WatchStatus.Empty;
            }

        }
        
    }
}
