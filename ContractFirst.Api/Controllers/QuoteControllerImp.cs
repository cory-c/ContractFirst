using Example.Controllers;
namespace ContractFirst.Controllers;

public class QuoteControllerImp : IQuoteController
{
    public Task<IEnumerable<MovieQuote>> GetQuoteAsync()
    {
        throw new NotImplementedException();
    }
}