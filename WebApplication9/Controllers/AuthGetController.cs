using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;

namespace WebApplication9.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class AuthGetController : ControllerBase
    {
        [HttpGet]
        [MapToApiVersion("1.0")]
        [MapToApiVersion("2.0")]
        [MapToApiVersion("3.0")]
        [ApiVersion("1.0", Deprecated = true)]
        public IActionResult Get(string version)
        {
            switch (version)
            {
                case "1.0":
                    return Ok(228);
                case "2.0":
                    return Ok("Authorized GET method in version 2.0");
                case "3.0":
                    // Generate and return an Excel file for version 3.0
                    var stream = new MemoryStream();
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Sheet1");
                        worksheet.Cell("A1").Value = "Hello";
                        worksheet.Cell("B1").Value = "World";
                        workbook.SaveAs(stream);
                    }
                    stream.Position = 0;
                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "sample.xlsx");
                default:
                    return NotFound();
            }
        }
    }
}
