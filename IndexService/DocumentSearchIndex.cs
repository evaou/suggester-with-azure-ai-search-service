using Azure.Search.Documents.Indexes.Models;

public class DocumentSearchIndex : SearchIndex
{
    SearchField id = new("book_id", SearchFieldDataType.String)

    {
        IsFacetable = false,
        IsFilterable = false,
        IsKey = true,
        IsHidden = false,
        IsSearchable = true,
        IsSortable = false,
        AnalyzerName = "standard.lucene"
    };
    readonly List<SearchField> _searchFields = new List<SearchField>()
        {
            new SearchField("book_id", SearchFieldDataType.String)
            {
                IsFacetable = false,
                IsFilterable = false,
                IsKey = true,
                IsHidden = false,
                IsSearchable = true,
                IsSortable = false,
                AnalyzerName = "standard.lucene"
            },
            new SearchField("isbn", SearchFieldDataType.String)
            {
                IsFacetable = false,
                IsFilterable = false,
                IsHidden = false,
                IsSearchable = true,
                IsSortable = false,
                AnalyzerName = "standard.lucene"
            },
            new SearchField("authors", SearchFieldDataType.Collection(SearchFieldDataType.String))
            {
                IsFacetable = true,
                IsFilterable = true,
                IsHidden = false,
                IsSearchable = true,
                IsSortable = false,
                AnalyzerName = "standard.lucene"
            },
            new SearchField("publication_year", SearchFieldDataType.String)
            {
                IsFacetable = false,
                IsFilterable = false,
                IsHidden = false,
                IsSortable = false
            },
           new SearchField("title", SearchFieldDataType.String)
            {
                IsFacetable = false,
                IsFilterable = false,
                IsHidden = false,
                IsSearchable = true,
                IsSortable = true,
                AnalyzerName = "standard.lucene"
            },
            new SearchField("language_code", SearchFieldDataType.String)
            {
                IsFacetable = true,
                IsFilterable = true,
                IsHidden = false,
                IsSearchable = false,
                IsSortable = false
            },
            new SearchField("average_rating", SearchFieldDataType.Double)
            {
                IsFacetable = true,
                IsFilterable = true,
                IsHidden = false,
                IsSortable = true
            },
        };

    public DocumentSearchIndex(string name) : base(name)
    {
        _searchFields.ForEach(Fields.Add);

        Suggesters.Add(new SearchSuggester("sg", "authors", "title"));
    }
}
