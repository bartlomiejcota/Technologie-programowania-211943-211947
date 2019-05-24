using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarstwaUslug;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestKasyno
{
    [TestClass]
    public class DataRepositoryTest // DataRepository test
    {
        [TestInitialize]
        public void TestInitialize()
        {
            DataRepository.DataContext = new DataBaseDataContext();
            DataRepository.WypelnijDanymi(10, 10, 10, 10);
        }

        // Create test
        [TestMethod]
        public void CreateGraczTest()
        {
            int iloscGraczyPrzed = DataRepository.ReadAllGracz().Count();

            Gracz gracz = new Gracz()
            {
                IdGracza = iloscGraczyPrzed,
                Imie = string.Concat("Stefan", iloscGraczyPrzed),
                Nazwisko = "Ząbek",
                DataUrodzin = new DateTime(1983, 2, 4)
            };

            DataRepository.CreateGracz(gracz);

            int iloscGraczyPo = DataRepository.ReadAllGracz().Count();

            Assert.AreEqual(iloscGraczyPrzed + 1, iloscGraczyPo);
        }

        [TestMethod]
        public void CreateGraTest()
        {
            int iloscGierPrzed = DataRepository.ReadAllGra().Count();

            Gra gra = new Gra()
            {
                IdGry = iloscGierPrzed,
                NazwaGry = string.Concat("Super gra", iloscGierPrzed),
                InformacjeOGrze = string.Concat("Opis super gry", iloscGierPrzed)
            };

            DataRepository.CreateGra(gra);

            int iloscGierPo = DataRepository.ReadAllGra().Count();

            Assert.AreEqual(iloscGierPrzed + 1, iloscGierPo);
        }

        [TestMethod]
        public void CreateRozegranaGraTest()
        {
            int iloscRozegranychGierPrzed = DataRepository.ReadAllRozegranaGra().Count();

            RozegranaGra rozegranaGra = new RozegranaGra()
            {
                IdRozegranejGry = iloscRozegranychGierPrzed,
                Gra = iloscRozegranychGierPrzed % DataRepository.ReadAllGra().Count(),
                CzasRozpoczeciaGry = new DateTime(1950 + iloscRozegranychGierPrzed % 50, iloscRozegranychGierPrzed % 11 + 1, iloscRozegranychGierPrzed % 28 + 1),
                CzasTrwaniaGry = new TimeSpan(iloscRozegranychGierPrzed % 24, iloscRozegranychGierPrzed % 60, iloscRozegranychGierPrzed % 59 +1),
                OplataWejsciowa = (iloscRozegranychGierPrzed % 5) * 5,
                MinimalnyDepozyt = (iloscRozegranychGierPrzed % 6) * 6
            };

            DataRepository.CreateRozegranaGra(rozegranaGra);

            int iloscRozegranychGierPo = DataRepository.ReadAllRozegranaGra().Count();

            Assert.AreEqual(iloscRozegranychGierPrzed + 1, iloscRozegranychGierPo);
        }

        [TestMethod]
        public void CreateZdarzenieTest()
        {
            int iloscZdarzenPrzed = DataRepository.ReadAllZdarzenie().Count();

            Zdarzenie zdarzenie = new Zdarzenie()
            {
                IdZdarzenia = iloscZdarzenPrzed,
                UczestnikGry = iloscZdarzenPrzed % DataRepository.ReadAllGracz().Count(),
                UkonczonaGra = iloscZdarzenPrzed % DataRepository.ReadAllRozegranaGra().Count(),
                Wygrana = (iloscZdarzenPrzed % 10) * 10
            };

            DataRepository.CreateZdarzenie(zdarzenie);

            int iloscZdarzenPo = DataRepository.ReadAllZdarzenie().Count();

            Assert.AreEqual(iloscZdarzenPrzed + 1, iloscZdarzenPo);
        }

        // Delete test
        [TestMethod]
        public void DeleteGraTest()
        {
            int iloscGierPrzed = DataRepository.ReadAllGra().Count();

            Gra gra = DataRepository.ReadAllGra().Last();

            DataRepository.DeleteGra(gra.IdGry);

            int iloscGierPo = DataRepository.ReadAllGra().Count();

            Assert.AreEqual(iloscGierPrzed - 1, iloscGierPo);
        }

        [TestMethod]
        public void DeleteGraczTest()
        {
            int iloscGraczyPrzed = DataRepository.ReadAllGracz().Count();

            Gracz gracz = DataRepository.ReadAllGracz().Last();

            DataRepository.DeleteGracz(gracz.IdGracza);

            int iloscGraczyPo = DataRepository.ReadAllGracz().Count();

            Assert.AreEqual(iloscGraczyPrzed - 1, iloscGraczyPo);
        }

        [TestMethod]
        public void DeleteRozegranaGraTest()
        {
            int iloscRozegranychGierPrzed = DataRepository.ReadAllRozegranaGra().Count();

            RozegranaGra rozegranaGra = DataRepository.ReadAllRozegranaGra().Last();

            DataRepository.DeleteRozegranaGra(rozegranaGra.IdRozegranejGry);

            int iloscozegranychGierPo = DataRepository.ReadAllRozegranaGra().Count();

            Assert.AreEqual(iloscRozegranychGierPrzed - 1, iloscozegranychGierPo);
        }

        [TestMethod]
        public void DeleteZdarzenieTest()
        {
            int iloscZdarzenPrzed = DataRepository.ReadAllZdarzenie().Count();

            Zdarzenie zdarzenie = DataRepository.ReadAllZdarzenie().Last();

            DataRepository.DeleteZdarzenie(zdarzenie.IdZdarzenia);

            int iloscZdarzenPo = DataRepository.ReadAllZdarzenie().Count();

            Assert.AreEqual(iloscZdarzenPrzed - 1, iloscZdarzenPo);
        }

        // Read all
        [TestMethod]
        public void ReadAllGraTest()
        {
            IEnumerable<Gra> gry = DataRepository.ReadAllGra();
        }

        [TestMethod]
        public void ReadAllGraczTest()
        {
            IEnumerable<Gracz> gracze = DataRepository.ReadAllGracz();
        }

        [TestMethod]
        public void ReadAllRozegranaGraTest()
        {
            IEnumerable<RozegranaGra> rozegraneGry = DataRepository.ReadAllRozegranaGra();
        }

        [TestMethod]
        public void ReadAllZdarzenieTest()
        {
            IEnumerable<Zdarzenie> zdarzenia = DataRepository.ReadAllZdarzenie();
        }

        // Get
        [TestMethod]
        public void ReadGraTest()
        {
            Gra gra = DataRepository.ReadGra(0);
        }

        [TestMethod]
        public void ReadGraczTest()
        {
            Gracz gracz = DataRepository.ReadGracz(0);
        }

        [TestMethod]
        public void ReadRozegranaGraTest()
        {
            RozegranaGra rozegranaGra = DataRepository.ReadRozegranaGra(0);
        }

        [TestMethod]
        public void ReadZdarzenieTest()
        {
            Zdarzenie zdarzenie = DataRepository.ReadZdarzenie(0);
        }

        // Update
        [TestMethod]
        public void UpdateGraTest()
        {
            Gra gra = DataRepository.ReadGra(0);
            gra.NazwaGry = "Nowa nazwa";

            DataRepository.UpdateGra(gra);

            Gra tester = DataRepository.ReadGra(0);
            Assert.AreEqual("Nowa nazwa", tester.NazwaGry);
        }

        [TestMethod]
        public void UpdateGraczTest()
        {
            Gracz gracz = DataRepository.ReadGracz(0);
            gracz.Nazwisko = "nowenazwisko";

            DataRepository.UpdateGracz(gracz);

            Gracz tester = DataRepository.ReadGracz(0);
            Assert.AreEqual("nowenazwisko", tester.Nazwisko);
        }

        [TestMethod]
        public void UpdateRozegranaGraTest()
        {
            RozegranaGra rozegranaGra = DataRepository.ReadRozegranaGra(0);
            rozegranaGra.MinimalnyDepozyt = 666.00;

            DataRepository.UpdateRozegranaGra(rozegranaGra);

            RozegranaGra tester = DataRepository.ReadRozegranaGra(0);
            Assert.AreEqual(666.00, tester.MinimalnyDepozyt);
        }

        [TestMethod]
        public void UpdateZdarzenieTest()
        {
            Zdarzenie zdarzenie = DataRepository.ReadZdarzenie(0);
            zdarzenie.UczestnikGry = 1;

            DataRepository.UpdateZdarzenie(zdarzenie);

            Zdarzenie tester = DataRepository.ReadZdarzenie(0);
            Assert.AreEqual(1, tester.UczestnikGry);
        }
    }
}