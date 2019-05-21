using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

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

        private void ObslugaZmianWKolekcji(object sender, NotifyCollectionChangedEventArgs zdarzenie)
        {
            if (zdarzenie.Action == NotifyCollectionChangedAction.Add)
            {
                Console.Error.WriteLine("NotifyCollectionChangedAction.Add");
            }
            if (zdarzenie.Action == NotifyCollectionChangedAction.Remove)
            {
                Console.Error.WriteLine("NotifyCollectionChangedAction.Remove");
            }
            if (zdarzenie.Action == NotifyCollectionChangedAction.Replace)
            {
                Console.Error.WriteLine("NotifyCollectionChangedAction.Replace");
            }
            if (zdarzenie.Action == NotifyCollectionChangedAction.Move)
            {
                Console.Error.WriteLine("NotifyCollectionChangedAction.Move");
            }
        }
    }
}