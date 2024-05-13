using ABPBackendTZ.Models;
using ABPBackendTZ.Repository.IRepository;

namespace ABPBackendTZ.Repository;

public class ButtonColorRepository : IButtonColorRepository
{
    private readonly DataStorage _data = new();

    public async Task<ButtonColor> GetById(int? id) => _data.ButtonColors.Find(x => x.Id == id);
    public async Task<IEnumerable<ButtonColor>> GetAll() => _data.ButtonColors;
}