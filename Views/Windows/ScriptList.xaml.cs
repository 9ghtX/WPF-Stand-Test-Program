using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ScriptList.xaml
    /// </summary>
    public partial class ScriptList : Window
    {
        public ScriptList()
        {
            InitializeComponent();

            First_Block.Visibility = Visibility.Collapsed;
            Second_Block.Visibility = Visibility.Collapsed;
            Third_Block.Visibility = Visibility.Collapsed;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Close();
        }

        private void Script_Block_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Script_Block.SelectedIndex == 0)
            {
                First_Block.Visibility = Visibility.Visible;
            }
            else
            {
                First_Block.Visibility = Visibility.Collapsed;
            }

            if (Script_Block.SelectedIndex == 1)
            {
                Second_Block.Visibility = Visibility.Visible;
            }
            else
            {
                Second_Block.Visibility = Visibility.Collapsed;
            }

            if (Script_Block.SelectedIndex == 2)
            {
                Third_Block.Visibility = Visibility.Visible;
            }
            else
            {
                Third_Block.Visibility = Visibility.Collapsed;
            }
        }
    }
}
