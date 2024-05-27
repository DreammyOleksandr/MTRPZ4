using MTRPZ4.CoreDomain.Entities;
using MTRPZ4.Infrastructure.DataStorage;
using MTRPZ4.Infrastructure.Repository.IRepository;

namespace MTRPZ4.Infrastructure.Repository;

public class PriceRepository : IPriceRepository
{
    private readonly IDataStorage _data;

    public PriceRepository(IDataStorage data)
    {
        _data = data;
    }

    public async Task<Price> GetById(int? id) => _data.GetPrices().Find(x => x.Id == id);
    public async Task<List<Price>> GetAll() => _data.GetPrices();
}