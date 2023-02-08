using Practica6.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        Class1 pc = new Class1();  // создаем объект класса для отображения страниц
        // CatsFilter
        
        List<HomeTa> HomeFilter = new List<HomeTa>();
        Users users;
        public Home(Users users)
        {
            InitializeComponent();
            this.users= users;
            listHome.ItemsSource = Base.EP.HomeTa.ToList();

            //Sort.SelectedIndex = 0;

            HomeFilter = Base.EP.HomeTa.ToList();
            pc.CountPage = Base.EP.HomeTa.ToList().Count;
            DataContext = pc;
        }

        private void btnSearth_Click(object sender, RoutedEventArgs e)
        {
            if (Search.Text != "")
            {
                listHome.ItemsSource = Base.EP.HomeTa.Where(z => z.Name == Search.Text).ToList();

            }
        }

        private void btnЩлh_Click(object sender, RoutedEventArgs e)
        {
            int a = GetSortNumber(Sort.Text);
            if (a == 1)
            {
                listHome.ItemsSource = Base.EP.HomeTa.OrderBy(z => z.Cost).ToList();
            }
            else
            {
                listHome.ItemsSource = Base.EP.HomeTa.OrderByDescending(z => z.Cost).ToList();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            listHome.ItemsSource = Base.EP.HomeTa.ToList();
        }

        
        

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new PageAdmin(users));
        }

       

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);

            HomeTa tovar = Base.EP.HomeTa.FirstOrDefault(z => z.ID_Home == index);

            FrameClass.MainFrame.Navigate(new PageHomeUpd(tovar, users));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new AddHome());
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


        private void txtPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                pc.CountPage = Convert.ToInt32(txtPageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
            }
            catch
            {
                pc.CountPage = HomeFilter.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
            }
            pc.Countlist = HomeFilter.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
            listHome.ItemsSource = HomeFilter.Skip(0).Take(pc.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно CountPage
            pc.CurrentPage = 1; // текущая страница - это страница 1
        }

        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)  // обработка нажатия на один из Textblock в меню с номерами страниц
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    pc.CurrentPage--;
                    break;
                case "next":
                    pc.CurrentPage++;
                    break;
                default:
                    pc.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            listHome.ItemsSource = HomeFilter.Skip(pc.CurrentPage * pc.CountPage - pc.CountPage).Take(pc.CountPage).ToList();  // оображение записей постранично с определенным количеством на каждой странице
            // Skip(pc.CurrentPage* pc.CountPage - pc.CountPage) - сколько пропускаем записей
            // Take(pc.CountPage) - сколько записей отображаем на странице
        }

        

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.Uid);

            HomeTa home = Base.EP.HomeTa.FirstOrDefault(z => z.ID_Home == index);

            Base.EP.HomeTa.Remove(home);
            Base.EP.SaveChanges();

            FrameClass.MainFrame.Navigate(new Home(users));
        }
    }
}
