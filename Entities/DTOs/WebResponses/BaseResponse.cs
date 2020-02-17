namespace Entities.DTOs.WebResponses
{
    public class BaseResponse<T> where T : class
    {
        public int StatusCode { get; set; }

        public string StatusName { get; set; }

        public T Data { get; set; }

        public BaseResponse()
        {

        }

        public BaseResponse(int code, string name, T data)
        {
            this.StatusCode = code;
            this.StatusName = name;
            this.Data = data;
        }
    }
}
