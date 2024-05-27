using MTRPZ4.CoreDomain.Entities;
using MTRPZ4.Infrastructure.DataStorage;
using MTRPZ4.Infrastructure.Repository.IRepository;

namespace MTRPZ4.Infrastructure.Repository;

public class ButtonColorRepository : IButtonColorRepository
{
    private readonly IDataStorage _data;

    public ButtonColorRepository(IDataStorage data)
    {
        _data = data;
    }

    public async Task<ButtonColor> GetById(int? id) => _data.GetButtonColors().Find(x => x.Id == id);
    public async Task<List<ButtonColor>> GetAll() => _data.GetButtonColors();
}