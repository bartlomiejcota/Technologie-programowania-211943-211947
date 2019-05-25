using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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

        // Rozegrana gra

        // Zdarzenie

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

            // Rozegrana gra

            // Zdarzenie

        }

        // DataLayer
        public DelegateCommand GetDataCommand { get; private set; }

        // Gra
        public DelegateCommand CreateGraCommand { get; private set; }
        public DelegateCommand UpdateGraCommand { get; private set; }
        public DelegateCommand DeleteGraCommand { get; private set; }
        
        // Gracz

        // Rozegrana gra

        // Zdarzenie


        // DataLayer
        public DataLayer DataLayer
        {
            get => dataLayer;
            set
            {
                dataLayer = value;
                Gry = new ObservableCollection<Gra>(value.gryData);
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
             //   BiezacaGra = _gry.First(p => p.IdGry == _biezacaGra.IdGry);
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

        // Rozegrana gra

        // Zdarzenie
    }
}
