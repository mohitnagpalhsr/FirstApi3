using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstApi2.Models;
using FirstApi2.RepoLayer;

namespace FirstApi2.ServiceLayer;

public class ContainService : IContainService<Contain>
{
    public static IContainRepo<Contain> containRepo;

    public ContainService(IContainRepo<Contain> _containRepo)
    {
        containRepo = _containRepo;
    }
    public List<Contain> GetAllContains()
    {
        var getAllContains=containRepo.GetAllContains();
        return getAllContains;
    }

    public void AddContain(Contain C)
    {
        containRepo.AddContain(C);
    }

    public Contain GetContainById(int id)
    {
        var getContainById = containRepo.GetContainById(id);
        return getContainById;
    }

    public void UpdateContain(int id, Contain C)
    {
        containRepo.UpdateContain(id,C);
    }

    public void RemoveContain(int id)
    {
        containRepo.RemoveContain(id);
    }
}