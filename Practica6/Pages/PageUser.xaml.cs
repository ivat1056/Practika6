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
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        Users users1;
        public PageUser(Users users)
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

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnAddPhotos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdPhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdLogAndPass_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new UpdUsers(users1));


        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new MainPage());
        }

        private void Save_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Back)
            {
                e.Handled = true;
            }
        }

        private void Surname_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Back)
            {
                e.Handled = true;
            }
        }

        private void Otch_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Back)
            {
                e.Handled = true;
            }
        }

        private void Birthday_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Back)
            {
                e.Handled = true;
            }
        }

        private void ComboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Back)
            {
                e.Handled = true;
            }
        }
    }
}
