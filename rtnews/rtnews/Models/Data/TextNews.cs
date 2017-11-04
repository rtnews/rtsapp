using System;

namespace rtnews
{
    public class TextNews : ObservableObject, IStream, IEquatable<TextNews>
    {
        public void Serialize(ISerialize nSerialize, string nName, sbyte nCount)
        {
            nSerialize.RunNumber(ref mId, "Id");
            nSerialize.RunNumber(ref mName, "Name");
            nSerialize.RunNumber(ref mFileName, "FileName");
            nSerialize.RunNumber(ref mTitle, "Title");
            nSerialize.RunNumber(ref mText, "Text");
            nSerialize.RunNumber(ref mCount, "Count");
            nSerialize.RunNumber(ref mRead, "Read");
            nSerialize.RunNumber(ref mTime, "Time");
        }

        public bool IsDefault()
        {
            return ( ("" == mId) || ("" == mName) );
        }

        public bool Equals(TextNews other)
        {
            return (mId == other.ID);
        }

        public string ID
        {
            get
            {
                return mId;
            }
        }
        string mId = "";

        public string Name
        {
            get
            {
                return mName;
            }
        }
        string mName;

        public string FileName
        {
            get
            {
                return mFileName;
            }
        }
        string mFileName;

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

        public int Read
        {
            get
            {
                return mRead;
            }
            set
            {
                if (mRead == value)
                {
                    return;
                }
                mRead = value;
                this.OnPropertyChanged("Read");
            }
        }
        int mRead;

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
