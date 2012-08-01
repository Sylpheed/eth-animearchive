using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using EtheruneAnimeArchive.Classes.Parser;
using EtheruneAnimeArchive.Classes.Models;
using System.Xml;

namespace EtheruneAnimeArchive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IAnimeXMLParser parser = new UnofficialMALParser();

            XmlDocument xml = new XmlDocument();
            xml.Load("C:\\Users\\Sylpheed\\Downloads\\Sylpheed.xml");
            List<Anime> animeList = parser.GetAnimeList(xml);
        }
    }
}
