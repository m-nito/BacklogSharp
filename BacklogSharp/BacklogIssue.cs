using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklogSharp
{
    public class BacklogIssue : BacklogRequest<BacklogIssue>
    {

        public BacklogIssue(Dictionary<string, object> dict, BacklogProject proj)
        {
            _dict = dict;
            MyProject = proj;
        }


        private BacklogProject MyProject;
        private Dictionary<string, object> _dict;

        public string Assigner
        {
            get { return _dict["assigner"].ToString(); }
            set { _dict["assigner"] = value; }
        }
        public string Assignee
        {
            get { return _dict["assignee"].ToString(); }
            set { _dict["assignee"] = value; }
        }
        public string User
        {
            get { return _dict["user"].ToString(); }
            set { _dict["user"] = value; }
        }
        public int Priority
        {
            get
            {
                if (int.TryParse(_dict["priority"].ToString(), out int res) == false)
                    res = 0;
                return res;
            }
            set { _dict["priority"] = value; }
        }
        public string Vesrion
        {
            get { return _dict["vesrion"].ToString(); }
            set { _dict["vesrion"] = value; }
        }

        public string Milestone
        {
            get { return _dict["milestone"].ToString(); }
            set { _dict["milestone"] = value; }
        }

        public string IssueTypeID
        {
            get { return _dict["issueTypeID"].ToString(); }
            set { _dict["issueTypeID"] = value; }
        }
        public string IssueTitle
        {
            get { return _dict["issueTitle"].ToString(); }
            set { _dict["issueTitle"] = value; }
        }
        public string ProjectID
        {
            get { return _dict["projectID"].ToString(); }
            set { _dict["projectID"] = value; }
        }
        public int Status
        {
            get
            {
                if (int.TryParse(_dict["status"].ToString(), out int res) == false)
                    res = 0;
                return res;
            }
            set { _dict["status"] = value; }
        }
        public string Description
        {
            get { return _dict["description"].ToString(); }
            set { _dict["description"] = value; }
        }

        public bool Post()
        {
            try
            {
                ApiAccesser.Post(this, MyProject.MySpace.BaseUri, MyProject.MySpace.ApiKey);
            }
            catch (Exception ex) {
                throw ex;
            }
            return true;
        }

        public static IEnumerable<BacklogIssue> Get(BacklogProject proj)
        {
            var dict = ApiAccesser.GetAsDictionaries(proj.MySpace.BaseUri, proj.MySpace.ApiKey, "issues").Select(x => x);
            return dict.Select(x => new BacklogIssue(x, proj));
        }
    }
}
