// Projekt wykonany na studia w ramach przedmiotu "Programowanie obiektowe"

using System;
using System.Collections.Generic;

namespace Projekt_Programowanie_obiektowe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 20);

            // Utworzenie nowej gry i rozpoczęcie jej
            Gra gra = new Gra();
            gra.Rozpocznij();
        }
    }

    class Gra
    {
        private Waz waz;
        private Jedzenie jedzenie;
        private int wynik;

        public Gra()
        {
            // Inicjalizacja węża, jedzenia i wyniku
            waz = new Waz();
            jedzenie = new Jedzenie();
            wynik = 0;
        }

        public void Rozpocznij()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Wynik: " + wynik);
                waz.Rysuj();
                jedzenie.Rysuj();

                // Sprawdzenie, czy wąż zjadł jedzenie
                if (waz.Kolizja(jedzenie))
                {
                    waz.Zjedz(jedzenie);
                    jedzenie = new Jedzenie();
                    wynik++;
                }

                // Sprawdzenie, czy wąż zderzył się z samym sobą lub z krawędzią konsoli
                if (waz.Kolizja())
                {
                    Console.Clear();
                    Console.WriteLine("Koniec gry!");
                    Console.WriteLine("Wynik: " + wynik);
                    Console.ReadKey();
                    break;
                }

                // Odczytanie klawiszy strzałek i zmiana kierunku ruchu węża
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo klawisz = Console.ReadKey(true);
                    switch (klawisz.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            waz.ZmienKierunek(-1, 0);
                            break;
                        case ConsoleKey.RightArrow:
                            waz.ZmienKierunek(1, 0);
                            break;
                        case ConsoleKey.UpArrow:
                            waz.ZmienKierunek(0, -1);
                            break;
                        case ConsoleKey.DownArrow:
                            waz.ZmienKierunek(0, 1);
                            break;
                    }
                }

                // Przesunięcie węża o jeden punkt w kierunku jego głowy
                waz.Ruch();

                // Oczekiwanie na 100 milisekund przed kolejnym ruchem węża
                System.Threading.Thread.Sleep(100);
            }
        }
    }

    class Waz
    {
        private List<Punkt> cialo;
        private Punkt kierunek;

        public Waz()
        {
            // Inicjalizacja węża z jednym punktem na środku konsoli i kierunkiem w prawo
            cialo = new List<Punkt>();
            cialo.Add(new Punkt(20, 10));
            kierunek = new Punkt(1, 0);
        }

        public void Rysuj()
        {
            // Wyświetlenie każdego punktu ciała węża na konsoli
            foreach (Punkt punkt in cialo)
            {
                Console.SetCursorPosition(punkt.X, punkt.Y);
                Console.Write("*");
            }
        }

        public void Ruch()
        {
            // Dodanie nowego punktu na początku ciała węża i usunięcie ostatniego punktu
            Punkt glowa = cialo[0];
            Punkt nowaGlowa = new Punkt(glowa.X + kierunek.X, glowa.Y + kierunek.Y);
            cialo.Insert(0, nowaGlowa); // Dodaje nowy punkt na początek listy
            cialo.RemoveAt(cialo.Count - 1); // Usuwa ostatni punkt z listy
        }

        public bool Kolizja()
        {
            // Sprawdzenie, czy głowa węża zderzyła się z krawędzią konsoli
            Punkt glowa = cialo[0];

            if (glowa.X < 0 || glowa.X >= Console.WindowWidth || glowa.Y < 0 || glowa.Y >= Console.WindowHeight)
            {
                return true;
            }

            // Sprawdzenie, czy głowa węża zderzyła się z innym punktem jego ciała
            for (int i = 1; i < cialo.Count; i++)
            {
                if (glowa.X == cialo[i].X && glowa.Y == cialo[i].Y)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Kolizja(Jedzenie jedzenie)
        {
            // Sprawdzenie, czy głowa węża zderzyła się z jedzeniem
            Punkt glowa = cialo[0];

            if (glowa.X == jedzenie.Pozycja.X && glowa.Y == jedzenie.Pozycja.Y)
            {
                return true;
            }

            return false;
        }

        public void Zjedz(Jedzenie jedzenie)
        {
            // Dodanie nowego punktu na początku ciała węża po zjedzeniu jedzenia
            Punkt glowa = cialo[0];
            Punkt nowaGlowa = new Punkt(glowa.X + kierunek.X, glowa.Y + kierunek.Y);
            cialo.Insert(0, nowaGlowa);
        }

        // Metoda zmieniająca kierunek ruchu węża
        public void ZmienKierunek(int x, int y)
        {
            // Wąż nie może zawrócić o 180 stopni
            if (kierunek.X != -x && kierunek.Y != -y)
            {
                kierunek.X = x;
                kierunek.Y = y;
            }
        }
    }

    class Jedzenie
    {
        public Punkt Pozycja { get; private set; }

        public Jedzenie()
        {
            // Inicjalizacja jedzenia na losowej pozycji na konsoli
            Random losowa = new Random();
            Pozycja = new Punkt(losowa.Next(Console.WindowWidth), losowa.Next(Console.WindowHeight));
        }

        public void Rysuj()
        {
            // Wyświetlenie jedzenia na konsoli
            Console.SetCursorPosition(Pozycja.X, Pozycja.Y);
            Console.Write("@");
        }
    }

    class Punkt
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Punkt(int x, int y)
        {
            // Inicjalizacja punktu z podanymi współrzędnymi
            X = x;
            Y = y;
        }
    }
}
