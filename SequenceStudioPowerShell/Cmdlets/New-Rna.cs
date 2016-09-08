using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.New, "RNA", 
        DefaultParameterSetName = "Strand")]
    public class NewRnaCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, 
            ParameterSetName = "Strand",
            ValueFromPipeline = true,
            HelpMessage = "Enter a valid RNA sequence, e.g. ACAUCGAUCAUCGUGACAUG.")]
        [Alias("s")]
        [ValidatePattern("[ACUG]")]
        public string Strand
        {
            set { _strand = value; }
        }
        private string _strand;




        [Parameter(Mandatory = true, ParameterSetName = "RNA",
            ValueFromPipeline = true,
            HelpMessage = "Specify a previously-created, valid RNA class instance.")]
        [Alias("d")]
        public RNA Rna
        {
            set { _rna = value; }
        }
        private RNA _rna;


        [Parameter(Mandatory = false, ParameterSetName = "RNA",
            ValueFromPipeline = false,
            HelpMessage = "Choose -Reverse (-r) to create a new RNA object based upon the Reverse strand of this RNA object. Use this together with the -Compliment switch (-c) to create a new DNA object based upon the ReverseCompliment strand of this DNA object.")]
        [Alias("r")]
        public SwitchParameter Reverse
        {
            get { return _reverse; }
            set { _reverse = value; }
        }
        private SwitchParameter _reverse;


        [Parameter(Mandatory = false, ParameterSetName = "RNA",
            ValueFromPipeline = false,
            HelpMessage = "Choose -Compliment (-c) to create a new RNA object based upon the Compliment strand of this RNA object. Use this together with the -Reverse switch (-r) to create a new RNA object based upon the ReverseCompliment strand of this RNA object.")]
        [Alias("c")]
        public SwitchParameter Compliment
        {
            get { return _comp; }
            set { _comp = value; }
        }
        private SwitchParameter _comp;



        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "Strand")
            {
                WriteObject(new RNA(_strand));
            }
            else
            {
                if (_reverse && _comp)
                {
                    WriteObject(new RNA(SequenceMethods.GetReverseComplimentStrand(_rna), _rna.SequenceOriginType));
                }
                else if (_reverse)
                {
                    WriteObject(new RNA(SequenceMethods.GetReverseStrand(_rna), _rna.SequenceOriginType));
                }
                else if (_comp)
                {
                    WriteObject(new RNA(SequenceMethods.GetComplimentStrand(_rna), _rna.SequenceOriginType));
                }
                else { }
            }
        }
    }
}
