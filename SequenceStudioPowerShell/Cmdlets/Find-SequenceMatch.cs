using System.Management.Automation;
using SequenceStudio;
using System.Collections.Generic;
using System;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.Find, "SequenceMatch")]
    public class FindSequenceMatchCmdlet : PSCmdlet
    {
        #region Parameters
        private ISequence _seq1;
        private ISequence _seq2;

        // DNA Parameter set
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "DNA",
            HelpMessage = "Enter the first (of two) valid SequenceStudio.DNA class instance.")]
        [Alias("d1")]
        public DNA Dna1
        {
            set { _seq1 = value; }
        }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "DNA",
            HelpMessage = "Enter the second (of two) valid SequenceStudio.DNA class instance.")]
        [Alias("d2")]
        public DNA Dna2
        {
            set { _seq2 = value; }
        }


        // RNA Parameter set =============================================
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "RNA",
            HelpMessage = "Enter the first (of two) valid SequenceStudio.RNA class instance.")]
        [Alias("r1")]
        public RNA Rna1
        {
            set { _seq1 = value; }
        }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "RNA",
            HelpMessage = "Enter the second (of two) valid SequenceStudio.RNA class instance.")]
        [Alias("r2")]
        public RNA Rna2
        {
            set { _seq2 = value; }
        }



        // Poly Parameter set ==============================================
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "Poly",
            HelpMessage = "Enter the first (of two) valid SequenceStudio.Polypeptide class instance.")]
        [Alias("p1")]
        public Polypeptide Poly1
        {
            set { _seq1 = value; }
        }

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "Poly",
            HelpMessage = "Enter the second (of two) valid SequenceStudio.Polypeptide class instance.")]
        [Alias("p2")]
        public Polypeptide Poly2
        {
            set { _seq2 = value; }
        }


        // THIS PARAMETER SET REMOVED DUE TO COMPLEXITY -- USER CASE NOT STRONG ENOUGH  
        //// Strand Parameter set =============================================
        //[Parameter(Mandatory = true,
        //    ValueFromPipeline = true,
        //    ParameterSetName = "Strand",
        //    HelpMessage = "Enter the first (of two) valid sequence (DNA, RNA, or Polypeptide) string. Both sequences must be the same Type of sequence.")]
        //[Alias("s1")]
        //public string Strand1
        //{
        //    set { _strand1 = value; }
        //}
        //private string _strand1;

        //[Parameter(Mandatory = true,
        //    ValueFromPipeline = true,
        //    ParameterSetName = "Strand",
        //    HelpMessage = "Enter the first (of two) valid sequence (DNA, RNA, or Polypeptide) string. Both sequences must be the same Type of sequence.")]
        //[Alias("s2")]
        //public string Strand2
        //{
        //    set { _strand2 = value; }
        //}
        //private string _strand2;

        //[Parameter(Mandatory = true,
        //    ValueFromPipeline = true,
        //    ParameterSetName = "Strand",
        //    HelpMessage = "Enter the of the two sequences ( 'DNA', 'RNA', or 'Polypeptide'). Both sequences must be the same Type of sequence.")]
        //[Alias("t")]
        //[ValidateSet("DNA", "RNA", "Polypeptide")]
        //public string Type
        //{
        //    set { _type = value; }
        //}
        //private string _type;



        // Additional parameters


        [Parameter(Mandatory = false,
        ValueFromPipeline = false,
        HelpMessage = "Use this value to specify the minimum length the 'Contiguous Match'.")]
        public SwitchParameter Contiguous
        {
            set { _contig = value; }
        }
        private SwitchParameter _contig;


        [Parameter(Mandatory = false,
        ValueFromPipeline = false,
        HelpMessage = "Specify the percentage match threshold that the percentage match must meet or exceed to be valid. You must also provide a 'threshold' value between 10-100%.")]
        [ValidateRange(10, 100)]
        public int Threshold
        {
            set { _thold = value; }
        }
        private int _thold;

        #endregion


        // ProcessRecord =========================================
        protected override void ProcessRecord()
        {
            if (_contig)
            {
                WriteObject(SequenceMethods.FindMatches(
                    _seq1, _seq2, _seq1.SequenceOriginType,
                    _seq2.SequenceOriginType, _thold,
                    SequenceEnums.MatchType.ContiguousMatch));
            }
            else if (_thold >= 100)
            {
                WriteObject(SequenceMethods.FindMatches(
                    _seq1, _seq2, _seq1.SequenceOriginType,
                    _seq2.SequenceOriginType, _thold,
                    SequenceEnums.MatchType.ExactMatch));
            }
            else if (10 <= _thold || _thold <= 99)
            {
                WriteObject(SequenceMethods.FindMatches(
                    _seq1, _seq2, _seq1.SequenceOriginType,
                    _seq2.SequenceOriginType, _thold,
                    SequenceEnums.MatchType.PercentageMatch));
            }
            else
            {
                // Throw error
            }
        }    
    }
}
