using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly PlanetRepository planetRepository;
        private readonly AstronautRepository astronautRepository;
        private int missionCounter;
        private int deadAstronaut;
        public Controller()
        {
            planetRepository = new PlanetRepository();
            astronautRepository = new AstronautRepository();
            missionCounter = 0;
            deadAstronaut = 0;
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;
            if (type == "Biologist")
            {
                astronaut = new Biologist(astronautName);
                astronautRepository.Add(astronaut);
            }
            else if (type == "Geodesist")
            {
                astronaut = new Geodesist(astronautName);
                astronautRepository.Add(astronaut);
            }
            else if (type == "Meteorologist")
            {
                astronaut = new Meteorologist(astronautName);
                astronautRepository.Add(astronaut);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);

        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planetRepository.Add(planet);
            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planetRepository.Models.FirstOrDefault(x => x.Name == planetName);
            
            bool areThereSuitable = astronautRepository.Models.Any(x => x.Oxygen > 60);
            if (!areThereSuitable)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            List<IAstronaut> suitableAstro = new List<IAstronaut>();

            foreach (var astro in astronautRepository.Models)
            {
                if (astro.Oxygen > 60)
                {
                    suitableAstro.Add(astro);
                }
            }
            Mission mission = new Mission();
            mission.Explore(planet, suitableAstro);
            missionCounter += 1;
            foreach (var astornaut in suitableAstro)
            {
                if (astornaut.Oxygen==0)
                {
                    deadAstronaut++;
                }
            }
            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronaut);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{missionCounter} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astonaut in astronautRepository.Models)
            {
                sb.AppendLine($"Name: {astonaut.Name}");
                sb.AppendLine($"Oxygen: {astonaut.Oxygen}");
                sb.AppendLine($"Bag items: {(astonaut.Bag.Items.Count == 0 ? "none" : string.Join(", ", astonaut.Bag.Items))}");
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astro = astronautRepository.FindByName(astronautName);
            if (astro == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            astronautRepository.Remove(astro);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
