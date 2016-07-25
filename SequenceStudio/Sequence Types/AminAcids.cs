using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public class AminoAcids
    {
        #region Base Class
        public  class AminoAcidBase
        {
            protected AminoAcidBase()
            {
                LongName = "AminoAcidBase";
                ShortName = "*";
                Initial = "*";
                MolecularWeight = 0;
                Codons = new string[] { "" };
            }

            public string LongName { get; protected set; }

            public string ShortName { get; protected set; }

            public string Initial { get; protected set; }

            public double MolecularWeight { get; protected set; }

            public string[] Codons { get; protected set; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Long Name: " + LongName.ToString() + "\n");
                sb.Append("Short Name: " + ShortName.ToString() + "\n");
                sb.Append("Initial: " + Initial.ToString() + "\n");
                sb.Append("Molecular Weight: " + MolecularWeight.ToString() + "\n");
                sb.Append("Codons: ");
                foreach (string s in Codons)
                {
                    sb.Append(s + " ");
                }
                return sb.ToString();
            }

        }
        #endregion


        #region Amino Acid Classes

        public class Alanine : AminoAcidBase
        {
            public Alanine()
            {
                LongName = "Alanine";
                ShortName = "Ala";
                Initial = "A";
                MolecularWeight = 89.09404;
                Codons = new String[] { "GCU", "GCC", "GCA", "GCG" };
            }
        }

        public class Asparagine : AminoAcidBase
        {
            public Asparagine()
            {
                LongName = "Asparagine";
                ShortName = "Asn";
                Initial = "N";
                MolecularWeight = 132.11904;
                Codons = new String[] { "GAU", "GAC" };
            }
        }

        public class Cysteine : AminoAcidBase
        {
            public Cysteine()
            {
                LongName = "Cysteine";
                ShortName = "Cys";
                Initial = "C";
                MolecularWeight = 121.15404;
                Codons = new String[] { "UGU", "UGC" };
            }
        }

        public class AsparticAcid : AminoAcidBase
        {
            public AsparticAcid()
            {
                LongName = "AsparticAcid";
                ShortName = "Asp";
                Initial = "D";
                MolecularWeight = 133.10384;
                Codons = new String[] { "GAU", "GAC" };
            }
        }

        public class GlutamicAcid : AminoAcidBase
        {
            public GlutamicAcid()
            {
                LongName = "GlutamicAcid";
                ShortName = "Glu";
                Initial = "E";
                MolecularWeight = 147.13074;
                Codons = new String[] { "GAA", "GAG" };
            }
        }

        public class Phenylalanine : AminoAcidBase
        {
            public Phenylalanine()
            {
                LongName = "Phenylalanine";
                ShortName = "Phe";
                Initial = "F";
                MolecularWeight = 165.19184;
                Codons = new String[] { "UUU", "UUC" };
            }
        }

        public class Glycine : AminoAcidBase
        {
            public Glycine()
            {
                LongName = "Glycine";
                ShortName = "Gly";
                Initial = "G";
                MolecularWeight = 75.06714;
                Codons = new String[] { "GGU", "GGC", "GGA", "GGG" };
            }
        }

        public class Histidine : AminoAcidBase
        {
            public Histidine()
            {
                LongName = "Histidine";
                ShortName = "His";
                Initial = "H";
                MolecularWeight = 155.15634;
                Codons = new String[] { "CAU", "CAC" };
            }
        }

        public class Isoleucine : AminoAcidBase
        {
            public Isoleucine()
            {
                LongName = "Isoleucine";
                ShortName = "Ile";
                Initial = "I";
                MolecularWeight = 131.17464;
                Codons = new String[] { "AUU", "AUC", "AUA" };
            }
        }

        public class Lysine : AminoAcidBase
        {
            public Lysine()
            {
                LongName = "Lysine";
                ShortName = "Lys";
                Initial = "K";
                MolecularWeight = 146.18934;
                Codons = new String[] { "AAA", "AAG" };
            }
        }

        public class Leucine : AminoAcidBase
        {
            public Leucine()
            {
                LongName = "Leucine";
                ShortName = "Leu";
                Initial = "L";
                MolecularWeight = 131.17464;
                Codons = new String[] { "UUA", "UUG", "CUU", "CUC", "CUA", "CUG" };
            }
        }

        public class Methionine : AminoAcidBase
        {
            public Methionine()
            {
                LongName = "Methionine";
                ShortName = "Met";
                Initial = "M";
                MolecularWeight = 149.20784;
                Codons = new String[] { "AUG" };
            }
        }

        public class Proline : AminoAcidBase
        {
            public Proline()
            {
                LongName = "Proline";
                ShortName = "Pro";
                Initial = "P";
                MolecularWeight = 132.11904;
                Codons = new String[] { "CCU", "CCC", "CCA", "CCG" };
            }
        }

        public class Glutamine : AminoAcidBase
        {
            public Glutamine()
            {
                LongName = "Glutamine";
                ShortName = "Gln";
                Initial = "Q";
                MolecularWeight = 146.14594;
                Codons = new String[] { "GAA", "GAG" };
            }
        }

        public class Arginine : AminoAcidBase
        {
            public Arginine()
            {
                LongName = "Arginine";
                ShortName = "Arg";
                Initial = "R";
                MolecularWeight = 174.20274;
                Codons = new String[] { "CGU", "CGC", "CGA", "CGG", "AGA", "AGG" };
            }
        }

        public class Serine : AminoAcidBase
        {
            public Serine()
            {
                LongName = "Serine";
                ShortName = "Ser";
                Initial = "S";
                MolecularWeight = 105.09344;
                Codons = new String[] { "UCU", "UCC", "UCA", "UCG", "AGU", "AGC" };
            }
        }

        public class Threonine : AminoAcidBase
        {
            public Threonine()
            {
                LongName = "Threonine";
                ShortName = "Thr";
                Initial = "T";
                MolecularWeight = 119.12034;
                Codons = new String[] { "ACU", "ACC", "ACA", "ACG" };
            }
        }

        public class Valine : AminoAcidBase
        {
            public Valine()
            {
                LongName = "Valine";
                ShortName = "Val";
                Initial = "V";
                MolecularWeight = 117.14784;
                Codons = new String[] { "GUU", "GUC", "GUA", "GUG" };
            }
        }

        public class Tryptophan : AminoAcidBase
        {
            public Tryptophan()
            {
                LongName = "Tryptophan";
                ShortName = "Trp";
                Initial = "W";
                MolecularWeight = 204.22844;
                Codons = new String[] { "UGG" };
            }
        }

        public class Tyrosine : AminoAcidBase
        {
            public Tyrosine()
            {
                LongName = "Tyrosine";
                ShortName = "Tyr";
                Initial = "Y";
                MolecularWeight = 181.19124;
                Codons = new String[] { "UAU", "UAC" };
            }
        }

        public class Stop : AminoAcidBase
        {
            public Stop()
            {
                LongName = "Stop";
                ShortName = "Stop";
                Initial = "^";
                MolecularWeight = 0;
                Codons = new String[] { "UAA", "UAG" };
            }
        }

        #endregion


        #region Methods
        /// <summary>
        /// Creates a set of Amino ACid class instances for use in other methods and classes
        /// </summary>
        public static void InitAminoAcids()
        {
            Alanine ala = new Alanine();
            Arginine arg = new Arginine();
            Asparagine asn = new Asparagine();
            AsparticAcid asp = new AsparticAcid();
            Cysteine cys = new Cysteine();

            GlutamicAcid glu = new GlutamicAcid();
            Glutamine gln = new Glutamine();
            Glycine gly = new Glycine();
            Histidine his = new Histidine();
            Isoleucine ile = new Isoleucine();

            Leucine leu = new Leucine();
            Lysine lys = new Lysine();
            Methionine met = new Methionine();
            Phenylalanine phe = new Phenylalanine();
            Proline pro = new Proline();

            Serine ser = new Serine();
            Threonine thr = new Threonine();
            Tryptophan trp = new Tryptophan();
            Tyrosine tyr = new Tyrosine();
            Valine val = new Valine();
        }


        public static Dictionary<string, decimal> AminoMolecularWeights()
        {
            List<AminoAcidBase> aa = GetAminoAcidList();
            Dictionary<string, decimal> list = new Dictionary<string, decimal>();

            foreach (var a in aa)
            {
                list.Add(a.Initial, (decimal)a.MolecularWeight);
            }

            return list;
        }


        /// <summary>
        /// Returns a List(AminoAcidBase) of all the Amino Acid classes instances
        /// </summary>
        public static List<AminoAcidBase> GetAminoAcidList()
        {
            List<AminoAcidBase> aminoList = new List<AminoAcidBase>();

            aminoList.Add(new Alanine());
            aminoList.Add(new Arginine());
            aminoList.Add(new Asparagine());
            aminoList.Add(new AsparticAcid());
            aminoList.Add(new Cysteine());
            aminoList.Add(new GlutamicAcid());
            aminoList.Add(new Glutamine());
            aminoList.Add(new Glycine());
            aminoList.Add(new Histidine());
            aminoList.Add(new Isoleucine());

            aminoList.Add(new Leucine());
            aminoList.Add(new Lysine());
            aminoList.Add(new Methionine());
            aminoList.Add(new Phenylalanine());
            aminoList.Add(new Proline());

            aminoList.Add(new Serine());
            aminoList.Add(new Threonine());
            aminoList.Add(new Tryptophan());
            aminoList.Add(new Tyrosine());
            aminoList.Add(new Valine());

            return aminoList;
        }


        /// <summary>
        /// Returns the CodonMatrix, a
        /// list (of Tuple(string,string)) of all the codons for all amino acids
        /// </summary>
        /// <returns>List(Typle(string,string)) - the CodonMatrix</returns>
        public static List<Tuple<string, string>> GetCodonMatixTuple()
        {
            List<AminoAcidBase> la = GetAminoAcidList();
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            int i = 1;

            foreach (AminoAcidBase b in la)
            {
                string a = b.Initial;
                i = 1;
                foreach (string c in b.Codons)
                {
                    list.Add(Tuple.Create(a + i.ToString(), c.Replace("U", "T")));
                    i++;
                }
            }
            return list;
        }


        /// <summary>
        /// Returns the CodonMatrix, a
        /// Dictionary(string,string) of all the codons for all amino acids
        /// </summary>
        /// <returns>Dictionary(string,string) - the CodonMatrix</returns>
        public static Dictionary<string, string> GetCodonMatrix()
        {
            int i = 1;
            List<AminoAcidBase> la = GetAminoAcidList();
            Dictionary<string, string> list = new Dictionary<string, string>();

            foreach (AminoAcidBase b in la)
            {
                string a = b.Initial;
                i = 1;
                foreach (string c in b.Codons)
                {
                    list.Add(a + i.ToString(), c.Replace("U", "T"));
                    i++;
                }
            }
            return list;
        }
        #endregion
    }

}
