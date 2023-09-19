namespace DashBoardGr.Domain.Shared.Commands.Response
{
    public class CommandResponse
    {
        public CommandResponse(object data)
        {
            IsSuccessStatusCode = true;
            Date = DateTime.Now;
            Data = data;
        }

        public CommandResponse(int statusCode, string message, object data)
        {
            IsSuccessStatusCode = false;
            StatusCode = statusCode;
            Message = message;
            Date = DateTime.Now;
            Data = data;
        }

        public bool IsSuccessStatusCode { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime Date { get; private set; }
        public object Data { get; set; }
    }
}
