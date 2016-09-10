using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.Get, "CodonCount")]
    public class GetCodonCountCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "Provide a valid SequenceStudio.DNA class instance.")]
        [Alias("d")]
        public DNA Dna
        {
            set { _dna = value; }
        }
        private DNA _dna;


        protected override void ProcessRecord()
        {
            WriteObject(SequenceMethods.CodonCount(_dna));
        }
    }
}
