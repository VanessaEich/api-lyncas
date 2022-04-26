namespace ApiLyncas
{
    public class ErrosResposta
    {
        public ErrosResposta()
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetails>();
        }
        public ErrosResposta(string logref, string message)
        {
            TraceId = Guid.NewGuid().ToString();
            Errors = new List<ErrorDetails>();
            AddError(logref, message);
        }
        public string TraceId { get; private set; }
        public List<ErrorDetails> Errors { get; private set; }
        public class ErrorDetails
        {
            public ErrorDetails(string logref, string message)
            {
                Logref = logref;
                Message = message;
            }
            public string Logref { get; private set; }

            public string Message { get; private set; }
        }
        public void AddError(string logref, string message)
        {
            Errors.Add(new ErrorDetails(logref, message));
        }
    }
}

