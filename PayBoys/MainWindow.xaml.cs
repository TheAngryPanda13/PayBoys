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
using System.IO;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using Microsoft.Win32;

namespace PayBoys
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
       public class TestDataGrid
       {
        public string  CheckName { get; set; }
        public string  Buyer { get; set; }

       }

    public partial class MainWindow : Window
    {
        List<TestDataGrid> test = new List<TestDataGrid>();

        static readonly SqliteConnection connectionPBData = new SqliteConnection("Data Source = PBDataTest.db");
        public MainWindow()
        {
            InitializeComponent();

            //создание таблицы пользователей для записи суммы долка в рублях
            connectionPBData.Open();

            SqliteCommand command = new SqliteCommand();

            command.Connection = connectionPBData;
            command.CommandText = "CREATE TABLE IF NOT EXISTS Users (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Users TEXT NOT NULL, Eugene TEXT NOT NULL, Tank TEXT NOT NULL, Alina TEXT NOT NULL)";
            command.ExecuteNonQuery();

            //создание таблицы для хранения названий чеков
            command.CommandText = "CREATE TABLE IF NOT EXISTS Checks (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, ChecksName TEXT NOT NULL, Buyer TEXT NOT NULL DEFAULT \'Eugene\')";
            command.ExecuteNonQuery();

            command.CommandText = "SELECT * FROM Checks";
            command.ExecuteNonQuery();

            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())   // построчно считываем данные
                    {
                        TestDataGrid t = new TestDataGrid();
                        t.CheckName = reader.GetString(1);
                        t.Buyer = reader.GetString(2);
                        test.Add(t);
                    }
                }
            }
            dataTable.ItemsSource = test;
        }

        private void Button_Click_LoadJson(object sender, RoutedEventArgs e)
        {
           
            var f = new OpenFileDialog();
            if (f.ShowDialog().GetValueOrDefault(true))
            {                
                JsonClass check = JsonSerializer.Deserialize<JsonClass>(File.ReadAllText(f.FileName));

                DialogWindow buyerWindow = new DialogWindow();

                if (buyerWindow.ShowDialog() == true)
                { 
                    check.Buyer = buyerWindow.NameBuyer;
                }

                MessageBox.Show(check.Buyer);
                              
               /* SqliteCommand command = new SqliteCommand();
                                       
                command.Connection = connectionPBData;
                command.CommandText = $"CREATE TABLE IF NOT EXISTS \"{check.NameTable()}\" (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Product TEXT NOT NULL)";
                command.ExecuteNonQuery();

                command.CommandText = $"INSERT INTO Checks (ChecksName, Buyer) VALUES (\"{check.nameTable}\", \"unknown\")";
                command.ExecuteNonQuery();*/
            }
        }

       
    }
}
