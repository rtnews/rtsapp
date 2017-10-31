using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public class Dpart : IStream
    {
        public void Serialize(ISerialize nSerialize, string nName, sbyte nCount)
        {
            nSerialize.RunNumber(ref mIdentifier, "Identifier");

            nSerialize.RunNumber(ref mClerkId, "ClerkId");
            nSerialize.RunNumber(ref mName, "Name");
            nSerialize.RunNumber(ref mDepart, "Depart");
            nSerialize.RunNumber(ref mPhone, "Phone");
            nSerialize.RunNumber(ref mIcon, "Icon");
        }

        public bool IsDefault()
        {
            return ((0 == mIdentifier) || ("" == mClerkId));
        }

        public int Identifier
        {
            get
            {
                return mIdentifier;
            }
        }

        public string ClerkId
        {
            get
            {
                return mClerkId;
            }
        }

        public string Name
        {
            get
            {
                return mName;
            }
        }

        public string Depart
        {
            get
            {
                return mDepart;
            }
        }

        public string Phone
        {
            get
            {
                return mPhone;
            }
        }

        public string Icon
        {
            get
            {
                return mIcon;
            }
        }

        int mIdentifier;
        string mClerkId;
        string mName;
        string mDepart;
        string mPhone;
        string mIcon;
    }
}
