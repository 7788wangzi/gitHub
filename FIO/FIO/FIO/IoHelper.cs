using System.Collections.Generic;
using System.IO;


namespace FIO
{
    public class IoHelper
    {
        /// <summary>
        /// Get a list of files under a given path
        /// </summary>
        /// <param name="root">Given path</param>
        /// <param name="extensions">File types to search for</param>
        /// <returns>A list of files with given extensions under given path</returns>
        public List<string> FindFiles(string root, List<string> extensions)
        {
            List<string> files = new List<string>();
            TranverseFiles(ref files, root, extensions);

            return files;
        }
        private void TranverseFiles(ref List<string> files, string root, List<string> extensions)
        {
            if (!Directory.Exists(root))
                return;
            DirectoryInfo di = new DirectoryInfo(root);
            foreach (FileInfo file in di.GetFiles())
            {
                if(DoesListHasValue(file.Extension, extensions))
                {
                    files.Add(file.FullName);
                }
            }

            foreach (DirectoryInfo folder in di.GetDirectories())
            {
                TranverseFiles(ref files, folder.FullName, extensions);
            }
        }

        /// <summary>
        /// Get a list of folders under a path
        /// </summary>
        /// <param name="root">Given path</param>
        /// <param name="name">Specified folder name</param>
        /// <returns>A list of folder full path with given name under given path</returns>
        public List<string> FindFolders(string root, string name)
        {
            List<string> folders = new List<string>();
            TranversePath(ref folders, root, name);
            return folders;
        }
        private void TranversePath(ref List<string> FOLDERS, string root, string name)
        {
            if (!Directory.Exists(root))
                return;
            DirectoryInfo di = new DirectoryInfo(root);

            foreach (DirectoryInfo folder in di.GetDirectories())
            {
                if (folder.Name.ToLower() == name.ToLower())
                {
                    FOLDERS.Add(folder.FullName);
                }

                TranversePath(ref FOLDERS, folder.FullName, name);
            }
        }

        /// <summary>
        /// Check if value exist in a list
        /// </summary>
        /// <param name="value">Value to check</param>
        /// <param name="list">Given list</param>
        /// <returns>true if exist, false if not exist</returns>
        public bool DoesListHasValue(string value, List<string> list)
        {
            bool exist = false;
            foreach (string item in list)
            {
                if (item.ToLower() == value.ToLower())
                    exist = true;
            }

            return exist;
        }
    }
}
