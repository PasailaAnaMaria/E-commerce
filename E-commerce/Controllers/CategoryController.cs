using E_commerce_DataAccess.Data;
using E_commerce_Models.Models;
using Microsoft.AspNetCore.Mvc;


namespace E_commerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDBContext _dbContext;
        public CategoryController(AppDBContext appDBContext)
        {
            _dbContext = appDBContext; 
        }
        public IActionResult Index()
        {
            List<Category>objCategoryList= _dbContext.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create ()  
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
            _dbContext.Categories.Add(obj);
            _dbContext.SaveChanges();
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
    public IActionResult Edit (int? id)  
    {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category category = _dbContext.Categories.Find(id);
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
            _dbContext.Categories.Update(obj);
            _dbContext.SaveChanges(); 
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
            Category? category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            } 
            _dbContext.Categories.Remove(category);
             _dbContext.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
           
          

        }
    }
}
