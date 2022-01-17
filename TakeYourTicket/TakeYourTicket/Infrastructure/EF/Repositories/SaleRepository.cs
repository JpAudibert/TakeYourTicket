using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeYourTicket.Interfaces;
using TakeYourTicket.Models;

namespace TakeYourTicket.Infrastructure.EF.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private DataContext _dataContext;
        private ISessionRepository _sessionRepository;

        public SaleRepository(DataContext dataContext, ISessionRepository sessionRepository)
        { 
            _dataContext = dataContext;
            _sessionRepository = sessionRepository;
        }

        public async Task Commit()
        {
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Sale> Create(Sale sale)
        {
            Session foundSession = await _sessionRepository.FindById(sale.SessionId);
            int desiredQuantity = _dataContext.Sales.Where(oldSales => oldSales.SessionId == sale.SessionId).Sum(oldSales => oldSales.Quantity) + sale.Quantity;

            if (desiredQuantity > foundSession.NumberOfSeats)
            {
                throw new ArgumentException("Quantity is over the limit.");
            }

            Sale newSale = new Sale(sale);

            _dataContext.Sales.Add(newSale);

            await Commit();

            return newSale;
        }
    }
}
