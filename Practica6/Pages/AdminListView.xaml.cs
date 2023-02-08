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
using System.Xml.Linq;

namespace Practica6.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminListView.xaml
    /// </summary>
    public partial class AdminListView : Page
    {
        Users usres1;
        public AdminListView(Users users)
        {
            InitializeComponent();
            dgUsers.ItemsSource = Base.EP.Users.ToList();
            this.usres1 = users;
        }

        private void AdminChek_Click(object sender, RoutedEventArgs e)
        {
            dgUsers.ItemsSource = Base.EP.Users.Where(z => z.Role_ID == 1).ToList();
        }

        private void UserChek_Click(object sender, RoutedEventArgs e)
        {
            dgUsers.ItemsSource = Base.EP.Users.Where(z => z.Role_ID == 2).ToList();
        }

        private void no_Click(object sender, RoutedEventArgs e)
        {
            btnClear_Click(sender,e);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new PageAdmin(usres1));
        }

        private void btnSearth_Click(object sender, RoutedEventArgs e)
        {
            if (Search.Text != "")
            {
                dgUsers.ItemsSource = Base.EP.Users.Where(z => z.Surname  == Search.Text).ToList();
                
            }
           
            
        }

       

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            dgUsers.ItemsSource = Base.EP.Users.ToList();
        }

        private void btnЩлh_Click(object sender, RoutedEventArgs e)
        {
            int a = GetSortNumber(Sort.Text);
            if (a == 1)
            {
                dgUsers.ItemsSource = Base.EP.Users.OrderBy(z => z.Surname).ToList();
            }
            else
            {
                dgUsers.ItemsSource = Base.EP.Users.OrderByDescending(z => z.Surname).ToList();
            }
        }
        public int GetSortNumber(string RoleName)
        {
            if (RoleName == "По возрастанию")
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
