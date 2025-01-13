using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebShop2024.Core.Contracts;
using WebShop2024.Core.Services;
using WebShop2024.Models.Brand;
using WebShop2024.Models.Category;
using WebShop2024.Models.Product;

// In SDK-style projects such as this one, several assembly attributes that were historically
// defined in this file are now automatically added during build and populated with
// values defined in project properties. For details of which attributes are included
// and how to customise this process see: https://aka.ms/assembly-info-properties


// Setting ComVisible to false makes the types in this assembly not visible to COM
// components.  If you need to access a type in this assembly from COM, set the ComVisible
// attribute to true on that type.

[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("bdd2b390-f141-4ff7-8a03-a004be2fdce7")]

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly IBrandService _brandService;
    public ProductController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
    {
        this._productService = productService;
        this._categoryService = categoryService;
        this._brandService = brandService;
    }

    public ActionResult Create()
    {
        var product = new ProductCreateVM();
        product.Brands = _brandService.GetBrands()
        .Select(x => new BrandPairVM()
        {
            Id = x.Id,
            Name = x.BrandName
        }).ToList();
        product.Categories = _categoryService.GetCategories()
        .Select(x => new CategoryPairVM()
        {
            Id = x.Id,
            Name = x.CategoryName
        }).ToList();
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([FromForm] ProductCreateVM product)
    {
        if (ModelState.IsValid)
        {
            var createdId = _productService.Create(product.ProductName, product.BrandId,
            product.CategoryId, product.Picture,
            product.Quantity, product.Price, product.Discount);
            if (createdId)
            {
            }
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
}

