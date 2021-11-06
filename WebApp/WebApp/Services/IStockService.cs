using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IStockService
    {
        Task<Stock> GetStock(string name);
    }
}