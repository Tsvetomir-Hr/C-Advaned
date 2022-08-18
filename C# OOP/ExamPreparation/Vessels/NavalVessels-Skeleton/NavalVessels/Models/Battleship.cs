using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, 300)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            if (this.ArmorThickness<300)
            {
                this.ArmorThickness = 300;
            }
        }

        public void ToggleSonarMode()
        {
            if (SonarMode==false)
            {
                //flips
                SonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else if (SonarMode==true)
            {
                SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {(SonarMode==true?"ON":"OFF")}");
            return sb.ToString().TrimEnd();
        }
    }
}
