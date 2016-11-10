namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;    

    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Data;

    using NUnit.Framework;
    using Telerik.JustMock;
    
    [TestFixture]
    public class CarsControllerTests
    {
        [Test]
        public void Index_ReturnsAllCars_IfValidCarsRepositoryPassedToCarsControllerConstructor()
        {
            // Arrange
            var carsCollection = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };

            ICarsRepository carsRepositoryMocked = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => carsRepositoryMocked.All()).Returns(carsCollection);

            CarsController carsController = new CarsController(carsRepositoryMocked);

            // Act
            var model = (ICollection<Car>)this.GetModel(() => carsController.Index());

            // Assert
            CollectionAssert.AreEqual(carsCollection, model);
        }

        [Test]
        public void Add_ThrowsArgumentNullException_IfCarIsNull()
        {
            // Arrange
            ICarsRepository carsRepositoryMocked = Mock.Create<ICarsRepository>();

            CarsController carsController = new CarsController(carsRepositoryMocked);

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => carsController.Add(null));
        }

        [Test]
        public void Add_ThrowsArgumentNullException_IfCarMakeIsNull()
        {
            // Arrange
            ICarsRepository carsRepositoryMocked = Mock.Create<ICarsRepository>();

            CarsController carsController = new CarsController(carsRepositoryMocked);

            var car = new Car
            {
                Id = 15,
                Make = null,
                Model = "330d",
                Year = 2014
            };

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => carsController.Add(car));
        }

        [Test]
        public void Add_ThrowsArgumentNullException_IfCarMakeIsEmptyString()
        {
            // Arrange
            ICarsRepository carsRepositoryMocked = Mock.Create<ICarsRepository>();

            CarsController carsController = new CarsController(carsRepositoryMocked);

            var car = new Car
            {
                Id = 15,
                Make = string.Empty,
                Model = "330d",
                Year = 2014
            };

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => carsController.Add(car));
        }

        [Test]
        public void Add_ThrowsArgumentNullException_IfCarModelIsNull()
        {
            // Arrange
            ICarsRepository carsRepositoryMocked = Mock.Create<ICarsRepository>();

            CarsController carsController = new CarsController(carsRepositoryMocked);

            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = null,
                Year = 2014
            };

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => carsController.Add(car));
        }

        [Test]
        public void Add_ThrowsArgumentNullException_IfCarModelIsEmptyString()
        {
            // Arrange
            ICarsRepository carsRepositoryMocked = Mock.Create<ICarsRepository>();

            CarsController carsController = new CarsController(carsRepositoryMocked);

            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = string.Empty,
                Year = 2014
            };

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => carsController.Add(car));
        }

        [Test]
        public void Add_ReturnsADetail_IfValidCarDataPassed()
        {
            // Arrange
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            ICarsRepository carsRepositoryMocked = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => carsRepositoryMocked.Add(Arg.IsAny<Car>())).DoNothing();
            Mock.Arrange(() => carsRepositoryMocked.GetById(Arg.AnyInt)).Returns(car);

            CarsController carsController = new CarsController(carsRepositoryMocked);

            // Act
            var model = (Car)this.GetModel(() => carsController.Add(car));

            // Assert
            Assert.AreEqual(car.Id, model.Id);
            Assert.AreEqual(car.Make, model.Make);
            Assert.AreEqual(car.Model, model.Model);
            Assert.AreEqual(car.Year, model.Year);
        }

        [Test]
        public void Details_ThrowsArgumentNullException_IfCarIsNull()
        {
            // Arrange
            ICarsRepository carsRepositoryMocked = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => carsRepositoryMocked.GetById(Arg.AnyInt)).Returns((Car)null);

            CarsController carsController = new CarsController(carsRepositoryMocked);

            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => carsController.Add(car));
        }

        [Test]
        public void Details_ReturnsCar_WhenCarExistsAndCorrectIdIsPassed()
        {
            // Arrange
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            ICarsRepository carsRepositoryMocked = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => carsRepositoryMocked.GetById(Arg.AnyInt)).Returns(car);

            CarsController carsController = new CarsController(carsRepositoryMocked);

            // Act
            var model = (Car)this.GetModel(() => carsController.Details(car.Id));

            // Assert
            Assert.AreEqual(car, model);
        }

        [Test]
        public void Search_ReturnsCarsCollection_WhenNullPassedAsSearchCondition()
        {
            // Arrange
            var carsCollection = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };

            ICarsRepository carsRepositoryMocked = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => carsRepositoryMocked.Search(Arg.AnyString)).Returns(carsCollection);

            CarsController carsController = new CarsController(carsRepositoryMocked);

            // Act
            var model = (ICollection<Car>)this.GetModel(() => carsController.Search(null));

            // Assert
            CollectionAssert.AreEqual(carsCollection, model);
        }

        [Test]
        public void Search_ReturnsCarsCollection_WhenEmptyStringPassedAsSearchCondition()
        {
            // Arrange
            var carsCollection = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };

            ICarsRepository carsRepositoryMocked = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => carsRepositoryMocked.Search(Arg.AnyString)).Returns(carsCollection);

            CarsController carsController = new CarsController(carsRepositoryMocked);

            // Act
            var model = (ICollection<Car>)this.GetModel(() => carsController.Search(string.Empty));

            // Assert
            CollectionAssert.AreEqual(carsCollection, model);
        }

        [Test]
        public void Search_ReturnsFilteredCarsCollection_WhenValidSearchConditionAsStringWithCarMakePassed()
        {
            // Arrange
            var carsCollection = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };

            string condition = "Opel";

            ICollection<Car> filteredCarsCollection = carsCollection.FindAll(car => car.Make == condition);

            IDatabase databaseMocked = Mock.Create<IDatabase>();
            Mock.Arrange(() => databaseMocked.Cars).Returns(carsCollection);

            ICarsRepository carsRepository = new CarsRepository(databaseMocked);
            CarsController carsController = new CarsController(carsRepository);

            // Act
            var model = (ICollection<Car>)this.GetModel(() => carsController.Search(condition));

            // Assert
            CollectionAssert.AreEqual(filteredCarsCollection, model);
        }

        [Test]
        public void Search_ReturnsFilteredCarsCollection_WhenValidSearchConditionAsStringWithCarModelPassed()
        {
            // Arrange
            var carsCollection = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };

            string condition = "330d";

            ICollection<Car> filteredCarsCollection = carsCollection.FindAll(car => car.Model == condition);

            IDatabase databaseMocked = Mock.Create<IDatabase>();
            Mock.Arrange(() => databaseMocked.Cars).Returns(carsCollection);

            ICarsRepository carsRepository = new CarsRepository(databaseMocked);
            CarsController carsController = new CarsController(carsRepository);

            // Act
            var model = (ICollection<Car>)this.GetModel(() => carsController.Search(condition));

            // Assert
            CollectionAssert.AreEqual(filteredCarsCollection, model);
        }

        [Test]
        public void Sort_ThrowsArgumentException_IfInvalidParameterPassed()
        {
            // Arrange
            var carsCollection = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };

            IDatabase databaseMocked = Mock.Create<IDatabase>();
            Mock.Arrange(() => databaseMocked.Cars).Returns(carsCollection);

            ICarsRepository carsRepository = new CarsRepository(databaseMocked);
            CarsController carsController = new CarsController(carsRepository);

            string invalidParameter = "qwerty";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => carsController.Sort(invalidParameter));
        }

        [Test]
        public void Sort_ReturnsCarsCollectionSortedByMake_IfValidStringParameterPassed()
        {
            // Arrange
            var carsCollection = new List<Car>
            {
                new Car { Id = 3, Make = "Porsche", Model = "Carrera", Year = 2015 },
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 5, Make = "Volvo", Model = "S80", Year = 2000 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
                new Car { Id = 6, Make = "Skoda", Model = "Fabia", Year = 2011 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
            };

            IDatabase databaseMocked = Mock.Create<IDatabase>();
            Mock.Arrange(() => databaseMocked.Cars).Returns(carsCollection);

            ICarsRepository carsRepository = new CarsRepository(databaseMocked);
            CarsController carsController = new CarsController(carsRepository);

            ICollection<Car> carsCollectionSortedByMake = carsCollection
                .OrderBy(car => car.Make)
                .ToList();

            // Act
            var model = (ICollection<Car>)this.GetModel(() => carsController.Sort("make"));

            // Assert
            CollectionAssert.AreEqual(carsCollectionSortedByMake, model);
        }

        [Test]
        public void Sort_ReturnsCarsCollectionSortedByYear_IfValidStringParameterPassed()
        {
            // Arrange
            var carsCollection = new List<Car>
            {
                new Car { Id = 3, Make = "Porsche", Model = "Carrera", Year = 2015 },
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 5, Make = "Volvo", Model = "S80", Year = 2000 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
                new Car { Id = 6, Make = "Skoda", Model = "Fabia", Year = 2011 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
            };

            IDatabase databaseMocked = Mock.Create<IDatabase>();
            Mock.Arrange(() => databaseMocked.Cars).Returns(carsCollection);

            ICarsRepository carsRepository = new CarsRepository(databaseMocked);
            CarsController carsController = new CarsController(carsRepository);

            ICollection<Car> carsCollectionSortedByYear = carsCollection
                .OrderByDescending(car => car.Year)
                .ToList();

            // Act
            var model = (ICollection<Car>)this.GetModel(() => carsController.Sort("year"));

            // Assert
            CollectionAssert.AreEqual(carsCollectionSortedByYear, model);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
