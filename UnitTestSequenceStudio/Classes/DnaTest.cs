using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;

namespace UnitTestSequenceStudio
{
    public partial class SequenceStudioUnitTests
    {
        [TestMethod]
        public void InstantiateDnaTest()
        {
            string pass = "ACTAGCTCGTAGTCGATGCATGCTCGTAGCATGCTGA";
            string fail = "ACTGCATGCTAGCTGACTGCTGCHatgctctgcatgctagc";

            try
            {
                var passDNA = SequenceMethods.CreateSequence(pass, SequenceEnums.SequenceType.DNA, SequenceEnums.SequenceOriginType.Manual);
            }
            catch (SequenceException se)
            {
                Assert.Fail(se.Message);
            }

            try
            {
                var failDNA = SequenceMethods.CreateSequence(fail, SequenceEnums.SequenceType.DNA, SequenceEnums.SequenceOriginType.Manual);
            }
            catch (SequenceException se)
            {
                throw se;
            }
        }
    }
}
