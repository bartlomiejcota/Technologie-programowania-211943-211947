using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kasyno;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestKasyno
{
    [TestClass]
    public class DataRepositoryTest
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
            Assert.AreEqual(4, gry.Count());
            testDataRepository.DeleteGra(3);
            gry = testDataRepository.GetAllGra();
            Assert.AreEqual(3, gry.Count());
        }

        [TestMethod]
        public void DeleteGraczTest()
        {
            Assert.AreEqual(4, testDataRepository.GetAllGracz().Count());
            Gracz tester = testDataRepository.GetGracz(3);
            testDataRepository.DeleteGracz(1);
            Assert.AreEqual(3, testDataRepository.GetAllGracz().Count());
            Assert.AreEqual(tester, testDataRepository.GetGracz(2));
        }

        [TestMethod]
        public void DeleteRozegranaGraTest()
        {
            Assert.AreEqual(4, testDataRepository.GetAllRozegranaGra().Count());
            RozegranaGra rozegranaGra1 = testDataRepository.GetRozegranaGra(2);
            testDataRepository.DeleteRozegranaGra(1);
            Assert.AreEqual(3, testDataRepository.GetAllRozegranaGra().Count());
            Assert.AreEqual(rozegranaGra1, testDataRepository.GetRozegranaGra(1));
        }

        [TestMethod]
        public void DeleteZdarzenieTest()
        {
            Assert.AreEqual(5, testDataRepository.GetAllZdarzenie().Count());
            Zdarzenie zdarzenie1 = testDataRepository.GetZdarzenie(2);
            testDataRepository.DeleteZdarzenie(1);
            Assert.AreEqual(4, testDataRepository.GetAllZdarzenie().Count());
            Assert.AreEqual(zdarzenie1, testDataRepository.GetZdarzenie(1));
        }

        // Get all
        [TestMethod]
        public void GetAllGraTest()
        {
            
        }

        [TestMethod]
        public void GetAllGraczTest()
        {
            IEnumerable<Gracz> gracze = testDataRepository.GetAllGracz();
            Assert.AreEqual(4, gracze.Count());
            Assert.AreEqual("Kamil", gracze.ElementAt(2).Imie);
            Assert.AreEqual("Bednarek", gracze.ElementAt(2).Nazwisko);
            Assert.AreEqual(new DateTime(1983, 3, 3), gracze.ElementAt(2).DataUrodzin);
        }

        [TestMethod]
        public void GetAllRozegranaGraTest()
        {
            IEnumerable<RozegranaGra> rozegraneGry = testDataRepository.GetAllRozegranaGra();
            Assert.AreEqual(4, rozegraneGry.Count());
            Assert.AreEqual(2, rozegraneGry.ElementAt(2).IdRozegranejGry);
            Assert.AreEqual(new DateTime(2019, 1, 3, 20, 35, 30), rozegraneGry.ElementAt(2).CzasRozpoczeciaGry);
            Assert.AreEqual(70.00, rozegraneGry.ElementAt(2).OplataWejsciowa);
        }

        [TestMethod]
        public void GetAllZdarzenieTest()
        {
            IEnumerable<Zdarzenie> zdarzenia = testDataRepository.GetAllZdarzenie();
            Assert.AreEqual(5, zdarzenia.Count());
            Assert.AreEqual("Jan", zdarzenia.ElementAt(0).UczestnikGry.Imie);
            Assert.AreEqual("Kowalski", zdarzenia.ElementAt(0).UczestnikGry.Nazwisko);
            Assert.AreEqual(new DateTime(2019, 1, 1, 20, 10, 15), zdarzenia.ElementAt(0).CzasRozpoczeciaGry);
            Assert.AreEqual(new TimeSpan(0, 31, 35), zdarzenia.ElementAt(0).CzasTrwaniaGry);
            Assert.AreEqual(350.00, zdarzenia.ElementAt(0).Wygrana);
        }

        // Get
        [TestMethod]
        public void GetGraTest()
        {
            Gra gra1 = testDataRepository.GetGra(1);
            Assert.AreEqual("Poker", gra1.NazwaGry);
            Assert.AreEqual("Gra karciana rozgrywana talią składającą się z 52 kart, której celem jest wygranie pieniędzy (lub żetonów w wersji sportowej) od pozostałych uczestników dzięki skompletowaniu najlepszego układu lub za pomocą tzw. blefu.", gra1.InformacjeOGrze);
        }

        [TestMethod]
        public void GetGraczTest()
        {
            Gracz gracz1 = testDataRepository.GetGracz(0);
            Assert.AreEqual("Jan", gracz1.Imie);
            Assert.AreEqual("Kowalski", gracz1.Nazwisko);
            Assert.AreEqual(new DateTime(1981, 1, 1), gracz1.DataUrodzin);
        }

        [TestMethod]
        public void GetRozegranaGraTest()
        {
            RozegranaGra rozegranaGra1 = testDataRepository.GetRozegranaGra(1);
            Assert.AreEqual(new DateTime(2019, 1, 2, 21, 11, 54), rozegranaGra1.CzasRozpoczeciaGry);
            Assert.AreEqual(new TimeSpan(0, 15, 33), rozegranaGra1.CzasTrwaniaGry);
            Assert.AreEqual(120.00, rozegranaGra1.OplataWejsciowa);
            Assert.AreEqual(15.00, rozegranaGra1.MinimalnyDepozyt);
        }

        [TestMethod]
        public void GetZdarzenieTset()
        {
            Zdarzenie zdarzenie1 = testDataRepository.GetZdarzenie(0);
            Assert.AreEqual(0, zdarzenie1.UczestnikGry.IdGracza);
            Assert.AreEqual("Jan", zdarzenie1.UczestnikGry.Imie);
            Assert.AreEqual("Kowalski", zdarzenie1.UczestnikGry.Nazwisko);
            Assert.AreEqual(0, zdarzenie1.UkonczonaGra.IdRozegranejGry);
            Assert.AreEqual(new DateTime(2019, 1, 1, 20, 10, 15), zdarzenie1.CzasRozpoczeciaGry);
            Assert.AreEqual(new TimeSpan(0, 31, 35), zdarzenie1.CzasTrwaniaGry);
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
