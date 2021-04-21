using System;
using System.Collections.Generic;
using System.Text;
using csharp_practice.ltrnt.practice24.filippov.entity;
using csharp_practice.ltrnt.practice24.filippov.repository;

namespace csharp_practice.ltrnt.practice24.filippov.controller
{
    public class CatalogController
    {
        CatalogRepository repository;

        public CatalogController()
        {
            repository = LocalCatalogRepository.getInstance();
        }

        public bool CreateDisk(string title)
        {
            return repository.CreateDisk(title);
        }

        public Disk GetDisk(string title)
        {
            return repository.GetDisk(title);
        }

        public bool RemoveDisk(string title)
        {
            return repository.RemoveDisk(title);
        }

        public bool AddSongToDisk(string diskTitle, Song song)
        {
            return repository.AddSongToDisk(diskTitle, song);
        }

        public bool DeleteSongFromDiskByTitle(string diskTitle, string songTitle)
        {
            return repository.DeleteSongFromDiskByTitle(diskTitle, songTitle);
        }

        public String ShowCatalog()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in repository.GetDisks())
            {
                stringBuilder.Append(item);
                stringBuilder.Append("\n");
            }

            return stringBuilder.ToString();
        }

        public String ShowDiskByTitle(String diskTitle)
        {
            Disk disk = repository.GetDisk(diskTitle);

            if(disk == null)
            {
                return "";
            }

            return disk.ToString();
        }

        public List<Song> GetSongsByAuthor(string author)
        {
            return repository.GetSongsByAuthor(author);
        }
    }
}
