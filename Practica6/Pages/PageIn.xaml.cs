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
    /// Логика взаимодействия для PageIn.xaml
    /// 
    /// </summary>
    public partial class PageIn : Page
    {
        public PageIn()
        {
            InitializeComponent();
        }

       

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new MainPage());
        }

        private void btn_In_Click(object sender, RoutedEventArgs e)
        {
            Hashing h1 = new Hashing();
            string login = Login.Text;
            string pass = Password.Password;
            string password = h1.GetHash(pass);
            Users sotr = Base.EP.Users.FirstOrDefault(z => z.Login == login && z.Password == password);
            if (sotr == null)
            {
                MessageBox.Show("Такого пользователя нет");
            }
            else
            {
                if (sotr.Role_ID == 1)
                {
                    MessageBox.Show("Здравствуйте, администратор!");
                    FrameClass.MainFrame.Navigate(new PageAdmin(sotr));
                }
                else
                {
                    MessageBox.Show("Здравствуйте, пользователь!");
                    FrameClass.MainFrame.Navigate(new PageUser(sotr));
                }
                
            }
        }
    }
}
