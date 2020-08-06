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
                nextStep();
            }
        }

        private void b10_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(1, 0) == Rodzaj.Puste)
            {
                tablica.setTab(1, 0, Rodzaj.Kolko);
                i10.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                nextStep();
            }
        }

        private void b20_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(2, 0) == Rodzaj.Puste)
            {
                tablica.setTab(2, 0, Rodzaj.Kolko);
                i20.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                nextStep();
            }
        }

        private void b01_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(0, 1) == Rodzaj.Puste)
            {
                tablica.setTab(0, 1, Rodzaj.Kolko);
                i01.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                nextStep();
            }
        }

        private void b11_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(1, 1) == Rodzaj.Puste)
            {
                tablica.setTab(1, 1, Rodzaj.Kolko);
                i11.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                nextStep();
            }
        }

        private void b21_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(2, 1) == Rodzaj.Puste)
            {
                tablica.setTab(2, 1, Rodzaj.Kolko);
                i21.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                nextStep();
            }
        }

        private void b02_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(0, 2) == Rodzaj.Puste)
            {
                tablica.setTab(0, 2, Rodzaj.Kolko);
                i02.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                nextStep();
            }
        }

        private void b12_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(1, 2) == Rodzaj.Puste)
            {
                tablica.setTab(1, 2, Rodzaj.Kolko);
                i12.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                nextStep();
            }
        }

        private void b22_Click(object sender, RoutedEventArgs e)
        {
            if (tablica.getTab(2, 2) == Rodzaj.Puste)
            {
                tablica.setTab(2, 2, Rodzaj.Kolko);
                i22.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
                nextStep();
            }
        }
        private void rysuj(byte y, byte x, bool rodzaj = false)
        {
            if (y==0 && x==0) i00.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
            if (y==1 && x==0) i10.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
            if (y==2 && x==0) i20.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
            if (y==0 && x==1) i01.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
            if (y==1 && x==1) i11.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
            if (y==2 && x==1) i21.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
            if (y==0 && x==2) i02.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
            if (y==1 && x==2) i12.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
            if (y==2 && x==2) i22.Source = new BitmapImage(new Uri("obrazki/O1-icon.png", UriKind.Relative));
        }
        public void nextStep()
        {
            // szukanie wygranej!
            if (szukajWygranej())
                return;
        }
        private bool szukajWygranej()
        {
            for (byte i = 0; i < 3; i++)
            {
                //row
                if (tablica.getTab(i, 0) == Rodzaj.Kolko && tablica.getTab(i, 1) == Rodzaj.Kolko)
                {
                    tablica.setTab(i, 2,Rodzaj.Kolko); rysuj(i, 2); return true;
                }
                if (tablica.getTab(i, 0) == Rodzaj.Kolko && tablica.getTab(i, 2) == Rodzaj.Kolko)
                {
                    tablica.setTab(i, 1,Rodzaj.Kolko); rysuj(i, 1); return true;
                }
                if (tablica.getTab(i, 1) == Rodzaj.Kolko && tablica.getTab(i, 2) == Rodzaj.Kolko)
                {
                    tablica.setTab(i, 0,Rodzaj.Kolko); rysuj(i, 0); return true;
                }
                //column
                if (tablica.getTab(0, i) == Rodzaj.Kolko && tablica.getTab(1, i) == Rodzaj.Kolko)
                {
                    tablica.setTab(2, i,Rodzaj.Kolko); rysuj(2, i); return true;
                }
                if (tablica.getTab(0 ,i) == Rodzaj.Kolko && tablica.getTab(2,i) == Rodzaj.Kolko)
                {
                    tablica.setTab(1, i,Rodzaj.Kolko); rysuj(1, i); return true;
                }
                if (tablica.getTab(1, i) == Rodzaj.Kolko && tablica.getTab(2,i) == Rodzaj.Kolko)
                {
                    tablica.setTab(0, i,Rodzaj.Kolko); rysuj(0, i); return true;
                }
            }
            return false;
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
    }
}
