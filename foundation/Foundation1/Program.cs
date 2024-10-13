using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Music videos from youtube 
        Video video1 = new Video("Toploader - Dancing in the Moonlight (Lyrics)",  "Dan Music", 231);
        Video video2 = new Video("MKTO - Classic (Lyrics)", "Dan Music", 173);
        Video video3 = new Video("Crash Adams - Destination (Official Lyric Video)", "Crash Adams", 163);

        // Comments for video1
        video1.AddComment(new Comment("Slay_67","I can never stop singing this when I get excited. My family don't even really mind when I sing this."));
        video1.AddComment(new Comment("ErynSmith-bo9sm","So underrated"));
        video1.AddComment(new Comment("Dadwar_Real","love this song"));
        video1.AddComment(new Comment("Robliss","Four lions got me here lol and now I’m dancing in the moonlight for the rest of my life."));

        // Comments for video2
        video2.AddComment(new Comment("xkiaradanielle","This will always be one of those songs that make me feel good"));
        video2.AddComment(new Comment("rosemaryskinner9317","I never get tired of this song of how much i listen to it"));
        video2.AddComment(new Comment("heycamila7549","please don't let this song be forgotten"));

        // Comments for video3
        video3.AddComment(new Comment("DreamyVibezMusic","This sound is so wonderful. The person who is reading this comment, I wish you great success, health, love and happiness!"));
        video3.AddComment(new Comment("mauricioflores3732","Finally someone who sings without any toxic meaning like others"));
        video3.AddComment(new Comment("axlock1115","You two are very promising musicians. I wish you all the best in hitting the charts."));
        video3.AddComment(new Comment("kokjiyangmoe3788","Crash adams make the best songs"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}