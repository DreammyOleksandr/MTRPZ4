using MTRPZ4.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.Application.Services
{
	public interface IDataPreparationService
	{
		public Task<IEnumerable<ChartDataDTO>> GetAllOptions();
		public Task<List<IEnumerable<ChartDataDTO>>> MakeListOfSortedOptions();

		public Task<List<List<int>>> MakeListOfCountsForAllCharts();

		public Task<List<List<string>>> MakeListOfValuesForAllCharts();
	}
}
