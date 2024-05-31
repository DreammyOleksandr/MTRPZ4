using Moq;
using MTRPZ4.Application.DTO;
using MTRPZ4.Application.Services;
using MTRPZ4.CoreDomain.Entities;
using MTRPZ4.Infrastructure.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTRPZ4.UnitTests.CardServiceTests
{
	public class MakeListOfCountsForAllChartsTests
	{
		private readonly Mock<IUnitOfWork> _mockUnitOfWork;
		private readonly DataPreparationService _dataPreparationService;

		public MakeListOfCountsForAllChartsTests()
		{
			_mockUnitOfWork = new Mock<IUnitOfWork>();
			_dataPreparationService = new DataPreparationService(_mockUnitOfWork.Object);
		}

		[Fact]
		public async Task MakeListOfValuesForAllCharts_ReturnsCorrectValues()
		{
		
			var colors = new List<Color>
		{
			new Color { Pigment = "Red", Count = 10 },
			new Color { Pigment = "Blue", Count = 15 }
		};

			var prices = new List<Price>
		{
			new Price { Value = 9.99m, Count = 5 },
			new Price { Value = 19.99m, Count = 8 }
		};

			var fonts = new List<Font>
		{
			new Font { Type = "Arial", Count = 12 },
			new Font { Type = "Times New Roman", Count = 20 }
		};


			_mockUnitOfWork.Setup(u => u.Colors.GetAll()).ReturnsAsync(colors);
			_mockUnitOfWork.Setup(u => u.Prices.GetAll()).ReturnsAsync(prices);
			_mockUnitOfWork.Setup(u => u.Fonts.GetAll()).ReturnsAsync(fonts);

			var result = await _dataPreparationService.MakeListOfCountsForAllCharts();

			var expectedValues = new List<List<int>>
		{
			new List<int> { 20, 15, 12, 10, 8, 5},
			new List<int> { 15, 10 },
			new List<int> { 8, 5 },
			new List<int> { 20, 12 }
		};

			Assert.Equal(expectedValues.Count, result.Count);

			for (int i = 0; i < expectedValues.Count; i++)
			{
				Assert.Equal(expectedValues[i], result[i]);
			}
		}
	}
}