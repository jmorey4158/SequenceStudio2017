using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;

namespace UnitTestSequenceStudio
{
    public partial class SequenceStudioUnitTests
    {

        [TestMethod]
        public void TestPolypeptideType_Good_ShouldPass()
        {
            try
            {
                var testPoly = SequenceMethods.CreateSequence(TestValiables.Polypass,
                    SequenceEnums.SequenceType.Polypeptide, SequenceEnums.SequenceOriginType.Manual);

                Assert.IsInstanceOfType(testPoly, typeof(Polypeptide));
                Assert.AreEqual<string>(TestValiables.Polypass, testPoly.Strand);
                Assert.AreEqual<int>(20, testPoly.Strand.Length);
                Assert.AreEqual<string>(TestValiables.Polyhash, testPoly.StrandHash);
                Assert.AreEqual<SequenceEnums.SequenceType>(TestValiables.stPoly, testPoly.SequenceType);
                Assert.AreEqual<SequenceEnums.SequenceOriginType>(TestValiables.sotManual,
                    testPoly.SequenceOriginType);
            }
            catch (SequenceException se)
            {
                Assert.Fail(se.Message);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(SequenceException))]
        public void TestPolypeptideType_Bad_ShouldThrowSequenceException()
        {
            try
            {
                var failPoly = SequenceMethods.CreateSequence(TestValiables.Polyfail,
                    SequenceEnums.SequenceType.Polypeptide, SequenceEnums.SequenceOriginType.Manual);
            }
            catch (SequenceException se)
            {
                throw se;
            }
        }

    }
}
