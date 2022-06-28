using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            SoulMaster soul = new SoulMaster("Hex", 5);
            Console.WriteLine(soul);
        }
    }
}