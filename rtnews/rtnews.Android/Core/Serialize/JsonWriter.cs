using System;
using System.Collections.Generic;
using System.IO;
using System.Json;

namespace rtnews.Droid
{
    public class JsonWriter : Writer
    {
		public override void RunNumber(ref sbyte nValue, string nName)
		{
            mJsonValue[nName] = nValue;
		}

		public override void RunNumbers(ref sbyte nValue, string nName)
        {
            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(nValue);
        }

        public override void RunNumber(ref byte nValue, string nName)
        {
            mJsonValue[nName] = nValue;
        }

        public override void RunNumbers(ref byte nValue, string nName)
        {
            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(nValue);
        }

        public override void RunNumber(ref short nValue, string nName)
        {
            mJsonValue[nName] = nValue;
        }

		public override void RunNumbers(ref short nValue, string nName)
        {
            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(nValue);
        }

        public override void RunNumber(ref ushort nValue, string nName)
        {
            mJsonValue[nName] = nValue;
        }

        public override void RunNumbers(ref ushort nValue, string nName)
        {
            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(nValue);
        }

        public override void RunNumber(ref int nValue, string nName)
        {
            mJsonValue[nName] = nValue;
        }

		public override void RunNumbers(ref int nValue, string nName)
        {
            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(nValue);
        }

        public override void RunNumber(ref uint nValue, string nName)
        {
            mJsonValue[nName] = nValue;
        }

        public override void RunNumbers(ref uint nValue, string nName)
        {
            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(nValue);
        }

        public override void RunNumber(ref long nValue, string nName)
        {
            mJsonValue[nName] = nValue;
        }

		public override void RunNumbers(ref long nValue, string nName)
        {
            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(nValue);
        }

        public override void RunNumber(ref ulong nValue, string nName)
        {
            mJsonValue[nName] = nValue;
        }

        public override void RunNumbers(ref ulong nValue, string nName)
        {
            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(nValue);
        }

        public override void RunNumber(ref float nValue, string nName)
        {
            mJsonValue[nName] = nValue;
        }

		public override void RunNumbers(ref float nValue, string nName)
        {
            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(nValue);
        }

		public override void RunNumber(ref double nValue, string nName)
        {
            mJsonValue[nName] = nValue;
        }

		public override void RunNumbers(ref double nValue, string nName)
        {
            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(nValue);
        }

		public override void RunNumber(ref string nValue, string nName)
        {
            mJsonValue[nName] = nValue;
        }

		public override void RunNumbers(ref string nValue, string nName)
        {
            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(nValue);
        }

        public override void RunBuffer(ref byte[] nValue, ref short nLength)
        {
            LogEngine logEngine = Singleton<LogEngine>.Instance();
            logEngine.LogError(TAG, "RunBuffer", nLength);
        }

        public override void RunTime(ref ulong nValue, string nName)
        {
            DateTime dateTime = Convert.ToDateTime(nValue);

            mJsonValue[nName] = dateTime;
        }

        public override void RunTimes(ref ulong nValue, string nName)
        {
            DateTime dateTime = Convert.ToDateTime(nValue);

            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(dateTime);
        }

        public override void PushStream(string nValue)
        {
            mJsonValue = new JsonObject();
        }

        public override void PopStream(string nValue)
        {
        }

        public override void PushClass(string nName)
        {
            mJsonValues.Push(mJsonValue);

            var jsonValue = new JsonObject();
            mJsonValue[nName] = jsonValue;
            mJsonValue = jsonValue;
        }

        public override void PopClass(string nName)
        {
            mJsonValue = mJsonValues.Pop();
        }

        public override void PushArray(string nName)
        {
            mJsonValues.Push(mJsonValue);

            var jsonValue = new JsonArray();
            mJsonValue[nName] = jsonValue;
            mJsonValue = jsonValue;
        }

        public override bool RunChild(string nName)
        {
            mJsonValues.Push(mJsonValue);

            var jsonValue = new JsonObject();
            var jsonArray = (JsonArray)mJsonValue;
            jsonArray.Add(jsonValue);
            mJsonValue = jsonValue;

            return true;
        }

        public override bool RunNext(string nName)
        {
            mJsonValue = mJsonValues.Pop();

            return true;
        }

        public override void PopArray(string nName)
        {
            mJsonValue = mJsonValues.Pop();
        }

        public override bool IsText()
        {
            return true;
        }

        public override void SaveFile(string nName)
        {
            string path = UDirectory.Name2Path(nName);
            try
            {
                StreamWriter streamWriter = new StreamWriter(path);
                mJsonValue.Save(streamWriter);
                streamWriter.Close();
            }
            catch (Exception e)
            {
                LogEngine.Instance().LogError(e.Message);
            }
        }

        public override string StringValue()
        {
            var stringWriter = new StringWriter();
            mJsonValue.Save(stringWriter);

            return stringWriter.ToString();
        }

		public JsonWriter ()
		{
            mJsonValues = new Stack<JsonValue>();
        }

        static readonly string TAG = typeof(JsonWriter).Name;

        Stack<JsonValue> mJsonValues;
        JsonValue mJsonValue;
    }
}

