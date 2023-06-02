using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagmentSytem.Models;

namespace HotelManagmentSytem.Controllers
{
    public class ReservationsController : Controller
    {
        private HotelEntities db = new HotelEntities();

        // GET: Reservations
        public ActionResult Index(string option, string search)
        {
            var reservations = db.Reservations.Include(r => r.Clients).Include(r => r.Rooms);
            if (option == "reservation_id")
            {
                int num = Convert.ToInt32(search);
                return View(db.Reservations.Where(x => x.reservation_id == num || num == null).ToList());
            } else if(option == "client_id")
            {
                int num2 = Convert.ToInt32(search);
                return View(db.Reservations.Where(x => x.client_id == num2 || num2 == null).ToList());
            } else if(option == "room_id")
            {
                int num3 = Convert.ToInt32(search);
                return View(db.Reservations.Where(x => x.room_id == num3 || num3 == null).ToList());
            } else
            {
                return View(db.Reservations.ToList());
            }
            /* if (option == "passport_number")
             {
                 //Index action method will return a view with a student records based on what a user specify the value in textbox  
                 return View(db.Reservations.Where(x => x.passport_number == search || search == null).ToList());
             }
             else if (option == "phone_number")
             {
                 return View(db.Reservations.Where(x => x.phone_number == search || search == null).ToList());
             }
             else if (option == "full_name")
             {
                 return View(db.Reservations.Where(x => x.full_name.Contains(search)).ToList());
             }
             else
             {
                 return View(db.Reservations.ToList());
             }
            */
            return View(db.Reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservations reservations = db.Reservations.Find(id);
            if (reservations == null)
            {
                return HttpNotFound();
            }
            return View(reservations);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.client_id = new SelectList(db.Clients, "client_id", "full_name");
            ViewBag.room_id = new SelectList(db.Rooms, "room_id", "comfort_level");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "reservation_id,client_id,room_id,check_in_date,check_out_date,deposit_type,total_amount,is_paid")] Reservations reservations)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client_id = new SelectList(db.Clients, "client_id", "full_name", reservations.client_id);
            ViewBag.room_id = new SelectList(db.Rooms, "room_id", "comfort_level", reservations.room_id);
            return View(reservations);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservations reservations = db.Reservations.Find(id);
            if (reservations == null)
            {
                return HttpNotFound();
            }
            ViewBag.client_id = new SelectList(db.Clients, "client_id", "full_name", reservations.client_id);
            ViewBag.room_id = new SelectList(db.Rooms, "room_id", "comfort_level", reservations.room_id);
            return View(reservations);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reservation_id,client_id,room_id,check_in_date,check_out_date,deposit_type,total_amount,is_paid")] Reservations reservations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.client_id = new SelectList(db.Clients, "client_id", "full_name", reservations.client_id);
            ViewBag.room_id = new SelectList(db.Rooms, "room_id", "comfort_level", reservations.room_id);
            return View(reservations);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservations reservations = db.Reservations.Find(id);
            if (reservations == null)
            {
                return HttpNotFound();
            }
            return View(reservations);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservations reservations = db.Reservations.Find(id);
            db.Reservations.Remove(reservations);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
