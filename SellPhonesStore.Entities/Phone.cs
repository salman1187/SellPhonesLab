using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhonesStore.Entities
{
    public class Phone
    {
        public long PhoneId { get; set; }
        [Required]
        [MaxLength(500)]
        public string PhoneDescription {  get; set; }
        [Range(0, float.MaxValue)]
        public float Price { get; set; }
        public DateTime ManufacturingDate { get; set; } 
        public string BrandName { get; set; }
        public int InStock { get; set; }
    }
    public class OrderedPhone
    {
        public long OrderedPhoneId { get; set; }
        public virtual Phone TheOrderedPhone { get; set; }
        [Range(0, float.MaxValue)]
        public float Quantity { get; set; }
    }
    public class CustomerOrder
    {
        [Key]
        public long OrderId { get; set;}
        public DateTime OrderDate { get; set; }
        public virtual Customer Customer { get; set; }  
        public float OrderTotal { get; set; }   
        public virtual List<OrderedPhone> OrderedPhones { get; set; } = new List<OrderedPhone>();
    }
    public class Customer
    {
        public long CustomerId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CustomerName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string PinCode { get; set; }
        public long MobileNo { get; set; }
        public virtual List<CustomerOrder> Orders { get; set; } = new List<CustomerOrder>();
    }
}
