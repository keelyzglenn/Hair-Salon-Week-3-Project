
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

        // prevent repeats of tests or multiple test interferience
        public void Dispose()
       {
         Stylist.DeleteAll();
         Client.DeleteAll();
       }
    }
}
