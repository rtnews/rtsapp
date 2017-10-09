namespace rtnews
{
    public interface IStream
    {
        void Serialize(ISerialize nSerialize, string nName, sbyte nCount);

		bool IsDefault();
    }
}
