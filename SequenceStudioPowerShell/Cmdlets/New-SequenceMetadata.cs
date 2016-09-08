using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.New, "SequenceMetadata")]
    public class NewSequenceMetadataCmdlet : PSCmdlet
    {

        [Parameter(Mandatory = true, 
            ValueFromPipeline = true,
            ParameterSetName = "DNA",
            HelpMessage = "Enter a valid DNA class instance.")]
        [Alias("d")]
        public DNA Dna
        {
            set { _dna = value; }
        }
        private DNA _dna;


        [Parameter(Mandatory = true, 
            ValueFromPipeline = true,
            ParameterSetName = "RNA",
            HelpMessage = "Enter a valid RNA class instance.")]
        [Alias("r")]
        public RNA Rna
        {
            set { _rna = value; }
        }
        private RNA _rna;


        [Parameter(Mandatory = true, 
            ValueFromPipeline = true,
            ParameterSetName = "Poly",
            HelpMessage = "Enter a valid Polypeptide class instance.")]
        [Alias("p")]
        public Polypeptide Poly
        {
            set { _poly = value; }
        }
        private Polypeptide _poly;

        protected override void ProcessRecord()
        {
            if(this.ParameterSetName == "DNA")
            {
                WriteObject(new DnaMetadata(_dna));
            }
            else if(this.ParameterSetName == "RNA")
            {
                WriteObject(new RnaMetadata(_rna));
            }
            else
            {
                WriteObject(new PolypeptideMetadata(_poly));
            }



        }
    }
}
