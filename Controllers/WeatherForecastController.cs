using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Select_HtmlToPdf_NetCore.Utility;
using SelectPdf;

namespace Select_HtmlToPdf_NetCore.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly AppOptions _appOptions;
    private readonly PostgresOptions _postgresOptions;
    private readonly RabbitmqOptions _rabbitmqOptions;
    private readonly ILogger<WeatherForecastController> _logger;
    

    public WeatherForecastController(IOptions<AppOptions> appOptions,
        IOptions<PostgresOptions> postgresOptions,
        IOptions<RabbitmqOptions> rabbitmqOptions, 
        ILogger<WeatherForecastController> logger)
    {
        _appOptions = appOptions.Value;
        _postgresOptions = postgresOptions.Value;
        _rabbitmqOptions = rabbitmqOptions.Value;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("GetPDf")]
    public ActionResult GetPDf()
    {
        var html = TemplateGenerator.GetHTMLString("AUH0001",
                "01/01/2022",
                "MUHAMMED RAFI",
                "KASARAGOD",
                "TRIKARPUR",
                "TRIKARPUR",
                "ABU DHABI",
                "MUSAFFA",
                "MANDALAM AGENT"
                );

        var converter = new HtmlToPdf();

        converter.Options.PdfPageSize = PdfPageSize.Custom;
        converter.Options.PdfPageCustomSize = new SizeF(200, 300);

        var pdfDocument = converter.ConvertHtmlString(html);
        byte[] pdf = pdfDocument.Save();

        pdfDocument.Close();

        return File(
            pdf,
            "applicatin/pdf",
            "membership-card.pdf"
        );
    }

    [HttpGet("GetOptionsApp")]
    public ActionResult GetOptions()
    {
        if (_appOptions.Environment.ToLower() == "production")
        {
            return Ok(new {
                Rabbitmq = CryptExtension.Decrypt(_rabbitmqOptions.HostProdcution),
                Postgres = CryptExtension.Decrypt(_postgresOptions.ConnectionStringProdcution)
            });
        }

        return Ok(new {
            Rabbitmq = CryptExtension.Decrypt(_rabbitmqOptions.HostTesting),
            Postgres = CryptExtension.Decrypt(_postgresOptions.ConnectionStringTesting)
        });
    }

}
