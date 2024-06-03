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
	public class MakeListOfValuesForAllChartsTests
	{
		private readonly Mock<IUnitOfWork> _mockUnitOfWork;
		private readonly DataPreparationService _dataPreparationService;

		public MakeListOfValuesForAllChartsTests()
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

			var result = await _dataPreparationService.MakeListOfValuesForAllCharts();

			var expectedValues = new List<List<string>>
		{
			new List<string> { "Times New Roman", "Blue", "Arial", "Red", Convert.ToString(19.99M), Convert.ToString(9.99) },
			new List<string> { "Blue", "Red" },
			new List<string> { Convert.ToString(19.99M), Convert.ToString(9.99) },
			new List<string> { "Times New Roman", "Arial" }
		};

			Assert.Equal(expectedValues.Count, result.Count);

			for (int i = 0; i < expectedValues.Count; i++)
			{
				Assert.Equal(expectedValues[i], result[i]);
			}
		}
	}
}
