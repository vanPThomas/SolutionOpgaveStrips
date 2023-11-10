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
                string reeksURL = $"{url}/reeks/{reeks.ID}";
                List<string> strips = reeks.Strips
                    .Select(x => reeksURL + $"/strips/{x.ID}")
                    .ToList();
                ReeksDTO dto = new ReeksDTO(reeksURL, strips.Count, strips);
                return dto;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapFromGemeenteDomain", ex);
            }
        }
    }
}
