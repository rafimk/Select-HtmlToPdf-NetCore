using Microsoft.AspNetCore.Mvc;
using Select_HtmlToPdf_NetCore.Services;

namespace Select_HtmlToPdf_NetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptController : ControllerBase
    {
        private readonly ICryptService _cryptService;
        public CryptController(ICryptService cryptService)
        {
            _cryptService = cryptService;
        }    

        [HttpPost("Encrypt")]
        public ActionResult Encrypt(string textToEncrypt)
        {
            return Ok(_cryptService.Encrypt(textToEncrypt));
        }

        [HttpPost("Decrypt")]
        public ActionResult Decrypt(string textToDecrypt)
        {
            return Ok(_cryptService.Decrypt(textToDecrypt));
        }
    }
}

   