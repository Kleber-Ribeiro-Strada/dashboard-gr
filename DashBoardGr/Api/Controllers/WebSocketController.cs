using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    //public class WebSocketController : ControllerBase
    //{
    //    [HttpGet("/ws")]
    //    public async Task Get()
    //    {
    //        if (HttpContext.WebSockets.IsWebSocketRequest)
    //        {
                
    //            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
    //            await Echo(webSocket);
    //        }
    //        else
    //        {
    //            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
    //        }
    //    }
    //}
}
