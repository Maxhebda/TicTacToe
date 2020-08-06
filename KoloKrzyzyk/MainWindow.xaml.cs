using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KoloKrzyzyk
{
    public enum Rodzaj
    {
        Puste, Kolko, Krzyzyk
    }
    public partial class MainWindow : Window
    {
        bool win = false;
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
            if (win)
                return;
            if (tablica.getTab(0, 0) == Rodzaj.Puste)
            {
                tablica.setTab(0, 0, Rodzaj.Kolko);
                i00.Source = new BitmapImage(new Uri(adr_kolko, UriKind.Relative));
                nextStep();
            }
        }

        private void b10_Click(object sender, RoutedEventArgs e)
        {
            if (win)
                return;
            if (tablica.getTab(1, 0) == Rodzaj.Puste)
            {
                tablica.setTab(1, 0, Rodzaj.Kolko);
                i10.Source = new BitmapImage(new Uri(adr_kolko, UriKind.Relative));
                nextStep();
            }
        }

        private void b20_Click(object sender, RoutedEventArgs e)
        {
            if (win)
                return;
            if (tablica.getTab(2, 0) == Rodzaj.Puste)
            {
                tablica.setTab(2, 0, Rodzaj.Kolko);
                i20.Source = new BitmapImage(new Uri(adr_kolko, UriKind.Relative));
                nextStep();
            }
        }

        private void b01_Click(object sender, RoutedEventArgs e)
        {
            if (win)
                return;
            if (tablica.getTab(0, 1) == Rodzaj.Puste)
            {
                tablica.setTab(0, 1, Rodzaj.Kolko);
                i01.Source = new BitmapImage(new Uri(adr_kolko, UriKind.Relative));
                nextStep();
            }
        }

        private void b11_Click(object sender, RoutedEventArgs e)
        {
            if (win)
                return;
            if (tablica.getTab(1, 1) == Rodzaj.Puste)
            {
                tablica.setTab(1, 1, Rodzaj.Kolko);
                i11.Source = new BitmapImage(new Uri(adr_kolko, UriKind.Relative));
                nextStep();
            }
        }

        private void b21_Click(object sender, RoutedEventArgs e)
        {
            if (win)
                return;
            if (tablica.getTab(2, 1) == Rodzaj.Puste)
            {
                tablica.setTab(2, 1, Rodzaj.Kolko);
                i21.Source = new BitmapImage(new Uri(adr_kolko, UriKind.Relative));
                nextStep();
            }
        }

        private void b02_Click(object sender, RoutedEventArgs e)
        {
            if (win)
                return;
            if (tablica.getTab(0, 2) == Rodzaj.Puste)
            {
                tablica.setTab(0, 2, Rodzaj.Kolko);
                i02.Source = new BitmapImage(new Uri(adr_kolko, UriKind.Relative));
                nextStep();
            }
        }

        private void b12_Click(object sender, RoutedEventArgs e)
        {
            if (win)
                return;
            if (tablica.getTab(1, 2) == Rodzaj.Puste)
            {
                tablica.setTab(1, 2, Rodzaj.Kolko);
                i12.Source = new BitmapImage(new Uri(adr_kolko, UriKind.Relative));
                nextStep();
            }
        }

        private void b22_Click(object sender, RoutedEventArgs e)
        {
            if (win)
                return;
            if (tablica.getTab(2, 2) == Rodzaj.Puste)
            {
                tablica.setTab(2, 2, Rodzaj.Kolko);
                i22.Source = new BitmapImage(new Uri(adr_kolko, UriKind.Relative));
                nextStep();
            }
        }
        private void rysuj(byte y, byte x, bool rodzaj = false)
        {
            if (y==0 && x==0) i00.Source = new BitmapImage(new Uri(adr_krzyzyk, UriKind.Relative));
            if (y==1 && x==0) i10.Source = new BitmapImage(new Uri(adr_krzyzyk, UriKind.Relative));
            if (y==2 && x==0) i20.Source = new BitmapImage(new Uri(adr_krzyzyk, UriKind.Relative));
            if (y==0 && x==1) i01.Source = new BitmapImage(new Uri(adr_krzyzyk, UriKind.Relative));
            if (y==1 && x==1) i11.Source = new BitmapImage(new Uri(adr_krzyzyk, UriKind.Relative));
            if (y==2 && x==1) i21.Source = new BitmapImage(new Uri(adr_krzyzyk, UriKind.Relative));
            if (y==0 && x==2) i02.Source = new BitmapImage(new Uri(adr_krzyzyk, UriKind.Relative));
            if (y==1 && x==2) i12.Source = new BitmapImage(new Uri(adr_krzyzyk, UriKind.Relative));
            if (y==2 && x==2) i22.Source = new BitmapImage(new Uri(adr_krzyzyk, UriKind.Relative));
        }
        private void clearAll()
        {
            tablica.clearTab();
            i00.Source = new BitmapImage(new Uri("", UriKind.Relative));
            i01.Source = new BitmapImage(new Uri("", UriKind.Relative));
            i02.Source = new BitmapImage(new Uri("", UriKind.Relative));
            i10.Source = new BitmapImage(new Uri("", UriKind.Relative));
            i11.Source = new BitmapImage(new Uri("", UriKind.Relative));
            i12.Source = new BitmapImage(new Uri("", UriKind.Relative));
            i20.Source = new BitmapImage(new Uri("", UriKind.Relative));
            i21.Source = new BitmapImage(new Uri("", UriKind.Relative));
            i22.Source = new BitmapImage(new Uri("", UriKind.Relative));

            for (byte y = 0; y < 3; y++)
            {
                for (byte x = 0; x < 3; x++)
                {
                    colorWin(y, x, false);
                }
            }
        }
        public void nextStep()
        {
            bNewGame.Content = "1";
            // szukanie wygranej!
            if (szukajWygranej())
            {
                return;
            }
            bNewGame.Content = "2";
            if (szukajZagrozenia())
            {
                return;
            }
            bNewGame.Content = "3";
            if (zajmijSrodek())
            {
                return;
            }
            bNewGame.Content = "4";
            if (zajmijRog())
            {
                return;
            }

        }
        private bool zajmijSrodek()
        {
            if (tablica.getTab(1,1)==Rodzaj.Puste)
            {
                tablica.setTab(1, 1, Rodzaj.Krzyzyk);
                rysuj(1, 1);
                return true;
            }
            return false;
        }
        private bool zajmijRog()
        {
            if (tablica.getTab(0,0) != Rodzaj.Puste && tablica.getTab(2, 0) != Rodzaj.Puste && tablica.getTab(0, 2) != Rodzaj.Puste && tablica.getTab(2, 2) != Rodzaj.Puste)
            {
                return false;
            }
            Random random = new Random();
            int corner;
                bool goRandom = true;
                while (goRandom)
                {
                    corner = random.Next(0, 4);
                    switch (corner)
                    {
                        case 0:
                            if (tablica.getTab(0,0)==Rodzaj.Puste)
                            {
                                tablica.setTab(0, 0, Rodzaj.Krzyzyk);
                                rysuj(0, 0);
                                goRandom = false;
                            }
                            break;
                        case 1:
                            if (tablica.getTab(0, 2) == Rodzaj.Puste)
                            {
                                tablica.setTab(0, 2, Rodzaj.Krzyzyk);
                                rysuj(0, 2);
                                goRandom = false;
                            }
                            break;
                        case 2:
                            if (tablica.getTab(2, 2) == Rodzaj.Puste)
                            {
                                tablica.setTab(2, 2, Rodzaj.Krzyzyk);
                                rysuj(2, 2);
                                goRandom = false;
                            }
                            break;
                        case 3:
                            if (tablica.getTab(2, 0) == Rodzaj.Puste)
                            {
                                tablica.setTab(2, 0, Rodzaj.Krzyzyk);
                                rysuj(2, 0);
                                goRandom = false;
                            }
                            break;
                    }
                }
                return true;
        }
        private void colorWin(byte y, byte x, bool win)
        {
            if (y == 0 && x == 0) { if (win == true) b00.Background = Brushes.Green; else b00.Background = Brushes.Beige; };
            if (y == 0 && x == 1) { if (win == true) b01.Background = Brushes.Green; else b01.Background = Brushes.Beige; };
            if (y == 0 && x == 2) { if (win == true) b02.Background = Brushes.Green; else b02.Background = Brushes.Beige; };
            if (y == 1 && x == 0) { if (win == true) b10.Background = Brushes.Green; else b10.Background = Brushes.Beige; };
            if (y == 1 && x == 1) { if (win == true) b11.Background = Brushes.Green; else b11.Background = Brushes.Beige; };
            if (y == 1 && x == 2) { if (win == true) b12.Background = Brushes.Green; else b12.Background = Brushes.Beige; };
            if (y == 2 && x == 0) { if (win == true) b20.Background = Brushes.Green; else b20.Background = Brushes.Beige; };
            if (y == 2 && x == 1) { if (win == true) b21.Background = Brushes.Green; else b21.Background = Brushes.Beige; };
            if (y == 2 && x == 2) { if (win == true) b22.Background = Brushes.Green; else b22.Background = Brushes.Beige; };
        }
        private bool szukajWygranej()
        {
            for (byte i = 0; i < 3; i++)
            {
                //row
                if (tablica.getTab(i, 0) == Rodzaj.Krzyzyk && tablica.getTab(i, 1) == Rodzaj.Krzyzyk && tablica.getTab(i, 2) == Rodzaj.Puste)
                {
                    colorWin(i, 0, true);colorWin(i, 1, true);colorWin(i, 2, true);
                    win = true;
                    tablica.setTab(i, 2, Rodzaj.Krzyzyk); rysuj(i, 2); return true;
                }
                if (tablica.getTab(i, 0) == Rodzaj.Krzyzyk && tablica.getTab(i, 2) == Rodzaj.Krzyzyk && tablica.getTab(i, 1) == Rodzaj.Puste)
                {
                    colorWin(i, 0, true); colorWin(i, 2, true); colorWin(i, 1, true);
                    win = true;
                    tablica.setTab(i, 1, Rodzaj.Krzyzyk); rysuj(i, 1); return true;
                }
                if (tablica.getTab(i, 1) == Rodzaj.Krzyzyk && tablica.getTab(i, 2) == Rodzaj.Krzyzyk && tablica.getTab(i, 0) == Rodzaj.Puste)
                {
                    colorWin(i, 0, true); colorWin(i, 1, true); colorWin(i, 2, true);
                    win = true;
                    tablica.setTab(i, 0, Rodzaj.Krzyzyk); rysuj(i, 0); return true;
                }
                //column
                if (tablica.getTab(0, i) == Rodzaj.Krzyzyk && tablica.getTab(1, i) == Rodzaj.Krzyzyk && tablica.getTab(2, i) == Rodzaj.Puste)
                {
                    colorWin(0,i, true); colorWin(1,i, true); colorWin(2,i, true);
                    win = true;
                    tablica.setTab(2, i, Rodzaj.Krzyzyk); rysuj(2, i); return true;
                }
                if (tablica.getTab(0, i) == Rodzaj.Krzyzyk && tablica.getTab(2, i) == Rodzaj.Krzyzyk && tablica.getTab(1, i) == Rodzaj.Puste)
                {
                    colorWin(0, i, true); colorWin(1, i, true); colorWin(2, i, true);
                    win = true;
                    tablica.setTab(1, i, Rodzaj.Krzyzyk); rysuj(1, i); return true;
                }
                if (tablica.getTab(1, i) == Rodzaj.Krzyzyk && tablica.getTab(2, i) == Rodzaj.Krzyzyk && tablica.getTab(0, i) == Rodzaj.Puste)
                {
                    colorWin(0, i, true); colorWin(1, i, true); colorWin(2, i, true);
                    win = true;
                    tablica.setTab(0, i, Rodzaj.Krzyzyk); rysuj(0, i); return true;
                }
            }
                //slant
                if (tablica.getTab(0, 0) == Rodzaj.Krzyzyk && tablica.getTab(1, 1) == Rodzaj.Krzyzyk && tablica.getTab(2, 2) == Rodzaj.Puste)
                {
                    colorWin(2,2, true); colorWin(1,1, true); colorWin(0,0, true);
                    win = true;
                    tablica.setTab(2, 2, Rodzaj.Krzyzyk); rysuj(2, 2); return true;
                }
                if (tablica.getTab(1, 1) == Rodzaj.Krzyzyk && tablica.getTab(2, 2) == Rodzaj.Krzyzyk && tablica.getTab(0, 0) == Rodzaj.Puste)
                {
                    colorWin(2, 2, true); colorWin(1, 1, true); colorWin(0, 0, true);
                    win = true;
                    tablica.setTab(0, 0, Rodzaj.Krzyzyk); rysuj(0, 0); return true;
                }
                if (tablica.getTab(0, 0) == Rodzaj.Krzyzyk && tablica.getTab(2, 2) == Rodzaj.Krzyzyk && tablica.getTab(1, 1) == Rodzaj.Puste)
                {
                    colorWin(2, 2, true); colorWin(1, 1, true); colorWin(0, 0, true);
                    win = true;
                    tablica.setTab(1, 1, Rodzaj.Krzyzyk); rysuj(1, 1); return true;
                }

                if (tablica.getTab(2, 0) == Rodzaj.Krzyzyk && tablica.getTab(1, 1) == Rodzaj.Krzyzyk && tablica.getTab(0, 2) == Rodzaj.Puste)
                {
                    colorWin(0, 2, true); colorWin(1, 1, true); colorWin(2, 0, true);
                    win = true;
                    tablica.setTab(0, 2, Rodzaj.Krzyzyk); rysuj(0, 2); return true;
                }
                if (tablica.getTab(2, 0) == Rodzaj.Krzyzyk && tablica.getTab(0, 2) == Rodzaj.Krzyzyk && tablica.getTab(1, 1) == Rodzaj.Puste)
                {
                    colorWin(0, 2, true); colorWin(1, 1, true); colorWin(2, 0, true);
                    win = true;
                    tablica.setTab(1, 1, Rodzaj.Krzyzyk); rysuj(1, 1); return true;
                }
                if (tablica.getTab(0, 2) == Rodzaj.Krzyzyk && tablica.getTab(1, 1) == Rodzaj.Krzyzyk && tablica.getTab(2, 0) == Rodzaj.Puste)
                {
                    colorWin(0, 2, true); colorWin(1, 1, true); colorWin(2, 0, true);
                    win = true;
                    tablica.setTab(2, 0, Rodzaj.Krzyzyk); rysuj(2, 0); return true;
                }
            return false;
        }
        private bool szukajZagrozenia()
        {
            for (byte i = 0; i < 3; i++)
            {
                //row
                if (tablica.getTab(i, 0) == Rodzaj.Kolko && tablica.getTab(i, 1) == Rodzaj.Kolko && tablica.getTab(i, 2) == Rodzaj.Puste)
                {
                    tablica.setTab(i, 2, Rodzaj.Krzyzyk); rysuj(i, 2); return true;
                }
                if (tablica.getTab(i, 0) == Rodzaj.Kolko && tablica.getTab(i, 2) == Rodzaj.Kolko && tablica.getTab(i, 1) == Rodzaj.Puste)
                {
                    tablica.setTab(i, 1, Rodzaj.Krzyzyk); rysuj(i, 1); return true;
                }
                if (tablica.getTab(i, 1) == Rodzaj.Kolko && tablica.getTab(i, 2) == Rodzaj.Kolko && tablica.getTab(i, 0) == Rodzaj.Puste)
                {
                    tablica.setTab(i, 0, Rodzaj.Krzyzyk); rysuj(i, 0); return true;
                }
                //column
                if (tablica.getTab(0, i) == Rodzaj.Kolko && tablica.getTab(1, i) == Rodzaj.Kolko && tablica.getTab(2, i) == Rodzaj.Puste)
                {
                    tablica.setTab(2, i, Rodzaj.Krzyzyk); rysuj(2, i); return true;
                }
                if (tablica.getTab(0, i) == Rodzaj.Kolko && tablica.getTab(2, i) == Rodzaj.Kolko && tablica.getTab(1, i) == Rodzaj.Puste)
                {
                    tablica.setTab(1, i, Rodzaj.Krzyzyk); rysuj(1, i); return true;
                }
                if (tablica.getTab(1, i) == Rodzaj.Kolko && tablica.getTab(2, i) == Rodzaj.Kolko && tablica.getTab(0, i) == Rodzaj.Puste)
                {
                    tablica.setTab(0, i, Rodzaj.Krzyzyk); rysuj(0, i); return true;
                }
            }
                //slant
                if (tablica.getTab(0, 0) == Rodzaj.Kolko && tablica.getTab(1, 1) == Rodzaj.Kolko && tablica.getTab(2, 2) == Rodzaj.Puste)
                {
                    tablica.setTab(2, 2, Rodzaj.Krzyzyk); rysuj(2, 2); return true;
                }
                if (tablica.getTab(1, 1) == Rodzaj.Kolko && tablica.getTab(2, 2) == Rodzaj.Kolko && tablica.getTab(0, 0) == Rodzaj.Puste)
                {
                    tablica.setTab(0, 0, Rodzaj.Krzyzyk); rysuj(0, 0); return true;
                }
                if (tablica.getTab(0, 0) == Rodzaj.Kolko && tablica.getTab(2, 2) == Rodzaj.Kolko && tablica.getTab(1, 1) == Rodzaj.Puste)
                {
                    tablica.setTab(1, 1, Rodzaj.Krzyzyk); rysuj(1, 1); return true;
                }

                if (tablica.getTab(2, 0) == Rodzaj.Kolko && tablica.getTab(1, 1) == Rodzaj.Kolko && tablica.getTab(0, 2) == Rodzaj.Puste)
                {
                    tablica.setTab(0, 2, Rodzaj.Krzyzyk); rysuj(0, 2); return true;
                }
                if (tablica.getTab(2, 0) == Rodzaj.Kolko && tablica.getTab(0, 2) == Rodzaj.Kolko && tablica.getTab(1, 1) == Rodzaj.Puste)
                {
                    tablica.setTab(1, 1, Rodzaj.Krzyzyk); rysuj(1, 1); return true;
                }
                if (tablica.getTab(0, 2) == Rodzaj.Kolko && tablica.getTab(1, 1) == Rodzaj.Kolko && tablica.getTab(2, 0) == Rodzaj.Puste)
                {
                    tablica.setTab(2, 0, Rodzaj.Krzyzyk); rysuj(2, 0); return true;
                }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clearAll();
            win = false;

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
