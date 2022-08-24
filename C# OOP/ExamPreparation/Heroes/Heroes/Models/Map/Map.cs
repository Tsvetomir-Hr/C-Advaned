using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> barbarians = new List<IHero>();
            List<IHero> knights = new List<IHero>();
            foreach (IHero hero in players)
            {
                if (hero.GetType().Name == "Knight")
                {
                    knights.Add(hero);
                }
                else
                {
                    barbarians.Add(hero);
                }
            }

            while (true)
            {
                for (int i = 0; i < knights.Count; i++)
                {
                    if (knights[i].IsAlive != false)
                    {
                        foreach (var barbarian in barbarians)
                        {
                            if (barbarian.IsAlive)
                            {
                                barbarian.TakeDamage(knights[i].Weapon.DoDamage());
                            }
                        }
                    }
                }
                for (int i = 0; i < barbarians.Count; i++)
                {
                    if (barbarians[i].IsAlive != false)
                    {
                        foreach (var knight in knights)
                        {
                            if (knight.IsAlive)
                            {
                                knight.TakeDamage(barbarians[i].Weapon.DoDamage());
                            }

                        }
                    }
                }

                int deadBarb = 0;
                int deadKnights = 0;
                foreach (var barb in barbarians)
                {
                    if (barb.IsAlive == false)
                    {
                        deadBarb++;

                    }
                }
                foreach (var item in knights)
                {
                    if (item.IsAlive == false)
                    {
                        deadKnights++;

                    }
                }
                if (barbarians.Count == deadBarb)
                {
                    return $"The knights took {deadKnights} casualties but won the battle.";
                }
                if (knights.Count == deadKnights)
                {
                    return $"The barbarians took {deadBarb} casualties but won the battle.";
                }
            }
        }
    }
}
