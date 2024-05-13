using ABPBackendTZ.Models;

namespace ABPBackendTZ.Repository.IRepository;

public class PriceToShowRepository : IPriceToShowRepository
{
    private readonly DataStorage _data;

    public async Task<Price> GetById(int? id) =>  _data.Prices.Find(x => x.Id == id);
    public async Task<IEnumerable<Price>> GetAll() => _data.Prices;
}