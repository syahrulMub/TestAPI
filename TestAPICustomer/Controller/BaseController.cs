using Microsoft.AspNetCore.Mvc;

namespace TestAPICustomer.Controller;

[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase

{
    private readonly ILogger _logger;
    public BaseController(ILogger logger)
    {
        _logger = logger;
    }
    //handle response with data 
    protected async Task<IActionResult> HandleResponse<TEntity>(Func<Task<TEntity>> response, string massage = "")
    {
        var traceIdentifier = HttpContext.TraceIdentifier;
        _logger.LogInformation($"Request Trace ID: {traceIdentifier}");
        try
        {
            var responseData = await response();
            return Ok(new
            {
                transactionId = traceIdentifier,
                message = massage,
                Data = responseData
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                transactionId = traceIdentifier,
                message = ex.Message,
            });
        }
    }
    //handle response without data
    protected async Task<IActionResult> HandleResponse(Func<Task> response, string massage = "")
    {
        var traceIdentifier = HttpContext.TraceIdentifier;
        _logger.LogInformation($"Request Trace ID: {traceIdentifier}");
        try
        {
            await response();
            return Ok(new
            {
                transactionId = traceIdentifier,
                message = massage
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                transactionId = traceIdentifier,
                message = ex.Message,
            });
        }
    }

}
