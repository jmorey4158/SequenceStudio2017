using System.Management.Automation;
using SequenceStudio;

namespace SequenceStudioPowerShell
{
    [Cmdlet(VerbsCommon.Get, "MolecularWeight")]
    [Alias("gwm")]
    public class GetMolWeightCmdlet : PSCmdlet
    {

        private ISequence _Iseq;

        [Parameter(Mandatory = true, ParameterSetName = "DNA",
            ValueFromPipeline = true,
            HelpMessage = "Provide a valid DNA class instance.")]
        public DNA Dna
        {
            set { _Iseq = value; }
        }


        [Parameter(Mandatory = true, ParameterSetName = "RNA",
            ValueFromPipeline = true,
            HelpMessage = "Provide a valid RNA class instance.")]
        public RNA Rna
        {
            set { _Iseq = value; }
        }

        [Parameter(Mandatory = true, ParameterSetName = "Poly",
            ValueFromPipeline = true,
            HelpMessage = "Provide a valid Polypeptide class instance.")]
        public Polypeptide Poly
        {
            set { _Iseq = value; }
        }

        [Parameter(Mandatory = true, ParameterSetName = "Strand",
            ValueFromPipeline = true,
            HelpMessage = "Provide a valid DNA, RNA, or Polypeptide sequence.")]
        public string Strand
        {
            set { _strand = value; }
        }
        private string _strand;

        [Parameter(Mandatory = true, ParameterSetName = "Strand",
            ValueFromPipeline = true,
            HelpMessage = "Provide a valid Sequence Type ('DNA', 'RNA', or 'Poly'.")]
        [ValidateSet("DNA", "RNA", "Poly")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _type;


        protected override void ProcessRecord()
        {
            if (this.ParameterSetName == "Strand")
            {

                switch (Type)
                {
                    case "DNA":
                        if (SequenceMethods.ValidateSequence(_strand, SequenceEnums.SequenceType.DNA))
                        {
                            WriteObject(new DNA(_strand));
                        }
                        else
                        {
                            // WriteError();
                        }
                        break;

                    case "RNA":
                        if (SequenceMethods.ValidateSequence(_strand, SequenceEnums.SequenceType.RNA))
                        {
                            WriteObject(new RNA(_strand));
                        }
                        else
                        {
                            // WriteError();
                        }
                        break;

                    default:
                        // WriteError();
                        break;
                }
            }
            else
            {
                WriteObject(SequenceMethods.GetMolecularWeight(_Iseq));
            }

        }
    }
}
