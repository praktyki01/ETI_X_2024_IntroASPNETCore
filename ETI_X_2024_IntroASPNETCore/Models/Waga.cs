using System.ComponentModel.DataAnnotations;

namespace ETI_X_2024_IntroASPNETCore.Models
{
    public class Waga
    {
        public int WagaId { get; set; }
        public DateTime Data { get; set; }
        public float Wartosc { get; set; }

        [Display(Name = "Uzytkownik")]
        public int? UzytkownikId { get; set; }
        public Uzytkownik? Uzytkownik { get; set; } = null!;
    }
}
