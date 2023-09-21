using System.Data;
using WinFormsApp1;

namespace GAI.Repository
{
    public interface Repository<T> where T : class
    {
        DataTable GetAll();
        T? GetById(int id);
    }
}
