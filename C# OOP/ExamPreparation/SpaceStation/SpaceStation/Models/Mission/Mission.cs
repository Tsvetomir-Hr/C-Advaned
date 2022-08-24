using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {

          
            foreach (var astronaout in astronauts)
            {
              
                    if (planet.Items.Count==0)
                    {
                        return;
                    }

                    List<string> itemsToRemove = new List<string>();

                    foreach (var item in planet.Items)

                    {
                        if (astronaout.Oxygen<=0)
                        {
                            break;
                        }
                        astronaout.Bag.Items.Add(item);
                        astronaout.Breath();
                        itemsToRemove.Add(item);
                    }
                    foreach (var item in itemsToRemove)
                    {
                        if (planet.Items.Contains(item))
                        {
                            planet.Items.Remove(item);
                        }
                    }
                

            }
        }
    }
}
