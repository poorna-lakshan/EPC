using EPC.Models;
using LinqToExcel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace EPC.Controllers
{
    public class DefaultController : Controller
    {

        ApplicationDbContext _con;


        public DefaultController()
        {
            _con = new ApplicationDbContext();
        }

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }


        public FileResult DownloadExcel()
        {
            string path = "/Doc/Users.xlsx";
            return File(path, "application/vnd.ms-excel", "Users.xlsx");
        }


        [HttpPost]
        public ActionResult UploadExcel(HttpPostedFileBase FileUpload)
        {

            string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection con = new MySqlConnection(conStr);
            con.Open();
            try
            {

            if (FileUpload.ContentLength > 0)
            {

                string fileName = FileUpload.FileName;
                string path = Server.MapPath("~/Doc/")+ fileName;
               
                    FileUpload.SaveAs(path);
                    var msbl = new MySqlBulkLoader(con);
                      msbl.TableName = "tbl_epc";
                      msbl.FileName = path;
                      msbl.NumberOfLinesToSkip = 1;
                      msbl.FieldTerminator = ",";
                      msbl.FieldQuotationCharacter = '"';
                      msbl.Load();

                    ViewBag.Feedback = "Upload complete";

                }
            else
            {
                ViewBag.Feedback = "Please select a file";
            }



            return View("Index");

            }
            catch (Exception ex)
            {
                ViewBag.Feedback = ex.Message;
                return View("Index");
            }

            finally
            {
                con.Close();
                con.Dispose();
            }




        }



      
    }
}
