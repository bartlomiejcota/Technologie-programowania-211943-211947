using System;

namespace Kasyno
{
    public interface IDataService // interfejs DataService
    {
        // Add
        void AddGracz(int idGracza, string imie, string nazwisko, DateTime dataUrodzin);
        void AddGra(int idGry, string nazwaGry, string informacjeOGrze);
        void AddRozegranaGra(int idRozegranejGry, Gra gra, DateTime czasRozpoczeciaGry, TimeSpan czasTrwaniaGry, double oplataWejsciowa, double minimalnyDepozyt);
        void AddZdarzenie(Gracz uczestnikGry, RozegranaGra ukonczonaGra, DateTime czasRozpoczeciaGry, TimeSpan czasTrwaniaGry, double wygrana);

        // Delete
        void DeleteGra(int idGry);

        // Update
        void UpdateInformacjeOGrze(int idGry, string noweInformacje);
        void UpdateNazwiskoGracza(int idGracza, string noweNazwisko);

        // Filtration
        string PrintAllRozegranaGraOfGracz(int idGracza);
        string PrintAllGraczOfRozegranaGra(int idRozegranejGry);

        // Print all 
        string PrintAllGracz();
        string PrintAllGra();
        string PrintAllRozegranaGra();
        string PrintAllZdarzenie();
    }
}