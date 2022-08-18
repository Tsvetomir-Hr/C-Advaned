using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        [Test]
        public void ItemConstrucotrShouldWork()
        {
            Item item = new Item("Ceco", "123");

            Assert.AreEqual("Ceco", item.Owner);
            Assert.AreEqual("123", item.ItemId);
        }
        [Test]
        public void BankConstrucotrShouldWork()
        {
            BankVault bankVault = new BankVault();

            Assert.AreEqual(12, bankVault.VaultCells.Count);


        }
        [Test]
        public void AddItemShouldThrowBecauseOfNonExistantCell()
        {
            BankVault bankVault = new BankVault();

            Item item = new Item("Ceco", "123");

            Assert.Throws<ArgumentException>(
                () =>
                {
                    bankVault.AddItem("d4", item);
                });
        }
        [Test]
        public void AddItemShouldThrowBecauseAlreadyTakenCell()
        {
            BankVault bankVault = new BankVault();

            Item item = new Item("Ceco", "123");
            Item item2 = new Item("Mariela", "111");

            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(
                () =>
                {
                    bankVault.AddItem("A1", item2);
                });
        }
        [Test]
        public void AddItemShouldThrowBecauseItemAlreadyIsInCell()
        {
            BankVault bankVault = new BankVault();

            Item item = new Item("Ceco", "123");

            bankVault.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    bankVault.AddItem("A1", item);
                });
        }
        [Test]
        public void AddItemShouldWork()
        {
            BankVault bankVault = new BankVault();

            Item item = new Item("Ceco", "123");

            bankVault.AddItem("A1", item);
            Assert.AreEqual("123", bankVault.VaultCells.Values.Where(x=>x.ItemId==item.ItemId));
        }
    }
}