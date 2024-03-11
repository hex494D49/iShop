namespace iShop.Utilities
{
    public class Pager
    {
        public int PageSize { get; set; }

        public int TotalItems { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
    }
}

