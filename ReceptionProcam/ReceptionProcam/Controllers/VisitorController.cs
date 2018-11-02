﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReceptionProcam.Models;
using ReceptionProcam.EntityModel;
using System.IO;
using System.Data.Entity;

namespace ReceptionProcam.Controllers
{
    public class VisitorController : Controller
    {
        // GET: Visitor
        DBNCSVisitorEntities objVisEnti = new DBNCSVisitorEntities();
        public ActionResult VisitorDetails()
        {
            GetAllVisitorsDetails();
            return View();
        }

        // GET: Visitor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        // GET: Visitor/CreateVisitor
        public ActionResult CreateVisitor()
        {
            try
            {
                Session["CapturedImage"] = "";
            clsVisitor personal = new clsVisitor();
            var lastVisitorPassNumber = objVisEnti.tblVisitors.OrderByDescending(c => c.Id).FirstOrDefault();
            var date  = DateTime.Now.ToString("yyyy");
            if (lastVisitorPassNumber == null)
            {
                personal.VisitorId = "NCSPUN" + Convert.ToString(date) + "1" ;
            }
            else
            {
                personal.VisitorId = "NCSPUN" + (Convert.ToString(date) + lastVisitorPassNumber.Id+1);
            }
            return View(personal);
            }
            catch (Exception)
            {
                
                return View();
            }
        }

        [HttpPost]
        public ActionResult Capture()
        {

            if (Request.InputStream.Length > 0)
            {
                using (StreamReader reader = new StreamReader(Request.InputStream))
                {
                    string hexString = Server.UrlEncode(reader.ReadToEnd());
                    string imageName = DateTime.Now.ToString("ddMMyyhhmmsstt");
                    string imagePath = string.Format("~/VisitorImage/{0}.png", imageName);
                    System.IO.File.WriteAllBytes(Server.MapPath(imagePath), ConvertHexToBytes(hexString));
                    Session["CapturedImage"] = VirtualPathUtility.ToAbsolute(imagePath);
                }
            }

            return View();
        }

        private static byte[] ConvertHexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }



        // POST: Visitor/Create
        [HttpPost]
        public ActionResult CreateVisitor(clsVisitor objVisitor)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    tblVisitor dbVis = new tblVisitor();
                    // Id, VisitorId, First_Name, Middel_Name, Last_Name, Form, ToMeet, SubLocation, Building, Gate,
                    // Purpose, TimeIn, Remark, ImagePath, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate
                    //Random rmd = new Random(9999);
                    dbVis.VisitorId = objVisitor.VisitorId;
                    dbVis.First_Name = objVisitor.First_Name;
                    dbVis.Middel_Name = objVisitor.Middel_Name;
                    dbVis.Last_Name = objVisitor.Last_Name;
                    dbVis.EmailId = objVisitor.Email;
                    dbVis.MobileNo = objVisitor.MobileNo.ToString();
                    dbVis.AssetId = objVisitor.AssetId.ToString();
                    dbVis.Form = objVisitor.Form;
                    dbVis.ToMeet = objVisitor.ToMeet;
                    dbVis.SubLocation = objVisitor.SubLocation;
                    dbVis.Building = objVisitor.Building;
                    dbVis.Gate = objVisitor.Gate;
                    dbVis.Purpose = objVisitor.Purpose;
                    dbVis.TimeIn = objVisitor.TimeIn.ToString();
                    dbVis.ValidUpto = objVisitor.ValidUpto.ToString();
                    dbVis.Remark = objVisitor.Remark;
                    dbVis.ImagePath = Session["CapturedImage"].ToString();
                    dbVis.CreatedBy = objVisitor.CreatedBy;
                    dbVis.CreatedDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    objVisEnti.tblVisitors.Add(dbVis);
                    objVisEnti.SaveChanges();
                    TempData["Success"] = "Visitor added Successfully!";
                    return RedirectToAction("PrintPass", new { id = dbVis.VisitorId });

                }
                else
                {
                    return View(objVisitor);
                }
            }
            catch
            {
                return View(objVisitor);
            }
        }

        [HttpGet]
        // GET: Visitor/Edit/5
        public ActionResult EditVisitor(int Id)
        {
            try
            {
                var VisData = objVisEnti.tblVisitors.Where(s => s.Id == Id).FirstOrDefault() ;
                clsVisitor VisDtls = new clsVisitor{ Id = VisData.Id,VisitorId=VisData.VisitorId,First_Name=VisData.First_Name,Middel_Name=VisData.Middel_Name, Last_Name=VisData.Last_Name, Form=VisData.Form, ToMeet=VisData.ToMeet, SubLocation=VisData.SubLocation,AssetId=VisData.AssetId,MobileNo=VisData.MobileNo,Email=VisData.EmailId,ValidUpto=VisData.ValidUpto, Building=VisData.Building, Gate=VisData.Gate,Purpose=VisData.Purpose, TimeIn=VisData.TimeIn, Remark=VisData.Remark, ImagePath=VisData.ImagePath, CreatedBy=VisData.CreatedBy, CreatedDate=VisData.CreatedDate, ModifiedBy=VisData.ModifiedBy, ModifiedDate=VisData.ModifiedDate };
                return View(VisDtls);
            }
            catch (Exception)
            {
                return View();
            }
            
        }

        // POST: Visitor/EditVisitor/5
        [HttpPost]
        public ActionResult EditVisitor(int Id, clsVisitor objVisitor)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dbVis = objVisEnti.tblVisitors.SingleOrDefault(b => b.Id == Id);
                    if (dbVis != null)
                    {
                        
                        dbVis.VisitorId = objVisitor.VisitorId;
                        dbVis.First_Name = objVisitor.First_Name;
                        dbVis.Middel_Name = objVisitor.Middel_Name;
                        dbVis.Last_Name = objVisitor.Last_Name;
                        dbVis.EmailId = objVisitor.Email;
                        dbVis.MobileNo = objVisitor.MobileNo.ToString();
                        dbVis.AssetId = objVisitor.AssetId.ToString();
                        dbVis.Form = objVisitor.Form;
                        dbVis.ToMeet = objVisitor.ToMeet;
                        dbVis.SubLocation = objVisitor.SubLocation;
                        dbVis.Building = objVisitor.Building;
                        dbVis.Gate = objVisitor.Gate;
                        dbVis.Purpose = objVisitor.Purpose;
                        dbVis.TimeIn = objVisitor.TimeIn.ToString();
                        dbVis.ValidUpto = objVisitor.ValidUpto.ToString();
                        dbVis.Remark = objVisitor.Remark;
                        dbVis.ImagePath = Session["CapturedImage"].ToString();
                        dbVis.CreatedBy = objVisitor.CreatedBy;
                        dbVis.CreatedDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        objVisEnti.tblVisitors.Add(dbVis);

                        objVisEnti.tblVisitors.Attach(dbVis);
                        objVisEnti.Entry(dbVis).State = EntityState.Modified;
                        objVisEnti.SaveChanges();
                        TempData["Success"] = "Visitor updated Successfully!";
                        return RedirectToAction("CreateVisitor");
                    }
                    else
                    {
                        return RedirectToAction("CreateVisitor");
                    }
                }
                else
                {
                    return View(objVisitor);
                }
            }
            catch
            {
                return View(objVisitor);
            }
        }

        // GET: Visitor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Visitor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void GetAllVisitorsDetails()
        {
            try
            {
                var AllVisitors = objVisEnti.tblVisitors.ToList();
                ViewBag.AllVisitorsDetalis = AllVisitors;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult ViewVisitor()
        {
            try
            {
                var AllVisitors = objVisEnti.tblVisitors.ToList();
                ViewBag.AllVisitorsDetalis = AllVisitors;
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult PrintPass(string Id)
        {
            try
            {
                var VisData = objVisEnti.tblVisitors.Where(s => s.VisitorId == Id).FirstOrDefault();
                clsVisitor VisDtls = new clsVisitor { Id = VisData.Id, VisitorId = VisData.VisitorId, First_Name = VisData.First_Name, Middel_Name = VisData.Middel_Name, Last_Name = VisData.Last_Name, Form = VisData.Form, ToMeet = VisData.ToMeet, SubLocation = VisData.SubLocation, AssetId = VisData.AssetId, MobileNo = VisData.MobileNo, Email = VisData.EmailId, ValidUpto = VisData.ValidUpto, Building = VisData.Building, Gate = VisData.Gate, Purpose = VisData.Purpose, TimeIn = VisData.TimeIn, Remark = VisData.Remark, ImagePath = VisData.ImagePath, CreatedBy = VisData.CreatedBy, CreatedDate = VisData.CreatedDate, ModifiedBy = VisData.ModifiedBy, ModifiedDate = VisData.ModifiedDate };
                return View(VisDtls);
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
