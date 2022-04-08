using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExcelDataReader;
using MusicScaffold.Models;

namespace MusicScaffold.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Genre);

            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View(movies.ToList());
            }

            return View("ReadOnlyList", movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create([Bind(Include = "Id,Name,ReleaseDate,DateAdded,NumberInStocks,GenreId,File")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                // ---- This is to upload files into folder ----
                var path = Server.MapPath("~/App_Data/UploadFiles");
                var fileName = Path.GetFileName(movie.File.FileName);
                var fullPath = Path.Combine(path, fileName);
                movie.File.SaveAs(fullPath);
                // ---- This is to upload files into folder ----

                //---- Excel Reader ----//
                ////var fileExtension = new FileInfo(movie.File.FileName).Extension;
                ////IExcelDataReader excelReader = null;
                ////if (fileExtension == ".xlsx")
                ////{
                ////    excelReader = ExcelReaderFactory.CreateOpenXmlReader(File.InputStream);
                ////}
                ////else if (fileExtension == ".xls")
                ////{
                ////    excelReader = ExcelReaderFactory.CreateBinaryReader(File.InputStream);
                ////}

                ////DataSet ds = excelReader.AsDataSet();
                ////DataTable dt = ds.Tables[0];
                //---- Excel Reader ----//

                movie.byteFile = ConvertToBytes(movie.File);
                movie.FileExtension = new FileInfo(movie.File.FileName).Extension;
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit([Bind(Include = "Id,Name,ReleaseDate,DateAdded,NumberInStocks,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileResult DownloadFile(int? id)
        {
            var movie = db.Movies.Find(id);
            return File(movie.byteFile, "application/octet-stream", string.Format(@"{0}{1}", "Movie Certificate", movie.FileExtension));
        }

        private byte[] ConvertToBytes(HttpPostedFileBase file)
        {
            var reader = new BinaryReader(file.InputStream);
            return reader.ReadBytes(file.ContentLength);
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
