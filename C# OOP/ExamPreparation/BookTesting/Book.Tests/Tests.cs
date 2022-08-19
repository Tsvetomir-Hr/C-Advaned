namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstrucorShouldSetBookNameAndAuthor()
        {
            Book book = new Book("BeastMaking", "Someone");

            Assert.AreEqual("BeastMaking", book.BookName);
            Assert.AreEqual("Someone", book.Author);
            Assert.AreEqual(0, book.FootnoteCount);
        }
        [Test]
        public void BookNameIsNullThrow()
        {

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Book book = new Book(null, "Someone");
                });
        }
        [Test]
        public void BookNameIsEmptyStringThrow()
        {

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Book book = new Book("", "Someone");
                });
        }
        [Test]
        public void AuthorIsNullThrow()
        {

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Book book = new Book("BeastMaking", null);
                });
        }
        [Test]
        public void AuthorIsEmptyStringThrow()
        {

            Assert.Throws<ArgumentException>(
                () =>
                {
                    Book book = new Book("BeastMaking", "");
                });
        }
        [Test]
        public void AddFootnoteShouldThrowBecauseOfAlreadyExistnatFootNote()
        {
            Book book = new Book("BeastMaking", "Someone");
            book.AddFootnote(12, "Bil sum tuk");
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    book.AddFootnote(12, "Bil sum tuk");
                });
        }
        [Test]
        public void AddFootnoteShouldWorks()
        {
            Book book = new Book("BeastMaking", "Someone");
            book.AddFootnote(12, "Bil sum tuk");
            Assert.AreEqual(1, book.FootnoteCount);
        }
        [Test]
        public void FindFootnoteShouldThrowsBeacauseOfNonExistantFootNote()
        {
            Book book = new Book("BeastMaking", "Someone");
            book.AddFootnote(12, "Bil sum tuk");

            Assert.Throws<InvalidOperationException>(
            () =>
            {
                book.FindFootnote(10);
            });
        }

        [Test]
        public void FindFootnoteShouldWorksAndReturnsTheFootNote()
        {
            Book book = new Book("BeastMaking", "Someone");
            book.AddFootnote(10, "123");

            var footnote = book.FindFootnote(10);
            string returnedFootnoteText = $"Footnote #10: 123";

            Assert.AreEqual(returnedFootnoteText, footnote);

        }
        [Test]
        public void AlterFootnoteShouldThrowsBeacauseOfNonExistantFootNote()
        {
            Book book = new Book("BeastMaking", "Someone");
            book.AddFootnote(12, "Bil sum tuk");

            Assert.Throws<InvalidOperationException>(
            () =>
            {
                book.AlterFootnote(10,"123");
            });
        }
        [Test]
        public void AlterFootnoteShouldWork()
        {
            Book book = new Book("BeastMaking", "Someone");
            book.AddFootnote(12, "Bil sum tuk");

            book.AlterFootnote(12, "...");

            string note = book.FindFootnote(12);

            Assert.AreEqual($"Footnote #12: ...", note);
            
        }
    }
}