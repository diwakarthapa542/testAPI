using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace testAPI.Models
{
    public class Model_ItemLedger
    {
        public int ItemID { get; set; }
        public string ClientGUID { get; set; }
        public string ClientUserName { get; set; }
        public int ItemGroup { get; set; }
        public string ItemGroupName { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double OpeningQty { set; get; }
        public double TotalWeight { set; get; }
        public double Purity { set; get; }
        public double PurchaseRate { set; get; }
        public double SalesRate { set; get; }
        public double SaleDiscount { set; get; }
        public double PurchaseDiscount { set; get; }
        public int SaleUnit { set; get; }
        public int PurchaseUnit { set; get; }


        public double OpeningAmount { set; get; }

        public string Remarks { set; get; }
        public int Status { set; get; }
        public string StatusString { set; get; }
        public string UserName { set; get; }

    }


    public class Model_PackLedger
    {
        public string ClientGUID { get; set; }
        public string ClientUserName { get; set; }
        public int Item { get; set; }
        public int PackUnit { get; set; }
        public double Quantity { get; set; }
        public double TotalKG { get; set; }
    }

    public class Class_ItemLedger
    {
        string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public int InsertItemLedger(Model_ItemLedger model)
        {

            int i = 1;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("usp_ItemLedgerTableInsert", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ClientGUID", model.ClientGUID);
                com.Parameters.AddWithValue("@ClientUserName", model.ClientUserName);
                com.Parameters.AddWithValue("@ItemGroup", model.ItemGroup);
                com.Parameters.AddWithValue("@ItemName", model.ItemName);
                com.Parameters.AddWithValue("@Description", model.Description);
                com.Parameters.AddWithValue("@OpeningQty", model.OpeningQty);
                com.Parameters.AddWithValue("@TotalWeight", model.TotalWeight);
                com.Parameters.AddWithValue("@Purity ", model.Purity);
                com.Parameters.AddWithValue("@PurchaseRate", model.PurchaseRate);
                com.Parameters.AddWithValue("@SalesRate", model.SalesRate);
                com.Parameters.AddWithValue("@SaleDiscount", model.SaleDiscount);
                com.Parameters.AddWithValue("@PurchaseDiscount", model.PurchaseDiscount);
                com.Parameters.AddWithValue("@OpeningAmount", model.OpeningAmount);
                com.Parameters.AddWithValue("@PurchaseUnit", model.PurchaseUnit);
                com.Parameters.AddWithValue("@SaleUnit", model.SaleUnit);

                com.Parameters.AddWithValue("@Remarks", model.Remarks);
                com.Parameters.AddWithValue("@Status", model.Status);
                com.Parameters.AddWithValue("@username", model.UserName);
                i = com.ExecuteNonQuery();
            }
            return i;

        }
        public int InsertPackLedger(Model_PackLedger model)
        {

            int i = 1;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("usp_InsertPackLedger", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ClientGUID", model.ClientGUID);
                com.Parameters.AddWithValue("@ClientUserName", model.ClientUserName);
                com.Parameters.AddWithValue("@Item", model.Item);
                com.Parameters.AddWithValue("@PackUnit", model.PackUnit);
                com.Parameters.AddWithValue("@Quantity", model.Quantity);
                com.Parameters.AddWithValue("@TotalKG", model.TotalKG);


                i = com.ExecuteNonQuery();
            }
            return i;


        }

        //Select All Data
        public List<Model_ItemLedger> GetItemLedger()
        {
            List<Model_ItemLedger> lst = new List<Model_ItemLedger>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("usp_ItemLedgerTableSelect", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Model_ItemLedger
                    {
                        ItemID = Convert.ToInt32(rdr["ItemID"].ToString()),
                        ItemGroup = Convert.ToInt32(rdr["ItemGroup"].ToString()),
                        ItemGroupName = rdr["ItemGroupName"].ToString(),
                        ItemName = rdr["ItemName"].ToString(),
                        Description = rdr["Description"].ToString(),
                        OpeningQty = Convert.ToDouble(rdr["OpeningQty"].ToString()),
                        TotalWeight = Convert.ToDouble(rdr["TotalWeight"].ToString()),
                        Purity = Convert.ToDouble(rdr["Purity"].ToString()),
                        PurchaseRate = Convert.ToDouble(rdr["PurchaseRate"]),
                        SalesRate = Convert.ToDouble(rdr["SalesRate"]),
                        PurchaseDiscount = Convert.ToDouble(rdr["PurchaseDiscount"]),
                        SaleDiscount = Convert.ToDouble(rdr["SaleDiscount"]),
                        OpeningAmount = Convert.ToDouble(rdr["OpeningAmount"]),
                        PurchaseUnit = Convert.ToInt32(rdr["PurchaseUnit"]),
                        SaleUnit = Convert.ToInt32(rdr["SaleUnit"]),

                        Remarks = rdr["Remarks"].ToString(),
                        Status = Convert.ToInt32(rdr["Status"].ToString()),
                        StatusString = rdr["StatusString"].ToString(),
                    });
                }
                return lst;
            }
        }

        public int RemoveItemLedger(int ItemID)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("usp_ItemLedgerTableDelete", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ItemID", ItemID);
                i = com.ExecuteNonQuery();
            }
            return i;
        }

        public int UpdateItemLedger(Model_ItemLedger model, int ItemID)
        {
            try
            {
                int i = 1;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("usp_ItemLedgerTableUpdate", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@ItemID", ItemID);
                    com.Parameters.AddWithValue("@ClientGUID", model.ClientGUID);
                    com.Parameters.AddWithValue("@ClientUserName", model.ClientUserName);
                    com.Parameters.AddWithValue("@ItemGroup", model.ItemGroup);
                    com.Parameters.AddWithValue("@ItemName", model.ItemName);
                    com.Parameters.AddWithValue("@Description", model.Description);
                    com.Parameters.AddWithValue("@OpeningQty", model.OpeningQty);
                    com.Parameters.AddWithValue("@TotalWeight", model.TotalWeight);
                    com.Parameters.AddWithValue("@Purity ", model.Purity);
                    com.Parameters.AddWithValue("@PurchaseRate", model.PurchaseRate);
                    com.Parameters.AddWithValue("@SalesRate", model.SalesRate);
                    com.Parameters.AddWithValue("@PurchaseDiscount", model.PurchaseDiscount);
                    com.Parameters.AddWithValue("@SaleDiscount", model.SaleDiscount);
                    com.Parameters.AddWithValue("@OpeningAmount", model.OpeningAmount);
                    com.Parameters.AddWithValue("@PurchaseUnit", model.PurchaseUnit);
                    com.Parameters.AddWithValue("@SaleUnit", model.SaleUnit);

                    com.Parameters.AddWithValue("@Remarks", model.Remarks);
                    com.Parameters.AddWithValue("@Status", model.Status);
                    com.Parameters.AddWithValue("@username", model.UserName);
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