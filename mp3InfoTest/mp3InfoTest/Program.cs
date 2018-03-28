using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mp3InfoTest
{
    class Program
    {
        
        static void Main(string[] args)
        {



            //TagLib.Mpeg.AudioFile  file= new TagLib.Mpeg.AudioFile(@"F:\音乐\伊藤由奈 - trust you.mp3");
            //TagLib.Tag tag = file.Tag;

            //Console.WriteLine(tag.FirstArtist);
            //Console.WriteLine(tag.Album);
            //Console.WriteLine(tag.Pictures);

            //List<string> Info = new List<string>();

            //TagLib.File f = TagLib.File.Create(@"F:\音乐\孙燕姿 - 180度.mp3");

            //Info.Add($"专辑：{f.Tag.Album}"
            //);
            //Info.Add($"歌手：{f.Tag.FirstAlbumArtist}");
            //Info.Add($"曲名：{f.Tag.Title}");
            //foreach(string str in Info)
            //{
            //    Console.WriteLine(str);
            //}


            //var ss= GetCover(@"F:\音乐\孙燕姿 - 180度.mp3");
            //if(ss!=null)
            //{
            //    Image image=Image.FromStream(ss);
            //    FileStream fs = new FileStream($"MusicImgs/{f.Tag.Title}.jpg", FileMode.Create);
            //    image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);

            //}

            TagLibSharpSub tagSub = new TagLibSharpSub();
            tagSub.init(@"F:\音乐\Avril Lavigne - When You're Gone.mp3");
            List<string> info = tagSub.GetInfo();
            string path = tagSub.GetImagePath();
            foreach(string s in info)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(path);

            Console.ReadLine();
        }

        public static MemoryStream GetCover(string path)
        {
            TagLib.File f = TagLib.File.Create(path);
            if (f.Tag.Pictures != null && f.Tag.Pictures.Length != 0)
            {
                var bin = (byte[])(f.Tag.Pictures[0].Data.Data);
                return new MemoryStream(bin);
            }
            else
                return null;

        }
    }
}
