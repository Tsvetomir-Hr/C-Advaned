namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        [Test]
        public void FishConstructorShouldWork()
        {
            Fish fish = new Fish("Ceco");

            Assert.AreEqual("Ceco", fish.Name);
            Assert.AreEqual(true, fish.Available);
        }
        [Test]
        public void AquariumConstructorShouldWork()
        {
            Aquarium aquarium = new Aquarium("pri ribite", 10);
            Fish fish = new Fish("Ceco");

            Assert.AreEqual("pri ribite", aquarium.Name);
            Assert.AreEqual(10, aquarium.Capacity);
            Assert.AreEqual(0, aquarium.Count);
        }
        [Test]
        public void AquariumSetNameShouldThrowBecauseOfNull()
        {

            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    Aquarium aquarium = new Aquarium(null, 10);

                });

        }
        [Test]
        public void AquariumSetNameShouldThrowBecauseOfEmptyString()
        {

            Assert.Throws<ArgumentNullException>(
                () =>
                {
                    Aquarium aquarium = new Aquarium("", 10);

                });

        }
        [Test]
        public void AquariumSetCapacityShouldThrowBecauseOfNegativeCapacity()
        {

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Aquarium aquarium = new Aquarium("123", -1);

                });

        }
        [Test]
        public void AquariumAddFishShouldThrowBecauseOfFullAquarium()
        {
            Aquarium aquarium = new Aquarium("123", 1);
            Fish fish = new Fish("Ceco");
            Fish fish2 = new Fish("Mariela");
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    aquarium.Add(fish2);
                });

        }
        [Test]
        public void AquariumAddFishShouldWork()
        {
            Aquarium aquarium = new Aquarium("123", 5);
            Fish fish = new Fish("Ceco");
            Fish fish2 = new Fish("Mariela");
            aquarium.Add(fish);
            aquarium.Add(fish2);

            Assert.AreEqual(2,aquarium.Count);

        }
        [Test]
        public void AquariumRemoveFishShouldThrowBecauseOfNonExistantFish()
        {
            Aquarium aquarium = new Aquarium("123", 1);
            Fish fish = new Fish("Ceco");
           
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    aquarium.RemoveFish("Ivan");
                });

        }
        [Test]
        public void AquariumRemoveFishShouldWork()
        {
            Aquarium aquarium = new Aquarium("123", 1);
            Fish fish = new Fish("Ceco");

            aquarium.Add(fish);

            aquarium.RemoveFish("Ceco");
            Assert.AreEqual(0,aquarium.Count);

        }
        [Test]
        public void AquariumSellFishShouldThrowBecauseOfNonExistantFish()
        {
            Aquarium aquarium = new Aquarium("123", 1);
            Fish fish = new Fish("Ceco");

            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    aquarium.SellFish("Ivan");
                });

        }
        [Test]
        public void AquariumSellFishShouldWork()
        {
            Aquarium aquarium = new Aquarium("123", 5);
            Fish fish = new Fish("Ceco");
            Fish fish2 = new Fish("Cecoto");

            aquarium.Add(fish);
            aquarium.Add(fish2);
            var requestedFish = aquarium.SellFish("Cecoto");
            Assert.AreEqual(false, fish2.Available);
            
            Assert.AreEqual(requestedFish,fish2);

        }
        [Test]
        public void Report()
        {
            var aquarium = new Aquarium("Akulite", 3);
            Fish fish = new Fish("Ceco");
            Fish fish2 = new Fish("Mariela");
            aquarium.Add(fish);
            aquarium.Add(fish2);
            string report = aquarium.Report();
           
            Assert.AreEqual("Fish available at Akulite: Ceco, Mariela", report);
        }

    }
}
