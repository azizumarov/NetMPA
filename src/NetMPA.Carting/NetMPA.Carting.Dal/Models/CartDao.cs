using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Carting.Dal.Models
{
    public class CartDao
    {
        private IList<ItemDao> items;

        public Guid Id { get; set; }
        public IEnumerable<ItemDao> Items { get { return items; } }

        public void AddItem(ItemDao itemDao) 
        {
            items.Add(itemDao);
        }

        public bool DeleteItem(int itemId) {
            var item = items.FirstOrDefault(x => x.Id == itemId);
            if(item != null)
            {
                return items.Remove(item);
            }
            
            return false;
        }
    }
}
