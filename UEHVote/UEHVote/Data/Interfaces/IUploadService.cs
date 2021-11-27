using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UEHVote.Data.Interfaces
{
    public interface IUploadService
    {

        Task<string> GetDataUriAsync(IBrowserFile file);
        Task<string> SaveImageAsync(IBrowserFile file, string userId);
        void RemoveImage(string fileName);
    }
}
