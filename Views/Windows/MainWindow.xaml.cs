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

using System.Data.OleDb;

using System.IO.Ports;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        private void Ports_Get (object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            COMPort.Items.Add(ports);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SerialPort _port = new SerialPort("COMPort.Text",
                Convert.ToInt32(BaudRate.SelectedItem),
                Parity.None,
                8,
                StopBits.One);

            }

            catch
            {

                MessageBoxResult result = MessageBox.Show("Произошла ошибка. Проверьте настройки",
                                                          "Приложение приостановлено", 
                                                          MessageBoxButton.OKCancel, 
                                                          MessageBoxImage.Error);
                
                if (result == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }

            }
            
        }

    }
}
