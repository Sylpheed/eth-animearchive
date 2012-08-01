using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EtheruneAnimeArchive.Classes.Models
{
    class User
    {
        #region Fields
        private string username, password;
        #endregion // Fields

        public User(string userName, string passWord)
        {
            username = userName;
            password = passWord;
        }

        public string Username { get { return username; } }
        public string Password { get { return password; } }
        public string AnimeListXmlPath { get; set; }
    }
}
