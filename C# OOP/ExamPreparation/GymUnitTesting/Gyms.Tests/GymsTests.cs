using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void Test_Athlete_Constrictor()
        {

            Athlete athlete = new Athlete("Ceco");

            Assert.AreEqual("Ceco", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);

        }
        [Test]
        public void Test_Gym_Constrictor()
        {

            Gym gym = new Gym("33", 10);

            Assert.AreEqual("33", gym.Name);
            Assert.AreEqual(10, gym.Capacity);


            Athlete athlete = new Athlete("Ceco");

            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);

        }
        [Test]
        public void Test_Gym_Creation_With_Null_Name_Throws()
        {
            Assert.Throws<ArgumentNullException>(
                () =>
                {

                    Gym gym = new Gym(null, 10);

                });
       
        }
        [Test]
        public void Test_Gym_Creation_With_EmptyString_Name_Throws()
        {
         
            Assert.Throws<ArgumentNullException>(
              () =>
              {

                  Gym gym = new Gym("", 10);

              });
        }

        [Test]
        public void Test_Gym_Creation_With_Negative_Capacity_Throws()
        {
            Assert.Throws<ArgumentException>(
                () =>
                {

                    Gym gym = new Gym("123", -1);

                });
       
        }
        [Test]
        public void Test_Gym_Adding_Athlete_With_Full_Capacity_Throws()
        {

            Gym gym = new Gym("33",1);
            Athlete athlete = new Athlete("Ceco");
            Athlete athlete2 = new Athlete("Pesho");
            gym.AddAthlete(athlete);


            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    gym.AddAthlete(athlete2);
                });


        }
        [Test]
        public void Test_Gym_Remove_Athlete_Possitive()
        {

            Gym gym = new Gym("33", 3);
            Athlete athlete = new Athlete("Ceco");
            Athlete athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            gym.RemoveAthlete(athlete.FullName);

            Assert.AreEqual(1, gym.Count);
        }
        [Test]
        public void Test_Gym_Remove_NullAthlete_Throws()
        {

            Gym gym = new Gym("33", 3);
            Athlete athlete = new Athlete("Ceco");
            Athlete athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

         
            Assert.Throws<InvalidOperationException>(
               () =>
               {
                   gym.RemoveAthlete("12314341");
               });


        }
        [Test]
        public void Test_Injure_Athlete_Possitive()
        {

            Gym gym = new Gym("33", 3);
            Athlete athlete = new Athlete("Ceco");
            Athlete athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            var returnedAthlete = gym.InjureAthlete(athlete.FullName);

            Assert.AreEqual(true,athlete.IsInjured);
            Assert.AreSame(athlete,returnedAthlete);
        }
        [Test]
        public void Test_Injure_NonExistant_Athlete_Throws()
        {

            Gym gym = new Gym("33", 3);
            Athlete athlete = new Athlete("Ceco");
            Athlete athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            Assert.Throws<InvalidOperationException>(
             () =>
             {
                 gym.InjureAthlete("Ceco123");
             });
        }
        [Test]
        public void Test_Gym_Report_Possitive()
        {

            Gym gym = new Gym("33", 3);
            Athlete athlete = new Athlete("Ceco");
            Athlete athlete2 = new Athlete("Pesho");

            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete2);

            var returnedAthlete = gym.InjureAthlete(athlete.FullName);

            var report = gym.Report();

            Assert.AreEqual("Active athletes at 33: Pesho", gym.Report());
        }
        [Test]
        public void Test_Gym_Report_With_Empty_Gym()
        {

            Gym gym = new Gym("33", 3);
            

            var report = gym.Report();

            Assert.AreEqual("Active athletes at 33: ", gym.Report());
        }
    }
}
