using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string username);
        Task UpdateUserStocks(string username, string stockSymbol, int numOfStocks, double price);
        int GetStocksAmount(string username, string symbol);
        Task AddStockToList(Stock stock, string username);

    }
}