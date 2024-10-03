namespace ETI_X_2024_IntroASPNETCore.Models
{
    public class Produkt
    {
        public int ProduktId {  get; set; }
        public string Nazwa { get; set; }
        public string Opis {  get; set; }
        public float Cena { get; set; }

        public int? KategoriaId {  get; set; }
        public Kategoria? Kategoria { get; set; } = null!;
    }
}
