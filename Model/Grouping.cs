using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMAUI.Model
{
    public class Grouping<TKey, TItem> : ObservableCollection<TItem>, IGrouping<TKey, TItem>
    {
        public TKey Key { get; private set; }

        public Grouping(TKey key, IEnumerable<TItem> items)
        {
            Key = key;
            foreach (var item in items)
            {
                this.Items.Add(item);
            }
        }
    }
}
