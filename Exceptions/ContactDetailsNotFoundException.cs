namespace ContactApp.Exceptions
{
    internal class ContactDetailsNotFoundException : Exception
    {
        public ContactDetailsNotFoundException(string message) : base(message) { }
    }
}
