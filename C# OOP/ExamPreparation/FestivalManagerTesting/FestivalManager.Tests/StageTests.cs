// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
   
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class StageTests
    {
        [Test]
        public void StageConstructorShouldWork()
        {
            Stage stage = new Stage();

            Assert.AreEqual(0, stage.Performers.Count);

        }
        [Test]
        public void ValidateAddPerformer()
        {
            Stage stage = new Stage();
            Assert.Throws<ArgumentNullException>(
                () => stage.AddPerformer(null));

            Performer performer = new Performer("Ceco", "Hristov", 17);

            Assert.Throws<ArgumentException>(
                 () => stage.AddPerformer(performer));
            performer = new Performer("Ceco", "Hristov", 25);
            stage.AddPerformer(performer);

            Assert.AreEqual(1, stage.Performers.Count);

        }
        [Test]
        public void ValidateAddSong()
        {
            Stage stage = new Stage();
            Assert.Throws<ArgumentNullException>(
                () => stage.AddSong(null));

            Song song = new Song("Without me",TimeSpan.FromSeconds(50));


            Assert.Throws<ArgumentException>(
                 () => stage.AddSong(song));

            song = new Song("Without me", TimeSpan.FromSeconds(120));

            stage.AddSong(song);

        }
        [Test]
        public void ValidateAddSongToPerformer()
        {
            Stage stage = new Stage();
            Assert.Throws<ArgumentNullException>(
                () => stage.AddSong(null));
            Assert.Throws<ArgumentNullException>(
                () => stage.AddPerformer(null));

            Song song = new Song("Without me", TimeSpan.FromSeconds(120));
            var performer = new Performer("Ceco", "Hristov", 25);

            stage.AddSong(song);
            stage.AddPerformer(performer);
            stage.AddSongToPerformer(song.Name,performer.FullName);

            Assert.AreEqual(1, performer.SongList.Count);

            Assert.AreEqual("Without me (02:00) will be performed by Ceco Hristov", $"{song} will be performed by {performer.FullName}");
        }

        [Test]
        public void Play()
        {
            Stage stage = new Stage();

            Song song = new Song("123", TimeSpan.FromSeconds(70));
            Performer performer = new Performer("Ceco", "Hristov", 20);
            stage.AddSong(song);
            stage.AddPerformer(performer);
            stage.AddSongToPerformer("123", performer.FullName);
         
            Assert.AreEqual("1 performers played 1 songs", $"{stage.Performers.Count} performers played {stage.Performers.Select(x=>x.SongList.Count).Sum()} songs");
        }

       


    }
}