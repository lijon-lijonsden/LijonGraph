using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.Models.Beta
{
    public class RoleScopeTags
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }

        [JsonProperty("@odata.count")]
        public int OdataCount { get; set; }
        public List<RoleScopeTag> value { get; set; }
    }

    public class RoleScopeTag
    {

        public string id { get; set; }
        public string displayName { get; set; }
        public string description { get; set; }
        public bool isBuiltIn { get; set; }
    }
}
