using System.Collections.Generic;
using WarstwaUslug;
using WarstwaDanych;

namespace WarstwaPrezentacji.Model
{
    public class DataLayer
    {
        // Gra
        public IEnumerable<Gra> gryData
        {
            get
            {
                IEnumerable<Gra> gry = DataRepository.ReadAllGra();
                return gry;
            }
        }

        // Gracz
        public IEnumerable<Gracz> graczeData
        {
            get
            {
                IEnumerable<Gracz> gracze = DataRepository.ReadAllGracz();
                return gracze;
            }
        }

        // Rozegrana gra
        public IEnumerable<RozegranaGra> rozegraneGryData
        {
            get
            {
                IEnumerable<RozegranaGra> rozegraneGry = DataRepository.ReadAllRozegranaGra();
                return rozegraneGry;
            }
        }

        // Zdarzenie
        public IEnumerable<Zdarzenie> zdarzeniaData
        {
            get
            {
                IEnumerable<Zdarzenie> zdarzenia = DataRepository.ReadAllZdarzenie();
                return zdarzenia;
            }
        }
    }
}