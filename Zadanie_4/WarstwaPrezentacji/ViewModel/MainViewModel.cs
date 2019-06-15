using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WarstwaUslug;
using WarstwaPrezentacji.Model;
using WarstwaDanych;
using System.ComponentModel;

namespace WarstwaPrezentacji.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyEventChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // DataLayer
        private DataLayer dataLayer;

        // Gra
        private Gra _biezacaGra;
        private ObservableCollection<Gra> _gry;
        private int _NewIdGry;
        private string _NewNazwaGry;
        private string _NewInformacjeOGrze;

        // Gracz
        private Gracz _biezacyGracz;
        private ObservableCollection<Gracz> _gracze;
        private int _NewIdGracza;
        private string _NewImie;
        private string _NewNazwisko;
        private DateTime _NewDataUrodzin;

        // Rozegrana gra
        private RozegranaGra _biezacaRozegranaGra;
        private ObservableCollection<RozegranaGra> _rozegraneGry;
        private int _NewIdRozegranejGry;
        private int _NewGra;
        private DateTime _NewCzasRozpoczeciaGry;
        private TimeSpan _NewCzasTrwaniaGry;
        private float _NewOplataWejsciowa;
        private float _NewMinimalnyDepozyt;

        // Zdarzenie
        private Zdarzenie _biezaceZdarzenie;
        private ObservableCollection<Zdarzenie> _zdarzenia;
        private int _NewIdZdarzenia;
        private int _NewUczestnikGry;
        private int _NewUkonczonaGra;
        private float _NewWygrana;

        public MainViewModel()
        {
            // DataLayer
            dataLayer = new DataLayer();
            GetDataCommand = new DelegateCommand(() => DataLayer = new DataLayer());

            // SaveChanges
            SaveChangesCommand = new DelegateCommand(SaveChanges);

            // Gra
            _gry = new ObservableCollection<Gra>();
            CreateGraCommand = new DelegateCommand(CreateGra);
            UpdateGraCommand = new DelegateCommand(UpdateGra);
            DeleteGraCommand = new DelegateCommand(DeleteGra);

            // Gracz
            _gracze = new ObservableCollection<Gracz>();
            CreateGraczCommand = new DelegateCommand(CreateGracz);
            UpdateGraczCommand = new DelegateCommand(UpdateGracz);
            DeleteGraczCommand = new DelegateCommand(DeleteGracz);

            // Rozegrana gra
            _rozegraneGry = new ObservableCollection<RozegranaGra>();
            CreateRozegranaGraCommand = new DelegateCommand(CreateRozegranaGra);
            UpdateRozegranaGraCommand = new DelegateCommand(UpdateRozegranaGra);
            DeleteRozegranaGraCommand = new DelegateCommand(DeleteRozegranaGra);

            // Zdarzenie
            _zdarzenia = new ObservableCollection<Zdarzenie>();
            CreateZdarzenieCommand = new DelegateCommand(CreateZdarzenie);
            UpdateZdarzenieCommand = new DelegateCommand(UpdateZdarzenie);
            DeleteZdarzenieCommand = new DelegateCommand(DeleteZdarzenie);
        }

        // DataLayer
        public DelegateCommand GetDataCommand { get; private set; }

        // SaveChanges
        public DelegateCommand SaveChangesCommand { get; private set; }

        // Gra
        public DelegateCommand CreateGraCommand { get; private set; }
        public DelegateCommand UpdateGraCommand { get; private set; }
        public DelegateCommand DeleteGraCommand { get; private set; }

        // Gracz
        public DelegateCommand CreateGraczCommand { get; private set; }
        public DelegateCommand UpdateGraczCommand { get; private set; }
        public DelegateCommand DeleteGraczCommand { get; private set; }


        // Rozegrana gra
        public DelegateCommand CreateRozegranaGraCommand { get; private set; }
        public DelegateCommand UpdateRozegranaGraCommand { get; private set; }
        public DelegateCommand DeleteRozegranaGraCommand { get; private set; }

        // Zdarzenie
        public DelegateCommand CreateZdarzenieCommand { get; private set; }
        public DelegateCommand UpdateZdarzenieCommand { get; private set; }
        public DelegateCommand DeleteZdarzenieCommand { get; private set; }

        // DataLayer
        public DataLayer DataLayer
        {
            get => dataLayer;
            set
            {
                dataLayer = value;
                Gry = new ObservableCollection<Gra>(value.gryData);
                Gracze = new ObservableCollection<Gracz>(value.graczeData);
                RozegraneGry = new ObservableCollection<RozegranaGra>(value.rozegraneGryData);
                Zdarzenia = new ObservableCollection<Zdarzenie>(value.zdarzeniaData);
            }
        }

        // SaveChanges
        public void SaveChanges()
        {
            Task.Run(() => { DataRepository.SaveChanges(); });
        }

        //Gra
        public int NewIdGry
        {
            get => _NewIdGry;
            set
            {
                _NewIdGry = value;
                RaisePropertyEventChanged();
            }
        }
        public string NewNazwaGry
        {
            get => _NewNazwaGry;
            set
            {
                _NewNazwaGry = value;
                RaisePropertyEventChanged();
            }
        }
        public string NewInformacjeOGrze
        {
            get => _NewInformacjeOGrze;
            set
            {
                _NewInformacjeOGrze = value;
                RaisePropertyEventChanged();
            }
        }

        public Gra BiezacaGra
        {
            get => _biezacaGra;
            set
            {
                _biezacaGra = value;
                RaisePropertyEventChanged();
            }
        }

        public ObservableCollection<Gra> Gry
        {
            get => _gry;
            set
            {
                _gry = value;
                RaisePropertyEventChanged();
            }
        }

        private void CreateGra()
        {
            // DO ZROBIENIA PÓŹNIEJ walidacja danych wejściowych
            Gra nowaGra = new Gra()
            {
                IdGry = _NewIdGry,
                NazwaGry = _NewNazwaGry,
                InformacjeOGrze = _NewInformacjeOGrze
            };

            Task.Run(() => { DataRepository.CreateGra(nowaGra); });
            _gry.Add(nowaGra);
        }

        private void UpdateGra()
        {
            Task.Run(() => { DataRepository.UpdateGra(_biezacaGra); });
        }

        private void DeleteGra()
        {
            Task.Run(() => { DataRepository.DeleteGra(_biezacaGra.IdGry); });
            _gry.Remove(_biezacaGra);
        }

        // Gracz
        public int NewIdGracza
        {
            get => _NewIdGracza;
            set
            {
                _NewIdGracza = value;
                RaisePropertyEventChanged();
            }
        }
        public string NewImie
        {
            get => _NewImie;
            set
            {
                _NewImie = value;
                RaisePropertyEventChanged();
            }
        }
        public string NewNazwisko
        {
            get => _NewNazwisko;
            set
            {
                _NewNazwisko = value;
                RaisePropertyEventChanged();
            }
        }
        public DateTime NewDataUrodzin
        {
            get => _NewDataUrodzin;
            set
            {
                _NewDataUrodzin = value;
                RaisePropertyEventChanged();
            }
        }

        public Gracz BiezacyGracz
        {
            get => _biezacyGracz;
            set
            {
                _biezacyGracz = value;
                RaisePropertyEventChanged();
            }
        }

        public ObservableCollection<Gracz> Gracze
        {
            get => _gracze;
            set
            {
                _gracze = value;
                RaisePropertyEventChanged();
            }
        }

        private void CreateGracz()
        {
            // DO ZROBIENIA PÓŹNIEJ walidacja danych wejściowych
            Gracz nowyGracz = new Gracz()
            {
                IdGracza = _NewIdGracza,
                Imie = _NewImie,
                Nazwisko = _NewNazwisko,
                DataUrodzin = _NewDataUrodzin
            };

            Task.Run(() => { DataRepository.CreateGracz(nowyGracz); });
            _gracze.Add(nowyGracz);
        }

        private void UpdateGracz()
        {
            Task.Run(() => { DataRepository.UpdateGracz(_biezacyGracz); });
        }

        private void DeleteGracz()
        {
            Task.Run(() => { DataRepository.DeleteGracz(_biezacyGracz.IdGracza); });
            _gracze.Remove(_biezacyGracz);
        }

        // Rozegrana gra
        public int NewIdRozegranejGry
        {
            get => _NewIdRozegranejGry;
            set
            {
                _NewIdRozegranejGry = value;
                RaisePropertyEventChanged();
            }
        }
        public int NewGra
        {
            get => _NewGra;
            set
            {
                _NewGra = value;
                RaisePropertyEventChanged();
            }
        }
        public DateTime NewCzasRozpoczeciaGry
        {
            get => _NewCzasRozpoczeciaGry;
            set
            {
                _NewCzasRozpoczeciaGry = value;
                RaisePropertyEventChanged();
            }
        }
        public TimeSpan NewCzasTrwaniaGry
        {
            get => _NewCzasTrwaniaGry;
            set
            {
                _NewCzasTrwaniaGry = value;
                RaisePropertyEventChanged();
            }
        }
        public float NewOplataWejsciowa
        {
            get => _NewOplataWejsciowa;
            set
            {
                _NewOplataWejsciowa = value;
                RaisePropertyEventChanged();
            }
        }
        public float NewMinimalnyDepozyt
        {
            get => _NewMinimalnyDepozyt;
            set
            {
                _NewMinimalnyDepozyt = value;
                RaisePropertyEventChanged();
            }
        }

        public RozegranaGra BiezacaRozegranaGra
        {
            get => _biezacaRozegranaGra;
            set
            {
                _biezacaRozegranaGra = value;
                RaisePropertyEventChanged();
            }
        }

        public ObservableCollection<RozegranaGra> RozegraneGry
        {
            get => _rozegraneGry;
            set
            {
                _rozegraneGry = value;
                RaisePropertyEventChanged();
            }
        }

        private void CreateRozegranaGra()
        {
            // DO ZROBIENIA PÓŹNIEJ walidacja danych wejściowych
            RozegranaGra nowaRozegranaGra = new RozegranaGra()
            {
                IdRozegranejGry = _NewIdRozegranejGry,
                Gra = _NewGra,
                CzasRozpoczeciaGry = _NewCzasRozpoczeciaGry,
                CzasTrwaniaGry = _NewCzasTrwaniaGry,
                OplataWejsciowa = _NewOplataWejsciowa,
                MinimalnyDepozyt = _NewMinimalnyDepozyt
            };

            Task.Run(() => { DataRepository.CreateRozegranaGra(nowaRozegranaGra); });
            _rozegraneGry.Add(nowaRozegranaGra);
        }

        private void UpdateRozegranaGra()
        {
            Task.Run(() => { DataRepository.UpdateRozegranaGra(_biezacaRozegranaGra); });
        }

        private void DeleteRozegranaGra()
        {
            Task.Run(() => { DataRepository.DeleteRozegranaGra(_biezacaRozegranaGra.IdRozegranejGry); });
            _rozegraneGry.Remove(_biezacaRozegranaGra);
        }

        // Zdarzenie
        public int NewIdZdarzenia
        {
            get => _NewIdZdarzenia;
            set
            {
                _NewIdZdarzenia = value;
                RaisePropertyEventChanged();
            }
        }
        public int NewUczestnikGry
        {
            get => _NewUczestnikGry;
            set
            {
                _NewUczestnikGry = value;
                RaisePropertyEventChanged();
            }
        }
        public int NewUkonczonaGra
        {
            get => _NewUkonczonaGra;
            set
            {
                _NewUkonczonaGra = value;
                RaisePropertyEventChanged();
            }
        }
        public float NewWygrana
        {
            get => _NewWygrana;
            set
            {
                _NewWygrana = value;
                RaisePropertyEventChanged();
            }
        }

        public Zdarzenie BiezaceZdarzenie
        {
            get => _biezaceZdarzenie;
            set
            {
                _biezaceZdarzenie = value;
                RaisePropertyEventChanged();
            }
        }

        public ObservableCollection<Zdarzenie> Zdarzenia
        {
            get => _zdarzenia;
            set
            {
                _zdarzenia = value;
                RaisePropertyEventChanged();
            }
        }

        private void CreateZdarzenie()
        {
            // DO ZROBIENIA PÓŹNIEJ walidacja danych wejściowych
            Zdarzenie noweZdarzenie = new Zdarzenie()
            {
                IdZdarzenia = _NewIdZdarzenia,
                UczestnikGry = _NewUczestnikGry,
                UkonczonaGra = _NewUkonczonaGra,
                Wygrana = _NewWygrana
            };

            Task.Run(() => { DataRepository.CreateZdarzenie(noweZdarzenie); });
            _zdarzenia.Add(noweZdarzenie);
        }

        private void UpdateZdarzenie()
        {
            Task.Run(() => { DataRepository.UpdateZdarzenie(_biezaceZdarzenie); });
        }

        private void DeleteZdarzenie()
        {
            Task.Run(() => { DataRepository.DeleteZdarzenie(_biezaceZdarzenie.IdZdarzenia); });
            _zdarzenia.Remove(_biezaceZdarzenie);
        }
    }
}