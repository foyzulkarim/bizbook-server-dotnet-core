using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestModel.Customers
{
    public class CustomerImageRequestModel
    {
        public String FolderName { get; set; }

        public String Id { get; set; }

        public String CustomerImageType { get; set; }
        public IFormFile File { get; set; }
    }
}
