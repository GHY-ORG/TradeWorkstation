using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;
namespace DAL
{
    public interface IPicHandler
    {
        bool Create(Pic pic);

        List<Pic> ShowByIID(Guid iid);

        string GetPicUrl(Guid pid);
    }
}
