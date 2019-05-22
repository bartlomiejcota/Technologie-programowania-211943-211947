using System;
using Kasyno;

namespace WypelnianieDanymiTestowymi
{
    public class WypelnianieStalymi : IWypelnianieDanymi // WypelnianieStalymi
    {
        public void WypelnijDanymi(ref DataContext context)
        {
            context.ListaGraczy.Add(new Gracz(0, "Jan", "Kowalski", new DateTime(1981, 1, 1)));
            context.ListaGraczy.Add(new Gracz(1, "Krzysztof", "Krawczyk", new DateTime(1982, 2, 2)));
            context.ListaGraczy.Add(new Gracz(2, "Kamil", "Bednarek", new DateTime(1983, 3, 3)));
            context.ListaGraczy.Add(new Gracz(3, "Jan", "Sobieski", new DateTime(1984, 4, 4)));

            Gra gra1 = new Gra(0, "Ruletka", "Pseudolosowa gra, grana w większości kasyn. Są dwa systemy ruletki: europejski i amerykański. Suma wszystkich liczb w ruletce daje 666, stąd określenie 'szatańska gra'.");
            Gra gra2 = new Gra(1, "Poker", "Gra karciana rozgrywana talią składającą się z 52 kart, której celem jest wygranie pieniędzy (lub żetonów w wersji sportowej) od pozostałych uczestników dzięki skompletowaniu najlepszego układu lub za pomocą tzw. blefu.");
            Gra gra3 = new Gra(2, "Bakarat", "Popularna gra, rozgrywana między bankierem (stałym lub zmiennym – którego wybiera się spośród graczy) i kolejno z każdym z graczy. O wyniku rozgrywki decyduje liczba zdobytych punktów w 2 lub 3 kartach, zliczanych według precyzyjnie określonych reguł.");
            Gra gra4 = new Gra(3, "Blackjack", "Blackjack – gra karciana, w której gracz stara się pokonać krupiera poprzez uzyskanie sumy jak najbliższej 21 punktów w kartach jednak nie przekraczając 21.");
            context.ListaGier.Add(gra1.IdGry, gra1);
            context.ListaGier.Add(gra2.IdGry, gra2);
            context.ListaGier.Add(gra3.IdGry, gra3);
            context.ListaGier.Add(gra4.IdGry, gra4);

            context.ListaRozegranychGier.Add(new RozegranaGra(0, gra1, new DateTime(2019, 1, 1, 20, 10, 15), new TimeSpan(0, 31, 35), 100.00, 10.00));
            context.ListaRozegranychGier.Add(new RozegranaGra(1, gra2, new DateTime(2019, 1, 2, 21, 11, 54), new TimeSpan(0, 15, 33), 120.00, 15.00));
            context.ListaRozegranychGier.Add(new RozegranaGra(2, gra3, new DateTime(2019, 1, 3, 20, 35, 30), new TimeSpan(0, 56, 44), 70.00, 10.00));
            context.ListaRozegranychGier.Add(new RozegranaGra(3, gra4, new DateTime(2019, 1, 4, 22, 40, 24), new TimeSpan(1, 1, 32), 50.00, 5.00));

            context.ListaZdarzen.Add(new Zdarzenie(context.ListaGraczy[0], context.ListaRozegranychGier[0], new DateTime(2019, 1, 1, 20, 10, 15), new TimeSpan(0, 31, 35), 350.00));
            context.ListaZdarzen.Add(new Zdarzenie(context.ListaGraczy[1], context.ListaRozegranychGier[1], new DateTime(2019, 1, 2, 21, 11, 54), new TimeSpan(0, 15, 33), 88.00));
            context.ListaZdarzen.Add(new Zdarzenie(context.ListaGraczy[2], context.ListaRozegranychGier[2], new DateTime(2019, 1, 3, 20, 35, 30), new TimeSpan(0, 56, 44), 0.00));
            context.ListaZdarzen.Add(new Zdarzenie(context.ListaGraczy[3], context.ListaRozegranychGier[3], new DateTime(2019, 1, 4, 22, 40, 24), new TimeSpan(1, 1, 32), 120.00));
            context.ListaZdarzen.Add(new Zdarzenie(context.ListaGraczy[1], context.ListaRozegranychGier[0], new DateTime(2019, 1, 1, 20, 10, 15), new TimeSpan(0, 31, 35), 150.00));
        }
    }
}