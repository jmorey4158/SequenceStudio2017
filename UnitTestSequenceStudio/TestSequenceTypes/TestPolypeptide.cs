using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;

namespace UnitTestSequenceStudio
{
    public partial class SequenceStudioUnitTests
    {

        private string Polypass = "ACDEFGHIKLMNPQRSTVWY"; // Well-formed DNA sequence - should pass
        private string Polyfail = "ACDEFGHIKLMNXPQRSTVWY"; //  Has an 'X' in there somewhere
        private string Polyhash = "638ef73a7502450731f6bfb2c2dd8747"; // This is the SHA1 hash of the Strand
        private SequenceEnums.SequenceType stPoly = SequenceEnums.SequenceType.Polypeptide;

        [TestMethod]
        public void TestPolypeptideType_Good_ShouldPass()
        {
            try
            {
                var testPoly = SequenceMethods.CreateSequence(Polypass,
                    SequenceEnums.SequenceType.Polypeptide, SequenceEnums.SequenceOriginType.Manual);

                Assert.IsInstanceOfType(testPoly, typeof(Polypeptide));
                Assert.AreEqual<string>(Polypass, testPoly.Strand);
                Assert.AreEqual<int>(20, testPoly.Strand.Length);
                Assert.AreEqual<string>(Polyhash, testPoly.StrandHash);
                Assert.AreEqual<SequenceEnums.SequenceType>(stPoly, testPoly.SequenceType);
                Assert.AreEqual<SequenceEnums.SequenceOriginType>(sotManual,
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
                var failPoly = SequenceMethods.CreateSequence(Polyfail,
                    SequenceEnums.SequenceType.Polypeptide, SequenceEnums.SequenceOriginType.Manual);
            }
            catch (SequenceException se)
            {
                throw se;
            }
        }

    }
}
