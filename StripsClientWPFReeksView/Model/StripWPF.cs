using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsClientWPFReeksView.Model
{
    public class StripWPF
    {
        public StripWPF(int nr, string titel, string url)
        {
            this.nr = nr;
            this.titel = titel;
            this.url = url;
        }

        public int nr { get; set; }
        public string titel { get; set; }
        public string url { get; set; }
    }
}
