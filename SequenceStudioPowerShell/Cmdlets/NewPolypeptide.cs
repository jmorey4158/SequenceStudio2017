using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.New, "Polypeptide", DefaultParameterSetName = "String")]
    [Alias("newp")]
    public class NewPolyCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "String",
            ValueFromPipeline = true,
            HelpMessage = "Enter a valid Polypeptide sequence, e.g. ACDEFGHIKLMNPQRSTVWY.")]
        [Alias("s")]
        [ValidatePattern("[ACDEFGHIKLMNPQRSTVWY]")]
        public string Strand
        {
            set { _strand = value; }
        }
        private string _strand;


        protected override void ProcessRecord()
        {
            WriteObject(new Polypeptide(_strand));
        }
    }
}
