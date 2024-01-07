using Configuration.Business.Command;
using Configuration.Business.Query;
using ConfigurationUI.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConfigurationUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator, ILogger<HomeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> List(CreateCustomerCommand request)
        //{
        //    return Ok(await _mediator.Send(request));
        //}


        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Configurations(GetConfigurationListQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddConfiguration([FromBody]AddConfigurationCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetConfigurationById(GetConfigurationByIdQuery request)
        {
            return Ok(await _mediator.Send(request));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateConfiguration([FromBody]UpdateConfigurationCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteConfiguration(DeleteConfigurationCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
