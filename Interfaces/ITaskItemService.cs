namespace WebApiTest.Interfaces;

public interface ITaskItemsService
{
    public List<Dictionary<string, object>> GetAll();

    public void Save(Dictionary<string, object> hash);
}