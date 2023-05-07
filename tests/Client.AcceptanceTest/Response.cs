namespace Client.AcceptanceTest
{
    public class Response<TData>
    {
        public Response()
        {
        }

        public Response(TData data)
        {
            Success = true;
            Data = data;
        }

        public bool Success { get; set; }
        public TData? Data { get; set; }
    }
}
