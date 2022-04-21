using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RAS.Api.Domain.Services;
using RAS.Api.Domain.ViewModels;
using RAS.WebApi.Configurations;

namespace RAS.WebApi.Controllers
{
    public class DatabaseController : BaseController
    {
        public DatabaseController(IDatabaseService iDatabaseService,
                                    ILogger<DatabaseController> logger) : base(iDatabaseService, logger)
        {

        }
        [HttpGet]
        [Route("GetTables")]
        public async Task<IActionResult> GetTables()
        {
            var response = await _iService.GetTables();
            return Ok(response);
        }

        [HttpPost]
        [Route("GetColumnsByTableName")]
        public async Task<IActionResult> GetColumnsByTableName([FromBody] List<string> tableName)
        {
            var response = await _iService.GetColumnsByTableName(tableName);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetColumnInfoByTableName")]
        public async Task<IActionResult> GetColumnInfoByTableName()
        {
            var tables = new List<string> { "LabResults", "Manufacturer" };
            var response = await _iService.GetColumnsByTableName(tables);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetColumnsModelByTableName")]
        public async Task<IActionResult> GetColumnsModelByTableName(string tableName)
        {
            var tables = new List<string> { tableName };
            var response = await _iService.GetColumnsModelByTableName(tables);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetData")]
        public async Task<IActionResult> GetData(string tableName)
        {
             var response = await _iService.GetData(tableName);
            return Ok(response);
        }

        [HttpPost]
        [Route("ExecuteQuery")]
        public async Task<IActionResult> ExecuteQuery([FromBody] QueryViewModel query)
        {
            var response = await _iService.ExecuteQuery(query.Query);
            return Ok(response);
        }
    }
}
