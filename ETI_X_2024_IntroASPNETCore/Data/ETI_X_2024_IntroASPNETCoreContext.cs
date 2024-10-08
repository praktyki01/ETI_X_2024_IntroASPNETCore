using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ETI_X_2024_IntroASPNETCore.Models;

namespace ETI_X_2024_IntroASPNETCore.Data
{
    public class ETI_X_2024_IntroASPNETCoreContext : DbContext
    {
        public ETI_X_2024_IntroASPNETCoreContext (DbContextOptions<ETI_X_2024_IntroASPNETCoreContext> options)
            : base(options)
        {
        }

        public DbSet<ETI_X_2024_IntroASPNETCore.Models.Produkt> Produkt { get; set; } = default!;
        public DbSet<ETI_X_2024_IntroASPNETCore.Models.Kategoria> Kategoria { get; set; } = default!;
        public DbSet<ETI_X_2024_IntroASPNETCore.Models.Samochod> Samochod { get; set; } = default!;
        public DbSet<ETI_X_2024_IntroASPNETCore.Models.Marka> Marka { get; set; } = default!;
        public DbSet<ETI_X_2024_IntroASPNETCore.Models.Model> Model{ get; set; } = default!;
        public DbSet<ETI_X_2024_IntroASPNETCore.Models.Kolor> Kolor { get; set; } = default!;
        public DbSet<ETI_X_2024_IntroASPNETCore.Models.RodzajSilnika> RodzajSilnika { get; set; } = default!;
        public DbSet<ETI_X_2024_IntroASPNETCore.Models.Sport> Sport { get; set; } = default!;
        public DbSet<ETI_X_2024_IntroASPNETCore.Models.Trening> Trening { get; set; } = default!;
        public DbSet<ETI_X_2024_IntroASPNETCore.Models.Waga> Waga { get; set; } = default!;
        public DbSet<ETI_X_2024_IntroASPNETCore.Models.Uzytkownik> Uzytkownik { get; set; } = default!;
    }
}
