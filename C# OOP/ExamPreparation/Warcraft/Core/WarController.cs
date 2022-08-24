using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> characters;
        private readonly List<Item> itemPool;

        public WarController()
        {
            characters = new List<Character>();
            itemPool = new List<Item>();

        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];


            Character character = null;
            if (characterType == "Warrior")
            {
                character = new Warrior(name);
            }
            else if (characterType == "Priest")
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            characters.Add(character);
            return String.Format(SuccessMessages.JoinParty, name);

        }

        public string AddItemToPool(string[] args)
        {
            string name = args[0];

            Item item = null;
            if (name == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else if (name == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, name));
            }
            itemPool.Add(item);
            return String.Format(SuccessMessages.AddItemToPool, name);


        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = characters.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (!itemPool.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            Item item = itemPool.LastOrDefault();
            itemPool.Remove(item);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = characters.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return String.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                sb.AppendLine(String.Format(SuccessMessages.CharacterStats, item.Name, item.Health, item.BaseHealth, item.Armor, item.BaseArmor,
                    item.IsAlive ? "Alive" : "Dead"));
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string recieverName = args[1];
            Character attacker = characters.FirstOrDefault(x => x.Name == attackerName);

            Character reciever = characters.FirstOrDefault(x => x.Name == recieverName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            if (reciever == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, recieverName));
            }
            if (!(attacker is IAttacker))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }


                ((IAttacker)attacker).Attack(reciever);

                string result = string.Format(SuccessMessages.AttackCharacter, attackerName, recieverName, attacker.AbilityPoints, recieverName, reciever.Health, reciever.BaseHealth, reciever.Armor, reciever.BaseArmor);
                if (!reciever.IsAlive)
                {
                    result += Environment.NewLine + string.Format(SuccessMessages.AttackKillsCharacter, recieverName);
                }

                return result;

        }
        public string Heal(string[] args)
        {
            string healerName = args[0];
            string recieverName = args[1];
            Character healer = characters.FirstOrDefault(x => x.Name == healerName);

            Character reciever = characters.FirstOrDefault(x => x.Name == recieverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            if (reciever == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, recieverName));
            }

            if (!(healer is IHealer))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
            ((IHealer)healer).Heal(reciever);

            return String.Format(SuccessMessages.HealCharacter, healer.Name, reciever.Name, healer.AbilityPoints, reciever.Name, reciever.Health);
        }
    }
}
