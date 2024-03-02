using System;

namespace LR4.Music
{
    public class Music
    {
        private int id;
        public string Name;
        internal bool IsListened;
        protected double Rating;
        protected internal char LetterRating;

        public Music(int id, string name, bool isListened, double rating, char letterRating)
        {
            this.id = id;
            Name = name;
            IsListened = isListened;
            Rating = rating;
            LetterRating = letterRating;
        }

        public string GetFullRating()
        {
            return $"This song has {Rating} points and totally {LetterRating} rating";
        }

        protected int GetId()
        {
            return id;
        }

        public string GetInfo(Music music)
        {
            string isListenedMessage = IsListened ? "is listened" : "is not listened";
            string preferToListenMessage = IsListened ? "listen to the next one" : "listen to it at any time you want";
            return $"{Name} {isListenedMessage}, {preferToListenMessage}. You also can listen to {music.Name}";
        }

        public void WriteInfo(Music music)
        {
            string isListenedMessage = IsListened ? "is listened" : "is not listened";
            string preferToListenMessage = IsListened ? "listen to the next one" : "listen to it at any time you want";
            Console.WriteLine($"{Name} {isListenedMessage}, {preferToListenMessage}. You also can listen to {music.Name}");
        }
    }
}