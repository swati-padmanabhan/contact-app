namespace ContactApp.Exceptions
{
    internal class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(string message) : base(message) { }
    }
}
