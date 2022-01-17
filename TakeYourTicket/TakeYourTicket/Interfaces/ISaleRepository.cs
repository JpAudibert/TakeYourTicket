using System.Threading.Tasks;
using TakeYourTicket.Models;

namespace TakeYourTicket.Interfaces
{
    public interface ISaleRepository
    {
        public Task<Sale> Create(Sale sale);
        public Task Commit();
    }
}
