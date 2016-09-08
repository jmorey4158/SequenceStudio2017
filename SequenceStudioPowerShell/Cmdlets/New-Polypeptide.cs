using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.New, "Polypeptide")]
    public class NewPolyCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true,
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
