using System;

namespace rtnews
{
    public class TextNews : IStream
    {
        public void Serialize(ISerialize nSerialize, string nName, sbyte nCount)
        {
            nSerialize.RunNumber(ref mId, "mId");
            nSerialize.RunNumber(ref mName, "mName");
            nSerialize.RunNumber(ref mFileName, "mFileName");
            nSerialize.RunNumber(ref mTitle, "mTitle");
            nSerialize.RunNumber(ref mText, "mBody");
            nSerialize.RunNumber(ref mCount, "mCount");
            nSerialize.RunNumber(ref mTime, "mTime");
        }

        public bool IsDefault()
        {
            return ( (0 == mId) || ("" == mName) );
        }

        public int ID
        {
            get
            {
                return mId;
            }
        }
        int mId = 0;

        public string Name
        {
            get
            {
                return mName;
            }
        }
        protected string mName;

        public string FileName
        {
            get
            {
                return mFileName;
            }
        }
        protected string mFileName;

        public string Title
        {
            get
            {
                return mTitle;
            }
        }
        string mTitle;

        public string Text
        {
            get
            {
                return mText;
            }
        }
        string mText;

        public int Count
        {
            get
            {
                return mCount;
            }
        }
        int mCount;

        public string Time
        {
            get
            {
                return mTime;
            }
        }
        string mTime;
    }
}
