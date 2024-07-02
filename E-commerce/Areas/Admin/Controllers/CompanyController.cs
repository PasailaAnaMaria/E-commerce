using E_commerce_DataAccess.Repository.IRepository;
using E_commerce_Models.Models;
using E_commerce_Models.ViewModels;
using E_commerce_Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            
            return View(objCompanyList);
        }
# region Funct Create
        //public IActionResult Create()
        //{
        //    ProductVM productVM = new()
        //    {
        //        CategoryList = _unitOfWork.Category.GetAll().Select(u =>
        //            new SelectListItem
        //            {
        //                Text = u.Name,
        //                Value = u.Id.ToString()
        //            }),
        //        // CategoryList = CategoryList,
        //        Product=  new Product()
        //    };
        //    return View(productVM);

        //}
#endregion
      
        
        public IActionResult Upsert(int? id)
        {
           
            if ( id == null || id == 0 )
            {
                //create
              return View(new Company());
            }
            else
            {
                //update 
                Company companyObj= _unitOfWork.Company.Get(u=>u.Id==id);
                return View(companyObj);
            }
           

        }

        #region Funct Create   
        //public IActionResult Create(ProductVM obj)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Product.Add(obj.Product);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Product created successfully";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        obj.CategoryList = _unitOfWork.Category.GetAll().Select(u =>
        //            new SelectListItem
        //            {
        //                Text = u.Name,
        //                Value = u.Id.ToString()
        //            });

        //        return View(obj);
        //    }
        //}
        #endregion
       
        
        [HttpPost]
        public IActionResult Upsert(Company companyObj)
        {

            if (ModelState.IsValid)
            {
               
                if (companyObj.Id ==0) 
                {
                    _unitOfWork.Company.Add(companyObj);
                }
                else
                {
                    _unitOfWork.Company.Update(companyObj);
                }
               
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(companyObj);
            }


        }
        #region Funct Edit

        /////
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //   Product product = _unitOfWork.Product.Get(u => u.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);

        //}
        //[HttpPost]
        //public IActionResult Edit(Product obj)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Product.Update(obj);
        //        _unitOfWork.Save();
        //        TempData["success"] = "Product Updated successfully";
        //        return RedirectToAction("Index");
        //    }
        //    return View(obj);

        //}
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Product? product = _unitOfWork.Product.Get(u => u.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(product);

        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{
        //    Product? product = _unitOfWork.Product.Get(u => u.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Product.Remove(product);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Product deleted successfully";
        //    return RedirectToAction("Index");



        //}
        #region API's Call
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }
        #endregion

        #region API's Call
        [HttpDelete]
        public IActionResult Delete(int? id)
        {

            var CompanyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);
            if (CompanyToBeDeleted == null)
            {

                return Json(new { success = false, message = "Error while deleting" });
            }
           
            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });


        }
        #endregion
    }
}
