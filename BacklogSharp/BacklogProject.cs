using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BacklogSharp
{
    public class BacklogProject
    {
        public BacklogProject(Dictionary<string, object> dict, Backlog main)
        {
            MySpace = main;
            _dict = dict;
        }
        public Backlog MySpace;
        private Dictionary<string, object> _dict;

        public string id
        {
            get { return _dict["id"].ToString(); }
            set { _dict["id"] = value; }
        }

        string projectKey
        {
            get { return _dict["projectKey"].ToString(); }
            set { _dict["projectKey"] = value; }
        }
        string name
        {
            get { return _dict["name"].ToString(); }
            set { _dict["name"] = value; }
        }
        string chartEnabled
        {
            get { return _dict["chartEnabled"].ToString(); }
            set { _dict["chartEnabled"] = value; }
        }
        string subtaskingEnabled
        {
            get { return _dict["subtaskingEnabled"].ToString(); }
            set { _dict["subtaskingEnabled"] = value; }
        }
        string projectLeaderCanEditProjectLeader
        {
            get { return _dict["projectLeaderCanEditProjectLeader"].ToString(); }
            set { _dict["projectLeaderCanEditProjectLeader"] = value; }
        }
        string useWikiTreeView
        {
            get { return _dict["useWikiTreeView"].ToString(); }
            set { _dict["useWikiTreeView"] = value; }
        }
        string textFormattingRule
        {
            get { return _dict["textFormattingRule"].ToString(); }
            set { _dict["textFormattingRule"] = value; }
        }
        string archived
        {
            get { return _dict["archived"].ToString(); }
            set { _dict["archived"] = value; }
        }
        string displayOrder
        {
            get { return _dict["displayOrder"].ToString(); }
            set { _dict["displayOrder"] = value; }
        }
    }
}
