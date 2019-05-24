using System.Collections.Generic;
using System.Linq;

namespace WarstwaUslug
{
    public class DataRepository
    {
        private static DataBaseDataContext dataBaseDataContext = new DataBaseDataContext();

        public static DataBaseDataContext DataContext
        {
            get => dataBaseDataContext;
            set => dataBaseDataContext = value;
        }

        public static void CreateGracz(Gracz gracz)
        {
            dataBaseDataContext.Gracz.InsertOnSubmit(gracz);
            dataBaseDataContext.SubmitChanges();
        }

        public static IEnumerable<Gracz> GetAllGracz()
        {
            List<Gracz> gracze = (from Gracz in dataBaseDataContext.Gracz
                                  select Gracz).ToList();

            return gracze;
        }
    }
}