using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Video video1 = new Video("Tech Review", "Alice", 600);
        video1.AddComment(new Comment("John", "Great review!"));
        video1.AddComment(new Comment("Sarah", "I love this product."));
        video1.AddComment(new Comment("Dave", "Very informative!"));

        Video video2 = new Video("Cooking Tips", "Bob", 1200);
        video2.AddComment(new Comment("Emma", "Thanks for the recipe."));
        video2.AddComment(new Comment("Mike", "I'm trying this today!"));

        List<Video> videos = new List<Video> { video1, video2 };

        foreach (var video in videos)
        {
            video.Display();
        }
    }
}