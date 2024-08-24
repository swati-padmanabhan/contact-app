namespace ContactApp.Exceptions
{
    internal class UserInactiveException : Exception
    {
        public UserInactiveException(string message) : base(message) { }
    }
}
