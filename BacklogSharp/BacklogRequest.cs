using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklogSharp
{
    public enum RequestType {
        Task,
        Error
    }

    public class BacklogIssue
    {
        public BacklogIssue(Dictionary<string, object> dict)
        {
            _dict = dict;
        }

        private Dictionary<string, object> _dict;

        public string Assigner
        {
            get { return _dict["id"].ToString(); }
            set { _dict["id"] = value; }
        }
        public string Assignee
        {
            get { return _dict["id"].ToString(); }
            set { _dict["id"] = value; }
        }
        public string User
        {
            get { return _dict["id"].ToString(); }
            set { _dict["id"] = value; }
        }
        public int Priority
        {
            get
            {
                if (int.TryParse(_dict["id"].ToString(), out int res) == false)
                    res = 0;
                return res;
            }
            set { _dict["id"] = value; }
        }
        public string Vesrion
        {
            get { return _dict["id"].ToString(); }
            set { _dict["id"] = value; }
        }

        public string Milestone
        {
            get { return _dict["id"].ToString(); }
            set { _dict["id"] = value; }
        }

        public string IssueTypeID
        {
            get { return _dict["id"].ToString(); }
            set { _dict["id"] = value; }
        }
        public string IssueTitle
        {
            get { return _dict["id"].ToString(); }
            set { _dict["id"] = value; }
        }
        public string ProjectID
        {
            get { return _dict["id"].ToString(); }
            set { _dict["id"] = value; }
        }
        public int Status
        {
            get
            {
                if (int.TryParse(_dict["id"].ToString(), out int res) == false)
                    res = 0;
                return res;
            }
            set { _dict["id"] = value; }
        }

        public string desc {
            get { return _dict["id"].ToString(); }
            set { _dict["id"] = value; }
        }
    }
}
