using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.New, "RnaMetadata",
        DefaultParameterSetName = "DNA")]
    [Alias("newrm")]
    public class NewRnaMetadataCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true,
            ParameterSetName = "RNA",
            ValueFromPipeline = true,
            HelpMessage = "Enter a valid RNA class instance.")]
        [Alias("r")]
        public RNA Dna
        {
            set { _rna = value; }
        }
        private RNA _rna;


        protected override void ProcessRecord()
        {
            WriteObject(new RnaMetadata(_rna));
        }
    }
}
