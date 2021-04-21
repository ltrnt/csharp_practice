using System;
using System.Collections.Generic;
using csharp_practice.ltrnt.practice24.filippov.entity;

namespace csharp_practice.ltrnt.practice24.filippov.repository
{
    public class LocalCatalogRepository : CatalogRepository
    {
        private static LocalCatalogRepository repository = null;
        private List<Disk> disks;

        public static LocalCatalogRepository getInstance()
        {
            if(repository == null)
            {
                repository = new LocalCatalogRepository();
            }

            return repository;
        }

        private LocalCatalogRepository()
        {
            disks = new List<Disk>();
        }


        public bool CreateDisk(string title)
        {
            foreach (var item in disks)
            {
                if (item.Title.Equals(title))
                {
                    Console.WriteLine("Disk with title " + title + " already exist"); // TODO Change to log output
                    return false;
                }
            }

            disks.Add(new Disk(title));
            return false;
        }

        public Disk GetDisk(string title)
        {
            foreach (var item in disks)
            {
                if (item.Title.Equals(title))
                {
                    return item;
                }
            }

            return null;
        }

        public bool RemoveDisk(string title)
        {
            Disk target = null;
            foreach (var item in disks)
            {
                if (item.Title.Equals(title))
                {
                    target = item;
                    break;
                }
            }

            if(target != null)
            {
                disks.Remove(target);
                return true;
            }

            return false;
        }

        public List<Disk> GetDisks()
        {
            return disks;
        }

        public bool AddSongToDisk(string diskTitle, Song song)
        {
            Disk disk = GetDisk(diskTitle);

            if (disk == null)
            {
                Console.WriteLine("No disk with title " + diskTitle);
                return false;
            }

            if (disk.Songs.Contains(song))
            {
                Console.WriteLine("Disk with title " + diskTitle + " already have song: " + song);
                return false;
            }

            disk.AddSong(song);
            disk.Songs.Sort();
            return true;
        }

        public bool DeleteSongFromDiskByTitle(string diskTitle, string songTitle)
        {

            Disk disk = GetDisk(diskTitle);

            if (disk == null)
            {
                Console.WriteLine("No disk with title " + diskTitle);
                return false;
            }

            Song song = null;

            foreach (var item in disk.Songs)
            {
                if (item.Title.Equals(songTitle))
                {
                    song = item;
                    break;
                }
            }

            if (song == null)
            {
                Console.WriteLine("Disk with title " + diskTitle + " didn't have song with title " + songTitle);
                return false;
            }

            disk.DeleteSong(song);
            return true;
        }


        public List<Song> GetSongsByAuthor(string author)
        {
            List<Song> songs = new List<Song>();

            foreach (var disk in disks)
            {
                foreach (var song in disk.Songs)
                {
                    if (song.Author.Equals(author))
                    {
                        songs.Add(song);
                    }
                }
            }

            return songs;
        }


    }
}
