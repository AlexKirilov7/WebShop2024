using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebShop2024.Core.Contracts;
using WebShop2024.Infrastructure.Data;
using WebShop2024.Infrastructure.Data.Entities;

namespace WebShop2024.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Create(string name, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount)
        {
            // Creating a new Product object
            Product item = new Product
            {
                ProductName = name,
                Brand = _context.Brands.Find(brandId),
                Category = _context.Categories.Find(categoryId),
                Picture = picture,
                Quantity = quantity,
                Price = price,
                Discount = discount
            };

            // Adding the product to the Products DbSet and saving changes to the database
            _context.Products.Add(item);
            return _context.SaveChanges() != 0;

           

        }
        public Product GetProductById(int productId)
        {
            return _context.Products.Find(productId);
        }

        public List<Product> GetProducts()
        {
            List<Product> products = _context.Products.ToList();
            return products;
        }
        public List<Product> GetProducts(string searchStringCategoryName, string searchStringBrandName)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(searchStringCategoryName) && !string.IsNullOrEmpty(searchStringBrandName))
            {
                products = products.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower()) ||
                                                x.Brand.BrandName.ToLower().Contains(searchStringBrandName.ToLower()));
            }
            else if (!string.IsNullOrEmpty(searchStringCategoryName))
            {
                products = products.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower()));
            }
            else if (!string.IsNullOrEmpty(searchStringBrandName))
            {
                products = products.Where(x => x.Brand.BrandName.ToLower().Contains(searchStringBrandName.ToLower()));
            }

            return products.ToList();
        }

        public bool RemoveById(int productId)
        {
            var product = GetProductById(productId);
            if (product == null) 
                return false;

            _context.Products.Remove(product);  
            return _context.SaveChanges() != 0;  
        }
        public bool Update(int productId, string name, int brandId, int categoryId, string picture, int quantity, decimal price, decimal discount)
        {
            var product = GetProductById(productId);
            if (product == null) // Use `null` for checking if the product was not found
                return false;

            product.ProductName = name;
            product.BrandId = brandId; // Assuming BrandId is the correct property name
            product.CategoryId = categoryId; // Assuming CategoryId is the correct property name
            product.Picture = picture;
            product.Quantity = quantity;
            product.Price = price;
            product.Discount = discount;

            _context.Update(product);
            return _context.SaveChanges() != 0;
        }


    }

}
