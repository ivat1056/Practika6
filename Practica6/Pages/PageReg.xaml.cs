using Practica6.Classes;
using Practica6.Pages;
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
using System.Xml.Linq;

namespace Practica6
{
    /// <summary>
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
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
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new MainPage());
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Hashing h1 = new Hashing();
            if (Surname.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Поле фамилия должно быть заполнено!");
                return;
            }
            if (Name.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Поле имя должно быть заполнено!");
                return;
            }
            if (Patronomic.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Поле Отчество должно быть заполнено!");
                return;
            }
            if (ComboBox1.Text == "")
            {
                MessageBox.Show("Пол должен быть выбран!");
                return;
            }

            if (Birthday.Text == "")
            {
                MessageBox.Show("Поле дата рождения должно быть заполнено!");
                return;
            }
            if (Login.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Поле логин должно быть заполнено!");
                return;
            }
            string Pass = Password.Password;
            string FloorName = ComboBox1.Text;
            int RolId = GetFloorNumber(FloorName);
            Regex r1 = new Regex("(?=.*[A-Z])");
            Regex r2 = new Regex("[a-z].*[a-z].*[a-z]");
            Regex r3 = new Regex("\\d.*\\d");
            Regex r4 = new Regex("[!@#$%^&*()_+=]");
            Regex r5 = new Regex("(.+){8,}");
            if ((r1.IsMatch(Password.Password) == true) && ((r2.IsMatch(Password.Password) == true) && ((r3.IsMatch(Password.Password) == true) && ((r3.IsMatch(Password.Password) == true) && ((r4.IsMatch(Password.Password) == true) && ((r5.IsMatch(Password.Password) == true)))))))
            {
                string HashPass = h1.GetHash(Pass);
                string login = Login.Text;
                Users sotr = Base.EP.Users.FirstOrDefault(x => x.Login == login);
                if (sotr == null)
                {
                    Base.EP.SaveChanges();
                    Users users = new Users()
                    {
                        Surname = Surname.Text,
                        Name = Name.Text,
                        Middle_name = Patronomic.Text,
                        Floor_ID = RolId,
                        Date_of_birth = (DateTime)Birthday.SelectedDate,
                        Login = Login.Text,
                        Password = HashPass,
                        Role_ID = 2
                    };
                    Base.EP.Users.Add(users);
                    Base.EP.SaveChanges();
                    MessageBox.Show("Вы успешно зарегистрировались");
                    FrameClass.MainFrame.Navigate(new PageIn());

                }
                else
                {
                    MessageBox.Show("Данный логин уже существует");

                }
            }
            else
            {
                MessageBox.Show("Пароль не соответствует требованиям ! Введенный пароль должен удовлетворять следующим требованиям: не менее 1 заглавного латинского символа, не менее 3 строчных латинских символов, не менее 2 цифры и не менее 1 спец. символа. Общая длина пароля не менее 8 символов");
            }
        }

        private void Surname_KeyDown(object sender, KeyEventArgs e)
        {
           //
        }
    }
}
