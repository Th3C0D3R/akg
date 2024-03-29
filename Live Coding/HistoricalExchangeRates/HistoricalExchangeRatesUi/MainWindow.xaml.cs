﻿using HistoricalExchangeRatesDal;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace HistoricalExchangeRatesUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";
            
            // Basis aller Binding-Ausdrücke
            this.DataContext = new EcbReferenceRates(url);

        }
    }
}
