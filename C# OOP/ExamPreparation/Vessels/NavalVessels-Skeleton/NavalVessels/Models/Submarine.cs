using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 200)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < 200)
            {
                this.ArmorThickness = 200;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode == false)
            {
                //flips
                SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else if (SubmergeMode == true)
            {
                SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {(SubmergeMode == true ? "ON" : "OFF")}");
            return sb.ToString().TrimEnd();
        }
    }
}
