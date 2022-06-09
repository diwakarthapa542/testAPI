using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace testAPI.Models
{
    public class DivTableModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public double Amount { get; set; }
    }
    public class Class_DivTable
    {
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int InsertDivTable(DivTableModel model)
        {
            int i = 1;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("usp_DivTableInsert", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", model.Name);
                com.Parameters.AddWithValue("@Address", model.Address);
                com.Parameters.AddWithValue("@Phone", model.Phone);
                com.Parameters.AddWithValue("@Amount", model.Amount);
            }
            return i;
        }
        //Select All Data
        public List<DivTableModel> GetDivTable()
        {
            List<DivTableModel> lst = new List<DivTableModel>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("usp_DivTableSelect", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new DivTableModel
                    {
                        Name = rdr["Name"].ToString(),
                        Address = rdr["Address"].ToString(),
                        Phone = Convert.ToInt32(rdr["Phone"]),
                        Amount = Convert.ToDouble(rdr["Amount"]),
                    });
                }
                return lst;
            }
        }
        public int RemoveDivTable(int Name)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("usp_DivTableDelete", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", Name);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public int UpdateDivTable(DivTableModel model, int Name)
        {
            try
            {
                int i = 1;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("usp_DivTableUpdate", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Name", Name);
                    com.Parameters.AddWithValue("@Address", model.Address);
                    com.Parameters.AddWithValue("@Phone", model.Phone);
                    com.Parameters.AddWithValue("@Amount", model.Amount);

                    i = com.ExecuteNonQuery();
                }
                return i;

            }
            catch (Exception)
            {
                return 2;
            }
        }
    }
}
