using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using thinkbridgeAssignment;
using thinkbridgeAssignment.Controllers;
using thinkbridgeAssignment.Model;
using thinkbridgeAssignment.Repository;
using Xunit;

namespace CoreServiceTest
{
   public class PostUnitTestController
    {
        private ProductRepository repository;

        public static DbContextOptions<DataBaseConnectionContext> dbContextOptions { get; }

        //dont use connectionstring here we are using here for demo purpose
        public static string connectionString = "Data Source=DESKTOP-RI33KBB\\SQLEXPRESS;Initial Catalog=DemoDB;Persist Security Info=True; User ID=sa;Password=esskae";

        //initialse the connection 
        static PostUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<DataBaseConnectionContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public PostUnitTestController()
        {
            var context = new DataBaseConnectionContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            repository = new ProductRepository(context);
        }

        //OK Result Test
        [Fact]
        public async void Task_GetProduct_Return_OKResult()
        {
            //Arrange
            var controller = new ProductValues(repository);

            //Act
            var data = await controller.GetProducts();

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }


        [Fact]
        public async void Task_GetProductDetail_OKResult()
        {
            //Arrange
            var controller = new ProductValues(repository);
            int postId = 2;

            //Act
            var data = await controller.GetProductDetail(postId);

            //Assert
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetProductDetail_NotFoundResult()
        {
            //Arrange
            var controller = new ProductValues(repository);
            int postId = 5;
            //Act
            var data = await controller.GetProductDetail(postId);

            //Assert
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]

        public async void Task_Delete_Post_Return_OkResult()
        {
            //Arrange
            var controller = new ProductValues(repository);
            var postId = 2;

            //Act  
            var data = await controller.DeleteProduct(postId);

            //Assert  
            Assert.IsType<OkResult>(data);

        }


    }
}
