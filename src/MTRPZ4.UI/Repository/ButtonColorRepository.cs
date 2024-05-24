using MTRPZ4.Infrastructure.DataStorage;
using MTRPZ4.Repository.IRepository;
using MTRPZ4.UI.Models;

namespace MTRPZ4.Repository;

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