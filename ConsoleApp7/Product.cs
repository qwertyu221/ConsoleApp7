using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Product
    {

        public string city { get; set; }
        public string breadcrump { get; set; }
        public string name { get; set; }
        public string price { get; set; }
        public string oldprice { get; set; }
        public string exist { get; set; }
        public string pnglinks { get; set; }
        public string link { get; set; }

        public Product (string city, string breadcrump, string name, string price, string oldprice, string exist, string pnglinks, string link) {
            this.city = city;
            this.breadcrump = breadcrump;
            this.name = name;
            this.price = price;
            this.oldprice = oldprice;
            this.exist = exist;
            this.pnglinks = pnglinks;
            this.link = link;
        }


    }
}
