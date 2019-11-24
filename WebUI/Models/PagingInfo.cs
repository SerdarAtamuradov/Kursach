using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; } //General quantity of Book
        public int ItemsPerPage { get; set; } //Quantity of Books in per page
        public int CurrentPage { get; set; } //Number of current page
        public int TotalPages //General quantity of pages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}