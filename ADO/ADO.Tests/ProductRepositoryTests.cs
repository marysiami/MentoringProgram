using ADOLibrary;
using ADOLibrary.Models;
using ADOLibrary.Repositories;
using FluentAssertions;
using System.Data;

namespace ADO.Tests
{
    public class ProductRepositoryTests
    {
        private ProductRepository repository { get; set; }

        [SetUp]
        public void Setup()
        {
            DbConfig dbConfig = new()
            {
                ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO_ORM_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
            };
            repository = new ProductRepository(dbConfig);
        }

        [Test]
        public async Task Insert_WhenCorrectObject_ThenInsert()
        {
            var product = new Product() 
            {
                Name = "productName",
                Description = "productDescription",
                Length = 10,
                Weight = 10,
                Width = 2
            };

            Func<Task> act = async () => { await repository.Insert(product); };
  
            await act.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task Insert_WhenEmptyObject_ThenThrowEx()
        {
            var product = new Product();       

            Func<Task> act = async () => { await repository.Insert(product); };

            await act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public async Task Insert_WhenObjectNull_ThenThrowEx()
        {
            Product product = null;

            Func<Task> act = async () => { await repository.Insert(product); };

            await act.Should().ThrowAsync<Exception>();
        }

        [TestCase(null,"aa",10,0,0)]
        [TestCase("aa", null, 10, 0, 0)]
        public async Task Insert_WhenObjectNotCorrect_ThenThrowEx(string name,
            string description,
            int length,
            int weight,
            int width)
        {
            var product = new Product()
            {
                Name = name,
                Description = description,
                Length = length,
                Weight = weight,
                Width = width
            };

            Func<Task> act = async () => { await repository.Insert(product); };

            await act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public async Task Update_WhenCorrectObject_ThenUpdate()
        {
            var product = new Product()
            {
                Id  = 1,
                Name = "productName",
                Description = "productDescription",
                Length = 10,
                Weight = 10,
                Width = 2
            };

            Func<Task> act = async () => { await repository.Update(product); };

            await act.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task Update_WhenEmptyObject_ThenThrowEx()
        {
            var product = new Product();

            Func<Task> act = async () => { await repository.Update(product); };

            await act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public async Task Update_WhenObjectNull_ThenThrowEx()
        {
            Product product = null;

            Func<Task> act = async () => { await repository.Update(product); };

            await act.Should().ThrowAsync<Exception>();
        }

        [TestCase(1, null, "aa", 10, 0, 0)]
        [TestCase(1, "aa", null, 10, 0, 0)]
        public async Task Update_WhenObjectNotCorrect_ThenThrowEx(int id,
            string name,
            string description,
            int length,
            int weight,
            int width)
        {
            var product = new Product()
            {
                Id = id,
                Name = name,
                Description = description,
                Length = length,
                Weight = weight,
                Width = width
            };

            Func<Task> act = async () => { await repository.Update(product); };

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

        [Test]
        public void GetAll_WhenNoFilters_ThenReturnAll()
        {
            var list = repository.GetAll();

            list.Should().NotBeNullOrEmpty();
            list.Should().HaveCountGreaterThan(0);
            list.Should().AllBeOfType<Product>();
        }            
    }
}
