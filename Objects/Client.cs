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

        // get all method to return list of clients
        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                string clientName = rdr.GetString(0);
                int clientStylistId = rdr.GetInt32(1);
                int clientId = rdr.GetInt32(2);

                Client newClient = new Client(clientName, clientStylistId, clientId);
                allClients.Add(newClient);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return allClients;
        }

        // save method for clients
        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES (@ClientName, @ClientStylistId);", conn);

            SqlParameter nameParameter = new SqlParameter();
            nameParameter.ParameterName = "@ClientName";
            nameParameter.Value = this.GetName();

            SqlParameter clientStylistIdParameter = new SqlParameter();
            clientStylistIdParameter.ParameterName = "@ClientStylistId";
            clientStylistIdParameter.Value = this.GetStylistId();

            cmd.Parameters.Add(nameParameter);
            cmd.Parameters.Add(clientStylistIdParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        // find method based on id
        public static Client Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientId;", conn);
            SqlParameter clientIdParameter = new SqlParameter();
            clientIdParameter.ParameterName = "@ClientId";
            clientIdParameter.Value = id.ToString();
            cmd.Parameters.Add(clientIdParameter);
            SqlDataReader rdr = cmd.ExecuteReader();

            string foundClientName = null;
            int foundClientStylistId = 0;
            int foundClientId = 0;

            while(rdr.Read())
            {
                foundClientName = rdr.GetString(0);
                foundClientStylistId = rdr.GetInt32(1);
                foundClientId = rdr.GetInt32(2);
            }

            Client foundClient = new Client(foundClientName, foundClientStylistId, foundClientId);

            if (rdr != null)
           {
               rdr.Close();
           }
           if (conn != null)
           {
               conn.Close();
           }
           return foundClient;
        }

        // update method for client name
        public void Update(string newClientName)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE clients SET name = @newClientName OUTPUT INSERTED.name WHERE id = @ClientId;", conn);

            SqlParameter newClientNameParameter = new SqlParameter();
            newClientNameParameter.ParameterName = "@newClientName";
            newClientNameParameter.Value = newClientName;

            SqlParameter clientIdParameter = new SqlParameter();
            clientIdParameter.ParameterName = "@ClientId";
            clientIdParameter.Value = this.GetId();

            cmd.Parameters.Add(newClientNameParameter);
            cmd.Parameters.Add(clientIdParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
              {
                  this._name = rdr.GetString(0);
              }

              if (rdr !=null)
              {
                  rdr.Close();
              }

              if (conn != null)
              {
                  conn.Close();
              }
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
