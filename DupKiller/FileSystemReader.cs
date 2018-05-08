using System;
using System.IO.Abstractions;
using System.Security.Cryptography;

namespace DupKiller
{
    public class FileSystemReader
    {
        private readonly IFileSystem _fileSystem;

        public FileSystemReader(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public FileSystemReader() : this(new FileSystem())
        {
        }

        internal string GetExtension(string file)
        {
            return _fileSystem.Path.GetExtension(file);
        }

        internal string GetFileName(string file)
        {
            return _fileSystem.Path.GetFileNameWithoutExtension(file);
        }

        internal string GetFileSize(string file)
        {
            return _fileSystem.FileInfo.FromFileName(file).Length.ToString();
        }

        internal string GetShortHash(string file)
        {
            // Fix wrong path separators
            var sanitizedPath = _fileSystem.Path.GetFullPath(file);

            using (var md5 = MD5.Create())
            using (var stream = _fileSystem.File.OpenRead(sanitizedPath))
            {
                return Convert.ToBase64String(md5.ComputeHash(stream));
            }
        }

        internal string GetLongHash(string file)
        {
            var sanitizedPath = _fileSystem.Path.GetFullPath(file);

            using (var sha512 = SHA512.Create())
            using (var stream = _fileSystem.File.OpenRead(sanitizedPath))
            {
                return Convert.ToBase64String(sha512.ComputeHash(stream));
            }
        }
    }
}