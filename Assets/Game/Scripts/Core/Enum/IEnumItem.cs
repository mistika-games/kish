namespace Core.Enum
{
    public interface IEnumItem : IIdentified
    {
        public int Index { get; }
    }
    
    public interface IIdentified
    {
        string Id { get; }
    }
}