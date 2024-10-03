namespace ETI_X_2024_IntroASPNETCore.Models
{
    public class Uczen
    {
        public string Imie;
        public string Nazwisko;
        public string Adres;
        public int NumerWDzienniku;
        public string Klasa;
        public Uczen(string imie, string nazwisko, string adres, int numerWDzienniku, string klasa)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Adres = adres;
            NumerWDzienniku = numerWDzienniku;
            Klasa = klasa;
        }
    }
}
