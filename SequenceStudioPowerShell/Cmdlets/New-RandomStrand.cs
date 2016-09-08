using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.New, "RandomStrand",
        SupportsShouldProcess = false)]
    public class NewRandomStrandCmdlet : PSCmdlet
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



        protected override void ProcessRecord()
        {

            switch (Type)
            {
                case "DNA":
                    WriteObject(SequenceMethods.GenerateRandomStrand(_len, SequenceEnums.SequenceType.DNA));
                    break;

                case "RNA":
                    WriteObject(SequenceMethods.GenerateRandomStrand(_len, SequenceEnums.SequenceType.RNA));
                    break;

                case "Poly":
                    WriteObject(SequenceMethods.GenerateRandomStrand(_len, SequenceEnums.SequenceType.Polypeptide));
                    break;


                default:
                    // WriteError();
                    break;
            }

        }
    }
}
