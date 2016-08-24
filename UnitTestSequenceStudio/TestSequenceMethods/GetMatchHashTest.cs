using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;

namespace UnitTestSequenceStudio
{
    [TestClass]
    public partial class SequenceStudioUnitTests
    {
        [TestMethod]
        public void GetISequenceHashTest()
        {
            string a = "This is a string that will get hashinated.";
            string b = "This is a string that will get hashified.";

            string hashA = SequenceStudio.SequenceMethods.GetISequenceHash(a);
            string hashB = SequenceStudio.SequenceMethods.GetISequenceHash(b);

            Assert.IsNotNull(hashA);
            Assert.IsNotNull(hashB);
            Assert.AreNotEqual(a, b);
        }
    }
}
