using Practica6.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для AddHome.xaml
    /// </summary>
    public partial class AddHome : Page
    {
        Home home;
        Users users;
        public AddHome()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new Home(users));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(Name.Text != "")
            {
                if (Cost.Text != "")
                {
                    string a = Name.Text;
                    string b = Cost.Text;
                    Base.EP.SaveChanges();
                    HomeTa home = new HomeTa()
                    {
                        Name = a,
                        Cost = b
                    };
                    Base.EP.HomeTa.Add(home);
                    Base.EP.SaveChanges();
                    MessageBox.Show("Запись успешна добавлена");
                    FrameClass.MainFrame.Navigate(new Home(users));
                }
                else
                {
                    MessageBox.Show("Все поля должны быть заполнены");
                }
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
        }
    }
}
