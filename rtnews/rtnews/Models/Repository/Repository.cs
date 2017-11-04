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
            if (SerializeType.Initing == LoadType)
            {
                string updateTime = mUpdateTime.ToString();
                nSerialize.RunNumber(ref updateTime, "UpdateTime");
                mUpdateTime = Convert.ToDateTime(updateTime);
            }
        }

        public abstract string StreamName();

        void RunRefreshValue(string nText)
        {
            LoadType = SerializeType.Refresh;

            var serializeMgr = SerializeMgr.Instance();
            serializeMgr.SerializeJson(this, nText);
            if (null != mDataModel)
            {
                mDataModel.RunRefresh();
            }
            mUpdateTime = DateTime.Now;
        }

        void RefreshValueCallback(IAsyncResult asyncResult)
        {
            try
            {
                var request = asyncResult.AsyncState as HttpWebRequest;
                var response = request.EndGetResponse(asyncResult);
                Stream stream = response.GetResponseStream();
                var reader = new StreamReader(stream, Encoding.UTF8);
                string jsonValue = reader.ReadToEnd();
                this.RunRefreshValue(jsonValue);
            }
            catch (WebException e)
            {
                LogEngine.Instance().LogError(e.Message);
            }
            catch (Exception e)
            {
                LogEngine.Instance().LogError(e.Message);
            }
            mRunHttp = false;
        }

        static bool mRunHttp = false;
        public void RunRefreshValue()
        {
            if (mRunHttp) return;

            //if ((DateTime.Now - mUpdateTime).TotalMinutes < 10)
            //{
            //    return;
            //}

            mRunHttp = true;

            UConfig uConfig = UConfig.Instance();
            string url = uConfig.ApiUrl + this.GetUrl();
            try
            {
                var request = WebRequest.CreateHttp(url);
                request.Method = "GET";
                request.BeginGetResponse(RefreshValueCallback, request);
            }
            catch (WebException e)
            {
                LogEngine.Instance().LogError(e.Message);
                mRunHttp = false;
            }
        }

        void RunLoadValue(string nText)
        {
            LoadType = SerializeType.Loading;

            var serializeMgr = SerializeMgr.Instance();
            serializeMgr.SerializeJson(this, nText);
            if (null != mDataModel)
            {
                mDataModel.RunLoading();
            }
        }

        class LoadValueCallBack
        {
            public HttpWebRequest WebRequest;
            public int Callback;
        }

        class LoadStreamObject
        {
            public HttpWebRequest WebRequest;
            public int Callback;
            public string Body;
        }

        void LoadValueCallback(IAsyncResult asyncResult)
        {
            try
            {
                var loadCallBack = asyncResult.AsyncState as LoadValueCallBack;
                var request = loadCallBack.WebRequest;
                var callBack = loadCallBack.Callback;

                var response = request.EndGetResponse(asyncResult);
                Stream stream = response.GetResponseStream();
                var reader = new StreamReader(stream, Encoding.UTF8);
                string jsonValue = reader.ReadToEnd();
                if (1 == callBack)
                {
                    this.RunLoadValue(jsonValue);
                }
            }
            catch (WebException e)
            {
                LogEngine.Instance().LogError(e.Message);
            }
            catch (Exception e)
            {
                LogEngine.Instance().LogError(e.Message);
            }
            mRunHttp = false;
        }

        void LoadStreamCallback(IAsyncResult asyncResult)
        {
            try
            {
                var streamObject = asyncResult.AsyncState as LoadStreamObject;
                var request = streamObject.WebRequest;
                var body = streamObject.Body;
                var callback = streamObject.Callback;

                Stream stream = request.EndGetRequestStream(asyncResult);
                var byteArray = Encoding.UTF8.GetBytes(body);
                stream.Write(byteArray, 0, body.Length);

                var loadCallBack = new LoadValueCallBack();
                loadCallBack.WebRequest = request;
                loadCallBack.Callback = callback;

                request.BeginGetResponse(LoadValueCallback, request);
            }
            catch (WebException e)
            {
                LogEngine.Instance().LogError(e.Message);
                mRunHttp = false;
            }
            catch (Exception e)
            {
                LogEngine.Instance().LogError(e.Message);
                mRunHttp = false;
            }
        }

        public void RunLoadValue(string nUrl, string nBody, int nType)
        {
            if (mRunHttp) return;

            mRunHttp = true;

            UConfig uConfig = UConfig.Instance();
            string url = uConfig.ApiUrl + nUrl;
            try
            {
                var request = WebRequest.CreateHttp(url);
                request.Method = "POST";
                request.ContentType = "application/json;charset=utf-8";
                var streamObject = new LoadStreamObject();
                streamObject.WebRequest = request;
                streamObject.Body = nBody;
                streamObject.Callback = nType;
                request.BeginGetRequestStream(LoadStreamCallback, streamObject);
            }
            catch (WebException e)
            {
                LogEngine.Instance().LogError(e.Message);
                mRunHttp = false;
            }
        }

        protected abstract string GetUrl();

        public void RunLoad()
        {
            LoadType = SerializeType.Initing;

            var serializeMgr = SerializeMgr.Instance();
            serializeMgr.SerializeJson(this);
        }

        public void RunSave()
        {
            LoadType = SerializeType.Initing;

            var serializeMgr = SerializeMgr.Instance();
            serializeMgr.SerializeWrite(this);
        }

        public virtual void RunInit()
        {
            this.RunLoad();
        }

        public void SetDataModel(IDataModel nDataModel)
        {
            mDataModel = nDataModel;
        }

        protected SerializeType LoadType = SerializeType.Initing;

        protected DateTime mUpdateTime = DateTime.MinValue;

        protected IDataModel mDataModel = null;
    }
}
