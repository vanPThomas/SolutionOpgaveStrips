using StripsBL.Model;

namespace StripsREST.DTO
{
    public class ReeksDTO
    {
        public string URL { get; set; }
        public string Naam { get; set; }
        public int Aantal { get; set; }
        public List<StripDTO> Strips { get; set; }

        public ReeksDTO(string url, string naam, int aantal, List<StripDTO> strips)
        {
            URL = url;
            Naam = naam;
            Aantal = aantal;
            Strips = strips;
        }
    }
}
