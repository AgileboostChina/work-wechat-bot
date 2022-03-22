using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;
using WorkWechatBotTransfer.Helpers;
using WorkWechatBotTransfer.Models;

namespace WorkWechatBotTransfer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GitLabController : ControllerBase
    {
        private readonly ILogger<GitLabController> _logger;

        public GitLabController(ILogger<GitLabController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<string> Transfer(string key)
        {
            string requestJson = "";
            using (var stream = new MemoryStream())
            {
                using (var streamReader = new StreamReader(stream, Encoding.UTF8))
                {
                    await Request.Body.CopyToAsync(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    requestJson = await streamReader.ReadToEndAsync();
                }
            }

            // _logger.LogInformation($"GitLab event request:{requestJson}");

            var message = BuildMessageHelper.BuildMessage(requestJson);

            if (string.IsNullOrEmpty(message)) return "";
            
            using (var client = new HttpClient())
            {
                var url = "https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key=" + key;
                var stringContent = new StringContent(message, Encoding.UTF8,
                    "application/json");
                var response = await client.PostAsync(url, stringContent).ConfigureAwait(false);

                var result = await response.Content.ReadAsStringAsync();

                // _logger.LogInformation($"GitLab event response:{result}");
            }

            return "";
        }
    }
}