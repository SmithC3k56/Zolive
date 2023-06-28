using zolive_db.Models;

namespace zolive_api.DAOImpl
{
    public class Test
    {
        readonly newliveContext _context;
        Test(newliveContext context)
        {
            _context = context; 
        }
    }
}
