using EPC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using Newtonsoft.Json;

namespace EPC.Controllers
{
    public class PeakController : Controller
    {

        ApplicationDbContext _con;

        public PeakController()
        {
            _con = new ApplicationDbContext();
        }

        // GET: Peak
        public ActionResult Index()
        {
            return View();
        }


        // POST: Peak/Create
        [HttpPost]
        public ActionResult submit_data(string Customer_id)
        {
            try
            {

                var _data = (from c in _con.epc_data
                            select c).ToList();

                int _intPeak_Cnt = 0;
                double _dblPeak_Max = 0;
               
                for (int i = 0; _data.Count > i; i++){
                       
                    if (i > 1)
                    {
                        var _before_previousVal = Convert.ToDouble(_data[i - 1].GetType().GetProperty(Customer_id).GetValue(_data[i - 2], null));
                        var _previousVal = Convert.ToDouble(_data[i - 1].GetType().GetProperty(Customer_id).GetValue(_data[i - 1], null));
                        var _currentVal = Convert.ToDouble(_data[i].GetType().GetProperty(Customer_id).GetValue(_data[i], null));

                        if (_previousVal > _currentVal && _previousVal > _before_previousVal)
                        {
                            _intPeak_Cnt++;
                            if(_dblPeak_Max< _previousVal)
                            {
                                _dblPeak_Max = _previousVal;
                            }
                        }
                    }
                }

                ViewBag.Peak_Cnt = "The number of load peaks: " + _intPeak_Cnt.ToString();
                ViewBag.Peak_Max = "The maximum peak value: " + _dblPeak_Max.ToString();

                
                return View("Index");

            }
            catch(Exception ex)
            {
                return View("Index");
            }
        }

      
    }
}
