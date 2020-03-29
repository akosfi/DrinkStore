using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkStore.BLL.DTOs
{
    public class SubcategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
