using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kasyno
{
    public class DataContext // DataContext
    {
        public List<Gracz> ListaGraczy;
        public Dictionary<int, Gra> ListaGier;
        public ObservableCollection<RozegranaGra> ListaRozegranychGier;
        public ObservableCollection<Zdarzenie> ListaZdarzen;

        public DataContext()
        {
            ListaGraczy = new List<Gracz>();
            ListaGier = new Dictionary<int, Gra>();
            ListaRozegranychGier = new ObservableCollection<RozegranaGra>();
            ListaZdarzen = new ObservableCollection<Zdarzenie>();
        }
    }
}