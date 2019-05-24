using System;
using System.Collections.Generic;
using System.Linq;

namespace WarstwaUslug
{
    class Class1
    {
        static void Main()
        {
            using (DataBaseDataContext dataBaseDataContext = new DataBaseDataContext())
            {
                Gracz gracz1 = new Gracz()
                {
                    IdGracza = 0,
                    Imie = "Jan",
                    Nazwisko = "Kowalski",
                    DataUrodzin = new DateTime(1908, 1, 2)
                };

                DataRepository.CreateGracz(gracz1);
               
                Gracz gracz2 = new Gracz()
                {
                    IdGracza = 1,
                    Imie = "Karol",
                    Nazwisko = "Nowak",
                    DataUrodzin = new DateTime(1908, 1, 2)
                };

                DataRepository.CreateGracz(gracz2);
            }
        }
    }
}