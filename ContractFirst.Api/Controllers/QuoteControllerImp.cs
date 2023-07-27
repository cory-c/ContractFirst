using Example.Controllers;
namespace ContractFirst.Controllers;

public class QuoteControllerImp : IQuotesController 
{
    public Task<IEnumerable<MovieQuote>> GetQuotesByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MovieQuote>> GetQuotesByFilterAsync()
    {
        throw new NotImplementedException();
    }
    
    public Task<IEnumerable<MovieQuote>> GetRandomQuoteAsync()
    {
        throw new NotImplementedException();
    }
}