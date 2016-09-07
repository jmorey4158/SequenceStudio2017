using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.New, "DnaMetadata", 
        DefaultParameterSetName = "DNA")]
    [Alias("newdm")]
    public class NewDnaMetadataCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, 
            ParameterSetName = "DNA",
            ValueFromPipeline = true,
            HelpMessage = "Enter a valid DNA class instance.")]
        [Alias("d")]
        public DNA Dna
        {
            set { __dna = value; }
        }
        private DNA __dna;


        protected override void ProcessRecord()
        {
            WriteObject(new DnaMetadata(__dna));
        }
    }
}
