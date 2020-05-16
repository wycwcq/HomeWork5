using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    public class Order:IComparable<Order>
    {
        //属性
        public List<OrderItem> items;
        public DateTime CreateTime;
        public uint OrderID;
        public String CustomerName;

        public Order()
        {
            items = new List<OrderItem>();
            CreateTime = DateTime.Now;
        }
        public Order(uint OrderID, string CustomerName, List<OrderItem> items)
        {
            this.OrderID = OrderID;
            this.CustomerName = CustomerName;
            this.CreateTime = DateTime.Now;
            if(this.items == null)
            {
                this.items = items;
            }
        }
        public double TotalPrice
        {
            get => items.Sum(item => item.TotalPrice);
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Id:{OrderID}, customer:{CustomerName},orderTime:{CreateTime},totalPrice：{TotalPrice}");
            items.ForEach(temp => stringBuilder.Append("\n\t" + temp));
            return stringBuilder.ToString();
        }
        public override bool Equals(object obj)
        {
            var temp = obj as Order;
            return temp != null && temp.OrderID == this.OrderID;
        }
        public override int GetHashCode()
        {
            var hashCode = -12312344;
            hashCode = hashCode * -1521134295 + OrderID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerName);
            hashCode = hashCode * -1521134295 + CreateTime.GetHashCode();
            return hashCode;
        }
        public void AddItem(OrderItem orderItem)
        {
            if(items.Contains(orderItem))
            {
                throw new ApplicationException($"orderItem-{orderItem} 已经存在!");
            }
            else
            {
                items.Add(orderItem);
            }
        }
        public void ReMove(OrderItem orderItem)
        {
            items.Remove(orderItem);
        }
        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return this.OrderID.CompareTo(other.OrderID);
        }
    }
}
