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
        public void TestGetMolecularWeight_GoodSequences_ShouldPass()
        {
            Assert.AreEqual<decimal>(TestValiables.mwDNA, SequenceMethods.GetMolecularWeight(TestValiables.tvDNA));  
            Assert.AreEqual<decimal>(TestValiables.mwRNA, SequenceMethods.GetMolecularWeight(TestValiables.tvRNA));  
            Assert.AreEqual<decimal>(TestValiables.mwPoly, SequenceMethods.GetMolecularWeight(TestValiables.tvPoly));  
                      
        }


        [TestMethod]
        public void TestGetMolecularWeight_BadCompareValue_ShouldFail()
        {
            decimal fail = 123456789.123m;
            Assert.AreNotEqual<decimal>(fail, SequenceMethods.GetMolecularWeight(TestValiables.tvDNA));
            Assert.AreNotEqual<decimal>(fail, SequenceMethods.GetMolecularWeight(TestValiables.tvRNA));           
            Assert.AreNotEqual<decimal>(fail, SequenceMethods.GetMolecularWeight(TestValiables.tvPoly));           
          
             
        }
    }
}
