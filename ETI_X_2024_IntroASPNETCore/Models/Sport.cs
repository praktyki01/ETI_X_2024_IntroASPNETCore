﻿namespace ETI_X_2024_IntroASPNETCore.Models
{
    public class Sport
    {
        public int SportId { get; set; }
        public string Nazwa { get; set; }
        public string ImgUrl { get; set; }

        public ICollection<Trening> Trenings { get; } = new List<Trening>();
    }
}
