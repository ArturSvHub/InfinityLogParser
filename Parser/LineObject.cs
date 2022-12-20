namespace Parser
{
    public class LineObject
    {
        public List<string> Tokens { get; }
        public LineObject()
        {
            Tokens= new List<string>();
        }
        public LineObject(List<string> tokens)
        {
            Tokens= tokens;
        }
    }
}
