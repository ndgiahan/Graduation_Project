using Fahasa.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Fahasa
{
    public class CacheController
    {
        private readonly static string staffCacheKey = "staff";
        public void SaveStaffCache(StaffInformation staff)
        {
            ObjectCache cache = MemoryCache.Default;

            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cacheItemPolicy.Priority = CacheItemPriority.NotRemovable;

            cache.Add(staffCacheKey, staff, cacheItemPolicy);
        }

        public StaffInformation GetCacheStaff()
        {
            ObjectCache cache = MemoryCache.Default;
            StaffInformation staff = new StaffInformation();

            if (cache.Contains(staffCacheKey))
                staff = (StaffInformation)cache.Get(staffCacheKey);

            return staff;
        }
    }
}
