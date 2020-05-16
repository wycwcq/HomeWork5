using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace HomeWork5
{
    public class OrderService
    {
        //货物列表
        public List<Order> orders;
        public OrderService()
        {
            orders = new List<Order>();
        }
        public void AddOrder(Order order)
        {
            if(orders.Contains(order))
            {
                throw new ApplicationException($"添加订单错误：订单ID{order.OrderID}");
            }
            else
            {
                orders.Add(order);
            }
        }
        public void ReMove(uint orderId)
        {
            Order order = GetOrder(orderId);
            if (order != null)
            {
                orders.Remove(order);
            }
        }
        public List<Order> QuaryByCustomer(string Customer)
        {
            var result = orders
                .Where(order => order.CustomerName == Customer)
                .OrderBy(x => x.TotalPrice);
            return result.ToList();
        }
        public List<Order> QuaryByName(string Name)
        {
            var result = orders.Where(order => order.items.Exists(item => item.Name == Name)).OrderBy(y => y.TotalPrice);
            return result.ToList();
        }
        public Order GetOrder(uint id)
        {
            return orders.Where(x => x.OrderID == id).FirstOrDefault();
        }
        public void UpdateOrder(Order newOrder)
        {
            Order oldOrder = GetOrder(newOrder.OrderID);
            if (oldOrder == null)
                throw new ApplicationException($"更新失败：the order with id {newOrder.OrderID} 不存在!");
            orders.Remove(oldOrder);
            orders.Add(newOrder);
        }
        public void Sort()
        {
            orders.Sort();
        }

        public void Sort(Func<Order, Order, int> func)
        {
            orders.Sort((o1, o2) => func(o1, o2));
        }
    }
}
