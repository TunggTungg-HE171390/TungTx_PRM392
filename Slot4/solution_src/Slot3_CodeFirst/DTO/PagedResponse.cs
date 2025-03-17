namespace Slot3_CodeFirst.DTO
{
    public class PagedResponse<T>
    {
        public List<T> Result { get; set; }
        public int Page {  get; set; }
        public int Total { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public PagedResponse() { }

        public PagedResponse(List<T> result, int page, int total, int pageSize, int totalPages, int totalItems)
        {
            Result = result;
            Page = page;
            Total = total;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalItems = totalItems;
        }
    }
}
