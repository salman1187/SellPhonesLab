using SellPhonesStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhonesStore.DataAccess
{
    public class PhoneRepository : IPhoneRepository
    {
        SellPhonesStoreDbContext db = new SellPhonesStoreDbContext();
        public List<CustomerOrder> GetAllCustomerOrders()
        {
            var orders = (from ord in db.CustomerOrders
                         select ord).ToList();
            return orders;
        }

        public List<CustomerOrder> GetCustomerOrders(long customerId)
        {
            var orders = db.Customers.Find(customerId);
            return orders.Orders;
        }

        public long SaveCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer.CustomerId;
        }

        public long SaveOrder(CustomerOrder order)
        {
            db.CustomerOrders.Add(order);
            db.SaveChanges();
            return order.OrderId;
        }

        public long SaveOrderedPhone(OrderedPhone orderPhone, long orderId)
        {
            db.OrderedPhones.Add(orderPhone);
            db.SaveChanges();
            var order = db.CustomerOrders.Find(orderId);
            order.OrderedPhones.Add(orderPhone);
            db.SaveChanges();

            return orderPhone.OrderedPhoneId;
        }

        public long SavePhone(Phone phone)
        {
            db.Phones.Add(phone);
            db.SaveChanges();
            return phone.PhoneId;
        }
    }
}
