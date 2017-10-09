using System;
using System.Collections.Generic;
using System.IO;
using System.Json;

namespace rtnews.iOS
{
    public class JsonReader : IReader
	{
		public void RunNumber (ref sbyte nValue, string nName)
		{
            nValue = mJsonValue[nName];
		}

        public void RunNumber(ref byte nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public void RunNumbers (ref sbyte nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public void RunNumbers(ref byte nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public void RunNumber (ref short nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public void RunNumber(ref ushort nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public void RunNumbers (ref short nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public void RunNumbers(ref ushort nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public void RunNumber (ref int nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public void RunNumber(ref uint nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public void RunNumbers (ref int nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public void RunNumbers(ref uint nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public void RunNumber (ref long nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public void RunNumber(ref ulong nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

        public void RunNumbers (ref long nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public void RunNumbers(ref ulong nValue, string nName)
        {
            nValue = mJsonValue;
        }

        public void RunNumber (ref float nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

		public void RunNumbers (ref float nValue, string nName)
        {
            nValue = mJsonValue;
        }

		public void RunNumber (ref double nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

		public void RunNumbers (ref double nValue, string nName)
        {
            nValue = mJsonValue;
        }

		public void RunNumber (ref string nValue, string nName)
        {
            nValue = mJsonValue[nName];
        }

		public void RunNumbers (ref string nValue, string nName)
        {
            nValue = mJsonValue;
        }

		public void RunBuffer (ref byte[] nValue, ref short nLength)
		{
			LogEngine logEngine = Singleton<LogEngine>.Instance();
			logEngine.LogError(TAG, "RunBuffer", nLength);
		}

		public void RunTime (ref ulong nValue, string nName)
        {
            string value = mJsonValue;
            DateTime dateTime = Convert.ToDateTime(value);
            nValue = Convert.ToUInt64(dateTime);
        }

		public void RunTimes (ref ulong nValue, string nName)
        {
            string value = mJsonValue[nName];
            DateTime dateTime = Convert.ToDateTime(value);
            nValue = Convert.ToUInt64(dateTime);
        }

		public void PushName (string nName)
        {
            mJsonValues.Push(mJsonValue);
            mJsonValue = mJsonValue[nName];
        }

		public bool RunChild ()
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

		public bool RunNext ()
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

		public void PopName (string nName)
        {
            mJsonValue = mJsonValues.Pop();
        }

		public void PushClass (string nName)
        {
            mJsonValues.Push(mJsonValue);
            mJsonValue = mJsonValue[nName];
        }

		public void PopClass (string nName)
        {
            mJsonValue = mJsonValues.Pop();
        }

		public void PushStream (string nValue)
		{
		}

		public void PopStream (string nValue)
		{
		}

        public bool LoadFile(string nPath)
        {
            TextReader textReader = new StreamReader(nPath);
            mJsonValue = JsonObject.Load(textReader);
            return true;
        }

        public void StringValue(string nValue)
        {
            StringReader stringReader = new StringReader(nValue);
            mJsonValue = JsonObject.Load(stringReader);
		}

		public bool IsText ()
		{
			return true;
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

