using NUnit.Framework;

namespace MetaPong.NUnit.Tests
{
    using Utilities;

    [TestFixture]
    public class TestClass
    {
        [Test, Property("Priority", 0)]
        public void ComposerRegularUpper()
        {
            string boxUpper = "╔═══╗";
            var box = Composer.MakeBoxLayout(5, 2);
            var rows = Composer.Compose(box);
            // Assert that composer returns a propper element
            Assert.AreEqual(boxUpper,rows[0],"The UPPER size of the box is not correct. Check Composer.MakeBoxLayout method!");
        }

        [Test, Property("Priority", 1)]
        public void ComposerRegularLower()
        {
            string boxLower = "╚═══╝";
            var box = Composer.MakeBoxLayout(5, 2);
            var rows = Composer.Compose(box);
            // Assert that composer returns a propper element
            Assert.AreEqual(boxLower, rows[1], "The LOWER size of the box is not correct. Check Composer.MakeBoxLayout method!");
        }
    }
}
