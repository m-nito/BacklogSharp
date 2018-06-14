using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BacklogSharp;
using Xunit;
using System.Diagnostics;


namespace BacklogSharpTest
{
    public class BacklogSharpTest
    {
        private static Backlog _conIns;
        public static Backlog backlog {
            get { return _conIns; }
            set { _conIns = value; }
        }

        void Init() {
            backlog = Backlog.Instantiate(TestResource.baseUrl, TestResource.apiKey);
        }
        void cons(string str)
        {
            Debug.WriteLine(str);
        }
        [Fact]
        void TestGetProject() {
            Init();
            var res = backlog.GetAsStr("projects");
            if (res != null) cons(res);
            Assert.True(res != null);
        }
        [Fact]
        void TestGetProjectAsDict() {
            Init();
            var res = backlog.GetAsDict("projects");
            if (res != null)
            {
                var dict = res.First();
                dict.Keys.ToList().ForEach(x => cons(x.ToString()));
            }

            Assert.True(res != null);
        }

        [Fact]
        void TestGetUsers()
        {
            Init();
            var res = backlog.GetAsStr("users");
            if (res != null) cons(res);
            Assert.True(res != null);
        }
    }
}
