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
using WpfApp11.Model;

namespace WpfApp11.View.Page
{
    /// <summary>
    /// Логика взаимодействия для CreateNotes.xaml
    /// </summary>
    public partial class CreateNotes 
    {
        private DataContext? _db = null;
        private Users _users = new Users();
        public CreateNotes()
        {
            InitializeComponent();
            Osn();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string time = class1.Data;
            string notes = Task.Text;
            if (notes == "")
            {
                MessageBox.Show("Вы не ввели заметку");
            }
            else if(notes != "")
            {
                _users.Task = notes;
                _users.Data = time;
                _db?.Users.Add(_users);
                _db?.SaveChanges();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Close();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            CoreNavigate.connect.Navigate(new CalendarPage());

        }
        

        public void Osn()
        {
            _db = new DataContext();
            string time = class1.Data;
            Tbdata.Text +=time;
            Users authuser = null;
            using (DataContext d1b = new DataContext())
            {
                authuser = d1b.Users.Where(b => b.Data == time).FirstOrDefault();
            }
            if (authuser != null)
            {
                List<Users> users = _db.Users.ToList();
                List.ItemsSource = users;
            }
        }
        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {
            Osn();
        }
        public void Delete()
        {
            using (DataContext db = new Model.DataContext())
            {
                Users selectedUser = List.SelectedItem as Users;

                if (selectedUser != null)
                {
                    Users? user = db.Users.Single(f => f.Id == selectedUser.Id);
                    db.Users.Remove(user);
                    db.SaveChanges();
                    Osn();
                }
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }
    }
}
