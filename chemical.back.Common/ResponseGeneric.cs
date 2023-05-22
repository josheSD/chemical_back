namespace chemical.back.Common
{
    public class ResponseGeneric<T>
    {
        public T Data { get; set; }
        public string Code { get; set; }
        public bool IsSuccess { get; set; }
    }
}
