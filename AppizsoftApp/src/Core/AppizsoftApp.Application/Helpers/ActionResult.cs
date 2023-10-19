namespace AppizsoftApp.Application.Helpers
{
    public class ActionResult
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }
        public string[] Errors { get; set; }


        public ActionResult(bool success, int statusCode, string[] errors = null)
        {
            Success = success;
            StatusCode = statusCode;
            Errors = errors ?? new string[0];
        }
        public ActionResult()
        {
            Success = true;
            StatusCode = 200;
            Errors = new string[0];
        }
    }

}
