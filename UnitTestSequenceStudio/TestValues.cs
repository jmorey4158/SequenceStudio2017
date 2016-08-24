using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SequenceStudio;

namespace UnitTestSequenceStudio
{
    public partial class TestValiables
    {
        public const SequenceEnums.SequenceOriginType sotManual = SequenceEnums.SequenceOriginType.Manual;

        // These are known good values for testing DNA methods
        public const string DNApass = "ACTAGCTCGTAGTCGATGCATGCTCGTAGCATGCTGA"; // Well-formed DNA sequence - should pass
        public const string DNAfail = "ACTGCATGCTAGCTGACTGCTGCHatgctctgcatgctagc"; //  Has an 'h' in there somewhere
        public const string DNAcompStrand = "TGATCGAGCATCAGCTACGTACGAGCATCGTACGACT";
        public const string DNAreverseStrand = "AGTCGTACGATGCTCGTACGTAGCTGATGCTCGATCA";
        public const string DNAreverseComplimentStrand = "TCAGCATGCTACGAGCATGCATCGACTACGAGCTAGT";
        public const string DNAtranscript = "ACUAGCUCGUAGUCGAUGCAUGCUCGUAGCAUGCUGA";
        public const string DNAhash = "601480e0442a49f20cfe9aa59d129719"; // This is the SHA1 hash of the DNA.Strand
        public const SequenceEnums.SequenceType stDNA = SequenceEnums.SequenceType.DNA;
        public const decimal mwDNA = 10557.58m;
        public static DNA tvDNA = new DNA(DNApass);

        // These are known good values for testing RNA methods
        public const string RNApass = "ACUAGCUCGUAGUCGAUGCAUGCUCGUAGCAUGCUGA"; // Well-formed RNA sequence - should pass
        public const string RNAfail = "ACUGCAUGCUAGCUGACUGCUGCHaUgcUcUgcaUgcUagc"; //  Has an 'h' in there somewhere
        public const string RNAhash = "0fb2c54e7d617ffb5b53ccb481c5181f"; // This is the SHA1 hash of the RNA.Strand
        public const SequenceEnums.SequenceType stRNA = SequenceEnums.SequenceType.RNA;
        public const decimal mwRNA = 8792.18m;
        public static RNA tvRNA = new RNA(RNApass);

        // These are known good values for testing Polypeptide methods
        public const string Polypass = "ACDEFGHIKLMNPQRSTVWY"; // Well-formed Polypeptide sequence - should pass
        public const string Polyfail = "ACDEFGHIKLMNXPQRSTVWY"; //  Has an 'X' in there somewhere
        public const string Polyhash = "638ef73a7502450731f6bfb2c2dd8747"; // This is the SHA1 hash of the Polypeptide.Strand
        public const SequenceEnums.SequenceType stPoly = SequenceEnums.SequenceType.Polypeptide;
        public const decimal mwPoly = 2573.82126m;
        public static Polypeptide tvPoly = new Polypeptide(Polypass);
    }

}