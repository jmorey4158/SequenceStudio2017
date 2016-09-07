using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.New, "PolyMetadata",
        DefaultParameterSetName = "Poly")]
    [Alias("newpm")]
    public class NewPolyMetadataCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true,
            ParameterSetName = "Poly",
            ValueFromPipeline = true,
            HelpMessage = "Enter a valid Polypeptide class instance.")]
        [Alias("r")]
        public Polypeptide Dna
        {
            set { _poly = value; }
        }
        private Polypeptide _poly;


        protected override void ProcessRecord()
        {
            WriteObject(new PolypeptideMetadata(_poly));
        }
    }
}
