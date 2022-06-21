using ADOLibrary;
using ADOLibrary.Models;
using ADOLibrary.Repositories;
using FluentAssertions;
using System.Data;

namespace ADO.Tests
{
    public class OrderRepositoryTests
    {
        private OrderRepository repository { get; set; }

        [SetUp]
        public void Setup()
        {
            DbConfig dbConfig = new()
            {
                ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO_ORM_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            };
            repository = new OrderRepository(dbConfig);
        }

        [Test]
        public async Task Insert_WhenCorrectObject_ThenInsert()
        {
            var order = new Order()
            {
                CreatedDate = DateTime.Now,
                Status = "OK",
                UpdatedDate  = DateTime.Now,
                ProductId = 1
            };

            Func<Task> act = async () => { await repository.Insert(order); };

            await act.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task Insert_WhenEmptyObject_ThenThrowEx()
        {
            var order = new Order();

            Func<Task> act = async () => { await repository.Insert(order); };

            await act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public async Task Insert_WhenObjectNull_ThenThrowEx()
        {
            Order order = null;

            Func<Task> act = async () => { await repository.Insert(order); };

            await act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public async Task Insert_WhenObjectNotCorrect_ThenThrowEx()
        {
            var order = new Order()
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            Func<Task> act = async () => { await repository.Insert(order); };

            await act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public async Task Update_WhenCorrectObject_ThenUpdate()
        {
            var order = new Order()
            {
                CreatedDate = DateTime.Now,
                Status = "Error",
                UpdatedDate = DateTime.Now,
                ProductId = 1,
                Id = 1
            };

            Func<Task> act = async () => { await repository.Update(order); };

            await act.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task Update_WhenEmptyObject_ThenThrowEx()
        {
            var order = new Order();

            Func<Task> act = async () => { await repository.Update(order); };

            await act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public async Task Update_WhenObjectNull_ThenThrowEx()
        {
            Order order = null;

            Func<Task> act = async () => { await repository.Update(order); };

            await act.Should().ThrowAsync<Exception>();
        }

        [TestCase(1, null, 1)]
        public async Task Update_WhenObjectNotCorrect_ThenThrowEx(int id,
            string status,
            int productId)
        {
            var order = new Order()
            {
                Id = id,
                Status = status,
                ProductId = productId
            };

            Func<Task> act = async () => { await repository.Update(order); };

            await act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public void Get_WhenIdCorrect_ThenGetDataSet()
        {
            var dt = repository.Get(1);

            dt.Should().NotBeNull();
            dt.Should().BeOfType<DataSet>();
            dt.Should().HaveTable("Table").Which.Rows.Should().HaveCount(1);
            dt.Should().HaveTableCount(1);
        }

        [TestCase("OK", 1)]
        [TestCase("aa",1)]
        [TestCase("OK", 1002)]
        public void GetAll_WhenCorrectFilters_ThenReturnAll(
            string status,
            int productId)
        {
            var dt = repository.GetAll(status, DateTime.Now.AddYears(-1), DateTime.Now.AddMonths(1), productId);

            dt.Should().NotBeNull();
            dt.Columns.Should().HaveCount(5);
            dt.Rows.Should().HaveCountGreaterThan(0);
        }
    }
}