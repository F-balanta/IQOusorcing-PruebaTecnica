namespace IQOUTSOURCING.Domain
{
    public class Response<T>
    {
        private T? _data;
        public T? Data
        {
            get => _data;
            set
            {
                if (_data == null) _data = value;
            }
        }

        private string? _message;
        public string? Message
        {
            get => _message;
            set
            {
                if (_message == null) _message = value;
            }
        }

        public Response() { }
    }
}
