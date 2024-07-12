using Microsoft.AspNetCore.Mvc;
using MyNetCoreApi.Services.Interfaces;

namespace MyNetCoreApi.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class NewLambdaController : ControllerBase
    {
        private const string StudentsLambdaName = "AllStudentsLambdaFunction";
        private readonly ILambdaService _lambdaService;

        public NewLambdaController(ILambdaService lambdaService)
        {
            _lambdaService = lambdaService;
        }

        [HttpGet("invoke-students")]
        public async Task<IActionResult> InvokeGreetingsLambda()
        {
            try
            {
                var result = await _lambdaService.InvokeLambdaAsync(StudentsLambdaName, "{\"key\":\"value\"}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
