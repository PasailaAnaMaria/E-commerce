using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name ="List Price")]
        [Range(1,1000)]
        public double ListPrice { get; set; }
        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Price for +50")]
        [Range(1, 1000)]
        public double Price50 { get; set; }
        [Required]
        [Display(Name = "Price for +100")]
        [Range(1, 1000)]
        public double Price100 { get; set; }


        //we add here 2 prop for the relatrion between two table Categori
        //and product= the resul is we add the CategoryId in the product Table
        //and if we go in the db product table we can see the FK 
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
