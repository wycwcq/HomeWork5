using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    public class OrderItem
    {
        public uint ID { get; set; }  //序号
        //货物名称
        public String Name { get; set; }
        //数量
        public uint Number
        {
            get;
            set;
        }
        //单价
        public double Price{ get; set; }
        public OrderItem() { }
        public OrderItem(uint ID, String Name, double Price, uint Number)
        {
            this.ID = ID;
            this.Name = Name;
            this.Price = Price;
            this.Number = Number;
        }
        public double TotalPrice
        {
            get => Number * Price;
        }
        public override string ToString()
        {
            return $"[No.:{ID},goods:{Name},quantity:{Number},totalPrice:{TotalPrice}]";
        }
        public override bool Equals(object obj)
        {
            var temp = obj as OrderItem;
            return temp != null && temp.Name == this.Name;
        }
        public override int GetHashCode()
        {
            var hashCode = -2127111111;
            hashCode = hashCode * -1567725652 + ID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            return hashCode;
        }
    }
}
