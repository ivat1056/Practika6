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
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        Users users1;
        public PageAdmin(Users users)
        {
            string b;
            InitializeComponent();
            this.users1 = users;
            Surname.Text = users.Surname;
            Name.Text = users.Name;
            Otch.Text = users.Middle_name;
            Birthday.SelectedDate = users.Date_of_birth;
            string a = "Мужской";
            string a1 = "Женский";
            if (users.Floor_ID == 1 )
            {
                b = a ;
            }
            else
            {
                b=a1 ;
            }
            ComboBox1.Text = b ;
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new AdminListView(users1));
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new Home(users1));
        }

        private void btnLogPas_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new UpdLoginAndPass(users1));
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            users1.Surname = Surname.Text;
            users1.Name = Name.Text;
            users1.Middle_name = Otch.Text;
            users1.Date_of_birth = Birthday.SelectedDate;
            users1.Floor_ID = GetFloorNumber(ComboBox1.Text);
            Base.EP.SaveChanges();
            MessageBox.Show("Данные сохранены !");
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new MainPage());
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
