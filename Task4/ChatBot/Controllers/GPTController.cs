using Microsoft.AspNetCore.Mvc;
using OpenAI.Interfaces;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using System.Threading.Tasks;

namespace ChatBot.Controllers
{
    [Route("api/gpt")]
    [ApiController]
    public class GPTController : ControllerBase
    {
        private readonly IOpenAIService _openAIService;

        public GPTController(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpGet("use")]
        public async Task<IActionResult> UseChatGPT(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Query cannot be empty.");
            }

            var completionRequest = new CompletionCreateRequest
            {
                Prompt = query,
                Model = Models.Gpt_3_5_Turbo, // Change to gpt-3.5-turbo
                MaxTokens = 100,
                Temperature = (float)0.7
            };

            var response = await _openAIService.Completions.CreateCompletion(completionRequest);

            if (response.Successful)
            {
                return Ok(response.Choices[0].Text);
            }
            else
            {
                return StatusCode(500, response.Error?.Message ?? "OpenAI request failed.");
            }
        }
    }
}
