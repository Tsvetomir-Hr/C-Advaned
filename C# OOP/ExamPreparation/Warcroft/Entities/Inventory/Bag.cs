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
        public Bag(int capacity)
        {
            Capacity = 100;
            items = new List<Item>();
        }

        public int Capacity { get; set; }
        public int Load => this.Items.Select(x=>x.Weight).Sum();
        
        public IReadOnlyCollection<Item> Items => items;

        public void AddItem(Item item)
        {
            if (this.Load+item.Weight>this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
                
            }
                items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            Item item = items.FirstOrDefault(x => x.GetType().Name == name);
            if (item==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag,name));
            }
            items.Remove(item);
            return item;
        }
    }
}
