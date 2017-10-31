using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace rtnews
{
    public abstract class Repository<T> : Singleton<T>, IHeadstream where T : new()
    {
        public virtual void Serialize(ISerialize nSerialize)
        {
            if (mRunFile)
            {
                string updateTime = mUpdateTime.ToString();
                nSerialize.RunNumber(ref updateTime, "UpdateTime");
                mUpdateTime = Convert.ToDateTime(updateTime);
            }
        }

        public abstract string StreamName();

        void RunResponse(string nText)
        {
            var serializeMgr = SerializeMgr.Instance();
            serializeMgr.SerializeJson(this, nText);
        }

        void GetCallback(IAsyncResult asyncResult)
        {
            var request = asyncResult.AsyncState as HttpWebRequest;
            var response = request.EndGetResponse(asyncResult);
            Stream stream = response.GetResponseStream();
            var reader = new StreamReader(stream, Encoding.UTF8);
            string jsonValue = reader.ReadToEnd();
            this.RunResponse(jsonValue);
        }

        public void RunHttpGet()
        {
            if ((DateTime.Now - mUpdateTime).TotalMinutes < 10)
            {
                return;
            }

            UConfig uConfig = UConfig.Instance();
            string url = uConfig.ApiUrl + this.GetUrl();

            var request = WebRequest.CreateHttp(url);
            request.Method = "GET";
            request.BeginGetResponse(GetCallback, request);
        }

        public void RunHttpPost()
        {
            if ((DateTime.Now - mUpdateTime).TotalMinutes < 10)
            {
                return;
            }

            UConfig uConfig = UConfig.Instance();
            string url = uConfig.ApiUrl + this.GetUrl();

            var request = WebRequest.CreateHttp(url);
            request.Method = "POST";
            request.BeginGetResponse(GetCallback, request);
        }

        protected abstract string GetUrl();

        public virtual void RunInit()
        {
            mRunFile = true;

            var serializeMgr = SerializeMgr.Instance();
            serializeMgr.SerializeJson(this);

            mRunFile = false;
        }

        public void RunSave()
        {
            mRunFile = true;

            var serializeMgr = SerializeMgr.Instance();
            serializeMgr.SerializeWrite(this);

            mRunFile = false;
        }

        protected DateTime mUpdateTime = DateTime.MinValue;

        protected bool mRunFile = false;
    }
}
