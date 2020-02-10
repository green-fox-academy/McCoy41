using System;

namespace _17_BlogPost
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogPost blogpost1 = new BlogPost("Lorem Ipsum", "John Doe", "2000.05.04", 
                                 "Lorem ipsum dolor sit amet.");
            BlogPost blogpost2 = new BlogPost("Wait but why", "Tim Urban", "2010.10.10",
                                 "A popular long-form, stick-figure-illustrated blog about almost everything.");
            BlogPost blogpost3 = new BlogPost("One Engineer Is Trying to Get IBM to Reckon With Trump",
                                 "William Turton", "2017.03.28", "Daniel Hanley, a cybersecurity engineer at IBM, " +
                                 "doesn’t want to be the center of attention. When I asked to take his picture " +
                                 "outside one of IBM’s New York City offices, he told me that he wasn’t really into " +
                                 "the whole organizer profile thing.");

            Console.WriteLine(blogpost1.PrintBlogPost());
            Console.WriteLine(blogpost2.PrintBlogPost());
            Console.WriteLine(blogpost3.PrintBlogPost());
        }
    }

    class BlogPost
    {
        private string author, title, text, date;
        
        public BlogPost (string title, string author, string date, string text)
        {
            this.author = author;
            this.title = title;
            this.text = text;
            this.date = date;
        }

        public string PrintBlogPost()
        {
            return $"Created by {author} on {date}\n" +
                   $"{title}\n" +
                   $"{text}\n";
        }
        
    }
}
