namespace DansBlog.Model.Domain
{
    public class Quote
    {
        public int Id { get; set; }

        public string Text { get; private set; }

        public string Author { get; private set; }


        public Quote(int id, string text, string author)
        {
            Id = id;
            Text = text;
            Author = author;
        }

        public override string ToString()
        {
            return string.Format("[{0}] Text: {1} Author: {2}", 
                GetType().Name, Text, Author);
        }
    }
}
