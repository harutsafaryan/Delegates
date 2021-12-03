using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public class Item
    {
        public Item(int article, string name, int qty)
        {
            Article = article;
            Name = name;
            Qty = qty;
        }
        public int Article { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public const int MinQty = 5;
        public const int MaxQty = 100;
    }
    public class Stock
    {
        List<Item> _items = new List<Item>();
        public Stock(List<Item> items)
        {
            _items = items;
        }

        public delegate void StockOpertation(string message);
        StockOpertation _del;

        public void RegisterHandler(StockOpertation del)
        {
            _del += del;
        }

        public void UnregisterHandler(StockOpertation del)
        {
            _del -= del;
        }

        public void AddQty(int article, int qty)
        {
            Item currentItem = _items.FirstOrDefault(x => x.Article == article);
            currentItem.Qty += qty;

            if (currentItem.Qty > Item.MaxQty)
                _del?.Invoke($"The Item {currentItem.Name} rich the maximum qty");
        }

        public void TakOfQty(int article, int qty)
        {
            Item currentItem = _items.FirstOrDefault(x => x.Article == article);
            currentItem.Qty -= qty;

            if (currentItem.Qty < Item.MinQty)
                _del?.Invoke($"The Item {currentItem.Name} rich the minimum qty");
        }
    }
}
