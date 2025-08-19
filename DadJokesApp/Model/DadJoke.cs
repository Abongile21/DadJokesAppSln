using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadJokesApp.Model
{
    public class DadJoke
    {
        public string id { get; set; }
        public string joke { get; set; }
        public int status { get; set; }

        public static implicit operator DadJoke(ObservableCollection<DadJoke> v)
        {
            throw new NotImplementedException();
        }
    }
}
