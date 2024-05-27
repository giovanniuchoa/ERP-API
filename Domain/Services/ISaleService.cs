﻿using CarQuery__Test.Domain.Models;

namespace CarQuery__Test.Domain.Services
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> GetAllSalesAsync();
        Task<Sale> GetSaleByIdAsync(int id);
        Task<Sale> CreateSaleAsync(Sale sale);
        Task<Sale> UpdateSaleAsync(int id, Sale sale);
        Task<bool> DeleteSaleAsync(int id);

    } 
}
