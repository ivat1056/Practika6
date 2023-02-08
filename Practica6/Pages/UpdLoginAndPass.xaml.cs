using Practica6.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для UpdLoginAndPass.xaml
    /// </summary>
    public partial class UpdLoginAndPass : Page
    {
        Users users;
        public UpdLoginAndPass(Users users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Hashing h1 = new Hashing();
            string Pass = Password.Password;
            Regex r1 = new Regex("(?=.*[A-Z])");
            Regex r2 = new Regex("[a-z].*[a-z].*[a-z]");
            Regex r3 = new Regex("\\d.*\\d");
            Regex r4 = new Regex("[!@#$%^&*()_+=]");
            Regex r5 = new Regex("(.+){8,}");
            if ((r1.IsMatch(Password.Password) == true) && ((r2.IsMatch(Password.Password) == true) && ((r3.IsMatch(Password.Password) == true) && ((r3.IsMatch(Password.Password) == true) && ((r4.IsMatch(Password.Password) == true) && ((r5.IsMatch(Password.Password) == true)))))))
            {
                Users sotr = Base.EP.Users.FirstOrDefault(x => x.Login == Login.Text);
                if (sotr == null)
                {
                    string HashPass = h1.GetHash(Pass);
                    string login = Login.Text;

                    users.Login = login;
                    users.Password = HashPass;

                    Base.EP.SaveChanges();
                    MessageBox.Show("Успешное изменение логина и пароля!!!");
                    FrameClass.MainFrame.Navigate(new PageIn());
                }
                else
                {
                    MessageBox.Show("Данный логин существует!");
                }
            }
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new PageIn());
        }
    }
}
