using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompt0
{
    public class History
    {
        Dictionary<DateTime, string> historylist;

        public History()
        {
            historylist = new Dictionary<DateTime, string>();

        }

        public void Add(string CommandEntry)
        {
            historylist.Add(DateTime.Now, CommandEntry);

        }

        public string GetList()
        {
            StringBuilder returnlist = new StringBuilder();

            foreach (var entryitem in historylist)
            {
                returnlist.Append(entryitem.Key.ToString() +  " : " + entryitem.Value + "\r\n");
            }

            return returnlist.ToString();

        }

    }
}
