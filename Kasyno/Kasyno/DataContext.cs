using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Kasyno
{
    class DataContext // DataContext
    {
        public List<Gracz> ListaGraczy;
        public Dictionary<int, Gra> ListaGier;
        public ObservableCollection<RozegranaGra> ListaRozegranychGier;
        public ObservableCollection<Zdarzenie> ListaZdarzen;

        public DataContext(List<Gracz> listaGraczy, Dictionary<int, Gra> listaGier, ObservableCollection<RozegranaGra> listaRozegranychGier, ObservableCollection<Zdarzenie> listaZdarzen)
        {
            ListaGraczy = listaGraczy;
            ListaGier = listaGier;
            ListaRozegranychGier = listaRozegranychGier;
            ListaZdarzen = listaZdarzen;
        }
    }
}
