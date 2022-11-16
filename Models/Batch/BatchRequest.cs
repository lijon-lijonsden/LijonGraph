using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models.Batch
{
    public class Request
    {
        public string id { get; set; }
        public string method { get; set; }
        public string url { get; set; }
    }

    public class BatchRequest
    {
        public List<Request> requests { get; set; }
    }
}
