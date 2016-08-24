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
        public void TestGetComplimentStrand_GoodSequences_ShouldPass()
        {
            Assert.AreEqual<string>(TestValiables.DNAcompStrand, SequenceMethods.GetComplimentStrand(TestValiables.tvDNA));
        }


        [TestMethod]
        public void TestGetComplimentStrand_BadSequences_ShouldFail()
        {
            Assert.AreNotEqual<string>("CAGTGATCGTACGTAGCAGCTGATGC", SequenceMethods.GetComplimentStrand(TestValiables.tvDNA));
        }
    }
}