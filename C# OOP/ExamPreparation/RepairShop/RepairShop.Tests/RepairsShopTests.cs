using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void GarageConstructorShouldWorkProperly()
            {

                Garage garage = new Garage("Gumata", 2);
                Assert.AreEqual(2, garage.MechanicsAvailable);
                Assert.AreEqual("Gumata", garage.Name);
               
                Assert.AreEqual(0, garage.CarsInGarage);

            }
            [Test]
            public void GarageNameWorks()
            {

                Garage garage = new Garage("Gumata", 2);
                Assert.AreEqual("Gumata", garage.Name);


            }
            [Test]
            public void GarageNameIsNullThrows()
            {
                Assert.Throws<ArgumentNullException>(
                    () =>
                    {
                        Garage garage = new Garage(null, 2);
                    });


            }
            [Test]
            public void GarageNameIsEmptyStringThrows()
            {
                Assert.Throws<ArgumentNullException>(
                    () =>
                    {
                        Garage garage = new Garage("", 2);
                    });


            }
            [Test]
            public void GarageMechanicsAvailable()
            {
                Garage garage = new Garage("Gumata", 2);
                Assert.AreEqual(2, garage.MechanicsAvailable);
            }
            [Test]
            public void GarageMechanicsCountMustBeBiggerThanZero()
            {
                
                Assert.Throws<ArgumentException>(
                    () =>
                    {
                        Garage garage = new Garage("Gumata", 0);
                    });
            }
            [Test]
            public void CarsInGarageCount()
            {

                Garage garage = new Garage("Gumi",3);
                Car car = new Car("Golf",1);
                Car car1 = new Car("Passat",2);
                Car car2 = new Car("Audi",3);
                garage.AddCar(car);
                garage.AddCar(car1);
                garage.AddCar(car2);
                Assert.AreEqual(3,garage.CarsInGarage);

            }
            [Test]
            public void AddCarToGarageWorks()
            {
                Garage garage = new Garage("Gumi", 3);
                Car car = new Car("Golf", 1);
                Car car1 = new Car("Passat", 2);
                Car car2 = new Car("Audi", 3);
                garage.AddCar(car);
                garage.AddCar(car1);

                Assert.AreEqual(2, garage.CarsInGarage);

            }
            [Test]
            public void AddCarNoMachanicsAvailableThrows()
            {
                Garage garage = new Garage("Gumi", 2);
                Car car = new Car("Golf", 1);
                Car car1 = new Car("Passat", 2);
                Car car2 = new Car("Audi", 3);
                garage.AddCar(car);
                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(
                    () =>
                    {
                        garage.AddCar(car2);
                    });


            }
            [Test]
            public void Fix_CarDoNotExist_Throws()
            {
                Garage garage = new Garage("Gumi", 5);
                Car car = new Car("Golf", 1);
                Car car1 = new Car("Passat", 2);
                Car car2 = new Car("Audi", 3);
                garage.AddCar(car);
                garage.AddCar(car1);

                Assert.Throws<InvalidOperationException>(
                    () =>
                    {
                        garage.FixCar("Bmw");
                    });


            }
            [Test]
            public void FixCarAndReturnCarWihtoutIssues()
            {
                Garage garage = new Garage("Gumi", 5);
                Car car = new Car("Golf", 1);
           
                garage.AddCar(car);

                var carToReturn = garage.FixCar("Golf");

                Assert.AreEqual(0,carToReturn.NumberOfIssues);

                Assert.AreSame(car, carToReturn);

            }
            [Test]
            public void RemoveFixedCarWorks()
            {
                Garage garage = new Garage("Gumi", 5);
                Car car = new Car("Golf", 1);

                garage.AddCar(car);

                var carToReturn = garage.FixCar("Golf");

                Assert.AreEqual(0, carToReturn.NumberOfIssues);
                var fixedCarRemoved = garage.RemoveFixedCar();
                Assert.AreEqual(0, garage.CarsInGarage);

            }
            [Test]
            public void RemoveFixedCarNoCarsThrows()
            {
                Garage garage = new Garage("Gumi", 5);
                Car car = new Car("Golf", 1);

                garage.AddCar(car);

                var carToReturn = garage.FixCar("Golf");

                Assert.AreEqual(0, carToReturn.NumberOfIssues);
                garage.RemoveFixedCar();
                Assert.AreEqual(0, garage.CarsInGarage);

                Assert.Throws<InvalidOperationException>(
                    () =>
                    {
                        garage.RemoveFixedCar();
                    });
            }
            [Test]
            public void ReportWhenAllCarsAreFixed()
            {
                Garage garage = new Garage("Gumi", 5);
                Car car = new Car("Golf", 1);

                garage.AddCar(car);

                var carToReturn = garage.FixCar("Golf");


                garage.RemoveFixedCar();

                var report = garage.Report();

                Assert.AreEqual("There are 0 which are not fixed: .", report);
            }
            [Test]
            public void ReportWhenNotAllCarsAreFixed()
            {
                Garage garage = new Garage("Gumi", 5);
                Car car = new Car("Golf", 1);
                Car car2 = new Car("Audi",100);
                garage.AddCar(car);
                garage.AddCar(car2);

                garage.FixCar("Golf");

                garage.RemoveFixedCar();

                var report = garage.Report();

                Assert.AreEqual("There are 1 which are not fixed: Audi.", report);
            }





        }
    }
}