using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.RequestParameters
{
    public record Pagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Pagination()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public Pagination(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
