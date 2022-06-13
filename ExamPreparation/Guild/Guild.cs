using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (Count<Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player player = roster.FirstOrDefault(x => x.Name == name);
            if (player == null)
            {
                return false;
            }
            roster.Remove(player);
            return true;
        }
        public void PromotePlayer(string name)
        {
          Player player = roster.First(x => x.Name == name);
            if (player.Rank!="Member")
            {
                player.Rank = "Member";
            }
            
        }
        public void DemotePlayer(string name)
        {
            Player player = roster.First(x => x.Name == name);
            if (player.Rank!="Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> removedPlayers = new List<Player>();

            foreach (var player in roster)
            {
                if (player.Class==@class)
                {
                    removedPlayers.Add(player);
                }
            }
            roster.RemoveAll(x => x.Class == @class);
            return removedPlayers.ToArray();
        
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();   
        }
           

    }
}
