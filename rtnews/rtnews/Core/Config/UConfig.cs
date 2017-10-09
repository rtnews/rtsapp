using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public class UConfig : Singleton<UConfig>, IHeadstream
    {
        public string ApiUrl
        {
            get
            {
                return mApiUrl;
            }
        }

        public void Serialize(ISerialize nSerialize)
        {
            nSerialize.RunNumber(ref mApiUrl, "apiUrl");
        }

        public string StreamName()
        {
            return "UConfig.json";
        }

        public void RunInit()
        {
            var serializeMgr = SerializeMgr.Instance();
            serializeMgr.SerializeTable(this);
        }

        string mApiUrl;
    }
}
