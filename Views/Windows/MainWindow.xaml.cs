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

        SerialPort _serialPort = new SerialPort();

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
            if (_serialPort.IsOpen == true)
            {
                Start_B.IsEnabled = false;
            }


            if (_serialPort.IsOpen == false)
            {
                Pause_B.IsEnabled = false;
            }

            if (_serialPort.IsOpen == false)
            {
                Stop_B.IsEnabled = false;
            }
        }

        #region Получение списка подключенных портов
        private void Ports_Get (object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            COMPort.Items.Add(ports);
        }
        #endregion

        #region Подключение через кнопку "Старт"
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // Объявление порта и его параметров
                SerialPort _serialPort = new SerialPort("COMPort.Text",
                Convert.ToInt32(BaudRate.SelectedItem),
                Parity.None,
                8,
                StopBits.One);

                // Тайминги чтения и записи
                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;

                _serialPort.Open();

                // Считывает данные до появления указанного символа
                DataOutput.Text = _serialPort.ReadTo("1");

            }

            // Выдача ошибки при неудачном подключении
            catch
            {

                if (COMPort.SelectedItem == null) 
                {

                    MessageBoxResult result = MessageBox.Show("Не выбран COM-порт!",
                                                          "Подключение прервано",
                                                          MessageBoxButton.OKCancel,
                                                          MessageBoxImage.Error);

                }

                if (BaudRate.SelectedItem == null)
                {

                    MessageBoxResult result = MessageBox.Show("Не выбран BaudRate!",
                                                          "Подключение прервано",
                                                          MessageBoxButton.OKCancel,
                                                          MessageBoxImage.Error);

                }


                else 
                {

                    MessageBoxResult result = MessageBox.Show("Произошла неизвестная ошибка",
                                                          "Приложение приостановлено",
                                                          MessageBoxButton.OKCancel,
                                                          MessageBoxImage.Error);

                }
                
                
             }

            if (_serialPort.IsOpen == true)
            {
                Start_B.IsEnabled = false;
            }

        }


        #endregion

        private void Pause_Click(object sender, RoutedEventArgs e)
        {

            _serialPort.Close();

            // Считывает данные до появления указанного символа
            DataOutput.Text += "\n Прием приостановлен";

            Start_B.IsEnabled = true;

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {

            _serialPort.Close();

            // Считывает данные до появления указанного символа
            DataOutput.Text += "\n Прием остановлен";

            Start_B.IsEnabled = true;

        }
    }
}
