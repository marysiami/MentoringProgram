using FluentAssertions;
using ORMLibrary;
using ORMLibrary.Models;
using ORMLibrary.Repositories;

namespace ORM.Tests
{
    public class ProductRepositoryTests
    {
        private ProductRepository Repository { get; set; }
        private string ConnectionString { get; set; }

        [SetUp]
        public void Setup()
        {

            ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO_ORM_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var context = new MyContext(ConnectionString);
            Repository = new ProductRepository(context);
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

            Func<Task> act = async () => { await Repository.Insert(product); };

            await act.Should().NotThrowAsync<Exception>();
        }

        [Test]
        public async Task Insert_WhenEmptyObject_ThenThrowEx()
        {
            var product = new Product();       

            Func<Task> act = async () => { await Repository.Insert(product); };

            await act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public async Task Insert_WhenObjectNull_ThenThrowEx()
        {
            Product product = null;

            Func<Task> act = async () => { await Repository.Insert(product); };

            await act.Should().ThrowAsync<Exception>();
        }

        [TestCase(null,"aa",10,0,0)]
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

            Func<Task> act = async () => { await Repository.Insert(product); };

            await act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public void Update_WhenCorrectObject_ThenUpdate()
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

            Action act = () => { Repository.Update(product); } ;
            act.Should().NotThrow<Exception>();
        }

        [Test]
        public void Update_WhenEmptyObject_ThenThrowEx()
        {
            var product = new Product();

            Action act = () => { Repository.Update(product); };

            act.Should().Throw<Exception>();
        }

        [TestCase(1, "aa", null, 10, 0, 0)]
        [TestCase(1, "bbb", "aa", 10, 50, 0)]
        [TestCase(1, "aa", "bbb", 10, 2, 30)]
        public void Update_WhenObjectNotNull_ThenUpdate(int id,
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

            Action act = () => { Repository.Update(product); };

            act.Should().NotThrow<Exception>();
        }

        [Test]
        public void Get_WhenIdCorrect_ThenGetProduct()
        {
            var dt = Repository.Get(1);

            dt.Should().NotBeNull();
            dt.Should().BeOfType<Product>();
        }          
    }
}
