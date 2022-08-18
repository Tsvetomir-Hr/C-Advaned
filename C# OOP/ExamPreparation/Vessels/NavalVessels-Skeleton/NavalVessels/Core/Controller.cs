using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private readonly VesselRepository vessels;
        private readonly List<ICaptain> captains;
        public Controller()
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == selectedCaptainName);
            IVessel vessel = vessels.FindByName(selectedVesselName);
            if (captain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }
            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }
            if (vessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }
            vessel.Captain = captain;
            captain.Vessels.Add(vessel);
            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attcker = vessels.FindByName(attackingVesselName);
            IVessel defender = vessels.FindByName(defendingVesselName);
            if (attcker==null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            else if (defender==null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }
            if (attcker.ArmorThickness==0 )
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            else if (defender.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }
            attcker.Attack(defender);
            attcker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();
            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defender.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.FirstOrDefault(x => x.FullName == captainFullName);
            return captain.Report();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);
            if (captains.Contains(captain))
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            captains.Add(captain);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = null;
            if (vesselType == "Submarine")
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == "Battleship")
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else
            {
                return string.Format(OutputMessages.InvalidVesselType);
            }
            if (vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }
            else
            {
                vessels.Add(vessel);
                return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
            }
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            vessel.RepairVessel();
            return $"Vessel {vesselName} was repaired.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);
            
            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }
            if (vessel.GetType().Name == "Battleship")
            {

                Battleship battleship = (Battleship)vessel;
                battleship.ToggleSonarMode();
                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else
            {
                Submarine submarine = (Submarine)vessel;
                submarine.ToggleSubmergeMode();
                return $"Submarine {vesselName} toggled submerge mode.";
            }
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            return vessel.ToString();
        }
    }
}
