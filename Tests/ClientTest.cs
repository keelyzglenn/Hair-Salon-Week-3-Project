using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
    public class ClientTest : IDisposable
    {
        public ClientTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }

        // test that no doubles are created between database and modules
        [Fact]
        public void Equals_TestifEqauals_true()
        {
            {
            // arrange, act
            Client client1 = new Client("geoff", 1);
            Client client2 = new Client("geoff", 1);

            // assert
            Assert.Equal(client1, client2);
            }
        }

        // test that program will return a list of all clients
        [Fact]
        public void GetAll_ReturnAllClients_list()
        {
            // arrange
            Client client1 = new Client("geoff", 1);
            Client client2 = new Client("jeff", 2);
            client1.Save();
            client2.Save();

            // act
            List<Client> testClientList = new List<Client> {client1, client2};
            List<Client> resultClientList = Client.GetAll();

            // assert
            Assert.Equal(testClientList, resultClientList);
        }

        // this will test the save method
        [Fact]
        public void Save_TestIfSaved_true()
        {
            //Arrange
            Client client1 = new Client("geoff", 1);
            client1.Save();

            List<Client> testClientList = new List<Client> {client1};
            List<Client> resultClientList = Client.GetAll();

            //Assert
            Assert.Equal(testClientList, resultClientList);
        }

        // test for get id method
        [Fact]
        public void GetId_TestifGetId_id()
        {
            // arrange
            Client client1 = new Client("geoff", 1);
            client1.Save();

            // act
            Client savedClient = Client.GetAll()[0];
            int result = savedClient.GetId();
            int testId = client1.GetId();

            // assert
            Assert.Equal(testId, result);
        }

        // prevent repeats of tests or multiple test interferience
        public void Dispose()
       {
         Client.DeleteAll();
       }
    }
}
