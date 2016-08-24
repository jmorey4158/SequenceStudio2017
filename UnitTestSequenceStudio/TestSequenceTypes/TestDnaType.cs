using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;

namespace UnitTestSequenceStudio
{
    public partial class SequenceStudioUnitTests
    {

        [TestMethod]
        public void TestDnaType_Good_ShouldPass()
        {
            try
            {
                var testDNA = SequenceMethods.CreateSequence(TestValiables.DNApass, 
                    SequenceEnums.SequenceType.DNA, SequenceEnums.SequenceOriginType.Manual);

                Assert.IsInstanceOfType(testDNA, typeof(DNA));
                Assert.AreEqual<string>(TestValiables.DNApass, testDNA.Strand);
                Assert.AreEqual<int>(37, testDNA.Strand.Length);
                Assert.AreEqual<string>(TestValiables.DNAhash, testDNA.StrandHash);
                Assert.AreEqual<SequenceEnums.SequenceType>(TestValiables.stDNA, testDNA.SequenceType);
                Assert.AreEqual<SequenceEnums.SequenceOriginType>(TestValiables.sotManual,
                    testDNA.SequenceOriginType);
            }
            catch (SequenceException se)
            {
                Assert.Fail(se.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(SequenceException))]
        public void TestDnaType_Bad_ShouldThrowSequenceException()
        {
            try
            {
                var failDNA = SequenceMethods.CreateSequence(TestValiables.DNAfail, 
                    SequenceEnums.SequenceType.DNA, SequenceEnums.SequenceOriginType.Manual);
            }
            catch (SequenceException se)
            {
                throw se;
            }
        }

    }
}
