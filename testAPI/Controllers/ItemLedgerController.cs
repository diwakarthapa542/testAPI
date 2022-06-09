using testAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace testAPI.Controllers
{
    public class ItemLedgerController : ApiController
    {
        Class_ItemLedger ItemLedgerObj = new Class_ItemLedger();


        public int PostItemLedger(Model_ItemLedger model)
        {
            var i = ItemLedgerObj.InsertItemLedger(model);
            return i;
        }

        public int PostPackLedger(Model_PackLedger model)
        {
            var i = ItemLedgerObj.InsertPackLedger(model);
            return i;
        }

        [HttpGet]
        public List<Model_ItemLedger> GetItemLedger()
        {
            var lst = ItemLedgerObj.GetItemLedger();
            return lst;
        }

        [HttpGet]
        public Model_ItemLedger GetItemLedgerByItemID(int ItemID)
        {
            var lst = ItemLedgerObj.GetItemLedger().Find(x => x.ItemID.Equals(ItemID));
            return lst;
        }

        [HttpDelete]
        public int DeleteItemLedger(int ItemID)
        {
            var i = ItemLedgerObj.RemoveItemLedger(ItemID);
            return i;
        }

        [HttpPut]
        public int PutItemLedger(Model_ItemLedger model, int ItemID)
        {
            var i = ItemLedgerObj.UpdateItemLedger(model, ItemID);
            return i;
        }


    }
}
