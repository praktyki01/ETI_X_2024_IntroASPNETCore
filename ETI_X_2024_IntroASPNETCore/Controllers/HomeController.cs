using ETI_X_2024_IntroASPNETCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETI_X_2024_IntroASPNETCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Aby wys�a� dane z kontrolera do widoku mo�emy u�y� Viewbag
            //po kropce definiujemy w�asn� nazw�
            //aby wy�wietli� dane w widoku u�yjemy @ViewBag.info1
            ViewBag.info1 = "Pozdrowienia z kontrolera";
            ViewBag.info2 = 2024;
            ViewBag.dataigodzina = DateTime.Now;
            return View();
        }
        //Aby odebra� w kontrolerze dane z widoku wys�ane za pomoc� querystring
        //w widoku za pomoc� linku dodajemy dane
        //a w kontrolerze te dane odczytujemy
        public IActionResult Form2(string odpowiedz)
        {
            if(odpowiedz=="Warszawa")
            {
                ViewBag.odp = "Udzielono poprawnej odpowiedzi, stolic� Polski jest Warszawa";
            }
            return View();
        }
        public IActionResult Form5(string imie,string nazwisko, int rokUrodzenia,string adres,string fav_language)
        {        
            ViewBag.imie = imie;
            ViewBag.nazwisko=nazwisko;
            ViewBag.rokUrodzenia=rokUrodzenia;
            ViewBag.adres=adres;
            ViewBag.fav_language = fav_language;
            return View();
        }
        public IActionResult Form6()
        {
            List<string> dniTygodnia= new List<string>();
            dniTygodnia.Add("Poniedzia�ek");
            dniTygodnia.Add("Wtorek");
            dniTygodnia.Add("�roda");
            dniTygodnia.Add("Czwartek");
            dniTygodnia.Add("Pi�tek");
            dniTygodnia.Add("Sobota");
            dniTygodnia.Add("Niedziela");
            ViewBag.dniTygodnia=dniTygodnia;
            return View();
        }
        //mandaty
        public IActionResult Form7(int speed)
        {
            if (speed != 0)
            {
                if(speed>50)
                {
                    ViewBag.mandat = "Dostajesz mandat";
                }else
                {
                    ViewBag.mandat = "Pr�dko�� poprawna";
                }
            }
            return View();
        }
        //pola figur
        public IActionResult Form8(float bok1,float bok2, float wysokosc)
        {
            if (bok1!= 0)
            {
                float poletrapezu = ((bok1 + bok2) * wysokosc) / 2;
                ViewBag.poletrapezu = poletrapezu;
            }
            return View();
        }
        //tabliczka mnozenia1
        public IActionResult Form9()
        {
            return View();
        }
        //tabliczka mnozenia2
        //https://wordwall.net/pl/resource/11645442/tabliczka-mnozenia
        public IActionResult Form10(int liczba1, int liczba2,int wynik)
        {
            if (wynik == liczba1 * liczba2)
                ViewBag.wynik = "Poprawna odpowied�";
            else
                ViewBag.wynik = "Niepoprawna odpowied�, poprawny wynik to: "+liczba1*liczba2;
            return View();
        }
        //lista uczni�w
        public IActionResult Form11()
        {
            List<Uczen> listaUczniow= new List<Uczen>();
            listaUczniow.Add(new Uczen("Jan", "Kowalski", "ul. Zielona 27",1, "3A"));
            listaUczniow.Add(new Uczen("Adam", "Nowak", "ul. Jagiello�ska  45", 2, "3A"));
            listaUczniow.Add(new Uczen("Anna", "Kowal", "ul. Niebieska 67", 3, "3A"));
            listaUczniow.Add(new Uczen("Janina", "Nowakowska", "ul. Z�ta 3", 4, "3A"));
            listaUczniow.Add(new Uczen("Adrian", "Kot", "ul. Lwowska 7", 5, "3A"));
            ViewBag.listaUczniow = listaUczniow;
            return View();
        }
        //lista uczni�w szcz�liwy numerek
        public IActionResult Form12()
        {
            List<Uczen> listaUczniow = new List<Uczen>();
            listaUczniow.Add(new Uczen("Jan", "Kowalski", "ul. Zielona 27", 1, "3A"));
            listaUczniow.Add(new Uczen("Adam", "Nowak", "ul. Jagiello�ska  45", 2, "3A"));
            listaUczniow.Add(new Uczen("Anna", "Kowal", "ul. Niebieska 67", 3, "3A"));
            listaUczniow.Add(new Uczen("Janina", "Nowakowska", "ul. Z�ta 3", 4, "3A"));
            listaUczniow.Add(new Uczen("Adrian", "Kot", "ul. Lwowska 7", 5, "3A"));
            ViewBag.listaUczniow = listaUczniow;
            return View();
        }
        //lista uczni�w model
        public IActionResult Form13()
        {
            List<Uczen> listaUczniow = new List<Uczen>();
            listaUczniow.Add(new Uczen("Jan", "Kowalski", "ul. Zielona 27", 1, "3A"));
            listaUczniow.Add(new Uczen("Adam", "Nowak", "ul. Jagiello�ska  45", 2, "3A"));
            listaUczniow.Add(new Uczen("Anna", "Kowal", "ul. Niebieska 67", 3, "3A"));
            listaUczniow.Add(new Uczen("Janina", "Nowakowska", "ul. Z�ta 3", 4, "3A"));
            listaUczniow.Add(new Uczen("Adrian", "Kot", "ul. Lwowska 7", 5, "3A"));
            return View(listaUczniow);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
