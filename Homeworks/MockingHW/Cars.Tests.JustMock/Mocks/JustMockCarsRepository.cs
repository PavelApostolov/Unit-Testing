namespace Cars.Tests.JustMock.Mocks
{
    using System.Linq;

    using Cars.Contracts;
    using Cars.Models;

    using Telerik.JustMock;

    public class JustMockCarsRepository : CarRepositoryMock, ICarsRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            this.CarsData = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => this.CarsData.Add(Arg.IsAny<Car>())).DoNothing();
            Mock.Arrange(() => this.CarsData.All()).Returns(this.FakeCarCollection);
            Mock.Arrange(() => this.CarsData.Search(Arg.AnyString))
                .Returns((string condition) => this.FakeCarCollection
                        .Where(c => c.Make == condition || c.Model == condition)
                        .ToList());
            Mock.Arrange(() => this.CarsData.Search(Arg.NullOrEmpty))
                .Returns(this.FakeCarCollection.Take(0).ToList());
            Mock.Arrange(() => this.CarsData.GetById(Arg.AnyInt))
                .Returns(this.FakeCarCollection.First());
            Mock.Arrange(() => this.CarsData.SortedByMake())
                .Returns(this.FakeCarCollection.OrderBy(c => c.Make).ToList());
            Mock.Arrange(() => this.CarsData.SortedByYear())
                .Returns(this.FakeCarCollection.OrderByDescending(c => c.Year).ToList());
        }
    }
}
