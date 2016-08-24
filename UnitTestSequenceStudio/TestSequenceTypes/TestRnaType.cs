using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;

namespace UnitTestSequenceStudio
{
    public partial class SequenceStudioUnitTests
    {

        private string RNApass = "ACUAGCUCGUAGUCGAUGCAUGCUCGUAGCAUGCUGA"; // Well-formed DNA sequence - should pass
        private string RNAfail = "ACUGCAUGCUAGCUGACUGCUGCHaUgcUcUgcaUgcUagc"; //  Has an 'h' in there somewhere
        private string RNAhash = "0fb2c54e7d617ffb5b53ccb481c5181f"; // This is the SHA1 hash of the DNA.Strand
        private SequenceEnums.SequenceType stRNA = SequenceEnums.SequenceType.RNA;

        [TestMethod]
        public void TestRnaType_Good_ShouldPass()
        {
            try
            {
                var testRNA = SequenceMethods.CreateSequence(RNApass,
                    SequenceEnums.SequenceType.RNA, SequenceEnums.SequenceOriginType.Manual);

                Assert.IsInstanceOfType(testRNA, typeof(RNA));
                Assert.AreEqual<string>(RNApass, testRNA.Strand);
                Assert.AreEqual<int>(37, testRNA.Strand.Length);
                Assert.AreEqual<string>(RNAhash, testRNA.StrandHash);
                Assert.AreEqual<SequenceEnums.SequenceType>(stRNA, testRNA.SequenceType);
                Assert.AreEqual<SequenceEnums.SequenceOriginType>(sotManual,
                    testRNA.SequenceOriginType);
            }
            catch (SequenceException se)
            {
                Assert.Fail(se.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(SequenceException))]
        public void TestRnaType_Bad_ShouldThrowSequenceException()
        {
            try
            {
                var failRDNA = SequenceMethods.CreateSequence(RNAfail,
                    SequenceEnums.SequenceType.RNA, SequenceEnums.SequenceOriginType.Manual);
            }
            catch (SequenceException se)
            {
                throw se;
            }
        }

    }
}
