namespace Bloggie.Web.Models.Domain
{
    public class ErrorViewModel
    {
        
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}