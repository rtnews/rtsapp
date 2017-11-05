namespace rtnews
{
    public delegate bool FileExistEvent(string nName);

    public delegate Reader CreateReaderEvent();

    public delegate Writer CreateWriteEvent();

    public class SerializeMgr : Singleton<SerializeMgr>
    {
        public void SerializeJson<T>(T nT, string nValue) where T : IHeadstream
        {
            Reader reader = this.JsonFileReaderEvent();
            reader.StringValue(nValue);
            reader.PushStream(nT.StreamName());
            nT.Serialize(reader);
            reader.PopStream(nT.StreamName());
        }

        public void SerializeJson<T>(T nT) where T : IHeadstream
        {
            var streamName = nT.StreamName();
            if (!this.FileIsExist(streamName))
            {
                LogEngine logEngine = LogEngine.Instance();
                logEngine.LogMsg(TAG, "SerializeJson", streamName);
                return;
            }
            Reader reader = this.JsonFileReaderEvent();
            if (reader.LoadFile(streamName))
            {
                reader.PushStream(nT.StreamName());
                nT.Serialize(reader);
                reader.PopStream(nT.StreamName());
            }
        }

        public void SerializeWrite<T>(T nT) where T : IHeadstream
        {
            Writer writer = this.JsonFileWriteEvent();
            writer.PushStream(nT.StreamName());
            nT.Serialize(writer);
            writer.PopStream(nT.StreamName());
            writer.SaveFile(nT.StreamName());
        }

        public void SerializeTable<T>(T nT) where T : IHeadstream
        {
            Reader reader = this.TableFileReaderEvent();
            if ( reader.LoadFile(nT.StreamName()) )
            {
                reader.PushStream(nT.StreamName());
                nT.Serialize(reader);
                reader.PopStream(nT.StreamName());
            }
        }

        public event CreateReaderEvent TableFileReaderEvent;

        public Reader TableFileReader()
        {
            return this.TableFileReaderEvent();
        }

        public event FileExistEvent FileIsExistEvent;

        public bool FileIsExist(string nName)
        {
            return this.FileIsExistEvent(nName);
        }

        public event CreateReaderEvent JsonStringReaderEvent;

        public event CreateReaderEvent JsonFileReaderEvent;

        public Reader JsonStringReader()
        {
            return this.JsonStringReaderEvent();
        }

        public Reader JsonFileReader()
        {
            return this.JsonFileReaderEvent();
        }

        public event CreateWriteEvent JsonStringWriteEvent;

        public event CreateWriteEvent JsonFileWriteEvent;

        public Writer JsonStringWriter()
        {
            return this.JsonStringWriteEvent();
        }

        public Writer JsonFileWriter()
        {
            return this.JsonFileWriteEvent();
        }

        static readonly string TAG = typeof(SerializeMgr).Name;
    }
}
