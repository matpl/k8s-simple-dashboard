using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KubeCtlApi.Models
{
    public class NamespacedList<T>
    {
        public NamespacedList() {
            Items = new List<T>();
        }

        public IList<T> Items { get; set; }
        public string Namespace { get; set; }
    }
}
