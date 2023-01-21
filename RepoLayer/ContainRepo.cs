using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstApi2.Models;

namespace FirstApi2.RepoLayer;

public class ContainRepo : IContainRepo<Contain>
{
    private readonly FlightBookingDbContext db;

    public ContainRepo(FlightBookingDbContext _db)
    {
        db = _db;
    }

    public List<Contain> GetAllContains()
    {
        return db.Contains.ToList();
    }

    public void AddContain(Contain C)
    {
        db.Contains.Add(C);
        db.SaveChanges();
    }

    public Contain GetContainById(int id)
    {
        var contain = db.Contains.Find(id);
        return contain;
    }

    public void UpdateContain(int id, Contain C)
    {
        db.Entry(C).State = EntityState.Modified;
        db.SaveChanges();
    }

    public void RemoveContain(int id)
    {
        var contain = db.Contains.Find(id);
        db.Contains.Remove(contain);
        db.SaveChanges();
    }
}