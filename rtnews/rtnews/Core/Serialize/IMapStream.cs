namespace rtnews
{
    public interface IMapStream : IStream
    {
        T mapIndex<T>();
    }
}
