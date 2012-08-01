using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using EtheruneAnimeArchive.Classes.Models;

namespace EtheruneAnimeArchive.Classes.Parser
{
    interface IAnimeXMLParser
    {
        List<Anime> GetAnimeList(XmlNode rootNode);
        List<Anime> GetArchiveList(XmlNode rootNode);
        Anime GetAnime(XmlNode animeNode);
        AnimeType GetAnimeType(string type);
        AirStatus GetAirStatus(string status);
        WatchStatus GetWatchStatus(string status);
    }
}
