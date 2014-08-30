using IronBank.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IronBank.Testing.Units.Models
{
    [TestClass]
    public class ProductModel_AccountGenerator
    {
        [TestMethod]
        public void Generate_ShouldReturn_10_digits_by_default()
        {
            var generator = new AccountNumberGenerator();
            var should_have_ten_digits = generator.Generate();
            Assert.AreEqual(10, should_have_ten_digits.Length);
        }

        [TestMethod]
        public void Generate_ShouldReturn_Different_Strings_On_Successive_Calls()
        {
            var generator = new AccountNumberGenerator();
            var one = generator.Generate();
            var two = generator.Generate();
            Assert.AreNotEqual(one, two);
            Assert.AreNotEqual(generator.Generate(), generator.Generate(15));
            Assert.AreNotEqual(generator.Generate(5), generator.Generate(5));
            Assert.AreNotEqual(generator.Generate(15), generator.Generate(15));
        }
    }
}
