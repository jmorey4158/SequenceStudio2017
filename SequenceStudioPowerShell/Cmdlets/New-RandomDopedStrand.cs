using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.New, "RandomDopedStrand",
        SupportsShouldProcess = false)]
    public class NewRandomDopedStrandCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Provide a valid Sequence Type ('DNA', 'RNA', or 'Poly'.")]
        [ValidateSet("DNA", "RNA", "Poly")]
        [Alias("t")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _type;


        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Specify the length of the sequence 1 - IntMax")]
        [Alias("l")]
        [ValidateRange(1, int.MaxValue)]
        public int Length
        {
            get { return _len; }
            set { _len = value; }
        }
        private int _len;


        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "Specify the ratios of the residues in the result.")]
        [Alias("p")]
        public string Pattern
        {
            get { return _pattern; }
            set { _pattern = value; }
        }
        private string _pattern;




        protected override void ProcessRecord()
        {

            switch (Type)
            {
                case "DNA":
                    if(SequenceMethods.ValidateSequence(_pattern, SequenceEnums.SequenceType.DNA))
                    {
                        WriteObject(SequenceMethods.GenerateRandomDopedStrand(_len, SequenceEnums.SequenceType.DNA, _pattern));
                    }
                    else
                    {
                        // Throw error
                    }
                    break;

                case "RNA":
                    if (SequenceMethods.ValidateSequence(_pattern, SequenceEnums.SequenceType.RNA))
                    {
                        WriteObject(SequenceMethods.GenerateRandomDopedStrand(_len, SequenceEnums.SequenceType.RNA, _pattern));
                    }
                    else
                    {
                        // Throw error
                    }
                    break;

                case "Poly":
                    if (SequenceMethods.ValidateSequence(_pattern, SequenceEnums.SequenceType.Polypeptide))
                    {
                        WriteObject(SequenceMethods.GenerateRandomDopedStrand(_len, SequenceEnums.SequenceType.Polypeptide, _pattern));
                    }
                    else
                    {
                        // Throw error
                    }
                    break;


                default:
                    // WriteError();
                    break;
            }

        }
    }
}
