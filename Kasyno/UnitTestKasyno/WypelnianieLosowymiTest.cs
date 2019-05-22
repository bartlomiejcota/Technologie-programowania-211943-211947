using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Kasyno;
using WypelnianieDanymiTestowymi;

namespace UnitTestKasyno
{
    [TestClass]
    public class WypelnianieLosowymiTest
    {
        // Wypełnianie małym wolumenem danych losowych
        [TestMethod]
        public void WypelnianieLosowymiMalyWolumenTest()
        {
            IDataRepository dataRepository = new DataRepository(new WypelnianieLosowymi(100, 90, 80, 70));
            IDataService dataService = new DataService(dataRepository);

            Assert.AreEqual(100, dataRepository.GetAllGracz().Count());
            Assert.AreEqual(90, dataRepository.GetAllGra().Count());
            Assert.AreEqual(80, dataRepository.GetAllRozegranaGra().Count());
            Assert.AreEqual(70, dataRepository.GetAllZdarzenie().Count());

            dataService.PrintAllGracz();
            dataService.PrintAllGra();
            dataService.PrintAllRozegranaGra();
            dataService.PrintAllZdarzenie();
        }

        // Wypełnianie średnim wolumenem danych losowych
        [TestMethod]
        public void WypelnianieLosowymiSredniWolumenTest()
        {
            IDataRepository dataRepository = new DataRepository(new WypelnianieLosowymi(1000, 900, 800, 700));
            IDataService dataService = new DataService(dataRepository);

            Assert.AreEqual(1000, dataRepository.GetAllGracz().Count());
            Assert.AreEqual(900, dataRepository.GetAllGra().Count());
            Assert.AreEqual(800, dataRepository.GetAllRozegranaGra().Count());
            Assert.AreEqual(700, dataRepository.GetAllZdarzenie().Count());

            dataService.PrintAllGracz();
            dataService.PrintAllGra();
            dataService.PrintAllRozegranaGra();
            dataService.PrintAllZdarzenie();
        }

        //Wypełnianie dużym wolumenem danych losowych
        [TestMethod]
        public void WypelnianieLosowymiDuzyWolumenTest()
        {
            IDataRepository dataRepository = new DataRepository(new WypelnianieLosowymi(10000, 9000, 8000, 7000));
            IDataService dataService = new DataService(dataRepository);

            Assert.AreEqual(10000, dataRepository.GetAllGracz().Count());
            Assert.AreEqual(9000, dataRepository.GetAllGra().Count());
            Assert.AreEqual(8000, dataRepository.GetAllRozegranaGra().Count());
            Assert.AreEqual(7000, dataRepository.GetAllZdarzenie().Count());

            dataService.PrintAllGracz();
            dataService.PrintAllGra();
            dataService.PrintAllRozegranaGra();
            dataService.PrintAllZdarzenie();
        }
    }
}