using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsClientWPFReeksView.Model
{
    public class ReeksWPF
    {
        public string URL { get; set; }
        public string Naam { get; set; }
        public string Aantal { get; set; }
        public List<StripWPF> Strips { get; set; }

        public ReeksWPF(string url, string naam, string aantal, List<StripWPF> strips)
        {
            URL = url;
            Naam = naam;
            Aantal = aantal;
            Strips = strips;
        }
    }
}
