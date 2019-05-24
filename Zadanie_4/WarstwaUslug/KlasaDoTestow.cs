using System;
using System.Linq;

namespace WarstwaUslug
{
    class KlasaDoTestow
    {
        static void Main()
        {
            using (DataBaseDataContext dataBaseDataContext = new DataBaseDataContext())
            {
                Gracz gracz1 = new Gracz()
                {
                    IdGracza = 0,
                    Imie = "Jan",
                    Nazwisko = "Kowalski",
                    DataUrodzin = new DateTime(1908, 1, 2)
                };

                DataRepository.CreateGracz(gracz1);
               
                Gracz gracz2 = new Gracz()
                {
                    IdGracza = 1,
                    Imie = "Karol",
                    Nazwisko = "Nowak",
                    DataUrodzin = new DateTime(1908, 1, 2)
                };

                DataRepository.CreateGracz(gracz2);

                Gra gra1 = new Gra()
                {
                    IdGry = 0,
                    NazwaGry = string.Concat("Super gra", 0),
                    InformacjeOGrze = string.Concat("Opis super gry", 0)
                };

                DataRepository.CreateGra(gra1);

                Gra gra2 = new Gra()
                {
                    IdGry = 1,
                    NazwaGry = string.Concat("Super gra", 1),
                    InformacjeOGrze = string.Concat("Opis super gry", 1)
                };

                DataRepository.CreateGra(gra2);

                RozegranaGra rozegranaGra1 = new RozegranaGra()
                {
                    IdRozegranejGry = 0,
                    Gra = 0,
                    CzasRozpoczeciaGry = new DateTime(1950, 11, 1),
                    CzasTrwaniaGry = new TimeSpan(1, 1, 1),
                    OplataWejsciowa = 100.00,
                    MinimalnyDepozyt = 10.00
                };

                DataRepository.CreateRozegranaGra(rozegranaGra1);

                RozegranaGra rozegranaGra2 = new RozegranaGra()
                {
                    IdRozegranejGry = 1,
                    Gra = 0,
                    CzasRozpoczeciaGry = new DateTime(1950, 11, 1),
                    CzasTrwaniaGry = new TimeSpan(1, 1, 1),
                    OplataWejsciowa = 100.00,
                    MinimalnyDepozyt = 10.00
                };

                DataRepository.CreateRozegranaGra(rozegranaGra2);

                Zdarzenie zdarzenie1 = new Zdarzenie()
                {
                    IdZdarzenia = 0,
                    UczestnikGry = 0,
                    UkonczonaGra = 0,
                    Wygrana = 100.00
                };

                DataRepository.CreateZdarzenie(zdarzenie1);

                Zdarzenie zdarzenie2 = new Zdarzenie()
                {
                    IdZdarzenia = 1,
                    UczestnikGry = 1,
                    UkonczonaGra = 1,
                    Wygrana = 300.00
                };

                DataRepository.CreateZdarzenie(zdarzenie2);
            }
        }
    }
}