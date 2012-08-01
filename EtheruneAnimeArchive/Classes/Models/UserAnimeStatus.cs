using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtheruneAnimeArchive.Classes.Models
{
    class UserAnimeStatus
    {
        public WatchStatus Status { get; set; }
        public int Episode { get; set; }
        public int Score { get; set; }

        #region NotYetImplemented
        public int DownloadedEpisodes { get; set; }
        public string StorageType { get; set; }
        public string StorageValue { get; set; }
        public int TimesRewatched { get; set; }
        public int RewatchValue { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateFinished { get; set; }
        public int Priority { get; set; }
        public List<string> Fansubs { get; set; }
        public List<string> Tags { get; set; }
        #endregion // NotYetImplemented
    }

    enum WatchStatus : byte
    {
        Empty,
        Watching,
        Completed,
        OnHold,
        Dropped,
        PlanToWatch
    }
}
