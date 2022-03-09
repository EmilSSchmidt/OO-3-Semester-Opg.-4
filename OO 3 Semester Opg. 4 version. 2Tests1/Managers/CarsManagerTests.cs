using Microsoft.VisualStudio.TestTools.UnitTesting;
using OO_3_Semester_Opg._4_version._2.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obligatorisk_Opgave_3_semester;

namespace OO_3_Semester_Opg._4_version._2.Managers.Tests
{
    [TestClass()]
    public class CarsManagerTests

    {
        public CarsManager _manager = new CarsManager();

        [TestMethod] 
        
        public void GetAllTest()
        {
            Assert.AreEqual(4, _manager.GetAll().Count);

        }


        [TestMethod]
        public void TestGetByID()
        {
            Car car = _manager.GetById(1);
            //checking the first Car
            Assert.IsNotNull(car);

            Assert.AreEqual("BilModel1", car.Model);
            //checking an ID that shouldn't exist
            Assert.IsNull(_manager.GetById(25));
        }

        [TestMethod]
        public void TestAddCar()
        {
            //Reads the count before adding so we can compare it to the number after adding
            int beforeAddCount = _manager.GetAll().Count;
            //creates a variable with the Id we assign, should be overridden when the manager add the Car
            int defaultId = 0;

            Car newCar = new Car(defaultId, "BilModel1", 1000, "AA12345" );
            //Adding the Car, and storing the result in a variable
            Car addCar = _manager.AddCar(newCar);
            //stores the newly assigned Id
            int newID = addCar.Id;
            //Checking that the manager assigns a new ID
            Assert.AreNotEqual(defaultId, newID);
            //Checking that the count of the car is now 1 more than before
            Assert.AreEqual(beforeAddCount + 1, _manager.GetAll().Count);

        }

        [TestMethod]
        public void TestDeleteCar()
        {
            Car deletedCar = _manager.Delete(2);

            Assert.IsNotNull(deletedCar);

            Assert.AreEqual("BilModel2", deletedCar.Model);
           

            //checks that if we ask to delete an Car with an Id that doesn't exist, that it returns null
            Assert.IsNull(_manager.Delete(30));
        }


    }
}