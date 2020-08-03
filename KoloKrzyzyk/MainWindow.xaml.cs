using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace KoloKrzyzyk
{
    public enum Rodzaj
    {
        Puste, Kolko, Krzyzyk
    }
    public partial class MainWindow : Window
    {
        bool player = true;     //true = O , false = X
        string adr_kolko = "obrazki/O1-icon.png";
        string adr_krzyzyk = "obrazki/X1-icon.png";
        Tablica tablica = new Tablica();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void b00_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(0, 0) == Rodzaj.Puste)
            {
                tablica.setTab(0, 0, Rodzaj.Kolko);
                i00.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                tablica.nextStep();
            }
        }

        private void b10_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(1, 0) == Rodzaj.Puste)
            {
                tablica.setTab(1, 0, Rodzaj.Kolko);
                i10.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                tablica.nextStep();
            }
        }

        private void b20_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(2, 0) == Rodzaj.Puste)
            {
                tablica.setTab(2, 0, Rodzaj.Kolko);
                i20.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                tablica.nextStep();
            }
        }

        private void b01_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(0, 1) == Rodzaj.Puste)
            {
                tablica.setTab(0, 1, Rodzaj.Kolko);
                i01.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                tablica.nextStep();
            }
        }

        private void b11_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(1, 1) == Rodzaj.Puste)
            {
                tablica.setTab(1, 1, Rodzaj.Kolko);
                i11.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                tablica.nextStep();
            }
        }

        private void b21_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(2, 1) == Rodzaj.Puste)
            {
                tablica.setTab(2, 1, Rodzaj.Kolko);
                i21.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                tablica.nextStep();
            }
        }

        private void b02_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(0, 2) == Rodzaj.Puste)
            {
                tablica.setTab(0, 2, Rodzaj.Kolko);
                i02.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                tablica.nextStep();
            }
        }

        private void b12_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(1, 2) == Rodzaj.Puste)
            {
                tablica.setTab(1, 2, Rodzaj.Kolko);
                i12.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                tablica.nextStep();
            }
        }

        private void b22_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(2, 2) == Rodzaj.Puste)
            {
                tablica.setTab(2, 2, Rodzaj.Kolko);
                i22.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                tablica.nextStep();
            }
        }
    }

    class Tablica
    {
        private Rodzaj[,] rodzaj;
        public Tablica()
        {
            rodzaj = new Rodzaj[3, 3];
            clearTab();
        }
        public void clearTab()
        {
            for (byte y = 0; y < 3; y++)
            {
                for (byte x = 0; x < 3; x++)
                {
                    rodzaj[y, x] = Rodzaj.Puste;
                }
            }
        }
        public void setTab(byte y, byte x, Rodzaj rodzaj)
        {
            this.rodzaj[y, x] = rodzaj;
        }
        public Rodzaj getTab(byte y, byte x)
        {
            if (x > 2 || y > 2) return Rodzaj.Puste;
            return rodzaj[y, x];
        }
        public void nextStep()
        {
            // działania kompa
        }
    }
}
