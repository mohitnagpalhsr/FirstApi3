using FirstApi2.Models;

namespace FirstApi2.RepoLayer;

public interface IContainRepo<Contain>
{
    List<Contain> GetAllContains();
    void AddContain(Contain C);
    Contain GetContainById(int id);
    void UpdateContain(int id, Contain C);
    void RemoveContain(int id);
}