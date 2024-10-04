namespace ETI_X_2024_IntroASPNETCore.Models
{
    public class Marka
    {
        public int MarkaId { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Samochod> Samochods { get; } = new List<Samochod>();
    }
}
