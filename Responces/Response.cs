namespace Base.Responces
{
    public class Response<T>
    {   public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public IEnumerable< T>? Data{ get; set; }
        public string ResponseMessage { get; set; }


    }
}
