﻿using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Backpack : IBag
    {
        private readonly List<string> items;

        public ICollection<string> Items => items;

        public Backpack()
        {
            items = new List<string>();
        }
    }
}