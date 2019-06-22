using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kasyno;
using System.Collections.Generic;
using System.Linq;
using WypelnianieDanymiTestowymi;

namespace UnitTestKasyno
{
    [TestClass]
    public class DataRepositoryTest // DataRepository test
    {
        IDataRepository testDataRepository = new DataRepository(new WypelnianieStalymi());

        // Add test
        [TestMethod]
        public void AddGraczTest()
        {
            Gracz gracz1 = new Gracz(4, "Stefan", "Ząbek", new DateTime(1983, 2, 4));
            testDataRepository.AddGracz(gracz1);
            Gracz tester = testDataRepository.GetGracz(4);
            Assert.AreEqual(gracz1, tester);
        }

        [TestMethod]
        public void AddGraTest()
        {
            Gra gra1 = new Gra(4, "Bierki", "Gra polega na wyciąganiu bierek.");
            testDataRepository.AddGra(gra1);
            Gra tester = testDataRepository.GetGra(4);
            Assert.AreEqual(gra1, tester);
        }

        [TestMethod]
        public void AddRozegranaGraTest()
        {
            RozegranaGra rozegranaGra1 = new RozegranaGra(4, testDataRepository.GetGra(0), new DateTime(2019, 1, 3, 20, 1, 1), new TimeSpan(1, 1, 2), 200.00, 20.00);
            testDataRepository.AddRozegranaGra(rozegranaGra1);
            RozegranaGra tester = testDataRepository.GetRozegranaGra(4);
            Assert.AreEqual(rozegranaGra1, tester);
        }

        [TestMethod]
        public void AddZdarzenieTest()
        {
            Zdarzenie zdarzenie1 = new Zdarzenie(testDataRepository.GetGracz(0), testDataRepository.GetRozegranaGra(0), new DateTime(2019, 2, 3, 10, 3, 44), new TimeSpan(0, 30, 1), 210.00);
            testDataRepository.AddZdarzenie(zdarzenie1);
            Zdarzenie tester = testDataRepository.GetZdarzenie(5);
            Assert.AreEqual(zdarzenie1, tester);
        }

        // Delete test
        [TestMethod]
        public void DeleteGraTest()
        {
            IEnumerable<KeyValuePair<int, Gra>> gry = testDataRepository.GetAllGra();
            int iloscPrzed = gry.Count();
            testDataRepository.DeleteGra(3);
            gry = testDataRepository.GetAllGra();
            int iloscPo = gry.Count();
            Assert.AreEqual(iloscPrzed - 1, iloscPo);
        }

        [TestMethod]
        public void DeleteGraczTest()
        {
            int iloscPrzed = testDataRepository.GetAllGracz().Count();
            testDataRepository.DeleteGracz(1);
            int iloscPo = testDataRepository.GetAllGracz().Count();
            Assert.AreEqual(iloscPrzed - 1, iloscPo);
        }

        [TestMethod]
        public void DeleteRozegranaGraTest()
        {
            int iloscPrzed = testDataRepository.GetAllRozegranaGra().Count();
            testDataRepository.DeleteRozegranaGra(1);
            int iloscPo = testDataRepository.GetAllRozegranaGra().Count();
            Assert.AreEqual(iloscPrzed - 1, iloscPo);
        }

        [TestMethod]
        public void DeleteZdarzenieTest()
        {
            int iloscPrzed = testDataRepository.GetAllZdarzenie().Count();
            testDataRepository.DeleteZdarzenie(1);
            int iloscPo = testDataRepository.GetAllZdarzenie().Count();
            Assert.AreEqual(iloscPrzed - 1, iloscPo);
        }

        // Get all
        [TestMethod]
        public void GetAllGraTest()
        {
            IEnumerable<KeyValuePair<int, Gra>> gry = testDataRepository.GetAllGra();
            Assert.AreEqual(4, gry.Count());
        }

        [TestMethod]
        public void GetAllGraIEnumerableTest()
        {
            IEnumerable<Gra> gry = testDataRepository.GetAllGraIEnumerable();
            Assert.AreEqual(4, gry.Count());
        }

        [TestMethod]
        public void GetAllGraczTest()
        {
            IEnumerable<Gracz> gracze = testDataRepository.GetAllGracz();
            Gracz gracz1 = new Gracz(2, "Kamil", "Bednarek", new DateTime(1983, 03, 03));
            Assert.AreEqual(gracz1.Imie, gracze.ElementAt(2).Imie);
        }

        [TestMethod]
        public void GetAllRozegranaGraTest()
        {
            IEnumerable<RozegranaGra> rozegraneGry = testDataRepository.GetAllRozegranaGra();
            Gra gra3 = new Gra(2, "Bakarat", "Popularna gra, rozgrywana między bankierem (stałym lub zmiennym – którego wybiera się spośród graczy) i kolejno z każdym z graczy. O wyniku rozgrywki decyduje liczba zdobytych punktów w 2 lub 3 kartach, zliczanych według precyzyjnie określonych reguł.");
            RozegranaGra rozegranaGra1 = new RozegranaGra(2, gra3, new DateTime(2019, 1, 3, 20, 35, 30), new TimeSpan(0, 56, 44), 70.00, 10.00);
            Assert.AreEqual(rozegranaGra1.MinimalnyDepozyt, rozegraneGry.ElementAt(2).MinimalnyDepozyt);
        }

        [TestMethod]
        public void GetAllZdarzenieTest()
        {
            IEnumerable<Zdarzenie> zdarzenia = testDataRepository.GetAllZdarzenie();
            Gracz gracz = new Gracz(0, "Jan", "Kowalski", new DateTime(1981, 1, 1));
            Gra gra = new Gra(0, "Ruletka", "Pseudolosowa gra, grana w większości kasyn. Są dwa systemy ruletki: europejski i amerykański. Suma wszystkich liczb w ruletce daje 666, stąd określenie 'szatańska gra'.");
            RozegranaGra rozegranaGra = new RozegranaGra(0, gra, new DateTime(2019, 1, 1, 20, 10, 15), new TimeSpan(0, 31, 35), 100.00, 10.00);
            Zdarzenie zdarzenie = new Zdarzenie(gracz, rozegranaGra, new DateTime(2019, 1, 1, 20, 10, 15), new TimeSpan(0, 31, 35), 350.00);
            Assert.AreEqual(zdarzenie.Wygrana, zdarzenia.ElementAt(0).Wygrana);
        }

        // Get
        [TestMethod]
        public void GetGraTest()
        {
            Gra gra1 = testDataRepository.GetGra(1);
            Assert.AreEqual("Poker", gra1.NazwaGry);
        }

        [TestMethod]
        public void GetGraczTest()
        {
            Gracz gracz1 = testDataRepository.GetGracz(0);
            Assert.AreEqual("Jan", gracz1.Imie);
        }

        [TestMethod]
        public void GetRozegranaGraTest()
        {
            RozegranaGra rozegranaGra1 = testDataRepository.GetRozegranaGra(1);
            Assert.AreEqual(new DateTime(2019, 1, 2, 21, 11, 54), rozegranaGra1.CzasRozpoczeciaGry);
        }

        [TestMethod]
        public void GetZdarzenieTest()
        {
            Zdarzenie zdarzenie1 = testDataRepository.GetZdarzenie(0);
            Assert.AreEqual("Jan", zdarzenie1.UczestnikGry.Imie);
        }

        // Update
        [TestMethod]
        public void UpdateGraTest()
        {
            Gra gra1 = new Gra(4, "Tysiąc", "Gra karciana");
            testDataRepository.UpdateGra(gra1);
            Gra tester = testDataRepository.GetGra(4);
            Assert.AreEqual(gra1, tester);
        }

        [TestMethod]
        public void UpdateGraczTest()
        {
            Gracz gracz1 = new Gracz(5, "Magda", "Gesler", new DateTime(1950, 4, 3));
            testDataRepository.UpdateGracz(1, gracz1);
            Gracz tester = testDataRepository.GetGracz(1);
            Assert.AreEqual(gracz1, tester);
        }

        [TestMethod]
        public void UpdateRozegranaGraTest()
        {
            RozegranaGra rozegranaGra1 = new RozegranaGra(4, testDataRepository.GetGra(0), new DateTime(2019, 1, 1, 20, 1, 1), new TimeSpan(0, 50, 1), 100.00, 15.00);
            testDataRepository.UpdateRozegranaGra(0, rozegranaGra1);
            RozegranaGra tester = testDataRepository.GetRozegranaGra(0);
            Assert.AreEqual(rozegranaGra1, tester);
        }

        [TestMethod]
        public void UpdateZdarzenieTest()
        {
            Zdarzenie zdarzenie1 = new Zdarzenie(testDataRepository.GetGracz(0), testDataRepository.GetRozegranaGra(0), new DateTime(2019, 1, 1, 20, 3, 4), new TimeSpan(1, 2, 15), 100.00);
            testDataRepository.UpdateZdarzenie(1, zdarzenie1);
            Zdarzenie tester = testDataRepository.GetZdarzenie(1);
            Assert.AreEqual(tester, zdarzenie1);
        }
    }
}