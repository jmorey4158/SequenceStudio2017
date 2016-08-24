using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;

namespace UnitTestSequenceStudio
{
    public partial class SequenceStudioUnitTests
    {

        [TestMethod]
        public void TestRnaType_Good_ShouldPass()
        {
            try
            {
                var testRNA = SequenceMethods.CreateSequence(TestValiables.RNApass,
                    SequenceEnums.SequenceType.RNA, SequenceEnums.SequenceOriginType.Manual);

                Assert.IsInstanceOfType(testRNA, typeof(RNA));
                Assert.AreEqual<string>(TestValiables.RNApass, testRNA.Strand);
                Assert.AreEqual<int>(37, testRNA.Strand.Length);
                Assert.AreEqual<string>(TestValiables.RNAhash, testRNA.StrandHash);
                Assert.AreEqual<SequenceEnums.SequenceType>(TestValiables.stRNA, testRNA.SequenceType);
                Assert.AreEqual<SequenceEnums.SequenceOriginType>(TestValiables.sotManual,
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
                var failRDNA = SequenceMethods.CreateSequence(TestValiables.RNAfail,
                    SequenceEnums.SequenceType.RNA, SequenceEnums.SequenceOriginType.Manual);
            }
            catch (SequenceException se)
            {
                throw se;
            }
        }

    }
}
