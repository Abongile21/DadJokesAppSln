using DadJokesApp.Model;
using DadJokesApp.Services;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DadJokesApp.ViewModels
{
    public class DisplayJokesViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<DadJoke> _dadJoke;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged( [CallerMemberName]string propertyName =null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand GetDadJoke { get; }

        public ObservableCollection<DadJoke> DadJokes
        {
            get { return _dadJoke; }
            set { _dadJoke = value;

                OnPropertyChanged();
            }
        }

        public DadJokeApiService _DadJokeApiService { get; set; }

        public DisplayJokesViewModel(DadJokeApiService DadJokeApiService)
        {

            _DadJokeApiService = DadJokeApiService;
            _dadJoke = new ObservableCollection<DadJoke>();

            GetDadJoke = new Command(GetJoke);
        }
        

        public async void GetJoke()
        {
            DadJokes.Add(await _DadJokeApiService.GetDadJoke());
        }

    }
}
