using Practica6.Classes;
using Practica6.Pages;
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

namespace Practica6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// Администратор 
    /// логин - admin
    /// пароль - QWERqwer123!@#
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameClass.MainFrame = frm;
            FrameClass.MainFrame.Navigate(new MainPage());
            Base.EP = new BaseEntities2();
        }

       
    }
}
