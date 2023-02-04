using Practica6.Classes;
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

namespace Practica6.Pages
{
    /// <summary>
    /// Логика взаимодействия для UpdUsers.xaml
    /// </summary>
    public partial class UpdUsers : Page
    {
        Users users1;
        public UpdUsers(Users users)
        {
            string b;
            InitializeComponent();
            this.users1 = users;
            Surname.Text = users.Surname;
            Name.Text = users.Name;
            Patronomic.Text = users.Middle_name;
            Birthday.SelectedDate = users.Date_of_birth;
            string a = "Мужской";
            string a1 = "Женский";
            if (users.Floor_ID == 1)
            {
                b = a;
            }
            else
            {
                b = a1;
            }
            ComboBox1.Text = b;
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new PageIn());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            users1.Surname = Surname.Text;
            users1.Name = Name.Text;
            users1.Middle_name = Patronomic.Text;
            users1.Date_of_birth = Birthday.SelectedDate;
            users1.Floor_ID = GetFloorNumber(ComboBox1.Text);
            Base.EP.SaveChanges();
            MessageBox.Show("Данные сохранены !");
            FrameClass.MainFrame.Navigate(new PageUser(users1));
        }

        public int GetFloorNumber(string RoleName)
        {
            if (RoleName == "Мужской")
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
