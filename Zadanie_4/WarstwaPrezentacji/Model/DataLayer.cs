using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarstwaUslug;

namespace WarstwaPrezentacji.Model
{
    public class DataLayer
    {
        public IEnumerable<Gra> gryData
        {
            get
            {
                IEnumerable<Gra> gry = DataRepository.ReadAllGra();
                return gry;
            }
        }   

        public Gra graData
        {
            get
            {
                Gra gra = DataRepository.ReadGra(0);
                return gra;
            }
        }
    }
}
