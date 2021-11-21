namespace BasicBilling.API.Context.Entities
{
    public interface ILogicalDelete
    {
        bool IsDeleted { get; set; }
    }
}
