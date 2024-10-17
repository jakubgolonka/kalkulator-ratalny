<p align="center">
  <img alt="logotype" src="logotype-new.png" width="600px">
</p>

# Kalkulator ratalny

## Cel i funkcje aplikacji
Kalkulator ratalny to aplikacja konsolowa, która umożliwia obliczenie harmonogramu spłat kredytu na podstawie kwoty kredytu, okresu spłaty, oprocentowania oraz opcjonalnej nadpłaty. Użytkownik wprowadza dane, a aplikacja oblicza i wyświetla miesięczne raty kredytu, dzieląc je na część kapitałową oraz odsetkową. Kalkulator pomaga również zrozumieć, jak nadpłata wpływa na skrócenie okresu kredytowania i zmniejszenie kwoty odsetek.

## Problem, który rozwiązuje aplikacja
Aplikacja ułatwia użytkownikom dokładne planowanie spłaty kredytu, uwzględniając zmienne oprocentowanie oraz nadpłaty. Pozwala na szybkie obliczenia i symulacje, które mogą być trudne do wykonania ręcznie, dostarczając użytkownikowi jasne dane o jego zobowiązaniach kredytowych.

# Architektura aplikacji
| **Moduł** | **Funkcje** | **Opis** |
|:---------:|:-----------:|:-----------:|
| **Wczytywanie Danych** | | **Odpowiada za pobieranie i walidację danych od użytkownika.**
| Wczytywanie kwoty kredytu | *wczytywanieKwotyKredytu()* | Funkcja pobiera od użytkownika kwotę kredytu. Waliduje, czy wprowadzona wartość jest liczbą dodatnią. Jeśli nie, wyświetla błąd i prosi o ponowne wprowadzenie wartości.
| Wczytywanie liczby miesięcy | *wczytywanieLiczbyMiesiecy()* | Funkcja pobiera liczbę miesięcy na spłatę kredytu. Waliduje poprawność danych (liczba musi być większa od 0).
| Wczytywanie oprocentowania kredytu | *wczytywanieOprocentowaniaKredytu()* | Funkcja pobiera oprocentowanie roczne w procentach. Sprawdza, czy użytkownik wprowadził poprawną wartość większą niż 0.
| Wczytywanie nadpłaty kredytu | *wczytywanieNadplatyKredytu(decimal kwotaKredytu)* | Funkcja pyta użytkownika, czy chce dodać nadpłatę do kredytu. Jeśli tak, pobiera wartość nadpłaty i weryfikuje, czy nadpłata nie przekracza pozostałej kwoty kredytu.
| **Obliczenia i przetwarzanie** | | **Odpowiada za wszystkie obliczenia związane z harmonogramem spłat kredytu oraz ratami.**
| Obliczanie oprocentowania | *obliczanieOprocentowania()* | Funkcja przelicza oprocentowanie roczne na miesięczne (oprocentowanie roczne podzielone na 12).
| Obliczanie raty kredytu | *obliczRateKredytu()* | Funkcja oblicza wysokość miesięcznej raty kredytu. Uwzględnia oprocentowanie oraz liczbę miesięcy. Używa formuły dla rat stałych. 
| Przeliczanie nowej raty | *przeliczNowaRate() | Funkcja przelicza nową ratę kredytu po zastosowaniu nadpłaty. Oblicza nową wysokość raty na podstawie pozostałego kapitału.
| **Wyświetlanie wyników** | | **Wyświetla dane dotyczące kredytu użytkowników w konsoli.**
| Wyswietlanie harmonogramu | *wyswietlanieHarmonogramu()* | Prezentuje harmonogram spłat kredytu podając dla każdego miesiąca część kapitałową, odsetkową, wartość nadpłaty oraz pozostałą kwotę do spłaty.
| **Informacje dodatkowe** | | **Dodatkowe funkcje**
| Wyswietlanie autorów | *wyswietlanieAutorow()* | Wyświetla informacje o autorach programu.

## Moduły aplikacji

### Moduł wczytywania danych
* Odpowiada za wprowadzenie danych użytkownika takich jak, kwota kredytu, liczba miesięcy, oprocentowanie oraz nadpłata. Dane są weryfikowane pod kątem poprawności.

### Moduł obliczeń
* Oblicza miesięczną ratę kredytu z podziałem na część kapitałową i odsetkową, na podstawie wprowadzonych danych. Uwzględnia wpływa nadpłaty na pozostały kapitał oraz modyfikuje harmonogram spłat.

### Moduł wyświetlania wyników
* Odpowiada za prezentację harmonogramu spłat, który zawiera szczegóły każdej raty, a także informacje o nadpłatach i pozostałym kapitale.

# Opis funkcji i funkcjonalności

### Funkcja *wczytywanieKwotyKredytu*
* Pobiera od użytkownika kwotę kredytu. Sprawdza czy podana wartość jest liczbą dodatnią. W przypadku błędu użytkownik zostaje poproszony o ponowne wprowadzenie danych.

### Funkcja *wczytywanieLiczbyMiesiecy*
* Odpowiada za wprowadzenie liczby miesięcy spłaty. Zabezpiecza przed podaniem wartości ujemnych lub nieprawidłowych.

### Funkcja *wczytywanieOprocentowaniaKredytu*
* Użytkownik podaje roczne oprocentowanie w procentach. Program przelicza je na oprocentowanie miesięczne.

### Funkcja *wczytywanieNadplatyKredytu*
* Pozwala użytkownikowi na opcjonalne wprowadzenie kwoty nadpłaty. Sprawdza, czy nadpłata nie przekracza kwoty kredytu.

### Funkcja *obliczanieOprocentowania*
* Oblicza oprocentowanie miesięczne na podstawie wartości rocznego oprocentowania.

### Funkcja *obliczRateKredytu*
* Oblicza miesięczną ratę kredytu z uwzględnieniem części kapitałowej i odsetkowej. Algorytm wykorzystuje formułę dla rat stałych.

### Funkcja *wyswietlanieHarmonogramu*
* Wyświetla szczegółowy harmonogram spłat, który zawiera informacje o częściach kapitałowej, odsetkowej oraz nadpłacie.

# Instalacja i konfiguracja

## Wymagania systemowe

### System operacyjny
* Windows
* Linux
* macOS

### .NET SDK
* Wersja 6.0 lub nowsza

### IDE 
* Visual Studio 2022 (lub nowsze)

## Kroki instalacji i konfiguracji
* **1.** Pobierz i zainstaluj .NET SDK ze strony <a href = "https://developer.microsoft.com/en-us/windows/downloads/windows-sdk/">Microsoft</a>
* **2.** Otwórz projekt w Visual Studio lub uruchom z linii komend
* **3.** Skopiuj pliki źródłowe programu do wybranego katalogu
* **4.** W Visual Studio wybierz opcję *Otwórz projekt* i wskaż plik .csproj, a następnie kliknij *Uruchom* lub użyj *dotnet run* w linii komend

# Dokumentacja kodu
* **Klasa Program**: Główna klasa, która zawiera wszystkie funkcje programu.
* **Funkcje wczytywanieKwotyKredytu, wczytywanieLiczbyMiesiecy, wczytywanieOprocentowaniaKredytu, wczytywanieNadplatyKredytu**: Funkcje te wczytują dane od użytkownika i obsługują potencjalne błędy, jak nieprawidłowe wartości wejściowe.
* **Funkcja obliczRateKredytu**: Kluczowy algorytm obliczający stałą ratę kredytu według formuły równej raty.
* **Funkcja wyswietlanieHarmonogramu**: Wyświetla harmonogram rat na konsoli, z podziałem na kapitał, odsteki oraz pozostały dług.

# Przykłady użycia 

## Przykład 1
* **Dane wejściowe**
   * Kwota kredytu: 10,000 zł
   * Liczba miesięcy: 24
   * Oprocentowanie: 5%
   * Nadpłata: brak

* **Wynik:** Harmonogram z spłat z ratą miesięczną około 438,71zł (w tym kapitał i odsetki)

## Przykład 2
* **Dane wejściowe**
   * Kwota kredytu: 50,000 zł
   * Liczba miesięcy 60
   * Oprocentowanie: 3%
   * Nadpłata 200 zł miesięcznie

* **Wynik:** Harmonogram z nadpłatą, która skraca czas spłaty i zmniejsza odsetki

# Błędy i ich obsługa

## Aplikacja obsługuje błędy poprzez
* Sprawdzenie, czy wprowadzone wartości są liczbami dodatnimi.
* Obsługę błędnych formatów danych (np. litery zamiast liczb).
* Ograniczenie nadpłaty do kwoty mniejszej niż wartość pozostałego kapitału.

# Wnioski i przyszłe usprawnienia

## Elementy do usprawnienia
* Dodanie graficznego interfejsu użytkownika **(GUI)** dla lepszej interakcji.

## Wnioski:
Projekt był wartościowym doświadczeniem, które nauczyło nas efektywnego korzystania z funkcji obsługi błędów oraz algorytmów matematycznych. W kolejnych wersjach moglibyśmy skupić się na rozbudowie funkcjonalności programu i interfejsu użytkownika.

# Autorzy
* *Jakub Golonka*
* *Krystian Frączek* 
* *Jakub Matras*
* *Łukasz Szewczyk*
