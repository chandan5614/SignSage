public class RenewalDTO
{
    public string Id { get; set; }
    public string DocumentId { get; set; }
    public DateTime ExpirationDate { get; set; }
    public DateTime RenewalDate { get; set; }
    public string Status { get; set; }
}
