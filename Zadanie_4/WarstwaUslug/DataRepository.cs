using System.Collections.Generic;
using System.Linq;
using System;
using WarstwaDanych;

namespace WarstwaUslug
{
    public class DataRepository // DataRepository - funkcjonalność CRUD
    {
        private static DataBaseDataContext dataBaseDataContext = new DataBaseDataContext();

        public static DataBaseDataContext DataContext
        {
            get => dataBaseDataContext;
            set => dataBaseDataContext = value;
        }

        //SaveChanges
        public static void SaveChanges()
        {
            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {
            }

        }

        // Add
        public static void CreateGracz(Gracz gracz)
        {
            dataBaseDataContext.Gracz.InsertOnSubmit(gracz);
            SaveChanges();
        }

        public static void CreateGra(Gra gra)
        {
            dataBaseDataContext.Gra.InsertOnSubmit(gra);
            SaveChanges();
        }

        public static void CreateRozegranaGra(RozegranaGra rozegranaGra)
        {
            dataBaseDataContext.RozegranaGra.InsertOnSubmit(rozegranaGra);
            SaveChanges();
        }

        public static void CreateZdarzenie(Zdarzenie zdarzenie)
        {
            dataBaseDataContext.Zdarzenie.InsertOnSubmit(zdarzenie);
            SaveChanges();
        }

        // Delete
        public static void DeleteGra(int id)
        {
            Gra gra = (from gry in dataBaseDataContext.Gra
                       where gry.IdGry == id
                       select gry).First();

            if (gra != null)
            {
                dataBaseDataContext.Gra.DeleteOnSubmit(gra);
            }

            SaveChanges();
        }

        public static void DeleteGracz(int id)
        {
            Gracz gracz = (from gracze in dataBaseDataContext.Gracz
                           where gracze.IdGracza == id
                           select gracze).First();

            if (gracz != null)
            {
                dataBaseDataContext.Gracz.DeleteOnSubmit(gracz);
            }

            SaveChanges();
        }

        public static void DeleteRozegranaGra(int id)
        {
            RozegranaGra rozegranaGra = (from rozegraneGry in dataBaseDataContext.RozegranaGra
                                         where rozegraneGry.IdRozegranejGry == id
                                         select rozegraneGry).First();

            if (rozegranaGra != null)
            {
                dataBaseDataContext.RozegranaGra.DeleteOnSubmit(rozegranaGra);
            }

            SaveChanges();
        }

        public static void DeleteZdarzenie(int idZdarzenia)
        {
            Zdarzenie zdarzenie = (from zdarzenia in dataBaseDataContext.Zdarzenie
                                   where zdarzenia.IdZdarzenia == idZdarzenia
                                   select zdarzenia).First();

            if (zdarzenie != null)
            {
                dataBaseDataContext.Zdarzenie.DeleteOnSubmit(zdarzenie);
            }

            SaveChanges();
        }

        // Get all
        public static List<Gra> ReadAllGra()
        {
            List<Gra> result = (from gry in dataBaseDataContext.Gra
                                select gry).ToList();

            return result;
        }

        public static List<Gracz> ReadAllGracz()
        {
            List<Gracz> result = (from gracze in dataBaseDataContext.Gracz
                                  select gracze).ToList();

            return result;
        }

        public static List<RozegranaGra> ReadAllRozegranaGra()
        {
            List<RozegranaGra> result = (from rozegraneGry in dataBaseDataContext.RozegranaGra
                                         select rozegraneGry).ToList();

            return result;
        }

        public static List<Zdarzenie> ReadAllZdarzenie()
        {
            List<Zdarzenie> result = (from zdarzenia in dataBaseDataContext.Zdarzenie
                                      select zdarzenia).ToList();

            return result;
        }

        // Get
        public static Gra ReadGra(int id)
        {
            Gra gra = (from gry in dataBaseDataContext.Gra
                       where gry.IdGry == id
                       select gry).First();

            return gra;
        }

        public static Gracz ReadGracz(int id)
        {
            Gracz gracz = (from gracze in dataBaseDataContext.Gracz
                           where gracze.IdGracza == id
                           select gracze).First();

            return gracz;
        }

        public static RozegranaGra ReadRozegranaGra(int id)
        {
            RozegranaGra rozegranaGra = (from rozegraneGry in dataBaseDataContext.RozegranaGra
                                         where rozegraneGry.IdRozegranejGry == id
                                         select rozegraneGry).First();

            return rozegranaGra;
        }

        public static Zdarzenie ReadZdarzenie(int idZdarzenia)
        {
            Zdarzenie zdarzenie = (from zdarzenia in dataBaseDataContext.Zdarzenie
                                   where zdarzenia.IdZdarzenia == idZdarzenia
                                   select zdarzenia).First();

            return zdarzenie;
        }

        // Update
        public static void UpdateGra(Gra gra)
        {
            Gra updateGra = dataBaseDataContext.Gra.Single(p => p.IdGry == gra.IdGry);

            updateGra.NazwaGry = gra.NazwaGry;
            updateGra.InformacjeOGrze = gra.InformacjeOGrze;

            SaveChanges();
        }

        public static void UpdateGracz(Gracz gracz)
        {
            Gracz updateGracz = dataBaseDataContext.Gracz.Single(p => p.IdGracza == gracz.IdGracza);

            updateGracz.Imie = gracz.Imie;
            updateGracz.Nazwisko = gracz.Nazwisko;
            updateGracz.DataUrodzin = gracz.DataUrodzin;

            SaveChanges();
        }

        public static void UpdateRozegranaGra(RozegranaGra rozegranaGra)
        {
            RozegranaGra updateRozegranaGra = dataBaseDataContext.RozegranaGra.Single(p => p.IdRozegranejGry == rozegranaGra.IdRozegranejGry);

            updateRozegranaGra.Gra = rozegranaGra.Gra;
            updateRozegranaGra.CzasRozpoczeciaGry = rozegranaGra.CzasRozpoczeciaGry;
            updateRozegranaGra.CzasTrwaniaGry = rozegranaGra.CzasTrwaniaGry;
            updateRozegranaGra.OplataWejsciowa = rozegranaGra.OplataWejsciowa;
            updateRozegranaGra.MinimalnyDepozyt = rozegranaGra.MinimalnyDepozyt;

            SaveChanges();
        }

        public static void UpdateZdarzenie(Zdarzenie zdarzenie)
        {
            Zdarzenie updateZdarzenie = dataBaseDataContext.Zdarzenie.Single(p => p.IdZdarzenia == zdarzenie.IdZdarzenia);

            updateZdarzenie.UczestnikGry = zdarzenie.UczestnikGry;
            updateZdarzenie.UkonczonaGra = zdarzenie.UkonczonaGra;
            updateZdarzenie.Wygrana = zdarzenie.Wygrana;

            SaveChanges();
        }

        // Wypełnianie danymi
        public static void WypelnijDanymi(int iloscGraczy, int iloscGier, int iloscRozegranychGier, int iloscZdarzen)
        {
            // Dodawanie graczy
            int iloscGraczyPrzed = 0;
            if (DataRepository.ReadAllGracz().Count() != 0)
            {
                iloscGraczyPrzed = DataRepository.ReadAllGracz().Last().IdGracza + 1;
            }

            for (int i = iloscGraczyPrzed; i < iloscGraczyPrzed + iloscGraczy; i++)
            {
                Gracz gracz = new Gracz()
                {
                    IdGracza = i,
                    Imie = string.Concat("Gracz", i),
                    Nazwisko = string.Concat("Graczowski", i),
                    DataUrodzin = new DateTime(1950 + i % 50, i % 11 + 1, i % 28 + 1)
                };

                DataRepository.CreateGracz(gracz);
            }

            // Dodawanie gier
            int iloscGierPzed = 0;
            if (DataRepository.ReadAllGra().Count() != 0)
            {
                iloscGierPzed = DataRepository.ReadAllGra().Last().IdGry + 1;
            }

            for (int i = iloscGierPzed; i < iloscGierPzed + iloscGier; i++)
            {
                Gra gra = new Gra()
                {
                    IdGry = i,
                    NazwaGry = string.Concat("Gra", i),
                    InformacjeOGrze = string.Concat("Opis o grze ", i)
                };

                DataRepository.CreateGra(gra);
            }

            // Dodawanie rozegranych gier
            int iloscRozegranychGierPrzed = 0;
            if (DataRepository.ReadAllRozegranaGra().Count() != 0)
            {
                iloscRozegranychGierPrzed = DataRepository.ReadAllRozegranaGra().Last().IdRozegranejGry + 1;
            }

            for (int i = iloscRozegranychGierPrzed; i < iloscRozegranychGierPrzed + iloscRozegranychGier; i++)
            {
                RozegranaGra rozegranaGra = new RozegranaGra()
                {
                    IdRozegranejGry = i,
                    Gra = i % DataRepository.ReadAllGra().Count(),
                    CzasRozpoczeciaGry = new DateTime(1950 + i % 50, i % 12 + 1, i % 28 + 1),
                    CzasTrwaniaGry = new TimeSpan(i % 24, i % 60, i % 59 + 1),
                    OplataWejsciowa = (i % 5) * 5,
                    MinimalnyDepozyt = (i % 6) * 6
                };

                DataRepository.CreateRozegranaGra(rozegranaGra);
            }

            // Dodawanie Zdarzeń
            int iloscZdarzenPrzed = 0;
            if (DataRepository.ReadAllZdarzenie().Count() != 0)
            {
                iloscZdarzenPrzed = DataRepository.ReadAllZdarzenie().Last().IdZdarzenia + 1;
            }

            for (int i = iloscZdarzenPrzed; i < iloscZdarzenPrzed + iloscZdarzen; i++)
            {
                Zdarzenie zdarzenie = new Zdarzenie()
                {
                    IdZdarzenia = i,
                    UczestnikGry = i % DataRepository.ReadAllGracz().Count(),
                    UkonczonaGra = i % DataRepository.ReadAllRozegranaGra().Count(),
                    Wygrana = (i % 10) * 10
                };

                DataRepository.CreateZdarzenie(zdarzenie);
            }
        }
        static public void Main() { }
    }
}