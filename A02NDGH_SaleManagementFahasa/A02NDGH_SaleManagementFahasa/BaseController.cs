using Fahasa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fahasa
{
    public class BaseController
    {
        public BaseController(Form form) {
            //Loi trong cache ra kiem tra coi co Information chua?
            //Neu co roi thi cho pass
            //Neu chua thi loi fileName ra kiem tra
            //Neu get duoc full thi luu vao cache  --> Cho pass
            //Nguoc lai day ra form Main


            CacheController cache = new CacheController();
            StaffInformation staff = cache.GetCacheStaff();

            if (!Utils.IsFullInformation(staff))
            {
                string path = Utils.getPath();
                staff = Utils.GetInformation(path);

                if (Utils.IsFullInformation(staff))
                {
                    cache.SaveStaffCache(staff);

                }
                else {
                    form.ShowInTaskbar = false;
                    form.Opacity = 0;
                    frmInformation information = new frmInformation();
                    information.Show();
                }

            }
           

        }
       
    }
}
