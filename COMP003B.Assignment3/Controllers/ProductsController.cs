using COMP003B.Assignment3_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace COMP003B.Assignment3_.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Product> _products = new List<Product>();
        public IActionResult Index()
        {
            return View(_products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                if (!_products.Any(s => s.Id == product.Id))
                {
                    _products.Add(product);
                }

                return RedirectToAction(nameof(Index));
            }
            return View();

        }

        [HttpGet]
        public IActionResult Edit(int? id) 
        {
        if (id == null) 
            { 
            return NotFound();
            }

        var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null) 
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
        if (id != product.Id) 
            {
                return NotFound();
            }

        if (ModelState.IsValid) 
            { 
            var existingProduct = _products.FirstOrDefault(s => s.Id == product.Id);

                if (existingProduct != null)
                {
                
                    existingProduct.Id = product.Id;
                    existingProduct.Name = product.Name;
                }
                return RedirectToAction(nameof(Index));
            }
        return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
        if (id == null)
            {
                return NotFound();
            }

        var product = _products.FirstOrDefault(s => s.Id == id);

            if (product!= null) 
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteComfirmed(int id) 
        {
        var product = _products.FirstOrDefault(s => s.Id == id);
            if (product!= null) 
            {
            _products.Remove(product);
            }

            return RedirectToAction(nameof(Index));
        }

        
    }
}
