
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

        // prevent repeats of tests or multiple test interferience
        public void Dispose()
       {
         Stylist.DeleteAll();
         Client.DeleteAll();
       }
    }
}
