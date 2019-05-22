using System;
using System.Collections.Generic;
using System.Linq;

namespace Kasyno
{
    public class DataService : IDataService // DataService
    {
        private IDataRepository Repository;

        public DataService(IDataRepository repository)
        {
            Repository = repository;
        }

        // Add
        public void AddGra(int idGry, string nazwaGry, string informacjeOGrze)
        {
            IEnumerable<Gra> gry = Repository.GetAllGraIEnumerable();
            bool idIstnieje = false;

            foreach(var gra in gry)
            {
                if (gra.IdGry.Equals(idGry))
                    idIstnieje = true;
            }

            if (idIstnieje == false)
            {
                Repository.AddGra(new Gra(idGry, nazwaGry, informacjeOGrze));
            }
            else
            {
                throw new ArgumentException("Gra o podanym ID już istnieje.");
            }
        }

        public void AddGracz(int idGracza, string imie, string nazwisko, DateTime dataUrodzin)
        {
            IEnumerable<Gracz> gracze = Repository.GetAllGracz();
            bool idIstnieje = false;

            foreach (var gracz in gracze)
            {
                if (gracz.IdGracza.Equals(idGracza))
                    idIstnieje = true;
            }

            if (idIstnieje == false)
            {
                Repository.AddGracz(new Gracz(idGracza, imie, nazwisko, dataUrodzin));
            }
            else
            {
                throw new ArgumentException("Gracz o podanym ID już istnieje.");
            }
        }

        public void AddRozegranaGra(int idRozegranejGry, Gra gra, DateTime czasRozpoczeciaGry, TimeSpan czasTrwaniaGry, double oplataWejsciowa, double minimalnyDepozyt)
        {
            IEnumerable<RozegranaGra> rozegraneGry = Repository.GetAllRozegranaGra();
            bool idIstnieje = false;

            foreach (var rozegranaGra in rozegraneGry)
            {
                if (rozegranaGra.IdRozegranejGry.Equals(idRozegranejGry))
                    idIstnieje = true;
            }

            if (idIstnieje == false)
            {
                Repository.AddRozegranaGra(new RozegranaGra(idRozegranejGry, gra, czasRozpoczeciaGry, czasTrwaniaGry, oplataWejsciowa, minimalnyDepozyt));
            }
            else
            {
                throw new ArgumentException("Rozegrana gra o podanym ID już istnieje.");
            }
        }

        public void AddZdarzenie(Gracz uczestnikGry, RozegranaGra ukonczonaGra, DateTime czasRozpoczeciaGry, TimeSpan czasTrwaniaGry, double wygrana)
        {
            bool graczIstnieje = Repository.GetAllGracz().Contains(uczestnikGry);
            bool rozegranaGraIstnieje = Repository.GetAllRozegranaGra().Contains(ukonczonaGra);

            if (graczIstnieje && rozegranaGraIstnieje)
            {
                Repository.AddZdarzenie(new Zdarzenie(uczestnikGry, ukonczonaGra, czasRozpoczeciaGry, czasTrwaniaGry, wygrana));
            }
            else
            {
                throw new ArgumentException("Podany gracz lub rozegrana gra nie istnieją.");
            }
        }

        // Delete
        public void DeleteGra(int idGry)
        {
            IEnumerable<Gra> gry = Repository.GetAllGraIEnumerable();
            bool graIstnieje = false;

            foreach (var gra in gry)
            {
                if (gra.IdGry.Equals(idGry))
                    graIstnieje = true;
            }

            if (graIstnieje)
            {
                Repository.DeleteGra(idGry);
            }
            else
            {
                throw new ArgumentException("Gra o podanym ID nie istnieje.");
            }
        }

        // Update
        public void UpdateInformacjeOGrze(int idGry, string noweInformacje)
        {
            IEnumerable<Gra> gry = Repository.GetAllGraIEnumerable();
            bool graIstnieje = false;

            foreach (var gra in gry)
            {
                if (gra.IdGry.Equals(idGry))
                    graIstnieje = true;
            }

            if (graIstnieje)
            {
                Gra graU = Repository.GetGra(idGry);
                graU.InformacjeOGrze = noweInformacje;
                Repository.UpdateGra(graU);
            }
            else
            {
                throw new ArgumentException("Gra o podanym ID nie istnieje.");
            }
        }

        public void UpdateNazwiskoGracza(int idGracza, string noweNazwisko)
        {
            IEnumerable<Gracz> gracze = Repository.GetAllGracz();
            bool graczIstnieje = false;

            foreach (var gracz in gracze)
            {
                if (gracz.IdGracza.Equals(idGracza))
                    graczIstnieje = true;
            }

            if (graczIstnieje)
            {
                Gracz graczU = Repository.GetGracz(idGracza);
                graczU.Nazwisko = noweNazwisko;
                Repository.UpdateGracz(idGracza, graczU);
            }
            else
            {
                throw new ArgumentException("Gracz o podanym ID nie istnieje.");
            }
        }

        // Filtration
        public string PrintAllRozegranaGraOfGracz(int idGracza)
        {
            string result = "";
            IEnumerable<Zdarzenie> zdarzenia = Repository.GetAllZdarzenie();

            if(zdarzenia.Count() != 0)
            {
                foreach(Zdarzenie zdarzenie in zdarzenia)
                {
                    if (zdarzenie.UczestnikGry.IdGracza == idGracza)
                    {
                        result = string.Concat(result, zdarzenie.UkonczonaGra.ToString(), "\n");
                    }
                }

                if (result != "")
                {
                    return result;
                }
                else
                {
                    throw new Exception("Podany gracz nie rozegrał żadnych gier.");
                }
            }
            else
            {
                throw new Exception("Lista zdarzeń jest pusta.");
            }
        }

        public string PrintAllGraczOfRozegranaGra(int idRozegranejGry)
        {
            string result = "";
            IEnumerable<Zdarzenie> zdarzenia = Repository.GetAllZdarzenie();

            if (zdarzenia.Count() != 0)
            {
                foreach (Zdarzenie zdarzenie in zdarzenia)
                {
                    if (zdarzenie.UkonczonaGra.IdRozegranejGry == idRozegranejGry)
                    {
                        result = string.Concat(result, zdarzenie.UczestnikGry.ToString(), "\n");
                    }
                }

                if (result != "")
                {
                    return result;
                }
                else
                {
                    throw new Exception("Dla podanej gry nie ma zarejestrowanych graczy.");
                }
            }
            else
            {
                throw new Exception("Lista zdarzeń jest pusta.");
            }
        }

         // Print all
        public string PrintAllGra()
        {
            string result = "";
            IEnumerable<Gra> gry = Repository.GetAllGraIEnumerable();

            if (gry.Count() != 0)
            {
                foreach (Gra gra in gry)
                {
                    result = string.Concat(result, gra.ToString(), "\n");
                }

                return result;
            }
            else
            {
                throw new Exception("Lista gier jest pusta.");
            }
        }

        public string PrintAllGracz()
        {
            string result = "";
            IEnumerable<Gracz> gracze = Repository.GetAllGracz();

            if (gracze.Count() != 0) {
                foreach (Gracz gracz in gracze)
                {
                    result = string.Concat(result, gracz.ToString(), "\n");
                }

                return result;
            }
            else
            {
                throw new Exception("Lista graczy jest pusta.");
            }
        }

        public string PrintAllRozegranaGra()
        {
            string result = "";
            IEnumerable<RozegranaGra> rozegraneGry = Repository.GetAllRozegranaGra();

            if (rozegraneGry.Count() != 0)
            {
                foreach (RozegranaGra rozegranaGra in rozegraneGry)
                {
                    result = string.Concat(result, rozegranaGra.ToString(), "\n");
                }
                return result;
            }
            else
            {
                throw new Exception("Lista rozegranych gier jest pusta.");
            }
        }

        public string PrintAllZdarzenie()
        {
            string result = "";
            IEnumerable<Zdarzenie> zdarzenia = Repository.GetAllZdarzenie();

            if (zdarzenia.Count() != 0)
            {
                foreach (Zdarzenie zdarzenie in zdarzenia)
                {
                    result = string.Concat(result, zdarzenie.ToString(), "\n");
                }
                return result;
            }
            else
            {
                throw new Exception("Lista zdarzeń jest pusta.");
            }
        }
    }
}