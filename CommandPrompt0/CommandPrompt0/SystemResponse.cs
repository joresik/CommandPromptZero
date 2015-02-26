using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompt0
{
    public class SystemResponse : IMessage
    {
        string messageid;
        string body;
        int  createdbyuserid;
        DateTime createdon;

        public string MessageID { get; set; }
        public string Body { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedOn { get; set; }

        public SystemResponse (
            string MessageID
            , string Body
            , int CreatedByUserID
            , DateTime CreatedOn)
        {
            messageid = MessageID;
            body = Body;
            createdbyuserid = CreatedByUserID;
            createdon = CreatedOn;

        }

    }
}
