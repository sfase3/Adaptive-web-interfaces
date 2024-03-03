

namespace LR1.Models
{
    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public int HttpStatusCode { get; set; }
        public List<T> Data { get; set; }
    }
}
