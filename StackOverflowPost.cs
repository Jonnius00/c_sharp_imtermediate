using System;

/* 
Design a class called Post. This class models a StackOverflow post.
- It should have properties for TITLE, DESCRIPTION and the DATE/TIME it was created.
- The Class should be able to UP-VOTE or DOWN-VOTE a post. 
- The Class should also be able to see the CURRENT VOTE value.
In the main method: create a post, up-vote and down-vote it a few times and then display the the current vote value.
 */
namespace MoshHamedani_Csharp_imtermediate
{
    internal class StackOverflowPost
    {
        // Properties for title, description, and creation time
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; } // Read-only property

        // Private field to store the vote count
        private int _voteCount;
        // Public read-only property to get the current vote value
        public int VoteCount { get{ return _voteCount; } }

        // Constructor to initialize the post
        public StackOverflowPost( string title, string description)
        {
            // class properties initialisation due to auto-implemented by {get;set;} 
            Title = title; 
            Description = description;
            CreatedAt = DateTime.Now;
            _voteCount = 0;
        }

        public void Upvote() { _voteCount++; }

        public void Downvote() { _voteCount--; }
    }

    public class StackOverflowPostProgram
    {
        public static void Run()
        {
            // Create a new post
            var post = new StackOverflowPost("How to use classes in C#?",
                                    "I'm learning C# and want to understand how classes work.");

            post.Upvote(); post.Upvote(); post.Upvote(); post.Upvote();
            post.Downvote();

            // Display the current vote value
            Console.WriteLine($"Post: {post.Title}");
            Console.WriteLine($"Description: {post.Description}");
            Console.WriteLine($"Created At: {post.CreatedAt}");
            Console.WriteLine($"Current Vote Value: {post.VoteCount}");

        }
    }

} // End of namespace
