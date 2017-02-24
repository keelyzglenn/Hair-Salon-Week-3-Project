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

        // prevent repeats of tests or multiple test interferience
        public void Dispose()
       {
         Client.DeleteAll();
       }
    }
}
