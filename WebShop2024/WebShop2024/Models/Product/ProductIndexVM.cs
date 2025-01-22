using System.ComponentModel.DataAnnotations;

namespace WebShop2024.Models.Product
{
    public class ProductIndexVM
    {
        [Key]
        public int Id { get; set; }  // 4 references

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }  // 3 references

        public int BrandId { get; set; }  // 1 reference

        [Display(Name = "Brand")]
        public string BrandName { get; set; }  // 1 reference

        public int CategoryId { get; set; }  // 3 references

        [Display(Name = "Category")]
        public string CategoryName { get; set; }  // 3 references

        [Display(Name = "Picture")]
        public string Picture { get; set; }  // 3 references

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }  // 3 references

        [Display(Name = "Price")]
        public decimal Price { get; set; }  // 3 references

        [Display(Name = "Discount")]
        public decimal Discount { get; set; }  // 3 references
    }

}
