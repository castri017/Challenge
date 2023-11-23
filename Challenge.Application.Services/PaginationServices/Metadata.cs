namespace Challenge.Application.Services.PaginationServices
{
    public class Metadata
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalAcount { get; set; }
        public bool HasPreviusPage { get; set; }
        public bool HasNextPage { get; set; }

        private Metadata(int currentPage, int totalPages, int pageSize, int totalAcount, bool hasPreviusPage, bool hasNextPage)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalAcount = totalAcount;
            HasPreviusPage = hasPreviusPage;
            HasNextPage = hasNextPage;
        }

        public static Metadata create(int currentPage, int totalPages, int pageSize, int totalAcount, bool hasPreviusPage, bool hasNextPage)
        {
            return new Metadata(currentPage, totalPages, pageSize, totalAcount, hasPreviusPage, hasNextPage);
        }


    }
}

