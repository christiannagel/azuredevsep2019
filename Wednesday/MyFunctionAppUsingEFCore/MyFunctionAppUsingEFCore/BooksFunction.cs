using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BooksLib.Services;

namespace MyFunctionAppUsingEFCore
{
    public class BooksFunction
    {
        private readonly IBooksService _booksService;
        public BooksFunction(IBooksService booksService)
        {
            _booksService = booksService;
        }

        [FunctionName("BooksFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var books = await _booksService.GetBooksAsync();

            return new OkObjectResult(books);
        }
    }
}
