using QuotesAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesAPI.Repository.IRepository
{
    public interface IQuoteRepository : IRepository<Quote>
    {
        Task Update(Quote quote);
    }
}
