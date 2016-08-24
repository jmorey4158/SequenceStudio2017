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
        public void TestGetReverseStrand_GoodSequences_ShouldPass()
        {
            Assert.AreEqual<string>(TestValiables.DNAreverseStrand, SequenceMethods.GetReverseStrand(TestValiables.tvDNA));
        }


        [TestMethod]
        public void TestGetReverseStrand_BadSequences_ShouldFail()
        {
            Assert.AreNotEqual<string>("CAGTGATCGTACGTAGCAGCTGATGC", SequenceMethods.GetReverseStrand(TestValiables.tvDNA));
        }
    }
}