using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using RAS.Api.Domain.ApiModels;
using RAS.Api.Domain.Services;

namespace RAS.WebApi.Controllers
{
    public class DocumentController : BaseController
    {

        public DocumentController(IDatabaseService iDatabaseService,
                                    ILogger<DocumentController> logger) : base(iDatabaseService, logger)
        {
            
        }

        [HttpPost]
        [Route("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//documents");

            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            var path = Path.Combine(savePath, file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { file.FileName, file.Length });
        }

        [HttpGet]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot//documents", filename);

            if (System.IO.File.Exists(path))
            {
                var memory = new MemoryStream();

                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }

                memory.Position = 0;

                new FileExtensionContentTypeProvider()
                   .TryGetContentType(path, out string contentType);

                return File(memory, contentType, Path.GetFileName(path));
            }
            else
            {
                return Content("filename not present");
            }
        }

        [HttpGet]
        [Route("GetWordDocument")]
        public async Task<IActionResult> GetWordDocument(string fileName)
        {
            var response = await _iService.GetWordDocument(fileName);
            return Ok(response);
        }

        [HttpPost]
        [Route("SaveWordDocument")]
        public async Task<IActionResult> SaveWordDocument(SaveDocumentApiModel saveDocumentApi)
        {
            var response = await _iService.SaveWordDocument(saveDocumentApi);
            return Ok(response);
        }

        [HttpPost]
        [Route("UploadFileToAzure")]
        public async Task<IActionResult> UploadFileToAzure(SaveDocumentApiModel saveDocumentApi)
        {
            var response = await _iService.UploadToAzureAsync(saveDocumentApi);
            return Ok(response);
        }

        [HttpGet]
        [Route("DownloadFromAzureAsync")]
        public async Task<IActionResult> DownloadFromAzureAsync(string fileName)
        {
            var response = await _iService.DownloadFromAzureAsync(fileName);
            return Ok(response);
        }

        [HttpGet]
        [Route("RunMailMergeFields")]
        public async Task<IActionResult> RunMailMergeFields(string fileName)
        {
            var response = await _iService.RunMailMergeFields(fileName);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetJsonData")]
        public async Task<IActionResult> GetJsonData()
        {
            var response = await _iService.GetJsonData();

            return Ok(response);
        }

        [HttpPost]
        [Route("GenerateAdobeDocument")]
        public async Task<IActionResult> GenerateAdobeDocument()
        {
            var response = await _iService.GenerateAdobeDocument();

            return Ok(response);
        }

        [HttpPost]
        [Route("GenerateAdobeDocumentFromStream")]
        public async Task<IActionResult> GenerateAdobeDocumentFromStream(AdobeDocumentFromStreamApiModel adobeDocumentFromStream)
        {
            var response = await _iService.GenerateAdobeDocumentFromStream(adobeDocumentFromStream);

            return Ok(response);
        }
    }
}
