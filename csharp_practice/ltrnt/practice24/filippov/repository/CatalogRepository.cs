using System;
using System.Collections.Generic;
using csharp_practice.ltrnt.practice24.filippov.entity;

namespace csharp_practice.ltrnt.practice24.filippov.repository
{
    public interface CatalogRepository
    {
        bool CreateDisk(string title);
        Disk GetDisk(string title);
        bool RemoveDisk(string title);
        List<Disk> GetDisks();
        bool AddSongToDisk(string diskTitle, Song song);
        bool DeleteSongFromDiskByTitle(string diskTitle, string songTitle);
        List<Song> GetSongsByAuthor(string author);
    }
}
