using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testappdotnet.Helpers
{
    public class PaginationHeaders
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PaginationHeaders(int curPage, int itemsPerPage, int totalIems, int totalPages)
        {
            this.CurrentPage = curPage;
            this.ItemsPerPage = itemsPerPage;
            this.TotalItems = totalIems;
            this.TotalPages = totalPages;
        }
    }
}
