using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public string Keyword { get; set; }
        public DateTime SearchedAt { get; set; }
    }
}
