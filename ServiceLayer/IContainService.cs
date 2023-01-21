namespace FirstApi2.ServiceLayer;

public interface IContainService<Contain>
{
    List<Contain> GetAllContains();
    void AddContain(Contain C);
    Contain GetContainById(int id);
    void UpdateContain(int id, Contain C);
    void RemoveContain(int id);
}