using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.Find, "SequenceMatch")]
    public class FindSequenceMatchCmdlet : PSCmdlet
    {
        #region Parameters

        // DNA Parameter set
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "DNA",
            HelpMessage = "Enter the first (of two) valid SequenceStudio.DNA class instance.")]
        [Alias("d1")]
        public DNA Dna1
        {
            set { _dna1 = value; }
        }
        private DNA _dna1;

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "DNA",
            HelpMessage = "Enter the second (of two) valid SequenceStudio.DNA class instance.")]
        [Alias("d2")]
        public DNA Dna2
        {
            set { _dna2 = value; }
        }
        private DNA _dna2;


        // RNA Parameter set =============================================
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "RNA",
            HelpMessage = "Enter the first (of two) valid SequenceStudio.RNA class instance.")]
        [Alias("r1")]
        public RNA Rna1
        {
            set { _rna1 = value; }
        }
        private RNA _rna1;

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "RNA",
            HelpMessage = "Enter the second (of two) valid SequenceStudio.RNA class instance.")]
        [Alias("r2")]
        public RNA Rna2
        {
            set { _rna2 = value; }
        }
        private RNA _rna2;



        // Poly Parameter set ==============================================
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "Poly",
            HelpMessage = "Enter the first (of two) valid SequenceStudio.Polypeptide class instance.")]
        [Alias("p1")]
        public Polypeptide Poly1
        {
            set { _poly1 = value; }
        }
        private Polypeptide _poly1;

        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "Poly",
            HelpMessage = "Enter the second (of two) valid SequenceStudio.Polypeptide class instance.")]
        [Alias("p2")]
        public Polypeptide Poly2
        {
            set { _poly2 = value; }
        }
        private Polypeptide _poly2;


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
        [ValidateRange(10, int.MaxValue)]
        public int Contiguous
        {
            set { _contig = value; }
        }
        private int _contig;


        [Parameter(Mandatory = false,
        ValueFromPipeline = false,
        HelpMessage = "Specify the percentage match threshold that the percentage match must meet or exceed to be valid. You must also provide a 'threshold' value between 10-100%.")]
        [ValidateRange(10, 100)]
        public int Percentage
        {
            set { _thold = value; }
        }
        private int _thold;

        #endregion




        // ProcessRecord =========================================
        protected override void ProcessRecord()
        {
            switch (this.ParameterSetName)
            {
                case "DNA":
                    if(_contig > 0)
                    {
                        WriteObject(SequenceMethods.FindMatches(
                            _dna1, _dna2, _dna1.SequenceOriginType,
                            _dna2.SequenceOriginType, _thold, SequenceEnums.MatchType.ContiguousMatch));
                    }
                    else if(_thold == 100)
                    {
                        WriteObject(SequenceMethods.FindMatches(
                            _dna1, _dna2, _dna1.SequenceOriginType,
                            _dna2.SequenceOriginType, _thold, SequenceEnums.MatchType.ExactMatch));
                    }
                    else if (10 <= _thold || _thold <= 99)
                    {
                        WriteObject(SequenceMethods.FindMatches(
                            _dna1, _dna2, _dna1.SequenceOriginType,
                            _dna2.SequenceOriginType, _thold, SequenceEnums.MatchType.PercentageMatch));
                    }
                    else
                    {
                        // Throw error
                    }
                    break;



                case "RNA":
                    if (_contig > 0)
                    {
                        WriteObject(SequenceMethods.FindMatches(
                            _rna1, _rna2, _rna1.SequenceOriginType,
                            _rna2.SequenceOriginType, _thold, SequenceEnums.MatchType.ContiguousMatch));
                    }
                    else if (_thold == 100)
                    {
                        WriteObject(SequenceMethods.FindMatches(
                            _rna1, _rna2, _rna1.SequenceOriginType,
                            _rna2.SequenceOriginType, _thold, SequenceEnums.MatchType.ExactMatch));
                    }
                    else if (10 <= _thold || _thold <= 99)
                    {
                        WriteObject(SequenceMethods.FindMatches(
                            _rna1, _rna2, _rna1.SequenceOriginType,
                            _rna2.SequenceOriginType, _thold, SequenceEnums.MatchType.PercentageMatch));
                    }
                    else
                    {
                        // Throw error
                    }
                    break;



                case "Poly":
                    if (_contig > 0)
                    {
                        WriteObject(SequenceMethods.FindMatches(
                            _poly1, _poly2, _poly1.SequenceOriginType,
                            _poly2.SequenceOriginType, _thold, SequenceEnums.MatchType.ContiguousMatch));
                    }
                    else if (_thold == 100)
                    {
                        WriteObject(SequenceMethods.FindMatches(
                            _poly1, _poly2, _poly1.SequenceOriginType,
                            _poly2.SequenceOriginType, _thold, SequenceEnums.MatchType.ExactMatch));
                    }
                    else if (10 <= _thold || _thold <= 99)
                    {
                        WriteObject(SequenceMethods.FindMatches(
                            _poly1, _poly2, _poly1.SequenceOriginType,
                            _poly2.SequenceOriginType, _thold, SequenceEnums.MatchType.PercentageMatch));
                    }
                    else
                    {
                        // WriteError
                    }
                    break;


                default:
                    break;
            }
        }
    }
}
