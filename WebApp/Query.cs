using DataContext;
using Microsoft.EntityFrameworkCore;

namespace WebApp;

public class Query
{
    public string Greeting() => "Hello World";

    public IQueryable<Employee> GetEmployees(MyDbContext dbContext)
    {
        //MyDbContext dbContext = new MyDbContext();
        return dbContext.Employees;

    }

    public Employee? GetEmployee(MyDbContext dbContext, int? businessEntityId)
    {
        //MyDbContext dbContext = new MyDbContext();
        if (businessEntityId == null) return null;
        return dbContext.Employees.Where(e => e.BusinessEntityId == businessEntityId).FirstOrDefault();

    }
}
