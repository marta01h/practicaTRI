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
using System.Windows.Shapes;

namespace Proverkka
{
    /// <summary>
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        public Dialog()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public string textReturn
        {
            get { return textBox.Text; }
        }
    }
}