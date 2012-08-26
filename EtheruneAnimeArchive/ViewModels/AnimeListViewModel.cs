using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;

using EtheruneAnimeArchive.Classes.Models;
using EtheruneAnimeArchive.Classes.Parser;
using EtheruneAnimeArchive.ViewModels;
using System.Xml;

namespace EtheruneAnimeArchive
{

	class AnimeListViewModel : ViewModelEntity
	{
        private WatchStatus _selectedStatus;
        ObservableCollection<Anime> _animeList;

		public AnimeListViewModel()
		{
            IAnimeXMLParser parser = new UnofficialMALParser();
            XmlDocument xml = new XmlDocument();
            xml.Load("C:\\Users\\Sylpheed\\Documents\\GitHub\\eth-animearchive\\TestData\\ListSylpheed.xml");
            List<Anime> list = parser.GetAnimeList(xml);

            _animeList = new ObservableCollection<Anime>(list);

		}
		
		public WatchStatus SelectedStatus {
            get { return _selectedStatus; }
            set { 
                _selectedStatus = value;
                NotifyPropertyChanged("SelectedStatus");
            }
		}

        public ObservableCollection<Anime> AnimeList
        {
            get { return _animeList; }
            set { _animeList = value; NotifyPropertyChanged("AnimeList"); }
        }

        public List<Anime> Test
        {
            get
            {
                IAnimeXMLParser parser = new UnofficialMALParser();
                XmlDocument xml = new XmlDocument();
                xml.Load("C:\\Users\\Sylpheed\\Documents\\GitHub\\eth-animearchive\\TestData\\ListSylpheed.xml");
                List<Anime> list = parser.GetAnimeList(xml);

                return list;
            }
        }
	}
}