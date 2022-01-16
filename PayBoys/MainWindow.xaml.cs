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
    public class JsonClass
    {

        
        public string user { get; set; }
        public int totalSum { get; set; }
        public DateTime localDateTime { get; set; }
        public JsonItems[] items { get; set; }

        public string nameTable;
        public string NameTable()
        {
            if (this.user.Contains("Агроторг") || this.user.Contains("АГРОТОРГ"))
            {
                this.nameTable = "Пятёрочка " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Прайс") || this.user.Contains("ПРАЙС"))
            {
                this.nameTable = "ФиксПрайс " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Лента") || this.user.Contains("ЛЕНТА"))
            {
                this.nameTable = "Лента " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Перекресток") || this.user.Contains("ПЕРЕКРЕСТОК"))
            {
                this.nameTable = "Перекресток " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Магнит") || this.user.Contains("МАГНИТ"))
            {
                this.nameTable = "Магнит " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            if (this.user.Contains("Дикси") || this.user.Contains("ДИКСИ"))
            {
                this.nameTable = "Дикси " + this.localDateTime.ToString("dd.MM-hh:mm");
                return this.nameTable;
            }
            else
                return "Error";
        }
    }

    public class JsonItems
    {
        public string name { get; set; }
        public int sum { get; set; }
    }

    public partial class MainWindow : Window
    {
        static SqliteConnection connectionPBData = new SqliteConnection("Data Source = PBDataTest.db");
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
            command.CommandText = "CREATE TABLE IF NOT EXISTS Checks (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, ChecksName TEXT NOT NULL)";
            command.ExecuteNonQuery();
        }

        
        private void Button_Click_LoadJson(object sender, RoutedEventArgs e)
        {
           
            var f = new OpenFileDialog();
            if (f.ShowDialog().GetValueOrDefault(true))
            {
                var jsonString = File.ReadAllText(f.FileName);
                JsonClass jSon = JsonSerializer.Deserialize<JsonClass>(jsonString);
                              
                SqliteCommand command = new SqliteCommand();
                                       
                command.Connection = connectionPBData;
                command.CommandText = $"CREATE TABLE IF NOT EXISTS \"{jSon.NameTable()}\" (_id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, BoB TEXT NOT NULL)";
                command.ExecuteNonQuery();

                command.CommandText = $"INSERT INTO Checks (ChecksName) VALUES (\"{jSon.nameTable}\")";
                command.ExecuteNonQuery();
            }
        }

       
    }
}
