using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CatagoryController : Controller
    {
        private readonly ApplictionDbContxt _db;
        public CatagoryController(ApplictionDbContxt db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Catagory> objCataogryList = _db.Catagories.ToList();
            return View(objCataogryList);
        }
        //get
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Catagory obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder Cannt exact match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.Catagories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Catagory Created Successfuly" ;
                return RedirectToAction("Index");
            }
            return View(obj);
        }


// get
public IActionResult Edit(int? Id)
{
    if(Id==null || Id==0 )
    {
        return NotFound();
    }
            var CatagoryFromDb = _db.Catagories.Find(Id);
           // var CatagoryFromDbFirst = _db.Catagories.FirstOrDefault(u => u.Id == Id);
           // var CatagoryFromDbSingle = _db.Catagories.SingleOrDefault(u => u.Id);
           if (CatagoryFromDb == null)
            {
                return NotFound();
            }

            return View(CatagoryFromDb);
}
//post
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(Catagory obj)
{
    if (obj.Name == obj.DisplayOrder.ToString())
    {
        ModelState.AddModelError("Name", "The DisplayOrder Cannt exact match the name.");
    }
    if (ModelState.IsValid)
    {
        _db.Catagories.Update(obj);
        _db.SaveChanges();
        TempData["Success"] = "Catagory Updated Successfuly";
         return RedirectToAction("Index");
    }
    return View(obj);
}


        // get
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var CatagoryFromDb = _db.Catagories.Find(Id);
            // var CatagoryFromDbFirst = _db.Catagories.FirstOrDefault(u => u.Id == Id);
            // var CatagoryFromDbSingle = _db.Catagories.SingleOrDefault(u => u.Id);
            if (CatagoryFromDb == null)
            {
                return NotFound();
            }

            return View(CatagoryFromDb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _db.Catagories.Find(Id);
            if(obj == null)
            {
                return NotFound();
            }
                _db.Catagories.Remove(obj);
                _db.SaveChanges();
                TempData["Success"] = "Catagory Deleted Successfuly";
                return RedirectToAction("Index");
                return View(obj);
        }
    }
}
