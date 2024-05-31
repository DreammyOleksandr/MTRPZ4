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
	public class MakeListOfSortedOptionsTests
	{
		private readonly Mock<IUnitOfWork> _mockUnitOfWork;
		private readonly DataPreparationService _dataPreparationService;

		public MakeListOfSortedOptionsTests()
		{
			_mockUnitOfWork = new Mock<IUnitOfWork>();
			_dataPreparationService = new DataPreparationService(_mockUnitOfWork.Object);
		}

		[Fact]
		public async Task MakeListOfSortedOptions_ReturnsCorrectlySortedOptions()
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

			var result = await _dataPreparationService.MakeListOfSortedOptions();

			Assert.Equal(4, result.Count);

			Assert.Equal(20, result[0].ToList()[0].Count);
			Assert.Equal(15, result[0].ToList()[1].Count);
			Assert.Equal(12, result[0].ToList()[2].Count);
			Assert.Equal(10, result[0].ToList()[3].Count);	
			Assert.Equal(8, result[0].ToList()[4].Count);
			Assert.Equal(5, result[0].ToList()[5].Count);
			Assert.Equal(15, result[1].ToList()[0].Count);
			Assert.Equal(10, result[1].ToList()[1].Count);
			Assert.Equal(8, result[2].ToList()[0].Count);
			Assert.Equal(5, result[2].ToList()[1].Count);
			Assert.Equal(20, result[3].ToList()[0].Count);
			Assert.Equal(12, result[3].ToList()[1].Count);

			Assert.Equal("Times New Roman", result[0].ToList()[0].Value);
			Assert.Equal("Blue",result[0].ToList()[1].Value);
			Assert.Equal("Arial", result[0].ToList()[2].Value);
			Assert.Equal("Red", result[0].ToList()[3].Value);
			Assert.Equal("19.99", result[0].ToList()[4].Value);
			Assert.Equal("9.99", result[0].ToList()[5].Value);
			Assert.Equal("Blue", result[1].ToList()[0].Value);
			Assert.Equal("Red", result[1].ToList()[1].Value);
			Assert.Equal("19.99", result[2].ToList()[0].Value);
			Assert.Equal("9.99", result[2].ToList()[1].Value);
			Assert.Equal("Times New Roman", result[3].ToList()[0].Value);
			Assert.Equal("Arial", result[3].ToList()[1].Value);
		}
	}
}
