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
