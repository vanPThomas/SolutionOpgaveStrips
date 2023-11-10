namespace StripsREST.DTO
{
    public class StripDTO
    {
        public StripDTO(int nr, string titel, string url)
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
