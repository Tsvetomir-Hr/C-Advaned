using System;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void HeroConstructorShouldInisialize()
    {
        Hero hero = new Hero("Ceco", 1000);

        Assert.AreEqual("Ceco", hero.Name);
        Assert.AreEqual(1000, hero.Level);
    }
    [Test]
    public void CreateHeroShouldWorks()
    {
        Hero hero = new Hero("Ceco", 1000);
        HeroRepository heroRepositoty = new HeroRepository();
        heroRepositoty.Create(hero);

        string heroTostring = $"Successfully added hero {hero.Name} with level {hero.Level}";
        Assert.AreEqual($"Successfully added hero {hero.Name} with level {hero.Level}", heroTostring);
        Assert.AreEqual(1, heroRepositoty.Heroes.Count);

    }
    [Test]
    public void CreateHeroShouldThrowsBecauseHeroIsNull()
    {
        Hero hero = new Hero("ceco", 2);
        hero = null;
        HeroRepository heroRepositoty = new HeroRepository();

        Assert.Throws<ArgumentNullException>(
            () =>
            {
                heroRepositoty.Create(hero);
            });

    }
    [Test]
    public void CreateHeroShouldThrowsBecauseHeroAlreadyExist()
    {
        Hero hero = new Hero("ceco", 2);

        HeroRepository heroRepositoty = new HeroRepository();
        heroRepositoty.Create(hero);

        Assert.Throws<InvalidOperationException>(
            () =>
            {
                heroRepositoty.Create(hero);
            });

    }
    [Test]
    public void RemoveHeroShouldThrowsBecauseHeroIsNull()
    {
        Hero hero = new Hero("ceco", 2);
        hero = null;

        HeroRepository heroRepositoty = new HeroRepository();

        Assert.Throws<ArgumentNullException>(
            () =>
            {
                heroRepositoty.Remove(null);
            });

    }
    [Test]
    public void RemoveHeroShouldThrowsBecauseHeroIsWhiteSpace()
    {
        Hero hero = new Hero(" ", 2);

        HeroRepository heroRepositoty = new HeroRepository();

        Assert.Throws<ArgumentNullException>(
            () =>
            {
                heroRepositoty.Remove(" ");
            });

    }
    [Test]
    public void RemoveHeroShouldWorks()
    {
        Hero hero = new Hero("ceco", 2);

        HeroRepository heroRepositoty = new HeroRepository();

        heroRepositoty.Create(hero);
        bool isRemoved = heroRepositoty.Remove(hero.Name);

        Assert.AreEqual(true, isRemoved);


    }
    [Test]
    public void GetHeroWithHighestLevelShouldWork()
    {
        Hero hero = new Hero("Ceco", 2);
        Hero hero2 = new Hero("Ivan", 6);
        Hero hero3 = new Hero("Gosho", 210);
        Hero hero4 = new Hero("Pesho", 2111);

        HeroRepository heroRepositoty = new HeroRepository();

        heroRepositoty.Create(hero);
        heroRepositoty.Create(hero2);
        heroRepositoty.Create(hero3);
        heroRepositoty.Create(hero4);

        Hero highestLevelHero = heroRepositoty.GetHeroWithHighestLevel();

        Assert.AreEqual(hero4, highestLevelHero);
    }
    [Test]
    public void GetHeroByNameShouldWorks()
    {
        Hero hero = new Hero("Ceco", 2);
        Hero hero2 = new Hero("Ivan", 6);
        Hero hero3 = new Hero("Gosho", 210);
        Hero hero4 = new Hero("Pesho", 2111);

        HeroRepository heroRepositoty = new HeroRepository();

        heroRepositoty.Create(hero);
        heroRepositoty.Create(hero2);
        heroRepositoty.Create(hero3);
        heroRepositoty.Create(hero4);

        Hero heroByName = heroRepositoty.GetHero(hero.Name);

        Assert.AreEqual(hero, heroByName);
    }
    [Test]
    public void HeroesCollectionShouldBeDataFromTheConstructor()
    {
        Hero hero = new Hero("Ceco", 2);
        Hero hero2 = new Hero("Ivan", 6);
        Hero hero3 = new Hero("Gosho", 210);
        Hero hero4 = new Hero("Pesho", 2111);

        HeroRepository heroRepositoty = new HeroRepository();

        heroRepositoty.Create(hero);
        heroRepositoty.Create(hero2);
        heroRepositoty.Create(hero3);
        heroRepositoty.Create(hero4);

        Assert.AreEqual(4,heroRepositoty.Heroes.Count);
    }


}