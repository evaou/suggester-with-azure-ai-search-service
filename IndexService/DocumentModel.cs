public class DocumentModel
{
    public string book_id { get; set; }
    public string isbn { get; set; }
    public string[] authors { get; set; }
    public string publication_year { get; set; }
    public string title { get; set; }
    public string language_code { get; set; }
    public double average_rating { get; set; }
}
