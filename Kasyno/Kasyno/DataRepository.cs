namespace Kasyno
{
    public class DataRepository // DataRepository
    {
        private DataContext Context;

        public DataRepository(IWypelnianieStalymi wstrzykiwanieStalych)
        {
            Context = new DataContext();
            wstrzykiwanieStalych.WypelnijDanymi(ref Context);
        }
    }
}