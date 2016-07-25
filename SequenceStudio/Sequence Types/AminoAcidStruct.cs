using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public struct Alanine
    {
        public const string LongName = "Alanine";
        public const string ShortName = "Ala";
        public const string Initial = "A";
        public const double MolecularWeight = 89.09404;
        public static readonly string[] Codons = { "GCU", "GCC", "GCA", "GCG" };
    }

    public struct Asparagine
    {
        public const string LongName = "Asparagine";
        public const string ShortName = "Asn";
        public const string Initial = "N";
        public const double MolecularWeight = 132.11904;
        public static readonly string[] Codons = { "GAU", "GAC" };
    }

    public struct Cysteine
    {
        public const string LongName = "Cysteine";
        public const string ShortName = "Cys";
        public const string Initial = "C";
        public const double MolecularWeight = 121.15404;
        public static readonly string[] Codons = { "UGU", "UGC" };
    }

    public struct AsparticAcid
    {
        public const string LongName = "AsparticAcid";
        public const string ShortName = "Asp";
        public const string Initial = "D";
        public const double MolecularWeight = 133.10384;
        public static readonly string[] Codons = { "GAU", "GAC" };
    }

    public struct GlutamicAcid
    {
        public const string LongName = "GlutamicAcid";
        public const string ShortName = "Glu";
        public const string Initial = "E";
        public const double MolecularWeight = 147.13074;
        public static readonly string[] Codons = { "GAA", "GAG" };
    }

    public struct Phenylalanine
    {
        public const string LongName = "Phenylalanine";
        public const string ShortName = "Phe";
        public const string Initial = "F";
        public const double MolecularWeight = 165.19184;
        public static readonly string[] Codons = { "UUU", "UUC" };
    }

    public struct Glycine
    {
        public const string LongName = "Glycine";
        public const string ShortName = "Gly";
        public const string Initial = "G";
        public const double MolecularWeight = 75.06714;
        public static readonly string[] Codons = { "GGU", "GGC", "GGA", "GGG" };
    }

    public struct Histidine
    {
        public const string LongName = "Histidine";
        public const string ShortName = "His";
        public const string Initial = "H";
        public const double MolecularWeight = 155.15634;
        public static readonly string[] Codons = { "CAU", "CAC" };
    }

    public struct Isoleucine
    {
        public const string LongName = "Isoleucine";
        public const string ShortName = "Ile";
        public const string Initial = "I";
        public const double MolecularWeight = 131.17464;
        public static readonly string[] Codons = { "AUU", "AUC", "AUA" };
    }

    public struct Lysine
    {
        public const string LongName = "Lysine";
        public const string ShortName = "Lys";
        public const string Initial = "K";
        public const double MolecularWeight = 146.18934;
        public static readonly string[] Codons = { "AAA", "AAG" };
    }

    public struct Leucine
    {
        public const string LongName = "Leucine";
        public const string ShortName = "Leu";
        public const string Initial = "L";
        public const double MolecularWeight = 131.17464;
        public static readonly string[] Codons = { "UUA", "UUG", "CUU", "CUC", "CUA", "CUG" };
    }

    public struct Methionine
    {
        public const string LongName = "Methionine";
        public const string ShortName = "Met";
        public const string Initial = "M";
        public const double MolecularWeight = 149.20784;
        public static readonly string[] Codons = { "AUG" };
    }

    public struct Proline
    {
        public const string LongName = "Proline";
        public const string ShortName = "Pro";
        public const string Initial = "P";
        public const double MolecularWeight = 132.11904;
        public static readonly string[] Codons = { "CCU", "CCC", "CCA", "CCG" };
    }

    public struct Glutamine
    {
        public const string LongName = "Glutamine";
        public const string ShortName = "Glu";
        public const string Initial = "Q";
        public const double MolecularWeight = 146.14594;
        public static readonly string[] Codons = { "GAA", "GAG" };
    }

    public struct Arginine
    {
        public const string LongName = "Arginine";
        public const string ShortName = "Arg";
        public const string Initial = "R";
        public const double MolecularWeight = 174.20274;
        public static readonly string[] Codons = { "CGU", "CGC", "CGA", "CGG", "AGA", "AGG" };
    }

    public struct Serine
    {
        public const string LongName = "Serine";
        public const string ShortName = "Ser";
        public const string Initial = "S";
        public const double MolecularWeight = 105.09344;
        public static readonly string[] Codons = { "UCU", "UCC", "UCA", "UCG", "AGU", "AGC" };
    }

    public struct Threonine
    {
        public const string LongName = "Threonine";
        public const string ShortName = "Thr";
        public const string Initial = "T";
        public const double MolecularWeight = 119.12034;
        public static readonly string[] Codons = { "ACU", "ACC", "ACA", "ACG" };
    }

    public struct Valine
    {
        public const string LongName = "Valine";
        public const string ShortName = "Val";
        public const string Initial = "V";
        public const double MolecularWeight = 117.14784;
        public static readonly string[] Codons = { "GUU", "GUC", "GUA", "GUG" };
    }

    public struct Tryptophan
    {
        public const string LongName = "Tryptophan";
        public const string ShortName = "Trp";
        public const string Initial = "W";
        public const double MolecularWeight = 204.22844;
        public static readonly string[] Codons = { "UGG" };
    }

    public struct Tyrosine
    {
        public const string LongName = "Tyrosine";
        public const string ShortName = "Tyr";
        public const string Initial = "Y";
        public const double MolecularWeight = 181.19124;
        public static readonly string[] Codons = { "UAU", "UAC" };
    }

    public struct Stop
    {
        public const string LongName = "Stop";
        public const string ShortName = "Stop";
        public const string Initial = "^";
        public const double MolecularWeight = 0;
        public static readonly string[] Codons = { "UAA", "UAG" };
    }















}