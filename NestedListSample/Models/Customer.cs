using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedListSample.Models
{
    public class Customer
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public virtual ICollection<Record> Records { get; set; }

        public Customer()
        {
            Records = new List<Record>();
        }
    }
}
