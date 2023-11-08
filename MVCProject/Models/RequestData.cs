using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class RequestData : EmployeeDATA
    {
        private List<RequestData> _lisdata = new List<RequestData>();

        public List<RequestData> LSTREQ
        {
            get { return _lisdata; }
            set { _lisdata = value; }
        }

        public string REQCODE { get; set; }
        public string USERID { get; set; }
        public string TITLE { get; set; }
        public string DESCRIPTION { get; set; }
        public string APPROVEDID { get; set; }
        public DateTime CREATEDATE { get; set; }
    }
}