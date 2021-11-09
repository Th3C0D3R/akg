using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace RSSReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            XmlReader reader = XmlReader.Create("https://www.spiegel.de/schlagzeilen/tops/index.rss");
            //XmlReader reader = XmlReader.Create("http://feeds.feedburner.com/blogspot/rkEL");
            SyndicationFeed feed = SyndicationFeed.Load(reader);

            // Window.DataContext ist die Basis aller Binding-Ausdrücke
            this.DataContext = feed;
        }
    }
}
