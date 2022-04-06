namespace RestCT.Shared.Requests
{
    public class FilteringParameters
    {
        const int maxPageSize = 50;
        private int _pageSize = 2;

        public int PageNumber { get; set; }
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
    }
}
