using Moq;
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
	public class GetAllOptionsTests
	{
		private readonly Mock<IUnitOfWork> _mockUnitOfWork;
		private readonly DataPreparationService _dataPreparationService;

		public GetAllOptionsTests()
		{
			_mockUnitOfWork = new Mock<IUnitOfWork>();
			_dataPreparationService = new DataPreparationService(_mockUnitOfWork.Object);
		}

		[Fact]
		public async Task GetAllOptions_ReturnsCombinedChartData()
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

			var result = await _dataPreparationService.GetAllOptions();

			var resultList = result.ToList();
			Assert.Equal(6, resultList.Count);

			Assert.Contains(resultList, r => r.Value == "Red" && r.Count == 10);
			Assert.Contains(resultList, r => r.Value == "Blue" && r.Count == 15);
			Assert.Contains(resultList, r => r.Value == "9.99" && r.Count == 5);
			Assert.Contains(resultList, r => r.Value == "19.99" && r.Count == 8);
			Assert.Contains(resultList, r => r.Value == "Arial" && r.Count == 12);
			Assert.Contains(resultList, r => r.Value == "Times New Roman" && r.Count == 20);
		}
	}
}
