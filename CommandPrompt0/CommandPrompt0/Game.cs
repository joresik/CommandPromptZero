using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPrompt0
{
    public class Game
    {
        
        string _commandentry;
        public event EventHandler SystemResponse;
        
        Dictionary<string, Delegate> maincommands = new Dictionary<string, Delegate>();
        
        public Game()
        {
            LoadMainCommands();

        }

        public string UserCommand(string CommandEntry)
        {
            _commandentry = CommandEntry;
            ResponseEventArgs responseEventArgs = new ResponseEventArgs(Response());
            OnSystemResponse(responseEventArgs );
            return _commandentry;
       
        }
       
        public string Response()
        {
            
            string _commandMainWord = GetCommandWord(_commandentry);
            string _response;

            if (String.IsNullOrEmpty(_commandMainWord))
            {
                _response="Quit";
            }
            else
            {
                //_response = _commandentry; 
                   if (maincommands.ContainsKey(_commandMainWord))
                   {
                       if (_commandMainWord != null)
                       {
                           var tresponse = maincommands[_commandMainWord].DynamicInvoke(_commandentry);
                           _response = tresponse.ToString();
                       }
                       else
                       {
                           _response = _commandMainWord;
                       }
                   }
                   else
                   {
                       _response = "Unknown Command: " + _commandMainWord;
                   }
            }
            return _response;
        }


        void LoadMainCommands()
        { 
            maincommands = new Dictionary<string, Delegate>();
            maincommands["Logout"] = new Func<string, string>(GetLogoutResult);
            maincommands["Login"] = new Func<string, string>(GetLoginResult);
            maincommands["Inbox"] = new Func<string, string>(GetInboxResult);
            //maincommands.Add("Message", "Reading a message.");
            //maincommands.Add("To:", "Creating a message");
            //maincommands.Add("Help", "Getting Help.");
            //maincommands.Add("Search", "Searching the system.");
        }

        static string GetLogoutResult(string CommandString)
        {
            return "You are logging out of the system:  " + CommandString;
        }

        static string GetLoginResult(string UserName)
        {
            return "You are logging in as:  " + GetCommandSecondPart(UserName);
        }

        static string GetInboxResult(string CommandString)
        {
            return "Listing the contents of your inbox.";
        }

        static string GetCommandWord(string CommandToParse)
        {
            var _commandwords = CommandToParse.Split(' ');
           // Console.WriteLine(_commandwords.Length.ToString());
            return FirstLetterToUpper(_commandwords[0]);
            
        }

        static string GetCommandSecondPart(string CommandToParse)
        {
            string[] commandparts = CommandToParse.Split(new char[] { ' ' }, 2);
            string secondpartofcommand;
            if (commandparts[1] != null)
            {
                secondpartofcommand =  commandparts[1].ToString();
            }
            else
            {
                secondpartofcommand = "<No Entry>";
            }

            return secondpartofcommand;
        }
        static string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        // events;

        protected virtual void OnSystemResponse(ResponseEventArgs e)
        {
            EventHandler handler = SystemResponse;
            if (handler != null)
            {

                handler(this, e);

            }
        }
    }

    // using my own event args to no override defaults
    public class ResponseEventArgs : EventArgs
    {
        public string Response { get; private set; }

        public ResponseEventArgs (string response)
        { 
            this.Response = response;
        }
    }
}
