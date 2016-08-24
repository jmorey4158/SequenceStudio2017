using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSequenceStudio
{
    public partial class SequenceStudioUnitTests
    {

        [TestMethod]
        public void TestGetReverseComplimentStrand_GoodSequences_ShouldPass()
        {
            Assert.AreEqual<string>(TestValiables.DNAreverseComplimentStrand, 
                SequenceMethods.GetReverseComplimentStrand(TestValiables.tvDNA));
        }


        [TestMethod]
        public void TestGetReverseComplimentStrand_BadSequences_ShouldFail()
        {
            Assert.AreNotEqual<string>("CAGTGATCGTACGTAGCAGCTGATGC", 
                SequenceMethods.GetReverseComplimentStrand(TestValiables.tvDNA));
        }
    }
}