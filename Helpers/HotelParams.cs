namespace DoraTourist.API.Helpers
{
    public class HotelParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        public int pageSize = 9;
        public int PageSize 
        { 
            get{ return pageSize ; }
            set{ pageSize = (value > MaxPageSize)? MaxPageSize : value; } 
        }
    }
}