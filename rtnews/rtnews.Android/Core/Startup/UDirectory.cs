using Android.Content.Res;
using System;
using System.IO;

namespace rtnews.Droid
{
    class UDirectory
    {
        static Reader CreateJsonStringReader()
        {
            return new JsonReader();
        }

        static Reader CreateJsonFileReader()
        {
            return new JsonReader();
        }

        static Writer CreateJsonFileWriter()
        {
            return new JsonWriter();
        }

        static Reader CreateTableFileReader()
        {
            return new TableReader();
        }

        public static bool FileExists(string nName)
        {
            string path = Name2Path(nName);
            return File.Exists(path);
        }

        public static string Name2Path(string nName)
        {
            var docsPath = Environment.GetFolderPath(
                Environment.SpecialFolder.Personal
                );
            return Path.Combine(docsPath, nName);
        }

        public static Stream Name2Stream(string nName)
        {
            return mAssets.Open(nName);
        }

        public static void RunInit(AssetManager nAssets)
        {
            mAssets = nAssets;

            SerializeMgr serializeMgr = SerializeMgr.Instance();
            serializeMgr.JsonStringReaderEvent += CreateJsonStringReader;
            serializeMgr.JsonFileReaderEvent += CreateJsonFileReader;
            serializeMgr.JsonFileWriteEvent += CreateJsonFileWriter;
            serializeMgr.TableFileReaderEvent += CreateTableFileReader;
            serializeMgr.FileIsExistEvent += FileExists;
        }

        static AssetManager mAssets;
    }
}
