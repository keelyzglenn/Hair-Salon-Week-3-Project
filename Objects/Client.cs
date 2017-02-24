using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
    public class Client
    {
        private string _name;
        private int _stylistId;
        private int _id;

        public Client(string Name, int StylistId, int Id = 0)
        {
            _name = Name;
            _stylistId = StylistId;
            _id = Id;
        }

        // ensures no doubles are created in table
        public override bool Equals(System.Object otherClient)
        {
          if (!(otherClient is Client))
          {
              return false;
          }
          else
          {
              Client newClient = (Client) otherClient;
              bool idEquality = (this.GetId() == newClient.GetId());
              bool nameEquality = (this.GetName() == newClient.GetName());
              bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());

              return (idEquality && nameEquality && stylistIdEquality);
          }
        }

        // overrides hashcode
        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

        // get and set name
        public string GetName()
        {
            return _name;
        }

        public void SetName(string Name)
        {
            _name = Name;
        }

        // get stylist id
        public int GetStylistId()
        {
            return _stylistId;
        }

        // get id
        public int GetId()
        {
            return _id;
        }

        // method to run multiple tests at once
        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
}
