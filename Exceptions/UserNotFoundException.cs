namespace ContactApp.Exceptions
{
    internal class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message) { }
    }
}
