﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebShop2024.Models.Product
{
    public class ProductDetailsVM : Controller
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = null!;
        public int BrandId { get; set; }

        [Display(Name = "Brand")]
        public string BrandName { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "CategoryId")]
        public string CategoryName { get; set; } = null!;
        [Display(Name = "Picture")]
        public string Picture { get; set; } = null!;
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
    }
}
