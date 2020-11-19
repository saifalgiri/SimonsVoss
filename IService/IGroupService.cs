using SimonsVoss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsVoss.IService
{
    public interface IGroupService
    {
        List<GroupViewModel> SearchGroup(string searchText);
    }
}
