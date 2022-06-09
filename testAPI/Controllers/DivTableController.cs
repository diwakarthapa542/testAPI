using testAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace testAPI.Controllers
{
    public class DivTableController : ApiController
    {
        Class_DivTable DivTableObj = new Class_DivTable();


        public int PostDivTable(DivTableModel model)
        {
            var i = DivTableObj.InsertDivTable(model);
            return i;
        }

        //public int PostPackLedger(Model_PackLedger model)
        //{
        //    var i = DivTableObj.InsertPackLedger(model);
        //    return i;
        //}

        [HttpGet]
        public List<DivTableModel> GetDivTable()
        {
            var lst = DivTableObj.GetDivTable();
            return lst;
        }

        [HttpGet]
        public DivTableModel GetDivTableByName(int Name)
        {
            var lst = DivTableObj.GetDivTable().Find(x => x.Name.Equals(Name));
            return lst;
        }

        [HttpDelete]
        public int DeleteDivTable(int Name)
        {
            var i = DivTableObj.RemoveDivTable(Name);
            return i;
        }

        [HttpPut]
        public int PutDivTable(DivTableModel model, int Name)
        {
            var i = DivTableObj.UpdateDivTable(model, Name);
            return i;
        }
    }
}
