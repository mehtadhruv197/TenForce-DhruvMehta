using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Test_Taste_Console_Application.Domain.DataTransferObjects;

namespace Test_Taste_Console_Application.Domain.Objects
{
    public class Planet
    {
        public string Id { get; set; }
        public float SemiMajorAxis { get; set; }
        public ICollection<Moon> Moons { get; set; }
        public float AverageMoonGravity
        {
            get;
            set;
        } = 0.0f;

        public Planet(PlanetDto planetDto)
        {
            
            Id = planetDto.Id;
            SemiMajorAxis = planetDto.SemiMajorAxis;
            //Moons = new Collection<Moon>();
            Moons = planetDto.Moons != null ? planetDto.Moons.Select(moonDto => new Moon(moonDto)).ToList() : new List<Moon>();
            AverageMoonGravity = (planetDto.Moons != null)?planetDto.Moons.Average(m => m.Gravity):0;
            //if (planetDto.Moons != null)
            //{
            //    foreach (MoonDto moonDto in planetDto.Moons)
            //    {
            //        Moons.Add(new Moon(moonDto));
            //    }
            //}
        }

        public Boolean HasMoons()
        {
            return (Moons != null && Moons.Count > 0);
        }
    }
}
