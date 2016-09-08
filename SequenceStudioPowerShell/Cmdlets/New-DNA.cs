using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.New, "DNA", DefaultParameterSetName = "Strand" )]
    public class NewDnaCmdlet : PSCmdlet
    {
        [Parameter(Mandatory =true,ParameterSetName ="Stand", 
            ValueFromPipeline = true,
            HelpMessage = "Enter a valid DNA sequence, e.g. ACATCGATCATCGTGACATG.")]
        [Alias("s")]
        [ValidatePattern("[ACTG]")]
        public string Strand 
        {
            set { _strand = value; }
        }
        private string _strand;



        [Parameter(Mandatory =true,ParameterSetName ="DNA", 
            ValueFromPipeline = true,
            HelpMessage = "Specify a previously-created, valid DNA class instance.")]
        [Alias("d")]
        public DNA DNA 
        {
            set { _dna = value; }
        }
        private DNA _dna;


        [Parameter(Mandatory = false,ParameterSetName ="DNA", 
            ValueFromPipeline = false,
            HelpMessage = "Choose -Reverse (-r) to create a new DNA object based upon the Reverse strand of this DNA object. Use this together with the -Compliment switch (-c) to create a new DNA object based upon the ReverseCompliment strand of this DNA object.")]
        [Alias("r")]
        public SwitchParameter Reverse 
        {
            get { return _reverse; }
            set { _reverse = value; }
        }
        private SwitchParameter _reverse;


        [Parameter(Mandatory = false,ParameterSetName ="DNA", 
            ValueFromPipeline = false,
            HelpMessage = "Choose -Compliment (-c) to create a new DNA object based upon the Compliment strand of this DNA object. Use this together with the -Reverse switch (-r) to create a new DNA object based upon the ReverseCompliment strand of this DNA object.")]
        [Alias("c")]
        public SwitchParameter Compliment 
        {
            get { return _comp; }
            set { _comp = value; }
        }
        private SwitchParameter _comp;


        protected override void ProcessRecord()
        {
            if(this.ParameterSetName == "Stand")
            {
                WriteObject(new DNA(_strand));
            }
            else
            {
                if( _reverse && _comp )
                {
                    WriteObject(new DNA(SequenceMethods.GetReverseComplimentStrand(_dna), _dna.SequenceOriginType));
                }
                else if( _reverse )
                {
                    WriteObject(new DNA(SequenceMethods.GetReverseStrand(_dna), _dna.SequenceOriginType));
                }
                else if ( _comp )
                {
                    WriteObject(new DNA(SequenceMethods.GetComplimentStrand(_dna), _dna.SequenceOriginType));
                }
                else{ }
            }
        }
    }
}
