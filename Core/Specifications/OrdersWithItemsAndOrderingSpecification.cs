using Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class OrdersWithItemsAndOrderingSpecification : BaseSpecification<Order>
    {
        public OrdersWithItemsAndOrderingSpecification(string email) : base(o => o.BuyerEmail == email)
        {
            AddIncludes();
            AddOrderByDescending(o => o.OrderDate);
        }

        public OrdersWithItemsAndOrderingSpecification(int id, string email) : base(o => o.Id == id && o.BuyerEmail == email)
        {
            AddIncludes();
        }

        private void AddIncludes()
        {
            AddInlclude(o => o.OrderItems);
            AddInlclude(o => o.DeliveryMethod);
        }
    }
}