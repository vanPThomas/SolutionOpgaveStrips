using StripsBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Interfaces
{
    public interface IStripsRepository
    {
        public Reeks GeefReeks(int reeksID);
        public List<Strip> GeefStripsVanReeks(int id);
    }
}
