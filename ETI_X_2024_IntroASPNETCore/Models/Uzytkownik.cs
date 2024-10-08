namespace ETI_X_2024_IntroASPNETCore.Models
{
    public class Uzytkownik
    {
        public int UzytkownikId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wzrost { get; set; }
        public string Plec { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Waga> Wagas { get; } = new List<Waga>();
        public ICollection<Trening> Trenings { get; } = new List<Trening>();
    }
}
