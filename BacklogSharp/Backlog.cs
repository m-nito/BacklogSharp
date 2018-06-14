using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklogSharp
{
    public enum API_TYPE {
        Project,
        Projects,
        User,
        Users,
        Issue,
        Issues,
        Error
    }
    public class Backlog
    {
        private Backlog() {
            // Forbids
        }
        public static Backlog Instantiate(string baseUri, string apiKey) {
            return new Backlog()
            {
                BaseUri = baseUri,
                ApiKey = apiKey
            };
        }

        // Members
        public string BaseUri;
        public string ApiKey;

        // Methods
        public string GetAsStr(string apiType) {
            return ApiAccesser.GetAsString(this.BaseUri, this.ApiKey, apiType);
        }

        public List<Dictionary<string, object>> GetAsDict(string apiType) {
            return ApiAccesser.GetAsDictionaries(this.BaseUri, this.ApiKey, apiType);
        }


    }
}
