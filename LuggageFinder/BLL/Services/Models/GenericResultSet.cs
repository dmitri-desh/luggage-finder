namespace BLL.Services.Models
{
    public class GenericResultSet<T> : StandardResultObject
    {
        public T ResultSet { get; set; }
    }
}
