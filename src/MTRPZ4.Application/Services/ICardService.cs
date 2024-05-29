using MTRPZ4.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.Application.Services
{
    public interface ICardService
    {
        Task<IEnumerable<CardDTO>> GetRandomCards();
        Task SaveCardChoice(ChosedCardDTO? card);
    }
}
