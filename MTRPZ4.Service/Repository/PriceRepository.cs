using MTRPZ4.Models;

namespace MTRPZ4.Repository.IRepository;

public class PriceRepository : IPriceRepository
{
    private readonly IDataStorage _data;

    public PriceRepository(IDataStorage data)
    {
        _data = data;
    }

    public async Task<Price> GetById(int? id) =>  _data.GetPrices().Find(x => x.Id == id);
    public async Task<List<Price>> GetAll() => _data.GetPrices();
}