namespace ETI_X_2024_IntroASPNETCore.Models
{
    public class Kategoria
    {
        public int KategoriaId { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public ICollection<Produkt> Produkts { get; }=new List<Produkt>();
    }
}
