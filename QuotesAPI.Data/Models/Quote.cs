using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesAPI.Data.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

    }
}
