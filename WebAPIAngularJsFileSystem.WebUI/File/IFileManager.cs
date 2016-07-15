using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIAngularJsFileSystem.WebUI.Models;

namespace WebAPIAngularJsFileSystem.WebUI.File
{
    public interface IFileManager
    {
        IEnumerable<FileViewModel> getFiles();
        
    }
}
