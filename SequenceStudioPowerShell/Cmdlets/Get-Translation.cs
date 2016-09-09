using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.Get, "Translation")]
    public class GetTranslationCmdlet : PSCmdlet
    {
        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "Strand",
            HelpMessage = "Provide a valid RNA sequence string.")]
        [Alias("s")]
        [ValidatePattern("[ACGU]")]
        public string Strand
        {
            set { _strand = value; }
        }
        private string _strand;



        [Parameter(Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "RNA",
            HelpMessage = "Provide a valid RNA class instance.")]
        [Alias("r")]
        public RNA Rna
        {
            set { _rna = value; }
        }
        private RNA _rna;


        protected override void ProcessRecord()
        {
           if(this.ParameterSetName == "Strand")
            {
                if(SequenceMethods.ValidateSequence(_strand, SequenceEnums.SequenceType.RNA))
                {
                    WriteObject(SequenceMethods.GetTranslation(new RNA(_strand)));
                }
            }
            else
            {
                WriteObject(SequenceMethods.GetTranslation(_rna));
            }
        }
    }
}
