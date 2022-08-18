﻿using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            Targets = new List<string>();
        }
        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value; 
            }
        }

        public ICaptain Captain
        {
            get { return captain; }
             set 
            {
                if (value==null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                captain = value; 
            }
        }

        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets { get; }

        public void Attack(IVessel target)
        {

            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }
            target.ArmorThickness -= this.MainWeaponCaliber;
            if (target.ArmorThickness<0)
            {
                target.ArmorThickness = 0;
            }
            Targets.Add(target.Name);
        }
        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");
            sb.AppendLine($" *Targets: {(Targets.Count==0? "None" : string.Join(", ",Targets))}");

            return sb.ToString().TrimEnd();
        }

    }
}
