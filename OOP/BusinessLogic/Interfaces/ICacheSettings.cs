namespace BusinessLogic.Interfaces
{
    public interface ICacheable
    {
        bool IsCacheEnabled { get; set; }
        DateTime ExpirationDate { get; set; }       
    }
}
