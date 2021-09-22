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

namespace WPFDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\EmployeeAssets.accdb");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewAssets_Click(object sender, RoutedEventArgs e)
        {
            string query = "Select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            connection.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString() + "\n";
            }
            AssetData.Text = data;
            connection.Close();
        }

        private void ViewEmployees_Click(object sender, RoutedEventArgs e)
        {
            string query = "Select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            connection.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString() + "\n";
            }
            EmployeeData.Text = data;
            connection.Close();
        }
    }
}
