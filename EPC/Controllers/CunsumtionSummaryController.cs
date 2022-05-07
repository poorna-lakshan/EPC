using EPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using static EPC.Models.PCChart;
using Newtonsoft.Json;
namespace EPC.Controllers
{
    public class CunsumtionSummaryController : Controller
    {
        // GET: CunsumtionSummary

        ApplicationDbContext _con;

        public CunsumtionSummaryController()
        {
            _con = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }


        public ContentResult JSON(string Customer_id)
        {

            var result = _con.epc_data.AsEnumerable()
                .GroupBy(s => new { s.time.Hour })
                .Select(grp => new
                {
                    Hour = grp.Key.Hour,
                    QI_BL1_1_PV = grp.Sum(x => x.QI_BL1_1_PV) /grp.Count(),
                    QI_BL2_1_PV = grp.Sum(x => x.QI_BL2_1_PV) / grp.Count(),
                    QI_BL3_1_PV = grp.Sum(x => x.QI_BL3_1_PV) / grp.Count(),
                    QI_BL4_1_PV = grp.Sum(x => x.QI_BL4_1_PV) / grp.Count(),
                    QI_BLA_1_PV = grp.Sum(x => x.QI_BLA_1_PV) / grp.Count(),
                    QI_BL5_1_PV = grp.Sum(x => x.QI_BL5_1_PV) / grp.Count(),
                    QI_BL6_1_PV = grp.Sum(x => x.QI_BL6_1_PV) / grp.Count(),
                    QI_BL7_1_PV = grp.Sum(x => x.QI_BL7_1_PV) / grp.Count(),
                    QI_NTU_1_PV = grp.Sum(x => x.QI_NTU_1_PV) / grp.Count(),
                    QI_BP2_1_PV = grp.Sum(x => x.QI_BP2_1_PV) / grp.Count(),
                    QI_FUS_1_PV = grp.Sum(x => x.QI_FUS_1_PV) / grp.Count(),
                    QI_F2B_PV = grp.Sum(x => x.QI_F2B_PV) / grp.Count(),
                    QI_MUD_PV = grp.Sum(x => x.QI_MUD_PV) / grp.Count(),
                    QI_HOT_PV = grp.Sum(x => x.QI_HOT_PV) / grp.Count(),
                    QI_BP3_PV = grp.Sum(x => x.QI_BP3_PV) / grp.Count()
                }).AsQueryable();


            string selectStatement = "new ( " + Customer_id + ",Hour)";
            IQueryable iq = result.Select(selectStatement);

            ViewBag.Customer_id = Customer_id;
            ViewBag.FileList = iq;

            List<DataPoint> dataPoints = new List<DataPoint>();
            foreach (var _data in result)
            {
                double _dblVal = Math.Round(Convert.ToDouble(_data.GetType().GetProperty(Customer_id).GetValue(_data, null)),2,MidpointRounding.AwayFromZero);
                dataPoints.Add(new DataPoint(_data.Hour, _dblVal));
            }


            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
        }


    }
}