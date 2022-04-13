using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHIR_json.Models
{
    public class OriginalJson
    {

        //CRLF.cs
        public class CRLF
        {
            public string hospid { get; set; }
            public string id { get; set; }
            public string sex { get; set; }
            public string dbirth { get; set; }
            public string resid { get; set; }
            public string age { get; set; }
            public string sequence { get; set; }
            public string @class { get; set; }
            public string class_d { get; set; }
            public string class_t { get; set; }
            public string dcont { get; set; }
            public string didiag { get; set; }
            public string site { get; set; }
            public string lateral { get; set; }
            public string hist { get; set; }
            public string behavior { get; set; }
            public string grade_c { get; set; }
            public string grade_p { get; set; }
            public string confirm { get; set; }
            public string dmconf { get; set; }
            public string size { get; set; }
            public string pni { get; set; }
            public string lvi { get; set; }
            public string nexam { get; set; }
            public string nposit { get; set; }
            public string dsdiag { get; set; }
            public string sdiag_o { get; set; }
            public string sdiag_h { get; set; }
            public string ct { get; set; }
            public string cn { get; set; }
            public string cm { get; set; }
            public string cstage { get; set; }
            public string cdescr { get; set; }
            public string pt { get; set; }
            public string pn { get; set; }
            public string pm { get; set; }
            public string pstage { get; set; }
            public string pdescr { get; set; }
            public string ajcc_ed { get; set; }
            public string ostage { get; set; }
            public string ostagec { get; set; }
            public string ostagep { get; set; }
            public string dtrt_1st { get; set; }
            public string dop_1st { get; set; }
            public string dop_mds { get; set; }
            public string optype_o { get; set; }
            public string optype_h { get; set; }
            public string misurgery { get; set; }
            public string smargin { get; set; }
            public string smargin_d { get; set; }
            public string opln_o { get; set; }
            public string opln_h { get; set; }
            public string opother_o { get; set; }
            public string opother_h { get; set; }
            public string noop { get; set; }
            public string rtsumm { get; set; }
            public string rtmodal { get; set; }
            public string drt_1st { get; set; }
            public string drt_end { get; set; }
            public string srs { get; set; }
            public string sls { get; set; }
            public string rtstatus { get; set; }
            public string ebrt { get; set; }
            public string rth { get; set; }
            public string rth_dose { get; set; }
            public string rth_nf { get; set; }
            public string rtl { get; set; }
            public string rtl_dose { get; set; }
            public string rtl_nf { get; set; }
            public string ort_modal { get; set; }
            public string ort_tech { get; set; }
            public string ort { get; set; }
            public string ort_dose { get; set; }
            public string ort_nf { get; set; }
            public string dsyt { get; set; }
            public string chem_o { get; set; }
            public string chem_h { get; set; }
            public string dchem { get; set; }
            public string horm_o { get; set; }
            public string horm_h { get; set; }
            public string dhorm { get; set; }
            public string immu_o { get; set; }
            public string immu_h { get; set; }
            public string dimmu { get; set; }
            public string htep_h { get; set; }
            public string dhtep { get; set; }
            public string target_o { get; set; }
            public string target_h { get; set; }
            public string dtarget { get; set; }
            public string palli_h { get; set; }
            public string other { get; set; }
            public string dother { get; set; }
            public string drecur { get; set; }
            public string recur { get; set; }
            public string dlast { get; set; }
            public string vstatus { get; set; }
            public string height { get; set; }
            public string weight { get; set; }
            public string smoking { get; set; }
            public string btchew { get; set; }
            public string drinking { get; set; }
            public string ps { get; set; }
            public string ssf1 { get; set; }
            public string ssf2 { get; set; }
            public string ssf3 { get; set; }
            public string ssf4 { get; set; }
            public string ssf5 { get; set; }
            public string ssf6 { get; set; }
            public string ssf7 { get; set; }
            public string ssf8 { get; set; }
            public string ssf9 { get; set; }
            public string ssf10 { get; set; }
        }
        //LABD.cs
        public class LABD
        {
            [JsonProperty("LABD.h1")]
            public string LABDH1 { get; set; }

            [JsonProperty("LABD.h2")]
            public string LABDH2 { get; set; }

            [JsonProperty("LABD.h3")]
            public string LABDH3 { get; set; }

            [JsonProperty("LABD.h4")]
            public string LABDH4 { get; set; }

            [JsonProperty("LABD.h5")]
            public string LABDH5 { get; set; }

            [JsonProperty("LABD.h6")]
            public string LABDH6 { get; set; }

            [JsonProperty("LABD.h7")]
            public string LABDH7 { get; set; }

            [JsonProperty("LABD.h8")]
            public string LABDH8 { get; set; }

            [JsonProperty("LABD.h9")]
            public string LABDH9 { get; set; }

            [JsonProperty("LABD.h10")]
            public string LABDH10 { get; set; }

            [JsonProperty("LABD.h11")]
            public string LABDH11 { get; set; }

            [JsonProperty("LABD.h12")]
            public string LABDH12 { get; set; }

            [JsonProperty("LABD.h13")]
            public string LABDH13 { get; set; }

            [JsonProperty("LABD.h14")]
            public string LABDH14 { get; set; }

            [JsonProperty("LABD.h15")]
            public string LABDH15 { get; set; }

            [JsonProperty("LABD.h19")]
            public string LABDH19 { get; set; }

            [JsonProperty("LABD.h20")]
            public string LABDH20 { get; set; }

            [JsonProperty("LABD.h22")]
            public string LABDH22 { get; set; }

            [JsonProperty("LABD.r1")]
            public string LABDR1 { get; set; }

            [JsonProperty("LABD.r2")]
            public string LABDR2 { get; set; }

            [JsonProperty("LABD.r3")]
            public string LABDR3 { get; set; }

            [JsonProperty("LABD.r4")]
            public string LABDR4 { get; set; }

            [JsonProperty("LABD.r5")]
            public string LABDR5 { get; set; }

            [JsonProperty("LABD.r6_1")]
            public string LABDR61 { get; set; }

            [JsonProperty("LABD.r6_2")]
            public string LABDR62 { get; set; }

            [JsonProperty("LABD.r7")]
            public string LABDR7 { get; set; }

            [JsonProperty("LABD.r8_1")]
            public string LABDR81 { get; set; }

            [JsonProperty("LABD.r10")]
            public string LABDR10 { get; set; }

            [JsonProperty("LABD.r12")]
            public string LABDR12 { get; set; }

            [JsonProperty("LABD.gender")]
            public string LABDGender { get; set; }
        }
        //LABM.cs
        public class LABM
        {
            [JsonProperty("LABM.h1")]
            public string LABMH1 { get; set; }

            [JsonProperty("LABM.h2")]
            public string LABMH2 { get; set; }

            [JsonProperty("LABM.h3")]
            public string LABMH3 { get; set; }

            [JsonProperty("LABM.h4")]
            public string LABMH4 { get; set; }

            [JsonProperty("LABM.h5")]
            public string LABMH5 { get; set; }

            [JsonProperty("LABM.h6")]
            public string LABMH6 { get; set; }

            [JsonProperty("LABM.h7")]
            public string LABMH7 { get; set; }

            [JsonProperty("LABM.h8")]
            public string LABMH8 { get; set; }

            [JsonProperty("LABM.h9")]
            public string LABMH9 { get; set; }

            [JsonProperty("LABM.h10")]
            public string LABMH10 { get; set; }

            [JsonProperty("LABM.h11")]
            public string LABMH11 { get; set; }

            [JsonProperty("LABM.h12")]
            public string LABMH12 { get; set; }

            [JsonProperty("LABM.h13")]
            public string LABMH13 { get; set; }

            [JsonProperty("LABM.h14")]
            public string LABMH14 { get; set; }

            [JsonProperty("LABM.h17")]
            public string LABMH17 { get; set; }

            [JsonProperty("LABM.h18")]
            public string LABMH18 { get; set; }

            [JsonProperty("LABM.h22")]
            public string LABMH22 { get; set; }

            [JsonProperty("LABM.h23")]
            public string LABMH23 { get; set; }

            [JsonProperty("LABM.h25")]
            public string LABMH25 { get; set; }

            [JsonProperty("LABM.r1")]
            public string LABMR1 { get; set; }

            [JsonProperty("LABM.r2")]
            public string LABMR2 { get; set; }

            [JsonProperty("LABM.r3")]
            public string LABMR3 { get; set; }

            [JsonProperty("LABM.r4")]
            public string LABMR4 { get; set; }

            [JsonProperty("LABM.r5")]
            public string LABMR5 { get; set; }

            [JsonProperty("LABM.r6_1")]
            public string LABMR61 { get; set; }

            [JsonProperty("LABM.r6_2")]
            public string LABMR62 { get; set; }

            [JsonProperty("LABM.r7")]
            public string LABMR7 { get; set; }

            [JsonProperty("LABM.r8_1")]
            public string LABMR81 { get; set; }

            [JsonProperty("LABM.r10")]
            public string LABMR10 { get; set; }

            [JsonProperty("LABM.r12")]
            public string LABMR12 { get; set; }

            [JsonProperty("LABM.gender")]
            public string LABMGender { get; set; }
        }
        //spe.cs
        public class spe
        {
            public int biobankid { get; set; }
            public string speid { get; set; }
            public string indate { get; set; }
            public string agreedate { get; set; }
            public string takedate { get; set; }
            public string specategory { get; set; }
            public int tube { get; set; }
            public string practitioner { get; set; }
            public string org { get; set; }
            public string gender { get; set; }
            public int age { get; set; }
            public double heigh { get; set; }
            public double weight { get; set; }
            public string diseasecategory { get; set; }
        }
        //TOTFA.cs
        public class TOTFA
        {
            [JsonProperty("TOTFA.t2")]
            public int TOTFAT2 { get; set; }

            [JsonProperty("TOTFA.t3")]
            public string TOTFAT3 { get; set; }

            [JsonProperty("TOTFA.t5")]
            public int TOTFAT5 { get; set; }

            [JsonProperty("TOTFA.t6")]
            public string TOTFAT6 { get; set; }

            [JsonProperty("TOTFA.d1")]
            public int TOTFAD1 { get; set; }

            [JsonProperty("TOTFA.d2")]
            public int TOTFAD2 { get; set; }

            [JsonProperty("TOTFA.d4")]
            public string TOTFAD4 { get; set; }

            [JsonProperty("TOTFA.d5")]
            public string TOTFAD5 { get; set; }

            [JsonProperty("TOTFA.d6")]
            public string TOTFAD6 { get; set; }

            [JsonProperty("TOTFA.d7")]
            public string TOTFAD7 { get; set; }

            [JsonProperty("TOTFA.d8")]
            public int TOTFAD8 { get; set; }

            [JsonProperty("TOTFA.d9")]
            public string TOTFAD9 { get; set; }

            [JsonProperty("TOTFA.d10")]
            public string TOTFAD10 { get; set; }

            [JsonProperty("TOTFA.d11")]
            public string TOTFAD11 { get; set; }

            [JsonProperty("TOTFA.d3")]
            public string TOTFAD3 { get; set; }

            [JsonProperty("TOTFA.d19")]
            public string TOTFAD19 { get; set; }

            [JsonProperty("TOTFA.d20")]
            public string TOTFAD20 { get; set; }

            [JsonProperty("TOTFA.d21")]
            public string TOTFAD21 { get; set; }

            [JsonProperty("TOTFA.d22")]
            public string TOTFAD22 { get; set; }

            [JsonProperty("TOTFA.d23")]
            public string TOTFAD23 { get; set; }

            [JsonProperty("TOTFA.d24")]
            public string TOTFAD24 { get; set; }

            [JsonProperty("TOTFA.d25")]
            public string TOTFAD25 { get; set; }

            [JsonProperty("TOTFA.d26")]
            public string TOTFAD26 { get; set; }

            [JsonProperty("TOTFA.d27")]
            public int? TOTFAD27 { get; set; }

            [JsonProperty("TOTFA.d28")]
            public int TOTFAD28 { get; set; }

            [JsonProperty("TOTFA.gender")]
            public int TOTFAGender { get; set; }

            [JsonProperty("TOTFA.p1")]
            public int TOTFAP1 { get; set; }

            [JsonProperty("TOTFA.p2")]
            public int? TOTFAP2 { get; set; }

            [JsonProperty("TOTFA.p3")]
            public int TOTFAP3 { get; set; }

            [JsonProperty("TOTFA.p4")]
            public string TOTFAP4 { get; set; }

            [JsonProperty("TOTFA.p5")]
            public int? TOTFAP5 { get; set; }

            [JsonProperty("TOTFA.p6")]
            public string TOTFAP6 { get; set; }

            [JsonProperty("TOTFA.p7")]
            public string TOTFAP7 { get; set; }

            [JsonProperty("TOTFA.p9")]
            public string TOTFAP9 { get; set; }

            [JsonProperty("TOTFA.p10")]
            public int TOTFAP10 { get; set; }

            [JsonProperty("TOTFA.p13")]
            public int TOTFAP13 { get; set; }

            [JsonProperty("TOTFA.p14")]
            public string TOTFAP14 { get; set; }

            [JsonProperty("TOTFA.p15")]
            public string TOTFAP15 { get; set; }

            [JsonProperty("TOTFA.p17")]
            public string TOTFAP17 { get; set; }
        }
        //TOTFB.cs
        public class TOTFB
        {
            [JsonProperty("TOTFB.t2")]
            public int TOTFBT2 { get; set; }

            [JsonProperty("TOTFB.t3")]
            public string TOTFBT3 { get; set; }

            [JsonProperty("TOTFB.t5")]
            public int TOTFBT5 { get; set; }

            [JsonProperty("TOTFB.t6")]
            public string TOTFBT6 { get; set; }

            [JsonProperty("TOTFB.d1")]
            public int TOTFBD1 { get; set; }

            [JsonProperty("TOTFB.d2")]
            public int TOTFBD2 { get; set; }

            [JsonProperty("TOTFB.d3")]
            public string TOTFBD3 { get; set; }

            [JsonProperty("TOTFB.d6")]
            public string TOTFBD6 { get; set; }

            [JsonProperty("TOTFB.d9")]
            public string TOTFBD9 { get; set; }

            [JsonProperty("TOTFB.d10")]
            public string TOTFBD10 { get; set; }

            [JsonProperty("TOTFB.d11")]
            public string TOTFBD11 { get; set; }

            [JsonProperty("TOTFB.d14")]
            public int TOTFBD14 { get; set; }

            [JsonProperty("TOTFB.d15")]
            public string TOTFBD15 { get; set; }

            [JsonProperty("TOTFB.d18")]
            public string TOTFBD18 { get; set; }

            [JsonProperty("TOTFB.d21")]
            public string TOTFBD21 { get; set; }

            [JsonProperty("TOTFB.d24")]
            public string TOTFBD24 { get; set; }

            [JsonProperty("TOTFB.d25")]
            public string TOTFBD25 { get; set; }

            [JsonProperty("TOTFB.d26")]
            public string TOTFBD26 { get; set; }

            [JsonProperty("TOTFB.d27")]
            public string TOTFBD27 { get; set; }

            [JsonProperty("TOTFB.d28")]
            public string TOTFBD28 { get; set; }

            [JsonProperty("TOTFB.d29")]
            public string TOTFBD29 { get; set; }

            [JsonProperty("TOTFB.d45")]
            public string TOTFBD45 { get; set; }

            [JsonProperty("TOTFB.d46")]
            public string TOTFBD46 { get; set; }

            [JsonProperty("TOTFB.d47")]
            public string TOTFBD47 { get; set; }

            [JsonProperty("TOTFB.d48")]
            public string TOTFBD48 { get; set; }

            [JsonProperty("TOTFB.d49")]
            public string TOTFBD49 { get; set; }

            [JsonProperty("TOTFB.gender")]
            public string TOTFBGender { get; set; }

            [JsonProperty("TOTFB.p1")]
            public int TOTFBP1 { get; set; }

            [JsonProperty("TOTFB.p2")]
            public string TOTFBP2 { get; set; }

            [JsonProperty("TOTFB.p3")]
            public string TOTFBP3 { get; set; }

            [JsonProperty("TOTFB.p5")]
            public double? TOTFBP5 { get; set; }

            [JsonProperty("TOTFB.p6")]
            public string TOTFBP6 { get; set; }

            [JsonProperty("TOTFB.p7")]
            public string TOTFBP7 { get; set; }

            [JsonProperty("TOTFB.p8")]
            public string TOTFBP8 { get; set; }

            [JsonProperty("TOTFB.p14")]
            public string TOTFBP14 { get; set; }

            [JsonProperty("TOTFB.p15")]
            public string TOTFBP15 { get; set; }

            [JsonProperty("TOTFB.p16")]
            public int TOTFBP16 { get; set; }
        }
    }
}