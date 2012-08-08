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

                anime.MyAnimeListId = XMLHelper.IntValue(animeNode["id"]);
                anime.Title = XMLHelper.StringValue(animeNode["title"]);
                anime.TitleEnglish = XMLHelper.StringValue(animeNode["english_title"]);
                anime.TitleJapanese = XMLHelper.StringValue(animeNode["japanese_title"]);
                anime.Synopsis = XMLHelper.StringValue(animeNode["synopsis"]);
                anime.Type = GetAnimeType(XMLHelper.StringValue(animeNode["type"]));
                anime.ImageUrl = XMLHelper.StringValue(animeNode["image_url"]);
                anime.AirStatus = GetAirStatus(XMLHelper.StringValue(animeNode["status"]));
                anime.Classification = XMLHelper.StringValue(animeNode["classification"]);
                anime.Episodes = XMLHelper.IntValue(animeNode["episodes"]);
                anime.Rank = XMLHelper.IntValue(animeNode["rank"]);
                anime.PopularityRank = XMLHelper.IntValue(animeNode["popularity_rank"]);
                anime.MembersScore = XMLHelper.FloatValue(animeNode["members_score"]);
                anime.MembersCount = XMLHelper.IntValue(animeNode["members_count"]);
                anime.FavoritedCount = XMLHelper.IntValue(animeNode["favorited_count"]);

                // TODO - Air Date

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

                // Get related anime (TODO)

                // Build User's Watch Status
                UserAnimeStatus userStatus = new UserAnimeStatus();
                userStatus.Status = GetWatchStatus(XMLHelper.StringValue(animeNode["watched_status"]));
                userStatus.Score = XMLHelper.IntValue(animeNode["score"]);
                userStatus.Episode = XMLHelper.IntValue(animeNode["watched_episodes"]);
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
