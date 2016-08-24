using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;

namespace UnitTestSequenceStudio
{
    [TestClass]
    public partial class SequenceStudioUnitTests
    {
        private string seqA = "This is a string that will get hashinated.";
        private string seqB = "This is a string that will get hashified.";



        [TestMethod]
        public void TestGetISequenceHash_ShouldNotBeEqual()
        {
            string hashA = SequenceStudio.SequenceMethods.GetISequenceHash(seqA);
            string hashB = SequenceStudio.SequenceMethods.GetISequenceHash(seqB);

            Assert.IsNotNull(hashA);
            Assert.IsNotNull(hashB);
            Assert.AreNotEqual(hashA, hashB);
        }

        [TestMethod]
        public void TestGetISequenceHash_ShouldBeEqual()
        {
            string hashA = SequenceStudio.SequenceMethods.GetISequenceHash(seqA);
            string hashB = SequenceStudio.SequenceMethods.GetISequenceHash(seqA);

            Assert.IsNotNull(hashA);
            Assert.IsNotNull(hashB);
            Assert.AreEqual(hashA, hashB);
        }

    }
}
