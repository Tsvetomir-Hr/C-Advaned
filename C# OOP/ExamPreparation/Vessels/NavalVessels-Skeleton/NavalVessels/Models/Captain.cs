using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullname;
        

        public Captain(string fullName)
        {
            FullName = fullName;
            Vessels = new List<IVessel>();
            CombatExperience = 0;
        }
        public string FullName
        {
            get { return fullname; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullname = value;
            }
        }
        public int CombatExperience { get; private set; }
        public ICollection<IVessel> Vessels { get; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel==null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            Vessels.Add(vessel);
        }
        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
         
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");
            if (Vessels.Count>0)
            {
                foreach (var vessel in Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }
            return sb.ToString().TrimEnd();
            
        }
    }
}
