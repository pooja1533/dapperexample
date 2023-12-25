using Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace Project.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        public ActionResult Index()
        {
            List<Friend> FriendList = new List<Friend>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
            {

                FriendList = db.Query<Friend>("Select * From tblFriends").ToList();
            }
            return View(FriendList);
        }

        // GET: Friend/Details/5
        public ActionResult Details(int id)
        {
            try
            {
               Friend FriendList = new Friend();
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
                {
                    FriendList = db.Query<Friend>("select * from tblFriends where FriendID=" + id).FirstOrDefault();
                }
                return View(FriendList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Friend/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friend/Create
        [HttpPost]
        public ActionResult Create(Friend friend)
        {
            try
            {
                List<Friend> FriendList = new List<Friend>();
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
                {

                    string query = "insert into tblFriends (FriendName,City,PhoneNumber) values(" +"'"+ friend.FriendName+"'" + "," +"'"+ friend.City+"'"+"," +"'"+ friend.PhoneNumber+"'" + ")";
                    db.Execute(query);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Friend/Edit/5
        public ActionResult Edit(int id)
        {

            Friend FriendList = new Friend();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
            {
                FriendList = db.Query<Friend>("select * from tblFriends where FriendID=" + id).FirstOrDefault();
            }
            return View(FriendList);
        }

        // POST: Friend/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Friend friend)
        {
            try
            {
                // TODO: Add update logic here
                Friend FriendList = new Friend();
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
                {
                    string query="update tblFriends set FriendName="+"'"+friend.FriendName+"'"+ ",City="+"'"+friend.City+"'"+ ",PhoneNumber="+"'"+friend.PhoneNumber+"'" + "where FriendID=" + id;
                    db.Execute(query);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: Friend/Delete/5
        public ActionResult Delete(int id)
        {
            Friend FriendList = new Friend();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
            {
                FriendList = db.Query<Friend>("select * from tblFriends where FriendID=" + id).FirstOrDefault();
            }
            return View(FriendList);
        }

        // POST: Friend/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Friend FriendList = new Friend();
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
                {

                    string query = "delete from  tblFriends where FriendID="+id;
                    db.Execute(query);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
