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
    /// Логика взаимодействия для PageHomeUpd.xaml
    /// </summary>
    public partial class PageHomeUpd : Page
    {
        Users users;
        HomeTa home;
        public PageHomeUpd(HomeTa home, Users users)
        {
            InitializeComponent();
            this.home = home;
            Name.Text = home.Name;
            Cost.Text = home.Cost;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            home.Name = Name.Text;
            home.Cost = Cost.Text;
            Base.EP.SaveChanges();
            MessageBox.Show("Данные сохранены !");
            FrameClass.MainFrame.Navigate(new Home(users));
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new Home(users));
        }
    }
}
