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

namespace NumericUpDownControl
{
    /// <summary>
    /// Interaction logic for NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown : UserControl
    {
        public NumericUpDown()
        {
            InitializeComponent();

            this.Maximum = 10;
            this.Minimum = 0;

            txtValue.Text = "0";
        }

        /// <summary>
        /// In-/Decrease step width
        /// </summary>
        public double Increment { get; set; }


        #region DependencyProperties
        /// <summary>
        /// Value of the NumericUpDown
        /// </summary>
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(NumericUpDown), new PropertyMetadata(default(double), OnPropertyChanged));



        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(NumericUpDown), new PropertyMetadata(default(double)));



        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(NumericUpDown), new PropertyMetadata(default(double)));


        #endregion

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            if (this.Value < this.Maximum)
            {
                this.Value++; // Imkrement? Maximum?
                RaiseEvent(new RoutedEventArgs(ValueChangedEvent));
            }
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            if (this.Value > this.Minimum)
            {
                this.Value--; // Imkrement? Minimum?
                RaiseEvent(new RoutedEventArgs(ValueChangedEvent));
            }

        }

        private void txtValue_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txtValue_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }

        public event RoutedEventHandler ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        private static readonly RoutedEvent ValueChangedEvent =
                                                EventManager.RegisterRoutedEvent("ValueChanged",
                                                    RoutingStrategy.Bubble,
                                                    typeof(RoutedEventHandler),
                                                    typeof(NumericUpDown));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            NumericUpDown numericUpDown = d as NumericUpDown;
            numericUpDown.txtValue.Text = e.NewValue.ToString();
        }

    }
}
