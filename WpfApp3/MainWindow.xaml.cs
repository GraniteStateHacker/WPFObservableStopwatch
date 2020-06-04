﻿using System;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableStopwatch _stopwatch;

        public MainWindow()
        {
            InitializeComponent();
            _stopwatch = new ObservableStopwatch();
            DataContext = _stopwatch;
            _stopwatch.EndTime = DateTimeOffset.Now.AddMinutes(15);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch.Toggle();
        }
    }
}
