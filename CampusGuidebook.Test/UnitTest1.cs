using Xunit;

namespace CampusGuidebook.Test
{
    public class UnitTest1
    {
        private string ExpectedName = "Data";

        

        [Fact]
        public void Test1()
        {
            Assert.Equal(ExpectedName, "Data");
        }
    }
}