using MTRPZ4.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTRPZ4.CoreDomain.Entities;
using MTRPZ4.Application.DTO;

namespace MTRPZ4.Application.Services
{
	public class DataPreparationService : IDataPreparationService
	{
		private readonly IUnitOfWork _unitOfWork;
		public DataPreparationService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<ChartDataDTO>> GetAllOptions()
		{
			var colors = await _unitOfWork.Colors.GetAll();
			var prices = await _unitOfWork.Prices.GetAll();
			var fonts  = await _unitOfWork.Fonts.GetAll();

			IEnumerable<ChartDataDTO> colorsOptions = colors.Select(o => new ChartDataDTO { Value = o.Pigment, Count = o.Count });
			IEnumerable<ChartDataDTO> pricesOptions = prices.Select(o => new ChartDataDTO { Value = o.Value.ToString(), Count = o.Count });
			IEnumerable<ChartDataDTO> fontsOptions = fonts.Select(o => new ChartDataDTO { Value = o.Type, Count = o.Count });

			IEnumerable<ChartDataDTO> allOptions = colorsOptions.Concat(pricesOptions).Concat(fontsOptions);

			return allOptions;

		}

		public async Task<List<IEnumerable<ChartDataDTO>>> MakeListOfSortedOptions()
		{
			var colors = await _unitOfWork.Colors.GetAll();
			var prices = await _unitOfWork.Prices.GetAll();
			var fonts = await _unitOfWork.Fonts.GetAll();

			IEnumerable<ChartDataDTO> allOptions = await GetAllOptions();
			IEnumerable<ChartDataDTO> sortedAllOptions = allOptions.OrderBy(o => o.Count).Reverse();

			IEnumerable<ChartDataDTO> colorsOptions = colors.Select(o => new ChartDataDTO { Value = o.Pigment, Count = o.Count });
			IEnumerable<ChartDataDTO> sortedColorsOptions = colorsOptions.OrderBy(o => o.Count).Reverse();


			IEnumerable<ChartDataDTO> pricesOptions = prices.Select(o => new ChartDataDTO { Value = o.Value.ToString(), Count = o.Count });
			IEnumerable<ChartDataDTO> sortedPricesOptions = pricesOptions.OrderBy(o => o.Count).Reverse();


			IEnumerable<ChartDataDTO> fontsOptions = fonts.Select(o => new ChartDataDTO { Value = o.Type, Count = o.Count });
			IEnumerable<ChartDataDTO> sortedFontsOptions = fontsOptions.OrderBy(o => o.Count).Reverse();


			List<IEnumerable<ChartDataDTO>> ListOfSortedOptions = new List<IEnumerable<ChartDataDTO>>
			{
				sortedAllOptions,
				sortedColorsOptions,
				sortedPricesOptions,
				sortedFontsOptions
			};

			return ListOfSortedOptions;
		}

		public async Task<List<List<string>>> MakeListOfValuesForAllCharts()
		{
			List<IEnumerable<ChartDataDTO>> ListOfSortedOptions = await MakeListOfSortedOptions();

			List<List<string>> ListOfValuesForAllCharts = new List<List<string>>
			{
				ListOfSortedOptions[0].Select(o => o.Value).ToList()!,
				ListOfSortedOptions[1].Select(o => o.Value).ToList()!,
				ListOfSortedOptions[2].Select(o => o.Value).ToList()!,
				ListOfSortedOptions[3].Select(o => o.Value).ToList()!
			};

			return ListOfValuesForAllCharts;
		}

		public async Task<List<List<int>>> MakeListOfCountsForAllCharts()
		{
			List<IEnumerable<ChartDataDTO>> ListOfSortedOptions = await MakeListOfSortedOptions();

			List<List<int>> ListOfValuesForAllCharts = new List<List<int>>
			{
				ListOfSortedOptions[0].Select(o => o.Count).ToList()!,
				ListOfSortedOptions[1].Select(o => o.Count).ToList()!,
				ListOfSortedOptions[2].Select(o => o.Count).ToList()!,
				ListOfSortedOptions[3].Select(o => o.Count).ToList()!
			};

			return ListOfValuesForAllCharts;
		}
	}
}
