using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;

namespace UnitTestSequenceStudio
{
    public partial class SequenceStudioUnitTests
    {

        private string DNApass = "ACTAGCTCGTAGTCGATGCATGCTCGTAGCATGCTGA"; // Well-formed DNA sequence - should pass
        private string DNAfail = "ACTGCATGCTAGCTGACTGCTGCHatgctctgcatgctagc"; //  Has an 'h' in there somewhere
        private string DNAhash = "601480e0442a49f20cfe9aa59d129719"; // This is the SHA1 hash of the DNA.Strand
        private SequenceEnums.SequenceType stDNA = SequenceEnums.SequenceType.DNA;
        private SequenceEnums.SequenceOriginType sotManual = SequenceEnums.SequenceOriginType.Manual;

        [TestMethod]
        public void TestDnaType_Good_ShouldPass()
        {
            try
            {
                var testDNA = SequenceMethods.CreateSequence(RNApass, 
                    SequenceEnums.SequenceType.DNA, SequenceEnums.SequenceOriginType.Manual);

                Assert.IsInstanceOfType(testDNA, typeof(DNA));
                Assert.AreEqual<string>(RNApass, testDNA.Strand);
                Assert.AreEqual<int>(37, testDNA.Strand.Length);
                Assert.AreEqual<string>(DNAhash, testDNA.StrandHash);
                Assert.AreEqual<SequenceEnums.SequenceType>(stDNA, testDNA.SequenceType);
                Assert.AreEqual<SequenceEnums.SequenceOriginType>(sotManual,
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
                var failDNA = SequenceMethods.CreateSequence(DNAfail, 
                    SequenceEnums.SequenceType.DNA, SequenceEnums.SequenceOriginType.Manual);
            }
            catch (SequenceException se)
            {
                throw se;
            }
        }

    }
}
