using Sense.Application.Abstractions;
using Sense.Domain.Enums;
using Sense.Application.DTOs.BrandDTOs;
using Sense.Application.DTOs.CenterSettingDTOs;
using Sense.Application.UseCases.Brand.Commands.UpdateBrandCommand;
using Sense.Application.UseCases.Brand.Queries.GetAllBrandsQuery;
using Sense.Application.UseCases.CenterSetting.Commands.UpdateCenterSettingCommand;
using Sense.Application.UseCases.CenterSetting.Queries.GetCenterSettingQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sense.Areas.Admin.Controllers
{
    public class CenterSettingController : AdminBaseController
    {
        private readonly IMediator _mediator;
        private readonly IImageServices _imageServices;

        public CenterSettingController(IMediator mediator, IImageServices imageServices)
        {
            _mediator = mediator;
            _imageServices = imageServices;
        }
        public async Task<IActionResult> Index()
        {
            var query = new GetCenterSettingQuery { };
            var result = await _mediator.Send(query);
            var items = result.Data;
            ViewBag.ActiveMenu = "CenterSetting";
            ViewData["title"] = "إعدادات المتجر";
            return View(items);
        }


        [HttpPost("/Admin/CenterSetting/UploadLogo")]
        public async Task<IActionResult> UploadLogo(IFormFile logo)
        {
            if (logo is null || logo.Length == 0)
                return BadRequest("No logo file selected");

            var logoUrl = await _imageServices.UploadImageToFreeImageHost(logo);
            return Ok(new { logoUrl });
        }

        [HttpPost("/Admin/CenterSetting/UploadFavicon")]
        public async Task<IActionResult> UploadFavicon(IFormFile favicon)
        {
            if (favicon is null || favicon.Length == 0)
                return BadRequest("No favicon file selected");

            var faviconUrl = await _imageServices.UploadImageToFreeImageHost(favicon);
            return Ok(new { faviconUrl });
        }

        [HttpPut("/Admin/CenterSetting/Edit")]
        public async Task<IActionResult> Edit([FromBody] CenterSettingDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var command = new UpdateCenterSettingCommand { Dto = dto };
            var result = await _mediator.Send(command);

            if (result.Result.Code != ResultCodeStatus.Success)
            {
                return BadRequest(result.Result.Message);
            }

            return Ok(new { message = "Updated Successfully" });
        }
    }
}
