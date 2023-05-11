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
using WpfApp11.Core;

namespace WpfApp11.View.Page
{
    /// <summary>
    /// Логика взаимодействия для CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage 
    {
        public CalendarPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string a = Convert.ToString(cale.SelectedDate);
            if (a == "")
            {
                MessageBox.Show("Вы не выбрали дату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                class1.Data = a;
                CoreNavigate.connect.Navigate(new CreateNotes());
                MessageBox.Show($"Выбранная дата {a}");
            }
        }
    }
}
