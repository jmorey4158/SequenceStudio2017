using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;

namespace UnitTestSequenceStudio
{
    public partial class SequenceStudioUnitTests
    {

        private const string pass = "ACTAGCTCGTAGTCGATGCATGCTCGTAGCATGCTGA";
        private const string fail = "ACTGCATGCTAGCTGACTGCTGCHatgctctgcatgctagc";


        [TestMethod]
        public void TestDnaType_Good_ShouldPass()
        {
            try
            {
                var passDNA = SequenceMethods.CreateSequence(pass, 
                    SequenceEnums.SequenceType.DNA, SequenceEnums.SequenceOriginType.Manual);
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
                var failDNA = SequenceMethods.CreateSequence(fail, 
                    SequenceEnums.SequenceType.DNA, SequenceEnums.SequenceOriginType.Manual);
            }
            catch (SequenceException se)
            {
                throw se;
            }
        }

    }
}
