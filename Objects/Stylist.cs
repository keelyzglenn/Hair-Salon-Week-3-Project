using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace HairSalon
{
    public class Stylist
    {
        private string _name;
        private string _shift;
        private string _specialty;
        private int _id;

        public Stylist(string Name, string Shift, string Specialty, int Id = 0)
        {
            _name = Name;
            _shift = Shift;
            _specialty = Specialty;
            _id = Id;
        }

        // ensures no doubles are created in table
        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool idEquality = (this.GetId() == newStylist.GetId());
                bool nameEquality = (this.GetName() == newStylist.GetName());
                bool shiftEquality = (this.GetShift() == newStylist.GetShift());
                bool specialtyEquality = (this.GetSpecialty() == newStylist.GetSpecialty());

                return (idEquality && nameEquality && shiftEquality && specialtyEquality);
            }
        }

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

        // get shift
        public string GetShift()
        {
            return _shift;
        }

        // get Specialty
        public string GetSpecialty()
        {
            return _specialty;
        }

        // get id
        public int GetId()
        {
            return _id;
        }

        // get all method for Stylist
        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                string stylistName = rdr.GetString(0);
                string stylistShift = rdr.GetString(1);
                string stylistSpecialty = rdr.GetString(2);
                int stylistId = rdr.GetInt32(3);

                Stylist newStylist = new Stylist(stylistName, stylistShift, stylistSpecialty, stylistId);
                allStylists.Add(newStylist);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return allStylists;
        }

        //save method for stylists
        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name, shift, specialty) OUTPUT INSERTED.id VALUES (@StylistName, @StylistShift, @StylistSpecialty);", conn);

            SqlParameter nameParameter = new SqlParameter();
            nameParameter.ParameterName = "@StylistName";
            nameParameter.Value = this.GetName();

            SqlParameter shiftParameter = new SqlParameter();
            shiftParameter.ParameterName = "@StylistShift";
            shiftParameter.Value = this.GetShift();

            SqlParameter specialtyParameter = new SqlParameter();
            specialtyParameter.ParameterName = "@StylistSpecialty";
            specialtyParameter.Value = this.GetSpecialty();

            cmd.Parameters.Add(nameParameter);
            cmd.Parameters.Add(shiftParameter);
            cmd.Parameters.Add(specialtyParameter);

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

        // find mehod based on id
        public static Stylist Find(int id)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @StylistId;", conn);

            SqlParameter stylistIdParameter = new SqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = id.ToString();

            cmd.Parameters.Add(stylistIdParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            string foundStylistName = null;
            string foundStylistShift = null;
            string foundStylistSpecialty = null;
            int foundStylistId = 0;


            while(rdr.Read())
            {
                foundStylistName = rdr.GetString(0);
                foundStylistShift = rdr.GetString(1);
                foundStylistSpecialty = rdr.GetString(2);
                foundStylistId = rdr.GetInt32(3);
            }

            Stylist foundStylist = new Stylist(foundStylistName, foundStylistShift, foundStylistSpecialty, foundStylistId);

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return foundStylist;
        }

        // returns all clients for each stylist
        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE stylist_id = @StylistId;", conn);

            SqlParameter stylistIdParameter = new SqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = this.GetId();

            cmd.Parameters.Add(stylistIdParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                string clientName = rdr.GetString(0);
                int clientStylistId = rdr.GetInt32(1);
                int clientId = rdr.GetInt32(2);

                Client newClient = new Client(clientName, clientStylistId, clientId);
                clients.Add(newClient);

            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
            return clients;
        }


        //Update Stylist name method
        public void Update(string newStylistName)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE stylists SET type = @NewStylistName OUTPUT INSERTED.type WHERE id = @StylistId;", conn);

            SqlParameter newStylistNameParameter = new SqlParameter();
            newStylistNameParameter.ParameterName = "@newStylistName";
            newStylistNameParameter.Value = newStylistName;

            SqlParameter stylistIdParameter = new SqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = this.GetId();

            cmd.Parameters.Add(newStylistNameParameter);
            cmd.Parameters.Add(stylistIdParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._type = rdr.GetString(0);
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

        // method to delete category
        public void Delete()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("DELETE FROM stylists WHERE id = @StylistId; DELETE FROM clients WHERE stylist_id = @StylistId;", conn);

            SqlParameter stylistIdParameter = new SqlParameter();
            stylistIdParameter.ParameterName = "@StylistId";
            stylistIdParameter.Value = this.GetId();

            cmd.Parameters.Add(stylistIdParameter);
            cmd.ExecuteNonQuery();

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
            SqlCommand cmd = new SqlCommand("DELETE FROM stylists;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
