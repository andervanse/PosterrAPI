

namespace Posterr.Domain
{
    public class Pagination
    {
        public Pagination(int currentPage, int pageSize, int totalPages)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
        }

        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }

        public int Skip
        {
            get
            {
                return (CurrentPage > 0 ? CurrentPage -1 : 0) * PageSize;
            }
        }
        public int Take
        {
            get
            {
                return PageSize;
            }
        }

    }
}
