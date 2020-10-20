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
using WpfApp2.Views.Windows;
using System.Runtime.InteropServices;
using System.Linq.Expressions;
using System.Windows.Media.Animation;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataOutput.Text = " ";

            Pause_B.IsEnabled = false;
            Stop_B.IsEnabled = false;

            Get_Ports();
        }

        SerialPort serialPort = new SerialPort();

        [DllImport("FTD2XX_NET.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int FT_Open(int deviceNumber, ref int pHandle);

        #region Подключение через кнопку "Старт"
        private void Start_Click(object sender, RoutedEventArgs e)
        {

            string com = COMPort.Text;
            int speed = Int32.Parse(BaudRate.Text);

            // Объявление порта и его параметров
            
                try
                {

                serialPort = new SerialPort(com, speed, Parity.None, 8, StopBits.One);
                serialPort.Open();

                // Проверка открытия порта
                    if (serialPort.IsOpen)
                        {
                            Start_B.IsEnabled = false;
                            Script_B.IsEnabled = false;

                            Pause_B.IsEnabled = true;
                            Stop_B.IsEnabled = true;

                            Prgrss_Br.Value = 100;
                            Test_Name_Bar.Text = "Порт открыт";
                    }
                }

                // Выдача ошибки при неудачном подключении
                catch
                {

                    if (COMPort.SelectedItem == null)
                    {

                        MessageBoxResult result = MessageBox.Show("Не выбран COM-порт!",
                                                              "Подключение прервано",
                                                              MessageBoxButton.OK,
                                                              MessageBoxImage.Error);

                    }
                }

                

        }


        #endregion


        // Кнопка паузы
        private void Pause_Click(object sender, RoutedEventArgs e)
        {

            serialPort.Close();

            // Считывает данные до появления указанного символа
            DataOutput.Text += "\n Прием приостановлен";

            Start_B.IsEnabled = true;
            Script_B.IsEnabled = true;

            Pause_B.IsEnabled = false;
            Stop_B.IsEnabled = false;

        }


        // Кнопка остановки
        private void Stop_Click(object sender, RoutedEventArgs e)
        {

            serialPort.Close();

            // Считывает данные до появления указанного символа
            DataOutput.Text += "\n Прием остановлен";

            Start_B.IsEnabled = true;
            Script_B.IsEnabled = true;

            Pause_B.IsEnabled = false;
            Stop_B.IsEnabled = false;

        }

        // Открытие окна сценариев
        private void Script_Click(object sender, RoutedEventArgs e)
        {
            ScriptList sw = new ScriptList();

            sw.ShowDialog();

        }

        // Полное выключение программы
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // Получение портов
        public void Get_Ports()
        {
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                COMPort.Items.Add(port);
            }
        }

        private void Get_Click(object sender, RoutedEventArgs e)
        {
            
            DataOutput.Text += $"{serialPort.ReadLine()} \n";
            
        }

    }
}
