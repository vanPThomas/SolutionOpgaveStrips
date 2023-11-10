using StripsBL.DTOs;
using StripsBL.Exceptions;
using StripsBL.Interfaces;
using StripsBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Managers
{
    public class StripsManager
    {
        private IStripsRepository stripsRepository;

        public StripsManager(IStripsRepository stripsRepository)
        {
            this.stripsRepository = stripsRepository;
        }

        public Reeks GeefReeksMetStrips(int id)
        {
            Reeks r;
            List<Strip> strips = new List<Strip>();
            try
            {
                r = stripsRepository.GeefReeks(id);
            }
            catch (Exception e)
            {
                throw new StripsManagerException("GeefReeksMetStrips REEKS", e);
            }
            try
            {
                strips = stripsRepository.GeefStripsVanReeks(id);
            }
            catch (Exception e)
            {
                throw new StripsManagerException("GeefReeksMetStrips STRIPS", e);
            }
            r.Strips = strips;
            return r;
        }
    }
}
