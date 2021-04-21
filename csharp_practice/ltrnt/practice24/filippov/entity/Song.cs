using System;
using System.Collections.Generic;

namespace csharp_practice.ltrnt.practice24.filippov.entity
{
    public class Song : IComparable<Song>
    {
        private int id;
        private string title;
        private string author;

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public int Id { get => id; set => id = value; }

        public Song()
        {

        }

        public Song(string title, string author)
        {
            this.title = title;
            this.author = author;
        }

        public override bool Equals(object obj)
        {
            return obj is Song song &&
                   title.Equals(song.title) &&
                   author.Equals(song.author);
        }

        public override int GetHashCode()
        {
            int hashCode = 1709028807;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(author);
            return hashCode;
        }

        public override string ToString()
        {
            return "Song title: " + title + ". Author: " + author;
        }

        public int CompareTo(Song other)
        {
            return this.author.CompareTo(other.author);
        }

        public static bool operator ==(Song left, Song right)
        {
            return EqualityComparer<Song>.Default.Equals(left, right);
        }

        public static bool operator !=(Song left, Song right)
        {
            return !(left == right);
        }
    }
}
