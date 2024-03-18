using SellPhonesStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhonesStore.DataAccess
{
    public interface IPhoneRepository
    {
        long SavePhone(Phone phone);
        long SaveCustomer(Customer customer);
        long SaveOrder(CustomerOrder order);
        long SaveOrderedPhone(OrderedPhone orderPhone, long orderId);
        List<CustomerOrder> GetCustomerOrders(long customerId);
        List<CustomerOrder> GetAllCustomerOrders();
    }
}
