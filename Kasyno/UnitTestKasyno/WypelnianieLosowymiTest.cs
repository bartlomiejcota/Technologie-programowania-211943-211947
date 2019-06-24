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
            int ilosc = dataRepository.GetAllGracz().Count() + dataRepository.GetAllGra().Count() + dataRepository.GetAllRozegranaGra().Count() + dataRepository.GetAllZdarzenie().Count();

            Assert.AreEqual(340, ilosc);

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
            int ilosc = dataRepository.GetAllGracz().Count() + dataRepository.GetAllGra().Count() + dataRepository.GetAllRozegranaGra().Count() + dataRepository.GetAllZdarzenie().Count();

            Assert.AreEqual(3400, ilosc);

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
            int ilosc = dataRepository.GetAllGracz().Count() + dataRepository.GetAllGra().Count() + dataRepository.GetAllRozegranaGra().Count() + dataRepository.GetAllZdarzenie().Count();

            Assert.AreEqual(34000, ilosc);

            dataService.PrintAllGracz();
            dataService.PrintAllGra();
            dataService.PrintAllRozegranaGra();
            dataService.PrintAllZdarzenie();
        }
    }
}