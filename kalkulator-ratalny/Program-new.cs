// Autorzy programu:
// Jakub Matras
// Jakub Golonka
// Łukasz Szewczyk
// Krystian Frączek

using System.Data;

internal class Program
{

    // Funkcja pobierająca od użytkownika informację o kwocie kredytu.
    static decimal wczytywanieKwotyKredytu()
    {
        while (true)
        {
            // Obsługa możliwych błędów przy pobieraniu wartości kwoty kredytu.
            try
            {
                Console.Write("[->] Wprowadź kwotę kredytu: ");

                // Obsługa możliwych błędów z kwotą kredytu poniżej 0 i pobieraniem wartości kredytu.
                if (!decimal.TryParse(Console.ReadLine(), out decimal kwotaKredytu) || kwotaKredytu <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[BŁĄD] Wartość kwoty kredytu musi być większa od 0!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                return kwotaKredytu;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[BŁĄD] Wprowadzono nieprawidłową wartość kwoty kredytu. [" + e.Message + "]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    // Funkcja pobierająca od użytkownika informację o liczbie miesięcy.
    static int wczytywanieLiczbyMiesiecy()
    {
        while (true)
        {
            // Obsługa możliwych błędów przy pobieraniu liczby miesięcy.
            try
            {
                Console.Write("[->] Wprowadź liczbę miesięcy: ");

                // Obsługa możliwych błędów z liczbą miesięcy poniżej 0 i pobieraniem liczby miesięcy.
                if (!int.TryParse(Console.ReadLine(), out int liczbaMiesiecy) || liczbaMiesiecy <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[BŁĄD] Wartość liczby miesięcy musi być większa od 0!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                return liczbaMiesiecy;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[BŁĄD] Wprowadzono nieprawidłową wartość liczby miesięcy. [" + e.Message + "]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    // Funkcja pobierająca od użytkownika informację o wartości oprocentowania kredytu.
    static decimal wczytywanieOprocentowaniaKredytu()
    {
        while (true)
        {
            // Obsługa błędów przy pobieraniu wartości oprocentowania kredytu.
            try
            {
                Console.Write("[->] Wprowadź oprocentowanie roczne (w %): ");

                // Obsługa możliwych błędów z wartością oprocentowania kredytu poniżej 0 i pobieraniem wartości oprocentowania kredytu.
                if (!decimal.TryParse(Console.ReadLine(), out decimal oprocentowanieKredytu) || oprocentowanieKredytu <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[BŁĄD] Wartość oprocentowania kredytu musi być większa od 0!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                return oprocentowanieKredytu;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[BŁĄD] Wprowadzono nieprawidłową wartość oprocentowania kredytu. [" + e.Message + "]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    // Funkcja pobierająca od użytkownika informację o tym, czy występuje nadpłata, a jeśli tak to w jakiej kwocie.
    static decimal wczytywanieNadplatyKredytu(decimal kwotaKredytu)
    {
        while (true)
        {
            // Obsługa możliwych błędów przy pobieraniu wartości nadpłaty kredytu.
            try
            {
                Console.Write("[->] Czy chcesz wprowadzić nadpłatę kredytu? (tak/nie): ");
                string? czyNadplata = Console.ReadLine()?.ToLower();
                // Obsługa możliwych błędów występujących przy wybieraniu opcji.
                if (czyNadplata != "tak" && czyNadplata != "nie")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[BŁĄD] Wprowadzono nieprawidłową wartość wyboru nadpłaty.");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                // Sprawdzanie, czy występuje nadpłata kredytu, a jeśli tak, to wykonywnaie kolejnych funkcji.
                if (czyNadplata == "tak")
                {
                    Console.Write("[->] Wprowadź kwotę nadpłaty, którą chcesz wprowadzać miesięcznie: ");

                    // Obsługa możliwych błędów z wartością nadpłaty kredytu poniżej 0 i pobieraniem wartości nadpłaty kredytu.
                    if (!decimal.TryParse(Console.ReadLine(), out decimal nadplataKredytu) || nadplataKredytu <= 0 || nadplataKredytu > kwotaKredytu)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("[BŁĄD] Wartość nadpłaty kredytu musi być większa od 0 i mniejsza od kwoty kredytu!");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    return nadplataKredytu;
                }

                return 0;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[BŁĄD] Wprowadzono nieprawidłową wartość kwoty kredytu. [" + e.Message + "]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    // Funkcja obliczająca wartość oprocentowania kredytu według podanych danych.
    static decimal obliczanieOprocentowania(decimal oprocentowanieRoczne)
    {
        return Math.Round(oprocentowanieRoczne / 12 / 100, 5);
    }

    // Funkcja obliczajaca ratę kredytu według podanych danych.
    static decimal obliczRateKredytu(decimal kwotaKredytu, decimal miesieczneOprocentowanie, int liczbaMiesiecy)
    {
        if (miesieczneOprocentowanie == 0)
        {
            return Math.Round(kwotaKredytu / liczbaMiesiecy, 2);
        }

        return Math.Round(kwotaKredytu * (miesieczneOprocentowanie * (decimal)Math.Pow((double)(1 + miesieczneOprocentowanie), liczbaMiesiecy)) / ((decimal)Math.Pow((double)(1 + miesieczneOprocentowanie), liczbaMiesiecy) - 1), 2);
    }

    static decimal przeliczNowaRate(decimal pozostalyKapital, decimal miesieczneOprocentowanie, int liczbaMiesiecy)
    {
        return obliczRateKredytu(pozostalyKapital, miesieczneOprocentowanie, liczbaMiesiecy);
    }

    // Funkcja wyświetlająca harmonogram zawierający wszystkie informacje o kredycie.
    static void wyswietlanieHarmonogramu(decimal kwotaKredytu, decimal rataKredytu, decimal miesieczneOprocentowanie, int liczbaMiesiecy, decimal nadplataKredytu)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n[!!] Szczegółowy harmonogramu spłat kredytu: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Miesiąc \t Część kapitałowa \t Część odsetkowa \t Wartość nadpłaty \t Pozostały kapitał");

        decimal pozostalyKapital = kwotaKredytu;

        //  ustalanie indeksu kalkulatora historii kalkulatora.

        string ?linia;
        using (StreamReader odczytHistoriiKalkulatora = new StreamReader("historiaKalkulatorow.txt"))
        {
            linia = odczytHistoriiKalkulatora.ReadLine();
        }

        bool czyPustyPlik = false;
        if (linia == null)
        {
            czyPustyPlik = true;
        }

        // Otworzenie do zapisu pliku z historią harmonogramów.
       

        if (czyPustyPlik)
        {
            using (StreamWriter historiaKalkulatorow = new StreamWriter("historiaKalkulatorow.txt", true))
            {
                DateTime now = DateTime.Now;
                historiaKalkulatorow.WriteLine("--1-" + now);
            }
        } 
        else
        {
            
            int ostatniIndeks = 0;
            
            using (StreamReader odczytHistoriiKalkulatora = new StreamReader("historiaKalkulatorow.txt"))
            {
                linia = odczytHistoriiKalkulatora.ReadLine();
                while (linia != null)
                {
                    if (linia.Substring(0, 2) == "--")
                    {
                        ostatniIndeks = int.Parse(linia.Substring(2, 1));
                    }

                    
                    linia = odczytHistoriiKalkulatora.ReadLine();
                }
            }
            
            

            using (StreamWriter historiaKalkulatorow = new StreamWriter("historiaKalkulatorow.txt", true))
            {
                DateTime now = DateTime.Now;
                historiaKalkulatorow.WriteLine($"--{ostatniIndeks + 1 + "-" + now}");
            }
            
        }

        //zapisanie opisu do harmonogramu.
        using (StreamWriter historiaKalkulatorow = new StreamWriter("historiaKalkulatorow.txt", true))
        {
            historiaKalkulatorow.WriteLine("Miesiąc \t Część kapitałowa \t Część odsetkowa \t Wartość nadpłaty \t Pozostały kapitał");
        }
            
        

        // Pętla tworząca harmonogram zawierający informacje o kredycie.
        for (int miesiac = 1; miesiac <= liczbaMiesiecy; miesiac++)
        {
            // Obliczanie danych znajdujacych się w harmonogramie kredytu.
            decimal odsetki = Math.Round(pozostalyKapital * miesieczneOprocentowanie, 2);
            decimal kapital = Math.Round(rataKredytu - odsetki, 2);

            kapital += nadplataKredytu;

            if (kapital > pozostalyKapital)
            {
                kapital = pozostalyKapital;
            }

            pozostalyKapital -= kapital;

            if (pozostalyKapital < (decimal)0.5)
            {
                pozostalyKapital = 0;
            }

            Math.Round(pozostalyKapital, 2);

            // zapisanie lini z kalkulatora.
            Console.WriteLine($"{miesiac,-10} \t {kapital,-20:F2} \t {odsetki,-15:F2} \t {nadplataKredytu,-15:F2} \t {pozostalyKapital,0:F2}");
            using (StreamWriter historiaKalkulatorow = new StreamWriter("historiaKalkulatorow.txt", true))
            {
                historiaKalkulatorow.WriteLine($"{miesiac,-10} \t {kapital,-20:F2} \t {odsetki,-15:F2} \t {nadplataKredytu,-15:F2} \t {pozostalyKapital,0:F2}");
            }
                

            if (pozostalyKapital <= 0)
            {
                break;
            }

            rataKredytu = przeliczNowaRate(pozostalyKapital, miesieczneOprocentowanie, liczbaMiesiecy - miesiac);
        }
        
    }

    static void wyswietlanieHistoriiKalkulatora()
    {
        string ?linia;
        int maksymalnyIndeksOdczytuHistori = 1;
        using (StreamReader odczytHistoriiKalkulatora = new StreamReader("historiaKalkulatorow.txt"))
        {
            linia = odczytHistoriiKalkulatora.ReadLine();
        }

        //sprawdzenie, czy historia jest pusta
        if (linia == null)
        {
            //automatyczne zakończenie wykonywania funkcji, gdy historia jest pusta.
            Console.WriteLine("Niestety, historia twojego kalkulatora ratalnego jest pusta");
            return;
        }

        List<string[]> historiaKalkulator = new List<string[]>();

        using (StreamReader odczytHistoriiKalkulatora = new StreamReader("historiaKalkulatorow.txt"))
        {
            linia = odczytHistoriiKalkulatora.ReadLine();
            while (linia != null)
            {
                if (linia.Substring(0, 2) == "--")
                {
                    string[] oczytZlini = linia.Split('-');
                    historiaKalkulator.Add(oczytZlini);
                    maksymalnyIndeksOdczytuHistori = int.Parse(oczytZlini[2]);
                }

                linia = odczytHistoriiKalkulatora.ReadLine();
            }
        }

        foreach (var item in historiaKalkulator)
        {   
            Console.Write(item[2] + ":  " + item[3]);
            Console.WriteLine();  
        }
        

        int ktoryIndeksWyswietlic = 0;

        while (true)
        {
            // Obsługa możliwych błędów przy pobieraniu wartości true/false czy wyświetlać
            try
            {
                Console.Write("Którą historię chcesz wyświetlić (podaj liczbę indeksu): ");
                if (!int.TryParse(Console.ReadLine(), out int indeks) || indeks <= 0 || indeks > maksymalnyIndeksOdczytuHistori)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"[BŁĄD] Wartość liczby musi być większa od 0 oraz mniejsza bądź równa {maksymalnyIndeksOdczytuHistori}!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                ktoryIndeksWyswietlic = indeks;
                break;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[BŁĄD] Wprowadzoną złą odpowiedź. [" + e.Message + "]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        using (StreamReader odczytHistoriiKalkulatora = new StreamReader("historiaKalkulatorow.txt"))
        {
            linia = odczytHistoriiKalkulatora.ReadLine();
            Boolean czyWyswietlacLinie = false;
            while (linia != null)
            {
                if (linia.Substring(0, 2) == "--")
                {
                    if (linia.Substring(0, 3) == $"--{ktoryIndeksWyswietlic}")
                    {
                        czyWyswietlacLinie = true;

                        Console.WriteLine($"\nOdczyt z daty: {linia.Split("-")[3]}");
                        linia = odczytHistoriiKalkulatora.ReadLine();
                        continue;
                    }
                    else
                    {
                        czyWyswietlacLinie = false;
                    }
                }

                if (czyWyswietlacLinie)
                {
                    Console.WriteLine(linia);
                }

                linia = odczytHistoriiKalkulatora.ReadLine();
            }
        }
        Console.WriteLine();
    }


    // Funkcja wyświetlająca informacje o autorach programu.
    static void wyswietlanieAutorow()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n[!!] Autorzy programu: ");
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Jakub Matras \nJakub Golonka \nŁukasz Szewczyk \nKrystian Frączek \nKlasa: 3TP ZSTiO");
    }

    static Boolean czyWyswietlicHistorie()
    {
        while (true)
        {
            // Obsługa możliwych błędów przy pobieraniu wartości true/false czy wyświetlać
            try
            {
                Console.Write("Czy chcesz wyświetlić jakiś grafik z twojej historii kalkulatora ratalnego? (tak/nie): ");
                string ?odpowiedz = Console.ReadLine();
                if (odpowiedz == "tak")
                    return true;
                if (odpowiedz == "nie")
                    return false;

                Console.WriteLine("Wprowadzono złą wartość, Podana wartość musi być równa 'tak' lub 'nie'");
                continue;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[BŁĄD] Wystąpił błąd. [" + e.Message + "]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }

    private static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Kalkulator ratalny\n");
        Console.ForegroundColor = ConsoleColor.White;

        // Wybieranie opcji, czy użytkownik chce wyświetlić log z historii, czy obliczyć coś w kalkulatorze

        while (true)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n---------------------------Menu Opcji--------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Aby dokonać obliczenia w kalkulatorze ratalnym wybierz '1', ");
                Console.WriteLine("Aby wyświetlić jakiś grafik z historii kalkulatora wybierz '2', ");
                Console.WriteLine("Aby zakończyć program wybierz '3': ");
                Console.Write("Twój wybór: ");
                int.TryParse(Console.ReadLine(), out int wybor);
                if (wybor <= 0 || wybor > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[BŁĄD] Wybrano złą odpowiedź, wybrana odpowiedź musi być równa '1' albo '2' ");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                switch(wybor)
                {
                    case 1:
                        // Przypisywanie parametrów do poszczególnych zmiennych
                        decimal kwotaKredytu = wczytywanieKwotyKredytu();
                        int liczbaMiesiecy = wczytywanieLiczbyMiesiecy();
                        decimal oprocentowanieKredytu = wczytywanieOprocentowaniaKredytu();
                        decimal nadplataKredytu = wczytywanieNadplatyKredytu(kwotaKredytu);

                        decimal miesieczneOprocentowanie = obliczanieOprocentowania(oprocentowanieKredytu);
                        decimal rataKredytu = obliczRateKredytu(kwotaKredytu, miesieczneOprocentowanie, liczbaMiesiecy);

                        // Wywolywanie funkcji odpowiadających za wyświetlanie programu.
                        wyswietlanieHarmonogramu(kwotaKredytu, rataKredytu, miesieczneOprocentowanie, liczbaMiesiecy, nadplataKredytu);
                        wyswietlanieAutorow();
                        continue;
                    case 2:
                        wyswietlanieHistoriiKalkulatora();
                        continue;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n-----------------------PROGRAM ZAKOŃCZONY----------------------");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                break;
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[BŁĄD] Wystąpił błąd. [" + e.Message + "]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}