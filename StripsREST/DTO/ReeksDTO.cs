namespace StripsREST.DTO
{
    public class ReeksDTO
    {
        public string Naam { get; set; }
        public int Aantal { get; set; }
        public List<string> Strips { get; set; }

        public ReeksDTO(string naam, int aantal, List<string> strips)
        {
            Naam = naam;
            Aantal = aantal;
            Strips = strips;
        }
    }
}
