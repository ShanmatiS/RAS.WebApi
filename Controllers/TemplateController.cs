using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RAS.Api.Domain.ApiModels;
using RAS.Api.Domain.Services;

namespace RAS.WebApi.Controllers
{
    public class TemplateController : BaseController
    {
        public TemplateController(IDatabaseService iDatabaseService,
                                    ILogger<TemplateController> logger) : base(iDatabaseService, logger)
        {

        }

        [HttpGet]
        [Route("GetTemplates")]
        public async Task<IActionResult> GetTemplates()
        {
            var response = await _iService.GetTemplates();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetTemplateTags")]
        public async Task<IActionResult> GetTemplateTags()
        {
            var response = await _iService.GetTemplateTags();
            return Ok(response);
        }

        [HttpGet]
        [Route("GetTemplateTagsByTemplateId")]
        public async Task<IActionResult> GetTemplateTagsByTemplateId(long templateId)
        {
            var response = await _iService.GetTemplateTagsByTemplateId(templateId);
            return Ok(response);
        }

        [HttpPost]
        [Route("SaveTemplateTags")]
        public async Task<IActionResult> SaveTemplateTags(SaveTemplateTagsApiModel saveTemplateTags)
        {
            var response = await _iService.SaveTemplateTags(saveTemplateTags);
            return Ok(response);
        }

        [HttpPost]
        [Route("SaveUserInputs")]
        public async Task<IActionResult> SaveUserInputs(SaveUserInputApiModel saveUserInputApi)
        {
            var response = await _iService.SaveUserInputs(saveUserInputApi);
            return Ok(response);
        }

        [HttpPost]
        [Route("SaveUserVariables")]
        public async Task<IActionResult> SaveUserVariables(SaveVariableApiModel saveVariableApi)
        {
            var response = await _iService.SaveUserVariables(saveVariableApi);
            return Ok(response);
        }

        [HttpPost]
        [Route("SaveTextSnippets")]
        public async Task<IActionResult> SaveTextSnippets(SaveTextSnippetApiModel saveTextSnippetApi)
        {
            var response = await _iService.SaveTextSnippets(saveTextSnippetApi);
            return Ok(response);
        }
    }
}
