using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace rtnews.iOS
{
    class CoreInit : Singleton<CoreInit>
    {
        ISerialize CreateJsonReader(string nValue)
        {
            JsonReader jsonReader = new JsonReader();
            jsonReader.StringValue(nValue);
            return new IoReader<JsonReader>(jsonReader);
        }

        public void RunInit()
        {
            SerializeMgr serializeMgr = SerializeMgr.Instance();
            serializeMgr.CreateJsonEvent += CreateJsonReader;
        }
    }
}
