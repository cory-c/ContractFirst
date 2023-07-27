using Example.Controllers;
namespace ContractFirst.Controllers;

public class QuoteControllerImp : IQuotesController
{
    public Task<IEnumerable<MovieQuote>> GetQuotesAsync()
    {
        throw new NotImplementedException();
    }
}