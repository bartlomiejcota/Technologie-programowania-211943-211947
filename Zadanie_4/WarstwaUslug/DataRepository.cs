using System.Collections.Generic;
using System.Linq;
using System;

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

        // Add
        public static void CreateGracz(Gracz gracz)
        {
            dataBaseDataContext.Gracz.InsertOnSubmit(gracz);
            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void CreateGra(Gra gra)
        {
            dataBaseDataContext.Gra.InsertOnSubmit(gra);
            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void CreateRozegranaGra(RozegranaGra rozegranaGra)
        {
            dataBaseDataContext.RozegranaGra.InsertOnSubmit(rozegranaGra);
            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void CreateZdarzenie(Zdarzenie zdarzenie)
        {
            dataBaseDataContext.Zdarzenie.InsertOnSubmit(zdarzenie);
            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
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

            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
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

            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
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

            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
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

            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        // Get all
        public static IEnumerable<Gra> ReadAllGra()
        {
            List<Gra> result = (from gry in dataBaseDataContext.Gra
                                select gry).ToList();

            return result;
        }

        public static IEnumerable<Gracz> ReadAllGracz()
        {
            List<Gracz> result = (from gracze in dataBaseDataContext.Gracz
                                  select gracze).ToList();
                       
            return result;
        }

        public static IEnumerable<RozegranaGra> ReadAllRozegranaGra()
        {
            List<RozegranaGra> result = (from rozegraneGry in dataBaseDataContext.RozegranaGra
                                         select rozegraneGry).ToList();

            return result;
        }

        public static IEnumerable<Zdarzenie> ReadAllZdarzenie()
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

            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void UpdateGracz(Gracz gracz)
        {
            Gracz updateGracz = dataBaseDataContext.Gracz.Single(p => p.IdGracza == gracz.IdGracza);

            updateGracz.Imie = gracz.Imie;
            updateGracz.Nazwisko = gracz.Nazwisko;
            updateGracz.DataUrodzin = gracz.DataUrodzin;

            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void UpdateRozegranaGra(RozegranaGra rozegranaGra)
        {
            RozegranaGra updateRozegranaGra = dataBaseDataContext.RozegranaGra.Single(p => p.IdRozegranejGry == rozegranaGra.IdRozegranejGry);

            updateRozegranaGra.Gra = rozegranaGra.Gra;
            updateRozegranaGra.CzasRozpoczeciaGry = rozegranaGra.CzasRozpoczeciaGry;
            updateRozegranaGra.CzasTrwaniaGry = rozegranaGra.CzasTrwaniaGry;
            updateRozegranaGra.OplataWejsciowa = rozegranaGra.OplataWejsciowa;
            updateRozegranaGra.MinimalnyDepozyt = rozegranaGra.MinimalnyDepozyt;

            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }

        public static void UpdateZdarzenie(Zdarzenie zdarzenie)
        {
            Zdarzenie updateZdarzenie = dataBaseDataContext.Zdarzenie.Single(p => p.IdZdarzenia == zdarzenie.IdZdarzenia);

            updateZdarzenie.UczestnikGry = zdarzenie.UczestnikGry;
            updateZdarzenie.UkonczonaGra = zdarzenie.UkonczonaGra;
            updateZdarzenie.Wygrana = zdarzenie.Wygrana;

            try
            {
                dataBaseDataContext.SubmitChanges();
            }
            catch (Exception e)
            {

            }
        }
    }
}