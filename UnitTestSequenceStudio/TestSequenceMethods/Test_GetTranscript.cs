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
        public void TestTranscript_GoodSequences_ShouldPass()
        {
            Assert.AreEqual<string>(TestValiables.DNAtranscript, SequenceMethods.GetTranscript(TestValiables.tvDNA));
        }


        [TestMethod]
        public void TestTranscript_BadSequences_ShouldFail()
        {
            Assert.AreNotEqual<string>("CAGGACGACGAGCAGCGAGC", SequenceMethods.GetTranscript(TestValiables.tvDNA));
        }
    }
}