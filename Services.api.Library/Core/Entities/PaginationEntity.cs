namespace Services.api.Library.Core.Entities
{
    public class PaginationEntity<TDocument>
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public string Sort { get; set; }
    }
}
