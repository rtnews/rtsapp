namespace rtnews
{
    public interface IHeadstream
    {
        void Serialize(ISerialize nSerialize);

        string StreamName();
    }
}
