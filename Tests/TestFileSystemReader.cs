using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using DupKiller;
using Xunit;

namespace Tests
{
    public class TestFileSystemReader
    {
        private static readonly FileSystemReader MockFsr = new FileSystemReader(
            new MockFileSystem(
                new Dictionary<string, MockFileData>
                {
                    { @"A:\test\alpha\file.txt", new MockFileData("Test file") },
                    { @"B:\test\beta\file.txt", new MockFileData("Another test file") },
                    { @"C:\test\gamma\file.bin", new MockFileData(new byte[] { 0x12, 0x34, 0x56, 0xd2 }) }
                }
            )
        );

        [Theory]
        [InlineData("", @"A:/whateverpath/filename")]
        [InlineData(".ext", @"B:/whateverpath/.ext")]
        [InlineData(".ext", @"B:/whateverpath/filename.ext")]
        [InlineData("", @"C:/whateverpath/")]
        public void TestGetExtension(string extension, string path)
        {
            Assert.Equal(
                extension,
                MockFsr.ExecutePrivateMethod("GetExtension", new object[] { path })
            );
        }

        [Theory]
        [InlineData("filename", @"A:/whateverpath/filename")]
        [InlineData("", @"B:/whateverpath/.ext")]
        [InlineData("filename", @"B:/whateverpath/filename.ext")]
        [InlineData("", @"C:/whateverpath/")]
        public void TestGetFileName(string fileName, string path)
        {
            Assert.Equal(
                fileName,
                MockFsr.ExecutePrivateMethod("GetFileName", new object[] { path })
            );
        }

        [Theory]
        [InlineData("9", @"A:/test/alpha/file.txt")]
        [InlineData("4", @"C:/test/gamma/file.bin")]
        public void TestGetFileSize(string length, string path)
        {
            Assert.Equal(
                length,
                MockFsr.ExecutePrivateMethod("GetFileSize", new object[] { path })
            );
        }

        [Theory]
        [InlineData("7ckAdFxdFddz+83As3bwDA==", @"A:/test/alpha/file.txt")]
        [InlineData("7DY/LTZvMO/gSAwDOQj0Pw==", @"C:\test\gamma\file.bin")]
        public void TestGetShortHash(string md5, string path)
        {
            Assert.Equal(
                md5,
                MockFsr.ExecutePrivateMethod("GetShortHash", new object[] { path })
            );
        }

        [Theory]
        [InlineData("aRhaZl7LiPMznPzRr87uoFSjdXNWmG4G+mXb8ElwBeJIF2bft0NhK6Ueg2URakz/5L8Jxh+gztgdf7XsQBwsWg==",
            @"C:/test/gamma/file.bin")]
        public void TestGetLongHash(string sha512, string path)
        {
            Assert.Equal(
                sha512,
                MockFsr.ExecutePrivateMethod("GetLongHash", new object[] { path })
            );
        }
    }
}