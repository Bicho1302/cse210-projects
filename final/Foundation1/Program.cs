using System;
using System.Collections.Generic;

namespace YouTubeTracking
{
    // Comment class to track name and text of comments
    public class Comment
    {
        public string CommenterName { get; set; }
        public string CommentText { get; set; }

        public Comment(string commenterName, string commentText)
        {
            CommenterName = commenterName;
            CommentText = commentText;
        }

        public void DisplayComment()
        {
            Console.WriteLine($"Name: {CommenterName}, Comment: {CommentText}");
        }
    }

    // Video class to track video details and list of comments
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }
        private List<Comment> Comments { get; set; }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return Comments.Count;
        }

        public void DisplayVideoDetails()
        {
            Console.WriteLine($"Title: {Title}, Author: {Author}, Length: {Length} seconds, Number of Comments: {GetNumberOfComments()}");
            foreach (var comment in Comments)
            {
                comment.DisplayComment();
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create videos
            Video video1 = new Video("Introduction to C#", "John Doe", 300);
            Video video2 = new Video("Advanced C# Techniques", "Jane Smith", 600);
            Video video3 = new Video("C# Design Patterns", "Jim Brown", 450);

            // Add comments to video1
            video1.AddComment(new Comment("Alice", "Great introduction!"));
            video1.AddComment(new Comment("Bob", "Very helpful, thanks."));
            video1.AddComment(new Comment("Charlie", "I love this video!"));

            // Add comments to video2
            video2.AddComment(new Comment("David", "This is advanced stuff!"));
            video2.AddComment(new Comment("Eve", "Well explained."));
            video2.AddComment(new Comment("Frank", "Can't wait to try these techniques."));

            // Add comments to video3
            video3.AddComment(new Comment("Grace", "Design patterns are so important."));
            video3.AddComment(new Comment("Heidi", "This video is very informative."));
            video3.AddComment(new Comment("Ivan", "Good examples of patterns."));

            // Store videos in a list
            List<Video> videos = new List<Video> { video1, video2, video3 };

            // Display details for each video
            foreach (var video in videos)
            {
                video.DisplayVideoDetails();
            }
        }
    }
}
