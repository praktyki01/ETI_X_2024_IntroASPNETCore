namespace ETI_X_2024_IntroASPNETCore.Models
{
    public class RodzajSilnika
    {
        public int RodzajSilnikaId { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Samochod> Samochods { get; } = new List<Samochod>();
    }
}
