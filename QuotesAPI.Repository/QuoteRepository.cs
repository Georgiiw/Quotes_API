using QuotesAPI.Data;
using QuotesAPI.Data.Models;
using QuotesAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuotesAPI.Repository
{
    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {
        private ApplicationDbContext _dbContext;
        public QuoteRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Update(Quote quote)
        {
            _dbContext.Quotes.Update(quote);
            await SaveAsync();
        }
    }
}
