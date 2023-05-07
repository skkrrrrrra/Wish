using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Wish.Web.Middlewares;

class OperationCanceledMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<OperationCanceledMiddleware> _logger;
	public OperationCanceledMiddleware(
		RequestDelegate next, 
		ILogger<OperationCanceledMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch(OperationCanceledException)
		{
			_logger.LogInformation("Request was cancelled");
			context.Response.StatusCode = 409;
		}
	}
}
