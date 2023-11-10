using StripsBL.Model;
using StripsREST.DTO;
using StripsREST.Exceptions;
using System.Net.Mail;

namespace StripsREST.Mappers
{
    public class MapFromDomain
    {
        public static ReeksDTO MapFromReeksDomain(string url, Reeks reeks)
        {
            try
            {
                string reeksURL = $"{url}/{reeks.ID}";
                List<StripDTO> strips = new List<StripDTO>();

                foreach (Strip s in reeks.Strips)
                {
                    StripDTO stripDTO = new StripDTO((int)s.Nr, s.Titel, $"{url}/{s.ID}");
                    strips.Add(stripDTO);
                }

                ReeksDTO dto = new ReeksDTO(reeksURL, reeks.Naam, reeks.Strips.Count, strips);
                return dto;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapFromReeksDomain", ex);
            }
        }
    }
}
