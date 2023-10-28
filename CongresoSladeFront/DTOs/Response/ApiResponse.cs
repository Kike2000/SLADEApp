namespace CongresoServer.DTOs.Response
{
    public class ApiResponse<T>
    {
        public bool isSucessful { get; set; }
        public List<T> data { get; set; }
        public string message { get; set; }
        public object errors { get; set; }
    }
}
