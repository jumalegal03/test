using System;
using System.Collections.Generic;
using System.Text;

namespace TST.ENTITIES.Models.Generals
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public DateTime CreateAt { get; set; }
        public string CategoryId { get; set; }
        public string Img { get; set; }
        public Category Category { get; set; }
    }
}
