using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using DupKiller;
using Xunit;

namespace Tests
{
    public class TestCore : IDisposable
    {
        private Core _core = new Core(
            new MockFileSystem(
                new Dictionary<string, MockFileData>
                {
                    {@"A:\test\alpha\file.txt", new MockFileData("Test file")},
                    {@"B:\test\beta\file.txt", new MockFileData("Another test file")},
                    {@"C:\test\gamma\file.bin", new MockFileData(new byte[] {0x12, 0x34, 0x56, 0xd2})}
                }
            )
        );

        [Theory]
        [InlineData("", "A:/whateverpath/filename")]
        [InlineData(".ext", "B:/whateverpath/.ext")]
        [InlineData(".ext", "B:/whateverpath/filename.ext")]
        [InlineData("", "C:/whateverpath/")]
        public void TestGetExtension(string extension, string path)
        {
            Assert.Equal(
                extension,
                Utilities.ExecutePrivateMethod(_core, "GetExtension", new object[] { path })
            );
        }

        [Theory]
        [InlineData("filename", "A:/whateverpath/filename")]
        [InlineData("", "B:/whateverpath/.ext")]
        [InlineData("filename", "B:/whateverpath/filename.ext")]
        [InlineData("", "C:/whateverpath/")]
        public void TestGetFileName(string fileName, string path)
        {
            Assert.Equal(
                fileName,
                Utilities.ExecutePrivateMethod(_core, "GetFileName", new object[] { path })
            );
        }

        public void Dispose()
        {
            _core = null;
        }
    }
}