using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;
namespace DAL
{
   public  interface IPicHandler
    {
        int Create(Pic pic);

        List<Pic> show();
        //显示图片，通过userID
        List<Pic> showByUID(Guid uid);
    }
}
