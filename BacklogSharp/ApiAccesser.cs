using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BacklogSharp
{
    internal class ApiAccesser
    {
        /// <summary>
        /// HttpClient as a static member so that it will not occupy socket.
        /// </summary>
        private static readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Execute GET method.
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        private static Task<HttpResponseMessage> Get(string baseurl, string apikey)
        {
            return _client.GetAsync(baseurl + "?apiKey=" + apikey);
        }

        /// <summary>
        /// Execute GET method and returns string.
        /// </summary>
        /// <param name="apitype"></param>
        /// <returns></returns>
        public static string GetAsString(string baseurl, string apikey, string apitype)
        {
            var url = baseurl + "/api/v2/" + apitype;
            using (HttpResponseMessage res = Get(url, apikey).Result)
            {
                return res.Content.ReadAsStringAsync().Result;
            }
        }

        public static T GetResult<T>(string baseurl, string apikey, string apitype) {
            var res = (object)GetAsString(baseurl, apikey, apitype);
            return (T)res;
        }

        public static List<Dictionary<string,object>> GetAsDictionaries(string baseurl, string apikey, string apitype) {
            var json = GetAsString(baseurl, apikey, apitype);
            return JsonConvert.DeserializeObject<List<Dictionary<string,object>>>(json);
        }

        public static string GetIssueTypes(Backlog b, int projectId)
        {
            var url = b.BaseUri + "projects/" + projectId + "/issueTypes";
            using (HttpResponseMessage res = Get(url, b.ApiKey).Result)
            {
                return res.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// Execute POST and returns string.
        /// </summary>
        /// <param name="api"></param>
        /// <returns></returns>
        public static string Post(BacklogIssue i, string baseUrl, string apiKey)
        {
            // var i.desc;
            var url = Uri.EscapeUriString(baseUrl + @"/api/v2/issues?apiKey=" + apiKey);
            System.Diagnostics.Debug.WriteLine(url);
            var uri = new Uri(url);
            // Post結果を返す
            var res = Post(uri, GetIssueValues(i));
            Console.WriteLine(res);
            return res;
        }
        /// <summary>
        /// Convert into KVP.
        /// </summary>
        /// <returns></returns>
        private static List<KeyValuePair<string, string>> GetIssueValues(BacklogIssue i)
        {
            var val = new List<KeyValuePair<string, string>>
            {
                // new KeyValuePair<string, string>("apiKey", this._setting.APIKey),
                new KeyValuePair<string, string>("projectId", i.ProjectID),
                new KeyValuePair<string, string>("summary", i.IssueTitle),
                new KeyValuePair<string, string>("issueTypeId", i.IssueTypeID),
                new KeyValuePair<string, string>("priorityId", i.Priority.ToString()),
                new KeyValuePair<string, string>("description", i.Description),
                new KeyValuePair<string, string>("assigneeId", i.Assignee)
                //new KeyValuePair<string, string>("status", "1")
            };
            return val;
        }
        /// <summary>
        /// Execute POST with uri and KVP.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="kv"></param>
        /// <returns></returns>
        private static string Post(Uri uri, List<KeyValuePair<string, string>> kv)
        {
            // Not planning to go async yet.
            try
            {
                // var uri = new Uri(Uri.EscapeUriString(url));
                System.Diagnostics.Debug.WriteLine(uri.ToString());
                using (var req = new HttpRequestMessage(HttpMethod.Post, uri))
                using (var ec = new FormUrlEncodedContent(kv))
                {
                    req.Content = ec;
                    Console.WriteLine(req.Content.Headers.ToString());
                    var res = _client.SendAsync(req).Result;
                    return res.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                return "BackLogSharp:Post:ERROR";
            }
        }
    }
}
