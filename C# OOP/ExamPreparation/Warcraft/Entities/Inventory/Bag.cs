using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> items;

        public Bag(int capacity=100)
        {
            items = new List<Item>();
         Capacity = capacity;
            
        }
        public int Capacity { get ; set ; }

        public int Load => Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => items;
        public void AddItem(Item item)
        {
            if (Load + item.Weight>Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            Item item = items.FirstOrDefault(x => x.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));   
            }
            items.Remove(item);
            return item;
        }
    }
}
