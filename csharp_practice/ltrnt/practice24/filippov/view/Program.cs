using System;
using csharp_practice.ltrnt.practice24.filippov.controller;
using csharp_practice.ltrnt.practice24.filippov.entity;

namespace csharp_practice.ltrnt.practice24.filippov.view
{
    public class Program
    {
        public static void DoSomething()
        {
            CatalogController controller = new CatalogController();
            Console.WriteLine("________");

            controller.CreateDisk("Jazz");
            controller.CreateDisk("LoFi");

            Song song1 = new Song("Lalalalal", "abc");
            Song song2 = new Song("kekpuk", "aaa");
            Song song3 = new Song("mmmmm", "aaa");
            Song song4 = new Song("chillout", "Denis");


            controller.AddSongToDisk("Jazz", song1);
            controller.AddSongToDisk("Jazz", song2);
            controller.AddSongToDisk("Jazz", song3);
            controller.AddSongToDisk("LoFi", song4);


            Console.WriteLine(controller.ShowCatalog());

            //controller.DeleteSongFromDiskByTitle("Jazz", "kekpuk");

            Console.WriteLine(controller.ShowCatalog());

            Console.WriteLine();

            Console.WriteLine(controller.ShowDiskByTitle("LoFi"));

            foreach (var item in controller.GetSongsByAuthor("aaa"))
            {
                Console.WriteLine(item);
            }
        }
    }
}
