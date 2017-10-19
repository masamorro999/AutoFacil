namespace AutosRa.Backend.Controllers
{
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Net;
    using System.Web.Mvc;
    using AutosRA.Domain;
    using AutosRa.Backend.Models;
    using AutosRa.Backend.Helpers;
    using AutosRA.Backend.Models;
    using System;

    //[Authorize]
    public class VehiclesController : Controller
    {
        private DataContextLocal db = new DataContextLocal();

        // GET: Vehicles
        public async Task<ActionResult> Index()
        {
            var vehicles = db.Vehicles.Include(v => v.Category);
            return View(await vehicles.ToListAsync());
        }
         
        // GET: Vehicles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VehicleView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Images";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var vehicle = ToVehicle(view);
                vehicle.Image = pic;
                db.Vehicles.Add(vehicle);

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", view.CategoryId);
            return View(view);
        }

        private Vehicle ToVehicle(VehicleView view)
        {
            return new Vehicle
            {
                Category = view.Category,
                CategoryId = view.CategoryId,
                Description = view.Description,
                Image = view.Image,
                IsActive = view.IsActive,
                LastPurchase = view.LastPurchase,
                Price = view.Price,
                VehicleId = view.VehicleId,
                Remarks = view.Remarks,
                Stock = view.Stock
            };
        }

        // GET: Vehicles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var vehicle = await db.Vehicles.FindAsync(id);

            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", vehicle.CategoryId);
            var view = Toview(vehicle);

            return View(view);
        }

        private VehicleView Toview(Vehicle vehicle)
        {
            return new VehicleView
            {
                Category = vehicle.Category,
                CategoryId = vehicle.CategoryId,
                Description = vehicle.Description,
                Image = vehicle.Image,
                IsActive = vehicle.IsActive,
                LastPurchase = vehicle.LastPurchase,
                Price = vehicle.Price,
                VehicleId = vehicle.VehicleId,
                Remarks = vehicle.Remarks,
                Stock = vehicle.Stock
            };
        }

        // POST: Vehicles/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit( VehicleView view)
        {
            if (ModelState.IsValid)
            {
                var pic = view.Image;
                var folder = "~/Content/Images";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var vehicle = ToVehicle(view);
                vehicle.Image = pic;

                db.Entry(vehicle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Description", view.CategoryId);
            return View(view);
        }

        // GET: Vehicles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Vehicle vehicle = await db.Vehicles.FindAsync(id);
            db.Vehicles.Remove(vehicle);
            await db.SaveChangesAsync();
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
