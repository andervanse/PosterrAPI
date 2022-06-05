

namespace Posterr.Domain
{
    public class PagedResult<T> : AppResult<T>
    {
        public PagedResult(Pagination pagination)
        {
            CurrentPage = pagination.CurrentPage;
            PageSize = pagination.PageSize;
            TotalPages = pagination.TotalPages;
        }

        public IEnumerable<T> DataSet { get; set; } = Enumerable.Empty<T>();
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
    }
}
