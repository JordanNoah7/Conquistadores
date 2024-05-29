namespace Back_Net8_Pathfinder;

public class CORSMiddleware
{
    private readonly RequestDelegate _next;

    public CORSMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST");
        context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept");
        context.Response.Headers.Add("Access-Control-Max-Age", "1728000");

        if (context.Request.Method == "OPTIONS")
        {
            context.Response.StatusCode = 200;
            await context.Response.CompleteAsync();
            return;
        }

        await _next(context);
    }
}