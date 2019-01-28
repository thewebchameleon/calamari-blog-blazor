namespace CB.Blazor.Interface.ServiceModels
{
    public class SendContactEmailRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string Message { get; set; }
    }
}
