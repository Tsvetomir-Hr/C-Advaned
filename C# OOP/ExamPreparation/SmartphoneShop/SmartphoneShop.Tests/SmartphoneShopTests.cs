using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {

        [Test]
        public void ConstructorOfShopShouldSetCapacity()
        {
            Shop shop = new Shop(5);

            Assert.AreEqual(5, shop.Capacity);
        }

        [Test]
        public void ConstructorOfShopShouldNotSetCapacityThrows()
        {


            Assert.Throws<ArgumentException>(
                () =>
                {

                    Shop shop = new Shop(-5);

                });
        }
        [Test]
        public void CountOfThePhonesInShop()
        {
            Shop shop = new Shop(5);

            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void AddPhoneShouldWorks()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Nokia", 100);
            shop.Add(smartphone);
            Assert.AreEqual(1, shop.Count);

        }
        [Test]
        public void AddPhoneShouldThrow_NotEnoughCapacityInShop()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Nokia", 100);
            Smartphone smartphone2 = new Smartphone("Motorola", 50);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    shop.Add(smartphone2);

                });
        }
        [Test]
        public void AddPhoneShouldThrowBecauseOfTryingToAddAnExistantPhoneToShop()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Nokia", 100);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    shop.Add(smartphone);

                });
        }
        [Test]
        public void RemoveShouldThrowsBecauseOfNonExistantPhone()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Nokia", 100);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    shop.Remove("Motorola");

                });
        }
        [Test]
        public void RemoveMethodShouldWork()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Nokia", 100);
            Smartphone smartphone2 = new Smartphone("Motorola", 50);
            Smartphone smartphone3 = new Smartphone("Samsung", 200);

            shop.Add(smartphone);
            shop.Add(smartphone2);
            shop.Add(smartphone3);

            shop.Remove(smartphone2.ModelName);

            Assert.AreEqual(2, shop.Count);


        }
        [Test]
        public void TestPhoneShouldThrowsBecauseOfNonExistantPhone()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Nokia", 100);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    shop.TestPhone("Motorola", 20);

                });
        }
        [Test]
        public void TestPhoneShouldThrowsBecauseOfLowBattery()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Nokia", 20);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    shop.TestPhone("Nokia", 50);

                });
        }
        [Test]
        public void TestPhoneShouldWorks()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Nokia", 100);

            shop.Add(smartphone);

            shop.TestPhone("Nokia", 50);

            Assert.AreEqual(50,smartphone.CurrentBateryCharge);

        }
        [Test]
        public void ChargePhoneShouldThrowsBecauseOfNonExistantPhone()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Nokia", 100);

            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    shop.ChargePhone("Motorola");

                });
        }
        [Test]
        public void ChargePhoneShouldWorks()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Nokia", 100);

            shop.Add(smartphone);

            shop.TestPhone("Nokia", 50);

            shop.ChargePhone("Nokia");
            Assert.AreEqual(100,smartphone.CurrentBateryCharge);

        }
    }
}