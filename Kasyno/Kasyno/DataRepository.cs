using System.Collections.Generic;

namespace Kasyno
{
    public class DataRepository : IDataRepository // DataRepository
    {
        private DataContext Context;

        public DataRepository(IWypelnianieDanymi wstrzykiwanieStalych)
        {
            Context = new DataContext();
            wstrzykiwanieStalych.WypelnijDanymi(ref Context);
        }

        // Add
        public void AddGracz(Gracz gracz)
        {
            Context.ListaGraczy.Add(gracz);
        }

        public void AddGra(Gra gra)
        {
            Context.ListaGier.Add(gra.IdGry, gra);
        }

        public void AddRozegranaGra(RozegranaGra rozegranaGra)
        {
            Context.ListaRozegranychGier.Add(rozegranaGra);
        }

        public void AddZdarzenie(Zdarzenie zdarzenie)
        {
            Context.ListaZdarzen.Add(zdarzenie);
        }

        // Delete
        public void DeleteGra(int id)
        {
            Context.ListaGier.Remove(id);
        }

        public void DeleteGracz(int id)
        {
            Context.ListaGraczy.RemoveAt(id);
        }

        public void DeleteRozegranaGra(int id)
        {
            Context.ListaRozegranychGier.RemoveAt(id);
        }

        public void DeleteZdarzenie(int id)
        {
            Context.ListaZdarzen.RemoveAt(id);
        }

        // Get all
        public IEnumerable<KeyValuePair<int, Gra>> GetAllGra()
        {
            return Context.ListaGier;
        }

        public IEnumerable<Gra> GetAllGraIEnumerable()
        {
            return Context.ListaGier.Values;
        }

        public IEnumerable<Gracz> GetAllGracz()
        {
            return Context.ListaGraczy;
        }

        public IEnumerable<RozegranaGra> GetAllRozegranaGra()
        {
            return Context.ListaRozegranychGier;
        }

        public IEnumerable<Zdarzenie> GetAllZdarzenie()
        {
            return Context.ListaZdarzen;
        }

        // Get
        public Gra GetGra(int id)
        {
            return Context.ListaGier[id];
        }

        public Gracz GetGracz(int id)
        {
            return Context.ListaGraczy[id];
        }

        public RozegranaGra GetRozegranaGra(int id)
        {
            return Context.ListaRozegranychGier[id];
        }

        public Zdarzenie GetZdarzenie(int id)
        {
            return Context.ListaZdarzen[id];
        }

        // Update
        public void UpdateGra(Gra gra)
        {
            Context.ListaGier[gra.IdGry] = gra;
        }

        public void UpdateGracz(int id, Gracz gracz)
        {
            Context.ListaGraczy[id] = gracz;
        }

        public void UpdateRozegranaGra(int id, RozegranaGra rozegranaGra)
        {
            Context.ListaRozegranychGier[id] = rozegranaGra;
        }

        public void UpdateZdarzenie(int id, Zdarzenie zdarzenie)
        {
            Context.ListaZdarzen[id] = zdarzenie;
        }
    }
}