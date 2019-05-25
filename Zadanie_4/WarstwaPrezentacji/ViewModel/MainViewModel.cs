using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Mvvm;
using WarstwaUslug;
using WarstwaPrezentacji.Model;

namespace WarstwaPrezentacji.ViewModel
{
    public class MainViewModel : BindableBase
    {
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

        //Gra
        public int NewIdGry
        {
            get => _NewIdGry;
            set
            {
                _NewIdGry = value;
                RaisePropertyChanged();
            }
        }
        public string NewNazwaGry
        {
            get => _NewNazwaGry;
            set
            {
                _NewNazwaGry = value;
                RaisePropertyChanged();
            }
        }
        public string NewInformacjeOGrze
        {
            get => _NewInformacjeOGrze;
            set
            {
                _NewInformacjeOGrze = value;
                RaisePropertyChanged();
            }
        }

        public Gra BiezacaGra
        {
            get => _biezacaGra;
            set
            {
                _biezacaGra = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Gra> Gry
        {
            get => _gry;
            set
            {
                _gry = value;
                RaisePropertyChanged();
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
            //warunek gry nie ma zaznaczonej gry
            //warunek jak któreś pole jest niezmieniane
            _biezacaGra.NazwaGry = _NewNazwaGry;
            _biezacaGra.InformacjeOGrze = _NewInformacjeOGrze;

            Task.Run(() => { DataRepository.UpdateGra(_biezacaGra); });
        }

        private void DeleteGra()
        {
            //walidacja gdy nie ma zaznaczonej gry
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
                RaisePropertyChanged();
            }
        }
        public string NewImie
        {
            get => _NewImie;
            set
            {
                _NewImie = value;
                RaisePropertyChanged();
            }
        }
        public string NewNazwisko
        {
            get => _NewNazwisko;
            set
            {
                _NewNazwisko = value;
                RaisePropertyChanged();
            }
        }
        public DateTime NewDataUrodzin
        {
            get => _NewDataUrodzin;
            set
            {
                _NewDataUrodzin = value;
                RaisePropertyChanged();
            }
        }

        public Gracz BiezacyGracz
        {
            get => _biezacyGracz;
            set
            {
                _biezacyGracz = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Gracz> Gracze
        {
            get => _gracze;
            set
            {
                _gracze = value;
                RaisePropertyChanged();
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
            //warunek gry nie ma zaznaczonego gracza
            //warunek jak któreś pole jest niezmieniane
            _biezacyGracz.Imie = _NewImie;
            _biezacyGracz.Nazwisko = _NewNazwisko;
            _biezacyGracz.DataUrodzin = _NewDataUrodzin;
            Task.Run(() => { DataRepository.UpdateGracz(_biezacyGracz); });
        }

        private void DeleteGracz()
        {
            //walidacja gdy nie ma zaznaczonego gracza
            Task.Run(() => { DataRepository.DeleteGra(_biezacyGracz.IdGracza); });
            _gracze.Remove(_biezacyGracz);
        }

        // Rozegrana gra
        public int NewIdRozegranejGry
        {
            get => _NewIdRozegranejGry;
            set
            {
                _NewIdRozegranejGry = value;
                RaisePropertyChanged();
            }
        }
        public int NewGra
        {
            get => _NewGra;
            set
            {
                _NewGra = value;
                RaisePropertyChanged();
            }
        }
        public DateTime NewCzasRozpoczeciaGry
        {
            get => _NewCzasRozpoczeciaGry;
            set
            {
                _NewCzasRozpoczeciaGry = value;
                RaisePropertyChanged();
            }
        }
        public TimeSpan NewCzasTrwaniaGry
        {
            get => _NewCzasTrwaniaGry;
            set
            {
                _NewCzasTrwaniaGry = value;
                RaisePropertyChanged();
            }
        }
        public float NewOplataWejsciowa
        {
            get => _NewOplataWejsciowa;
            set
            {
                _NewOplataWejsciowa = value;
                RaisePropertyChanged();
            }
        }
        public float NewMinimalnyDepozyt
        {
            get => _NewMinimalnyDepozyt;
            set
            {
                _NewMinimalnyDepozyt = value;
                RaisePropertyChanged();
            }
        }

        public RozegranaGra BiezacaRozegranaGra
        {
            get => _biezacaRozegranaGra;
            set
            {
                _biezacaRozegranaGra = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<RozegranaGra> RozegraneGry
        {
            get => _rozegraneGry;
            set
            {
                _rozegraneGry = value;
                RaisePropertyChanged();
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
            //warunek gry nie ma zaznaczonej rozegranej gry
            //warunek jak któreś pole jest niezmieniane
            _biezacaRozegranaGra.Gra = _NewGra;
            _biezacaRozegranaGra.CzasRozpoczeciaGry = _NewCzasRozpoczeciaGry;
            _biezacaRozegranaGra.CzasTrwaniaGry = _NewCzasTrwaniaGry;
            _biezacaRozegranaGra.OplataWejsciowa = _NewOplataWejsciowa;
            _biezacaRozegranaGra.MinimalnyDepozyt = _NewMinimalnyDepozyt;

            Task.Run(() => { DataRepository.UpdateRozegranaGra(_biezacaRozegranaGra); });
        }

        private void DeleteRozegranaGra()
        {
            //walidacja gdy nie ma zaznaczonej rozegranej gry
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
                RaisePropertyChanged();
            }
        }
        public int NewUczestnikGry
        {
            get => _NewUczestnikGry;
            set
            {
                _NewUczestnikGry = value;
                RaisePropertyChanged();
            }
        }
        public int NewUkonczonaGra
        {
            get => _NewUkonczonaGra;
            set
            {
                _NewUkonczonaGra = value;
                RaisePropertyChanged();
            }
        }
        public float NewWygrana
        {
            get => _NewWygrana;
            set
            {
                _NewWygrana = value;
                RaisePropertyChanged();
            }
        }

        public Zdarzenie BiezaceZdarzenie
        {
            get => _biezaceZdarzenie;
            set
            {
                _biezaceZdarzenie = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Zdarzenie> Zdarzenia
        {
            get => _zdarzenia;
            set
            {
                _zdarzenia = value;
                RaisePropertyChanged();
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
            //warunek gry nie ma zaznaczonego zdarzenia
            //warunek jak któreś pole jest niezmieniane
            _biezaceZdarzenie.IdZdarzenia = _NewIdZdarzenia;
            _biezaceZdarzenie.UczestnikGry = _NewUczestnikGry;
            _biezaceZdarzenie.UkonczonaGra = _NewUkonczonaGra;
            _biezaceZdarzenie.Wygrana = _NewWygrana;

            Task.Run(() => { DataRepository.UpdateZdarzenie(_biezaceZdarzenie); });
        }

        private void DeleteZdarzenie()
        {
            //walidacja gdy nie ma zaznaczonego zdarzenia
            Task.Run(() => { DataRepository.DeleteZdarzenie(_biezaceZdarzenie.IdZdarzenia); });
            _zdarzenia.Remove(_biezaceZdarzenie);
        }
    }
}