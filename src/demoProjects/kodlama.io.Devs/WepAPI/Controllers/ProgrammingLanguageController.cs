using Application.Features.programmingLanguage.Commands.CreateProgrammingLanguage;
using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Model;
using Application.Features.programmingLanguage.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand )
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromBody] PageRequest pageRequest )
        {
            GetListProgrammingLanguageQuery result = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel programmingLanguageListModel= await Mediator.Send(result);
            return Ok(programmingLanguageListModel);
        }

    }
}
