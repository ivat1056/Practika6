using Microsoft.Win32;
using Practica6.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        Photo photo = new Photo();
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
            List<Photo> photos = Base.EP.Photo.Where(z => z.id_user == users.ID).ToList();
            if (photos.Count != 0)
            {
                byte[] Bar = photos[photos.Count - 1].binPath;
                showImage(Bar, photoUser);
            }
        }

        private void btnAddPhoto_Click(object sender, RoutedEventArgs e)
        {

            
                photo.id_user = users1.ID;
                OpenFileDialog OFD = new OpenFileDialog();
                OFD.ShowDialog();
                string path = OFD.FileName;
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);
                ImageConverter IC = new ImageConverter();
                byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));
                photo.binPath = Barray;
                Base.EP.Photo.Add(photo);
                Base.EP.SaveChanges();
                MessageBox.Show("Успешное добавление фото!!!");
                FrameClass.MainFrame.Navigate(new PageUser(users1));
            
           
        }

        private void btnAddPhotos_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = true;
            if (OFD.ShowDialog() == true)
            {
                foreach (string file in OFD.FileNames)
                {
                    Photo photo = new Photo();
                    photo.id_user = users1.ID;
                    string path = file;
                    System.Drawing.Image SDI = System.Drawing.Image.FromFile(file);
                    ImageConverter IC = new ImageConverter();
                    byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));
                    photo.binPath = Barray;
                    Base.EP.Photo.Add(photo);
                }
                Base.EP.SaveChanges();
                MessageBox.Show("Успешное добавление фото!!!");
            }
        }

        

        private void UpdLogAndPass_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.MainFrame.Navigate(new UpdLoginAndPass(users1));
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
        void showImage(byte[] Barray, System.Windows.Controls.Image img)
        {
            BitmapImage BI = new BitmapImage();
            using (MemoryStream m = new MemoryStream(Barray))
            {
                BI.BeginInit();
                BI.StreamSource = m;
                BI.CacheOption = BitmapCacheOption.OnLoad;
                BI.EndInit();
            }
            img.Source = BI;
            img.Stretch = Stretch.Uniform;
        }
    }
}
