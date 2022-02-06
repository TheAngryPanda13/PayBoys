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
using System.Windows.Shapes;

namespace PayBoys
{
    /// <summary>
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        public string NameBuyer { get; set; }

        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            RadioButton name = (RadioButton)sender;
            NameBuyer = name.Content.ToString();
        }

        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButtonClikc(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
