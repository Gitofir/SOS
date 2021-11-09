using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IStockService
    {
        Task<Stock> GetStock(string symbol);
        Task UpdateStockDetails(string sSymbol, string sName, double sPrice, double sChange, string sCategory);
        Task AddStock(Stock newStock);
    }
}