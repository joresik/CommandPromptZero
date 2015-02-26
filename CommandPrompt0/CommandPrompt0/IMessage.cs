using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompt0
{
    public interface IMessage
    {
        string MessageID { get; }
        string Body { get; set; }
        DateTime CreatedOn { get; }
        int CreatedByUserID { get; set; }

    }
}
