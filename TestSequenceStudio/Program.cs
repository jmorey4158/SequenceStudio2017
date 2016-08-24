using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SequenceStudio;

namespace TestSequenceStudio
{
    class Program
    {

        private const string pass = "ACDEFGHIKLMNPQRSTVWY"; // Well-formed RNA sequence - should pass
        static void Main(string[] args)
        {
            var pass = SequenceMethods.CreateSequence(Program.pass,
                SequenceEnums.SequenceType.Polypeptide, SequenceEnums.SequenceOriginType.Manual);

            Console.WriteLine($"Strand: {pass.Strand}\nStrandLength: {pass.Strand.Length} \nHash: {pass.StrandHash}\nSequenceType: {pass.SequenceType} \nSequenceOrigin: {pass.SequenceOriginType}");

            Console.ReadKey();
        }

    }

    public class PastCode
    {

            //var p = new EventPublisher();

            //p.NcbiFetchStarted += (sender, e) => Console.WriteLine(
            //    string.Format("Sender: {0} sent message details:\nMessage: {1}\nSource: {2}\nMethod: {3}\n"
            //    , sender, e.Message, e.Source, e.MethodName));

            //var qGood = new EFetchQuery(NcbiEnums.Databases.Nucleotide,
            //    new List<int>() { 1107, 181, 11098 },
            //    NcbiEnums.EFetchRetTypeMode.TinySeqFastA);
            //var qlist = new List<EFetchQuery>() { qGood };
            //var r = NcbiMethods.GetEFetchResults(qGood).Result;




        //var result =  EndToEndNcbi.GetNcbiEndToEnd(
        //    NcbiEnums.Databases.Nucleotide, "human[organism] insulin");


        //var result2 = NcbiMethods.NcbiEndToEnd(
        //    NcbiEnums.Databases.Nucleotide, "human[organism] hemoglobin", 
        //    NcbiEnums.Fields.EMPTY, NcbiEnums.RetMode.Xml, NcbiEnums.ESearchRetType.eUtility,5, 0).Result;



        //var qBad = new EFetchQuery(NcbiEnums.Databases.Nucleotide,
        //    new List<int>() { 117, 166, 127, 118, 179, 118 },
        //    NcbiEnums.EFetchRetTypeMode.TinySeqFastA);
        //var qlist = new List<EFetchQuery>() { qGood, qBad };



        //var qGood = new EFetchQuery(NcbiEnums.Databases.Nucleotide,
        //    new List<int>() { 1107, 181, 11098 },
        //    NcbiEnums.EFetchRetTypeMode.TinySeqFastA);
        //var qlist = new List<EFetchQuery>() { qGood };
        //var r = NcbiMethods.GetEFetchResults(qGood).Result;
        //var result1 = SequenceMethods.AddNcbiSequencesToDb(r).Result;



        //var qGood = new EFetchQuery(NcbiEnums.Databases.Nucleotide,
        //    new List<int>() { 1807, 781, 5098, 21 },
        //    NcbiEnums.EFetchRetTypeMode.TinySeqFastA);
        //var qlist = new List<EFetchQuery>() { qGood };
        //var r = NcbiMethods.GetEFetchResults(qGood).Result;
        //var result1 = SequenceMethods.AddNcbiSequencesToDb(r).Result;


    }
}
