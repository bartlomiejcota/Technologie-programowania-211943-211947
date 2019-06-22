using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kasyno;
using WypelnianieDanymiTestowymi;
using System;
using System.Linq;

namespace UnitTestKasyno
{
    [TestClass]
    public class DataServiceTest // DataService test
    {
        IDataRepository testDataRepository = new DataRepository(new WypelnianieStalymi());

        // Add test
        [TestMethod]
        public void AddGraczTest()
        {
            IDataService testDataService = new DataService(testDataRepository);

            testDataService.AddGracz(4, "Elvis", "Presley", new DateTime(1950, 2, 5));
            Gracz tester = testDataRepository.GetGracz(4);
            Assert.AreEqual("Elvis", tester.Imie);
        }

        [TestMethod]
        public void AddGraTestTest()
        {
            IDataService testDataService = new DataService(testDataRepository);

            testDataService.AddGra(4, "Bierki", "Gra polega na wyciąganiu bierek.");
            Gra tester = testDataRepository.GetGra(4);
            Assert.AreEqual("Bierki", tester.NazwaGry);
        }

        [TestMethod]
        public void AddRozegranaGraTestTest()
        {
            IDataService testDataService = new DataService(testDataRepository);

            testDataService.AddRozegranaGra(4, testDataRepository.GetGra(0), new DateTime(2019, 1, 3, 20, 1, 1), new TimeSpan(1, 1, 2), 200.00, 20.00);
            RozegranaGra tester = testDataRepository.GetRozegranaGra(4);
            Assert.AreEqual(200.00, tester.OplataWejsciowa);
        }

        [TestMethod]
        public void AddZdarzenieTestTest()
        {
            IDataService testDataService = new DataService(testDataRepository);

            testDataService.AddZdarzenie(testDataRepository.GetGracz(0), testDataRepository.GetRozegranaGra(0), new DateTime(2019, 2, 3, 10, 3, 44), new TimeSpan(0, 30, 1), 210.00);
            Zdarzenie tester = testDataRepository.GetZdarzenie(5);
            Assert.AreEqual(new DateTime(2019, 2, 3, 10, 3, 44), tester.CzasRozpoczeciaGry);
        }

        // Delete test
        [TestMethod]
        public void DeleteGraTest()
        {
            IDataService testDataService = new DataService(testDataRepository);
            int iloscPrzed = testDataRepository.GetAllGra().Count();
            testDataService.DeleteGra(1);
            int iloscPo = testDataRepository.GetAllGra().Count();
            Assert.AreEqual(iloscPrzed - 1, iloscPo);
        }

        // Update test
        [TestMethod]
        public void UpdateInformacjeOGrzeTest()
        {
            IDataService testDataService = new DataService(testDataRepository);
            testDataService.UpdateInformacjeOGrze(1, "Gra karciana");
            Assert.AreEqual("Gra karciana", testDataRepository.GetGra(1).InformacjeOGrze);
        }

        [TestMethod]
        public void UpdateNazwiskoGraczaTest()
        {
            IDataService testDataService = new DataService(testDataRepository);
            testDataService.UpdateNazwiskoGracza(1, "Ibisz");
            Assert.AreEqual("Ibisz", testDataRepository.GetGracz(1).Nazwisko);
        }

        // Filtration test
        [TestMethod]
        public void PrintAllRozegranaGraOfGraczTest()
        {
            IDataService testDataService = new DataService(testDataRepository);
            string result = "";

            RozegranaGra rozegranaGra1 = testDataRepository.GetRozegranaGra(1);
            RozegranaGra rozegranaGra2 = testDataRepository.GetRozegranaGra(0);

            result = string.Concat(result, rozegranaGra1.ToString(), "\n");
            result = string.Concat(result, rozegranaGra2.ToString(), "\n");

            Assert.AreEqual(result, testDataService.PrintAllRozegranaGraOfGracz(1));
        }

        [TestMethod]
        public void PrintAllGraczOfRozegranaGraTest()
        {
            IDataService testDataService = new DataService(testDataRepository);
            string result = "";

            Gracz gracz1 = testDataRepository.GetGracz(0);
            Gracz gracz2 = testDataRepository.GetGracz(1);

            result = string.Concat(result, gracz1.ToString(), "\n");
            result = string.Concat(result, gracz2.ToString(), "\n");

            Assert.AreEqual(result, testDataService.PrintAllGraczOfRozegranaGra(0));
        }

        // Print all test
        [TestMethod]
        public void PrintAllGraczTest()
        {
            IDataService testDataService = new DataService(testDataRepository);
            string result = "";

            Gracz gracz1 = testDataRepository.GetGracz(0);
            Gracz gracz2 = testDataRepository.GetGracz(1);
            Gracz gracz3 = testDataRepository.GetGracz(2);
            Gracz gracz4 = testDataRepository.GetGracz(3);

            result = string.Concat(result, gracz1.ToString(), "\n");
            result = string.Concat(result, gracz2.ToString(), "\n");
            result = string.Concat(result, gracz3.ToString(), "\n");
            result = string.Concat(result, gracz4.ToString(), "\n");

            Assert.AreEqual(result, testDataService.PrintAllGracz());
        }

        [TestMethod]
        public void PrintAllGraTest()
        {
            IDataService testDataService = new DataService(testDataRepository);
            string result = "";

            Gra gra1 = testDataRepository.GetGra(0);
            Gra gra2 = testDataRepository.GetGra(1);
            Gra gra3 = testDataRepository.GetGra(2);
            Gra gra4 = testDataRepository.GetGra(3);

            result = string.Concat(result, gra1.ToString(), "\n");
            result = string.Concat(result, gra2.ToString(), "\n");
            result = string.Concat(result, gra3.ToString(), "\n");
            result = string.Concat(result, gra4.ToString(), "\n");

            Assert.AreEqual(result, testDataService.PrintAllGra());
        }

        [TestMethod]
        public void PrintAllRozegranaGraTest()
        {
            IDataService testDataService = new DataService(testDataRepository);
            string result = "";

            RozegranaGra rozegranaGra1 = testDataRepository.GetRozegranaGra(0);
            RozegranaGra rozegranaGra2 = testDataRepository.GetRozegranaGra(1);
            RozegranaGra rozegranaGra3 = testDataRepository.GetRozegranaGra(2);
            RozegranaGra rozegranaGra4 = testDataRepository.GetRozegranaGra(3);

            result = string.Concat(result, rozegranaGra1.ToString(), "\n");
            result = string.Concat(result, rozegranaGra2.ToString(), "\n");
            result = string.Concat(result, rozegranaGra3.ToString(), "\n");
            result = string.Concat(result, rozegranaGra4.ToString(), "\n");

            Assert.AreEqual(result, testDataService.PrintAllRozegranaGra());
        }

        [TestMethod]
        public void PrintAllZdarzenieTest()
        {
            IDataService testDataService = new DataService(testDataRepository);
            string result = "";

            Zdarzenie zdarzenie1 = testDataRepository.GetZdarzenie(0);
            Zdarzenie zdarzenie2 = testDataRepository.GetZdarzenie(1);
            Zdarzenie zdarzenie3 = testDataRepository.GetZdarzenie(2);
            Zdarzenie zdarzenie4 = testDataRepository.GetZdarzenie(3);
            Zdarzenie zdarzenie5 = testDataRepository.GetZdarzenie(4);

            result = string.Concat(result, zdarzenie1.ToString(), "\n");
            result = string.Concat(result, zdarzenie2.ToString(), "\n");
            result = string.Concat(result, zdarzenie3.ToString(), "\n");
            result = string.Concat(result, zdarzenie4.ToString(), "\n");
            result = string.Concat(result, zdarzenie5.ToString(), "\n");

            Assert.AreEqual(result, testDataService.PrintAllZdarzenie());
        }
    }
}