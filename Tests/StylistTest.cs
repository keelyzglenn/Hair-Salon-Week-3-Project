
using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HairSalon
{
    public class StylistTest : IDisposable
    {
        public StylistTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
        }
        // test that no doubles are created between database and modules
        [Fact]
        public void Equals_TestifEqauals_true()
        {
            {
            // arrange, act
            Stylist stylist1 = new Stylist("Kendra", "1-Cl", "Mens hair", 1);
            Stylist stylist2 = new Stylist("Kendra", "1-Cl", "Mens hair", 1);

            // assert
            Assert.Equal(stylist1, stylist2);
            }
        }

        // test that all stylist will be returned in list
        [Fact]
        public void GetAll_ReturnAllStylists_list()
        {
            // arrange
            Stylist stylist1 = new Stylist("Kendra", "1-Cl", "Mens hair", 1);
            Stylist stylist2 = new Stylist("Maddy", "1-Cl", "Mens hair", 2);
            stylist1.Save();
            stylist2.Save();

            // act
            List<Stylist> testStylistList = new List<Stylist> {stylist1, stylist2};
            List<Stylist> resultStylistList = Stylist.GetAll();

            // assert
            Assert.Equal(testStylistList, resultStylistList);
        }

        // this will test the save method
        [Fact]
        public void Save_TestIfSaved_saved()
        {
            //Arrange
            Stylist stylist1 = new Stylist("Kendra", "1-Cl", "Mens hair", 1);
            stylist1.Save();

            // Act
            List<Stylist> testStylistList = new List<Stylist> {stylist1};
            List<Stylist> resultStylistList = Stylist.GetAll();

            //Assert
            Assert.Equal(testStylistList, resultStylistList);
        }

        // this will test the find method for ID
        [Fact]
        public void Find_FindStylistById_stylist()
        {
            // arrange
            Stylist stylist1 = new Stylist("Kendra", "1-Cl", "Mens hair", 1);
            stylist1.Save();

            // act
            Stylist foundStylist = Stylist.Find(stylist1.GetId());

            // assert
            Assert.Equal(stylist1, foundStylist);
        }

        // test if program returns all clients for each stylist1
        [Fact]
        public void GetClients_RetrievesAllClientsWithinStylist_list()
        {
            Stylist stylist1 = new Stylist("Kendra", "1-Cl", "Mens hair", 1);
            stylist1.Save();

            Client client1 = new Client("geoff", stylist1.GetId());
            Client client2 = new Client("jeff", stylist1.GetId());
            Client client3 = new Client("john", 3);
            client1.Save();
            client2.Save();
            client3.Save();

            List<Client> testClientList = new List<Client> {client1, client2};
            List<Client> resultClientList = stylist1.GetClients();

            Assert.Equal(testClientList, resultClientList);
        }

        // update stylists name
        [Fact]
        public void Test_Update_UpdateStylistInData()
        {
            // Arrange
            Stylist stylist1 = new Stylist("Kendra", "1-Cl", "Mens hair", 1);
            stylist1.Save();

            string newStylist = "Josh";

            // Act
            stylist1.Update(newStylist);

            string result = stylist1.GetName();

            // Assert
            Assert.Equal(newStylist, result);
        }


        //test that stylist was deleted from the database
        [Fact]
        public void Delete_DeleteStylistFromDatabase_null()
        {
            //Arrange

            Stylist stylist1 = new Stylist("Kendra", "1-Cl", "Mens hair", 1);
            stylist1.Save();


            Stylist stylist2 = new Stylist("John", "1-Cl", "Mens hair", 2);
            stylist2.Save();

            Client testClient1 = new Client("geoff", stylist1.GetId());
            Client testClient2 = new Client("geoff", stylist2.GetId());
            testClient1.Save();
            testClient2.Save();

            //Act
            stylist1.Delete();
            List<Stylist> resultStylist = Stylist.GetAll();
            List<Stylist> testStylistList = new List<Stylist> {stylist2};

            List<Client> resultClient = Client.GetAll();
            List<Client> testClientList = new List<Client> {testClient2};

            //Assert
            Assert.Equal(testStylistList, resultStylist);
            Assert.Equal(testClientList, resultClient);

        }

        // prevent repeats of tests or multiple test interferience
        public void Dispose()
       {
         Stylist.DeleteAll();
         Client.DeleteAll();
       }
    }
}
