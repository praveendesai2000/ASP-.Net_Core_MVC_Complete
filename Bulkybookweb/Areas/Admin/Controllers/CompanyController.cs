using Bulkybook.DataAccess;
using Bulkybook.DataAccess.Repository.IRepository;
using Bulkybook.Models;
using Bulkybook.Models.ViewModels;
using Bulkybook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bulkybookweb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitofWork _unitofWork;
       

        public CompanyController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
           
        }
        public IActionResult Index()
        {
            return View();
        }
        //Get
      
        //Get
        public IActionResult Upsert(int? id)
        {
            Company company = new();
            

            if (id == null || id == 0)
            {
                return View(company);
            }
            else
            {
                company = _unitofWork.Company.GetFirstOrDefault(u => u.Id == id);
              
                return View(company);
            }
          
           

        }


        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Company obj)
        {
           
            if (ModelState.IsValid)
            {
       
                if(obj.Id==0)
                {
                    _unitofWork.Company.Add(obj);
                    TempData["success"] = "Company Updated successfully";
                }
                else
                {
                    _unitofWork.Company.update(obj);
                    TempData["success"] = "Company Updated successfully";
                }

                
                _unitofWork.Save();
               
                return RedirectToAction("Index");
            }
            return View(obj);
        }
       



        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var companyList = _unitofWork.Company.GetAll();
            return Json(new { data = companyList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitofWork.Company.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitofWork.Company.Remove(obj);
            _unitofWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

            


        }

        #endregion
    }
}



