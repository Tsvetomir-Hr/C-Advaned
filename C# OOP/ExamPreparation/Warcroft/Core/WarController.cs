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
		private readonly List<Character> party;
		private readonly List<Item> itemPool;
		public WarController()
		{
			party = new List<Character>();
			itemPool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];
			Character character = null;
            if (characterType=="Warrior")
            {
				character = new Warrior(name);

			}
			else if (characterType == "Priest")
			{
				character = new Priest(name);

			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType,characterType));
            }
			party.Add(character);
			return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item = null;
            if (itemName=="FirePotion")
            {
				item = new FirePotion();

			}
			else if (itemName == "HealthPotion")
			{
				item = new HealthPotion();

			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
			}
			itemPool.Add(item);
			return string.Format(SuccessMessages.AddItemToPool, itemName);

		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			Character character = party.FirstOrDefault(x => x.Name == characterName);
            if (character==null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty,characterName));
            }
            if (itemPool.Count==0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			Item item = itemPool.Last();
			character.Bag.AddItem(item);
			itemPool.Remove(item);
			return string.Format(SuccessMessages.PickUpItem, characterName,item.GetType().Name);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			Character character = party.FirstOrDefault(x => x.Name == characterName);
			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}
		
			Item item = character.Bag.GetItem(itemName);
            if (item==null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, itemName));
			}
			character.UseItem(item);
			

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);

		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();
            foreach (var character in party.OrderByDescending(x=>x.IsAlive).ThenByDescending(x=>x.Health))
            {
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {(character.IsAlive?"Alive":"Dead")}");
            }
			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string defenderName = args[1];
			Warrior attacker = (Warrior)party.FirstOrDefault(x => x.Name == attackerName);
			Character defender = party.FirstOrDefault(x => x.Name == defenderName);
            if (attacker==null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty,attackerName));
            }
			if (defender == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, defenderName));
			}
	        attacker.EnsureAlive();
			defender.EnsureAlive();
            if (attacker.IsAlive==false)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
			if (defender.IsAlive == false)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
			}
			attacker.Attack(defender);
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(string.Format(SuccessMessages.AttackCharacter,attackerName,defenderName,attacker.AbilityPoints,defenderName,defender.Health,defender.BaseHealth,defender.Armor,defender.BaseArmor));
            if (!defender.IsAlive)
            {
				sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter,defenderName));
            }

			return sb.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string defenderName = args[1];
			Priest healer = (Priest)party.FirstOrDefault(x => x.Name == healerName);
			Character receiver = party.FirstOrDefault(x => x.Name == defenderName);
			if ( healer == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, defenderName));
			}
			healer.EnsureAlive();
			receiver.EnsureAlive();
			if (!healer.IsAlive)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}
			if (!receiver.IsAlive)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}

			healer.Heal(receiver);
			return string.Format(SuccessMessages.HealCharacter,healerName,defenderName,healer.AbilityPoints,defenderName,receiver.Health);
		
		}
	}
}
