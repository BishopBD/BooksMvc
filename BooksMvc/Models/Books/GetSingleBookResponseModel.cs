using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMvc.Models.Books
{
    public class GetSingleBookResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        [DisplayName("Available")]
        public bool InInventory { get; set; }
        [DisplayName("Number Of Pages")]
        public int NumberOfPages { get; set; }
    }
}
