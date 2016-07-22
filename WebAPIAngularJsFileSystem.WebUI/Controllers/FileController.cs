using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIAngularJsFileSystem.WebAPI.Models;
using System.IO;
using System.Web.WebPages;

namespace WebAPIAngularJsFileSystem.WebAPI.Controllers
{
    public class FileController : ApiController
    {
        FileContext db = new FileContext();

        // GET: api/Test
        public FileContext Get(string path)
        {
            List<string> directories = new List<string>();
            List<string> files = new List<string>();

            db.Directories = new List<DirectoryModel>();
            db.Files = new List<FileModel>();

            // checks if path is empty
            if (path.IsEmpty())
            {
                directories.AddRange(Environment.GetLogicalDrives());

                for (var i = 0; i < directories.Count; i++)
                {
                    string str = directories[i];

                    DirectoryModel dir = new DirectoryModel()
                    {
                        Name = str,
                        Path = str
                    };

                    db.Directories.Add(dir);
                }

                return db;
            }

            DriveInfo drives = new DriveInfo(path);

            // checks if the logical drive is ready
            if (!drives.IsReady)
            {
                path = String.Empty;
                return Get(path);
            }



            directories.AddRange(Directory.GetDirectories(path));
            db.Directories.Add(new DirectoryModel { Name = "...", Path = path });
            // add directories
            for (var i = 1; i < directories.Count; i++)
            {
                string fullName = directories[i];
                var lastIndex = directories[i].LastIndexOf("\\");

                string name = fullName.Substring(lastIndex + 1);

                DirectoryModel dir = new DirectoryModel()
                {
                    Name = name,
                    Path = fullName
                };

                db.Directories.Add(dir);
            }

            files.AddRange(Directory.GetFiles(path));

            // add files
            for (var i = 0; i < files.Count; i++)
            {
                string fullName = files[i];
                var lastIndex = files[i].LastIndexOf("\\");

                string name = fullName.Substring(lastIndex + 1);

                FileModel file = new FileModel()
                {
                    Name = name,
                    Size = files[i].Length
                };

                db.Files.Add(file);
            }

            //DirectoryInfo dInfo = new DirectoryInfo(path);
            //FileInfo[] fileArr = dInfo.GetFiles("*.*", SearchOption.AllDirectories);

            //foreach (FileInfo f in fileArr)
            //{
            //    if (f.Length < 10485760) db.Count10Mb++;
            //    if (f.Length > 10485760 && f.Length < 52428800) db.Count10_50Mb++;
            //    if (f.Length > 104857600) db.Count100Mb++;

            //    db.Files.Add(new FileModel()
            //    {
            //        Name = f.Name,
            //        Size = f.Length
            //    });
            //}

            db.Path = path;

            return db;


        }


        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

    }
}
