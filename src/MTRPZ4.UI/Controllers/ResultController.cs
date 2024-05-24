using Microsoft.AspNetCore.Mvc;
using MTRPZ4.Repository.IRepository;
using MTRPZ4.UI.Models;

namespace MTRPZ4.UI.Controllers
{
    public class ResultController : Controller
    {
        private const string GetButtonColorTemplate = "button-color";
        private const string GetPriceTemplate = "price";

        private readonly APIResponse _response = new();
        private readonly IDeviceRepository _deviceRepository;
        private readonly IButtonColorRepository _buttonColorRepository;
        private readonly IPriceRepository _priceRepository;

        public ResultController(
            IDeviceRepository deviceRepository,
            IButtonColorRepository buttonColorRepository,
            IPriceRepository priceRepository)
        {
            _priceRepository = priceRepository;
            _buttonColorRepository = buttonColorRepository;
            _deviceRepository = deviceRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet(GetButtonColorTemplate)]
        public async Task<IActionResult> GetButtonColor([FromQuery] string? deviceToken, [FromQuery] int buttonColorId)
        {
            try
            {
                _response.Key = GetButtonColorTemplate;
                if (string.IsNullOrEmpty(deviceToken) || buttonColorId <= 0 ||
                    buttonColorId > _buttonColorRepository.GetAll().Result.Count) return BadRequest(_response);

                var device = await _deviceRepository.GetByToken(deviceToken);

                if (device is { } && device.ButtonColorId is { } && device.ButtonColorId > 0)
                    _response.Value = device;

                if (device is { } && device.ButtonColorId is null)
                {
                    device.ButtonColorId = buttonColorId;
                    device.ButtonColor = await _buttonColorRepository.GetById(buttonColorId);
                    _response.Value = device;
                }

                if (device is null)
                {
                    device = new()
                    {
                        Token = deviceToken,
                        ButtonColorId = buttonColorId,
                        ButtonColor = await _buttonColorRepository.GetById(buttonColorId),
                    };
                    await _deviceRepository.Add(device);
                    _response.Value = device;
                }

                return Ok(_response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> GetPrice([FromQuery] string? deviceToken, [FromQuery] int priceId)
        {
            try
            {
                _response.Key = GetPriceTemplate;
                if (string.IsNullOrEmpty(deviceToken) || priceId <= 0 ||
                    priceId > _priceRepository.GetAll().Result.Count) return BadRequest(_response);

                var device = await _deviceRepository.GetByToken(deviceToken);

                if (device is { } && device.PriceId is { } && device.PriceId > 0)
                    _response.Value = device;

                if (device is { } && device.PriceId is null)
                {
                    device.PriceId = priceId;
                    device.Price = await _priceRepository.GetById(priceId);
                    _response.Value = device;
                }

                if (device is null)
                {
                    device = new()
                    {
                        Token = deviceToken,
                        PriceId = priceId,
                        Price = await _priceRepository.GetById(priceId),
                    };
                    await _deviceRepository.Add(device);
                    _response.Value = device;
                }

                return Ok(_response);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}