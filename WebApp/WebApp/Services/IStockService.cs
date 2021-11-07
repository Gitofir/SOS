using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IStockService
    {
        Task<Stock> GetStock(string name);
        Task UpdateStockDetails(string sName, double sPrice, double sChange);
        Task AddStock(Stock newStock);
    }
}