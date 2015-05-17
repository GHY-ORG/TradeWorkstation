using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSource;
namespace DAL
{
   public class PicHandler:IPicHandler
    {
       public int Create(Pic pic)
       {
           try
           {
               using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
               {
                   pic.PID = new Guid();
                   pic.Status = 1;
                   db.Pic.InsertOnSubmit(pic);
                   db.SubmitChanges();
               }
               return 1;
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex);
               return 0;
           }
       }
      public  List<Pic> show()
       {
               using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
               {
                  var result = from a in db.Pic
                                   select a;

                               return result.ToList<Pic>();
                        
               }
               
           
          
       }
       //显示图片，通过userID
      public List<Pic> showByUID(Guid uid)
      {
          using (TradeWorkstationDataContext db = new TradeWorkstationDataContext())
          {
              var result = from a in db.Pic
                           where a.IID == uid
                           select a;

              return result.ToList<Pic>();

          }
      }
    }
}
