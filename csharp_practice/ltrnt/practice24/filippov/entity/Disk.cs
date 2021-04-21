using System;
using System.Collections.Generic;
using System.Text;

namespace csharp_practice.ltrnt.practice24.filippov.entity
{
    public class Disk
    {
        private int id;
        private string title;
        private List<Song> songs;

        public string Title { get => title; set => title = value; }
        public List<Song> Songs { get => songs; set => songs = value; }
        public int Id { get => id; set => id = value; }

        public Disk()
        {

        }

        public Disk(string title)
        {
            this.title = title;
            songs = new List<Song>();
        }

        public Disk(string title, List<Song> songs)
        {
            this.title = title;
            this.songs = songs;
        }

        public override bool Equals(object obj)
        {
            return obj is Disk disk &&
                   title.Equals(disk.title) &&
                   EqualityComparer<List<Song>>.Default.Equals(songs, disk.songs);
        }

        public override int GetHashCode()
        {
            int hashCode = -745886826;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(title);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Song>>.Default.GetHashCode(songs);
            return hashCode;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(title);
            result.Append("\n");

            foreach (var item in songs)
            {
                result.Append(item);
                result.Append("\n");
            }

            return result.ToString();
        }

        // --

        public void AddSong(Song song)
        {
            songs.Add(song);
        }

        public void DeleteSong(Song song)
        {
            songs.Remove(song);
        }
    }
}
