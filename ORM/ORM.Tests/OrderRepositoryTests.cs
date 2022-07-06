
using FluentAssertions;
using ORMLibrary;
using ORMLibrary.Models;
using ORMLibrary.Repositories;

namespace ORM.Tests
{
    public class OrderRepositoryTests
    {
        private OrderRepository Repository { get; set; }
        private string ConnectionString { get; set; }

        [SetUp]
        public void Setup()
        {
            ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO_ORM_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var context = new MyContext(ConnectionString);
            Repository = new OrderRepository(context);
        }

        [Test]
        public async Task Insert_WhenCorrectObject_ThenInsert()
        {
            var order = new Order()
            {
                CreatedDate = DateTime.Now,
                Status = Status.Arrived,
                UpdatedDate = DateTime.Now,
                ProductId = 1
            };

            Func<Task> act = async () => { await Repository.Insert(order); };

            await act.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task Insert_WhenEmptyObject_ThenNotThrowEx()
        {
            var order = new Order();

            Func<Task> act = async () => { await Repository.Insert(order); };

            await act.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task Insert_WhenObjectNull_ThenThrowEx()
        {
            Order order = null;

            Func<Task> act = async () => { await Repository.Insert(order); };

            await act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public void Update_WhenCorrectObject_ThenUpdate()
        {
            var order = new Order()
            {
                CreatedDate = DateTime.Now,
                Status = Status.Done,
                UpdatedDate = DateTime.Now,
                ProductId = 1,
                Id = 1
            };

            Action act = () => { Repository.Update(order); };

            act.Should().NotThrow<Exception>();
        }

        [Test]
        public void Update_WhenEmptyObject_ThenNotThrowEx()
        {
            var order = new Order();

            Action act = () => {  Repository.Update(order); };

            act.Should().NotThrow<Exception>();
        }

        [Test]
        public void Update_WhenObjectNull_ThenThrowEx()
        {
            Order order = null;

            Action act = () => { Repository.Update(order); };

            act.Should().Throw<Exception>();
        }

        [TestCase(1, Status.Arrived, 1)]
        public void Update_WhenObjectCorrect_Update(int id,
            Status status,
            int productId)
        {
            var order = new Order()
            {
                Id = id,
                Status = status,
                ProductId = productId
            };

            Action act = () => { Repository.Update(order); };

            act.Should().NotThrow<Exception>();
        }

        [Test]
        public void Get_WhenIdCorrect_ThenGetOrder()
        {
            var dt = Repository.Get(1);

            dt.Should().NotBeNull();
            dt.Should().BeOfType<Order>();
        }

        [TestCase(Status.Done, 1)]
        [TestCase(Status.NotStarted, 1)]
        [TestCase(Status.Done, 1002)]
        public void GetAll_WhenCorrectFilters_ThenReturnAll(
            Status status,
            int productId)
        {
            var dt = Repository.GetAll(status, DateTime.Now.AddYears(-1), DateTime.Now.AddMonths(1), productId);

            dt.Should().NotBeNull();
        }
    }
}