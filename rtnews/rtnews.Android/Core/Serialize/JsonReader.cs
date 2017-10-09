using System;
using System.Collections.Generic;
using System.IO;
using System.Json;

namespace rtnews.Droid
{
    public class JsonReader : Reader
	{
		public override void RunNumber (ref sbyte nValue, string nName)
		{
            nValue = mJsonValue[nName];
		}

        public override void RunNumbers(ref sbyte nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public override void RunNumber(ref byte nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public override void RunNumbers(ref byte nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public override void RunNumber (ref short nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public override void RunNumbers(ref short nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public override void RunNumber(ref ushort nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public override void RunNumbers(ref ushort nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public override void RunNumber (ref int nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public override void RunNumbers(ref int nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public override void RunNumber(ref uint nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public override void RunNumbers(ref uint nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public override void RunNumber (ref long nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public override void RunNumbers (ref long nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public override void RunNumber(ref ulong nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public override void RunNumbers(ref ulong nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public override void RunNumber (ref float nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

		public override void RunNumbers (ref float nValue, string nName)
        {
            nValue = mJsonValue;
        }

		public override void RunNumber (ref double nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

		public override void RunNumbers (ref double nValue, string nName)
        {
            nValue = mJsonValue;
        }

		public override void RunNumber (ref string nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

		public override void RunNumbers (ref string nValue, string nName)
        {
            nValue = mJsonValue;
        }

		public override void RunBuffer (ref byte[] nValue, ref short nLength)
		{
			LogEngine logEngine = Singleton<LogEngine>.Instance();
			logEngine.LogError(TAG, "RunBuffer", nLength);
		}

		public override void RunTime (ref ulong nValue, string nName)
        {
            string value = mJsonValue[nName];

            DateTime dateTime = Convert.ToDateTime(value);
            nValue = Convert.ToUInt64(dateTime);
        }

		public override void RunTimes (ref ulong nValue, string nName)
        {
            string value = mJsonValue;

            DateTime dateTime = Convert.ToDateTime(value);
            nValue = Convert.ToUInt64(dateTime);
        }

        public override void PushStream(string nValue)
        {
        }

        public override void PopStream(string nValue)
        {
        }

        public override void PushClass(string nName)
        {
            mJsonValues.Push(mJsonValue);
            mJsonValue = mJsonValue[nName];
        }

        public override void PopClass(string nName)
        {
            mJsonValue = mJsonValues.Pop();
        }

        public override void PushArray (string nName)
        {
            mJsonValues.Push(mJsonValue);
            mJsonValue = mJsonValue[nName];
        }

		public override bool RunChild (string nName)
        {
            if (mJsonValue.Count < 1)
            {
                return false;
            }
            mJsonValues.Push(mJsonValue);
            mJsonValue = mJsonValue[0];
            mIndex = 1;
            return true;
        }

		public override bool RunNext (string nName)
		{
            mJsonValue = mJsonValues.Peek();
            if (mJsonValue.Count <= mIndex)
            {
                mJsonValues.Pop();
                return false;
            }
            mJsonValue = mJsonValue[mIndex];
            mIndex++;
            return true;
        }

		public override void PopArray (string nName)
        {
            mJsonValue = mJsonValues.Pop();
        }

        public override bool IsText()
        {
            return true;
        }

        public override void LoadFile(string nName)
        {
            string path = UDirectory.Name2Path(nName);

            TextReader textReader = new StreamReader(path);
            mJsonValue = JsonObject.Load(textReader);
        }

        public override void StringValue(string nValue)
        {
            StringReader stringReader = new StringReader(nValue);
            mJsonValue = JsonObject.Load(stringReader);
		}

		public JsonReader ()
		{
            mJsonValues = new Stack<JsonValue>();
        }

		static readonly string TAG = typeof(JsonReader).Name;

        Stack<JsonValue> mJsonValues;
        JsonValue mJsonValue;
        int mIndex;
    }
}

