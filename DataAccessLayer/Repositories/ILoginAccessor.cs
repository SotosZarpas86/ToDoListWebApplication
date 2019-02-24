using DataLayer.Entities;

namespace DataLayer.Repositories
{
    public interface ILoginAccessor
    {
        User Login(User user);
    }
}
