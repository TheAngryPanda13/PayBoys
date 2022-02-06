using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayBoys
{
    class JsonItems
    {
        public string name { get; set; }
        public int price { get; set; }
        public int sum { get; set; }
        public double quantity 
        { 
            get
            {
                return Convert.ToInt32(this.quantity);
            }

            set 
            { 
                quantity = value; 
            } 
        }
    }
}
