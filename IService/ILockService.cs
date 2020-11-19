using SimonsVoss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsVoss.IService
{
    public interface ILockService
    {
        List<LockViewModel> SearchLocksByText(string searchText);
        List<LockViewModel> AllLocksById(Guid Id, string searchText);
    }
}
