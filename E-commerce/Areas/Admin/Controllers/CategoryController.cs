using E_commerce_DataAccess.Data;
using E_commerce_DataAccess.Repository.IRepository;
using E_commerce_Models.Models;
using Microsoft.AspNetCore.Mvc;


namespace E_commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        //private readonly ICategoryRepository _categoryRepository;
        //public CategoryController(ICategoryRepository  categoryRepository)
        //{
        //        _categoryRepository = categoryRepository;   
        //}
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString() )
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            //}

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        /////
        /// <summary>
        /// 
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category category = _unitOfWork.Category.GetAll(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _unitOfWork.Category.GetAll(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _unitOfWork.Category.GetAll(u => u.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");



        }
    }
}
