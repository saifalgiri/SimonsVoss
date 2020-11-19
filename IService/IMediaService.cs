using SimonsVoss.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimonsVoss.IService
{
    public interface IMediaService
    {
        List<MediaViewModel> SearchMediaByText(string searchText);
        List<MediaViewModel> AllMediaById(Guid Id, string searchText);
    }
}
