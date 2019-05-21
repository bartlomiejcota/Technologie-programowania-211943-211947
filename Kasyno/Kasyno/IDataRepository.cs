using System.Collections.Generic;

namespace Kasyno
{
    public interface IDataRepository // interfejs DataRepository
    {
        // Add
        void AddGracz(Gracz gracz);
        void AddGra(Gra gra);
        void AddRozegranaGra(RozegranaGra rozegranaGra);
        void AddZdarzenie(Zdarzenie zdarzenie);

        // Get
        Gracz GetGracz(int id);
        Gra GetGra(int id);
        RozegranaGra GetRozegranaGra(int id);
        Zdarzenie GetZdarzenie(int id);

        // Get all
        IEnumerable<Gracz> GetAllGracz();
        IEnumerable<KeyValuePair<int, Gra>> GetAllGra();
        IEnumerable<Gra> GetAllGraIEnumerable();
        IEnumerable<RozegranaGra> GetAllRozegranaGra();
        IEnumerable<Zdarzenie> GetAllZdarzenie();

        // Update
        void UpdateGracz(int id, Gracz gracz);
        void UpdateGra(Gra gra);
        void UpdateRozegranaGra(int id, RozegranaGra rozegranaGra);
        void UpdateZdarzenie(int id, Zdarzenie zdarzenie);

        // Delete
        void DeleteGracz(int id);
        void DeleteGra(int id);
        void DeleteRozegranaGra(int id);
        void DeleteZdarzenie(int id);
    }
}