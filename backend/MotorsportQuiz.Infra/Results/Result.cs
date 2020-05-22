namespace MotorsportQuiz.Infra.Results
{
    public class Result<T>
    {
        public Result()
        {
        }

        public Result(T value)
        {
            Value = value;
        }

        public Result(string mensagem)
        {
            Message = mensagem;
        }

        public Result(T value, string mensagem)
        {
            Value = value;
            Message = mensagem;
        }

        public string Message { get; private set; }
        public T Value { get; private set; }
        public bool Success => string.IsNullOrEmpty(Message);
    }
}
