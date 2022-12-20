using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class ParserObject
    {
        public List<LineObject> LineObjects { get; set; }
        public ParserObject(List<LineObject> lineObjects)
        {
            LineObjects = lineObjects;
        }
        public ParserObject()
        {
            LineObjects=new List<LineObject>();
        }
        public Call ParseCalls()
        {
            Call call = new Call();
            string result = string.Empty;
            string[] tokens =new string[2];
            int init = 0;
            if(LineObjects.Count>0)
            {
                for (int i = 0; i < LineObjects.Count; i++)
                {
                    foreach (var token in LineObjects[i].Tokens)
                    {
                        if(token.Contains("CallerNumber")&&init<6)
                        {
                            call.OnIncomingCallDate = $"{LineObjects[i].Tokens[0]} {LineObjects[i].Tokens[1]}";
                            tokens =token.Split('=');
                            call.CallerNumber = tokens[1];
                            init++;
                        }
                        if(token.Contains("CalledNumber") && init < 6)
                        {
                            tokens = token.Split('=');
                            call.CalledNumber = tokens[1];
                            init++;
                        }
                        if (token.Contains("CallerName") && init < 6)
                        {
                            tokens = token.Split('=');
                            call.CallerName = tokens[1];
                            init++;
                        }
                        if (token.Contains("CallerAddress") && init < 6)
                        {
                            tokens = token.Split('=');
                            call.CallerAddress = tokens[1];
                            init++;
                        }
                        if (token.Contains("Connection") && init < 6)
                        {
                            tokens = token.Split('=');
                            call.Connection = tokens[1];
                            init++;
                        }
                        if (token.Contains("Uid")&&init < 6)
                        {
                            tokens = token.Split('=');
                            call.Uid = tokens[1];
                            init++;
                        }
                    }
                }
            }
            return call;
        }
    }
}
