namespace RestCT.Shared.Requests
{
    public class FilteringParameters
    {
        const int maxPageSize = 50;
        private int _pageSize = 10;
        private int _pageNumber = 1;

        public int PageNumber
        {
            get
            {
                return _pageNumber - 1;
            }
            set
            {
                _pageNumber = (value <= 0) ? 1 : value;
            }
        }
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public int? CategoryId { get; set; } = null;
    }
}
