using System.ComponentModel.DataAnnotations;

namespace ETI_X_2024_IntroASPNETCore.Models
{
    public class Samochod
    {
        public int SamochodId { get; set; }
        [Range(10000, 100000)]
        public int Przebieg { get; set; }
        public int RokProdukcji { get; set; }
        public int Cena { get; set; }
        [Display(Name ="Marka")]
        public int? MarkaId { get; set; }
        public Marka? Marka { get; set; } = null!;
        [Display(Name = "Model")]
        public int? ModelId { get; set; }
        public Model? Model { get; set; } = null!;
        [Display(Name = "Rodzaj silnika")]
        public int? RodzajSilnikaId { get; set; }
        public RodzajSilnika? RodzajSilnika { get; set; } = null!;
        [Display(Name = "Kolor")]
        public int? KolorId { get; set; }
        public Kolor? Kolor { get; set; } = null!;

    }
}
