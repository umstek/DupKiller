using DupKiller;
using Xunit;

namespace Tests
{
    public class TestCore
    {
        [Theory]
        [InlineData("", "A:/whateverpath/filename")]
        [InlineData(".ext", "B:/whateverpath/.ext")]
        [InlineData(".ext", "B:/whateverpath/filename.ext")]
        [InlineData("", "C:/whateverpath/")]
        public void TestGetExtension(string extension, string path)
        {
            Assert.Equal(
                extension,
                Utilities.ExecuteStaticPrivateMethod(typeof(Core), "GetExtension", new object[] {path})
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
                Utilities.ExecuteStaticPrivateMethod(typeof(Core), "GetFileName", new object[] {path})
            );
        }
    }
}