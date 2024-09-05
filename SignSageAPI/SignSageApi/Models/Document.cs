public class Document
{
    public string documentId { get; set; }
    public string TemplateId { get; set; }
    public dynamic CustomerData { get; set; }
    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
