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
            [JsonProperty("CRLF_hospid")]
            public string hospid { get; set; }
            [JsonProperty("CRLF_id")]
            public string id { get; set; }
            [JsonProperty("CRLF_sex")]
            public string sex { get; set; }
            [JsonProperty("CRLF_dbirth")]
            public string dbirth { get; set; }
            [JsonProperty("CRLF_resid")]
            public string resid { get; set; }
            [JsonProperty("CRLF_age")]
            public string age { get; set; }
            [JsonProperty("CRLF_sequence")]
            public string sequence { get; set; }
            [JsonProperty("CRLF_class")]
            public string @class { get; set; }
            [JsonProperty("CRLF_class_d")]
            public string class_d { get; set; }
            [JsonProperty("CRLF_class_t")]
            public string class_t { get; set; }
            [JsonProperty("CRLF_dcont")]
            public string dcont { get; set; }
            [JsonProperty("CRLF_didiag")]
            public string didiag { get; set; }
            [JsonProperty("CRLF_site")]
            public string site { get; set; }
            [JsonProperty("CRLF_lateral")]
            public string lateral { get; set; }
            [JsonProperty("CRLF_hist")]
            public string hist { get; set; }
            [JsonProperty("CRLF_behavior")]
            public string behavior { get; set; }
            [JsonProperty("CRLF_grade_c")]
            public string grade_c { get; set; }
            [JsonProperty("CRLF_grade_p")]
            public string grade_p { get; set; }
            [JsonProperty("CRLF_confirm")]
            public string confirm { get; set; }
            [JsonProperty("CRLF_dmconf")]
            public string dmconf { get; set; }
            [JsonProperty("CRLF_size")]
            public string size { get; set; }
            [JsonProperty("CRLF_pni")]
            public string pni { get; set; }
            [JsonProperty("CRLF_lvi")]
            public string lvi { get; set; }
            [JsonProperty("CRLF_nexam")]
            public string nexam { get; set; }
            [JsonProperty("CRLF_nposit")]
            public string nposit { get; set; }
            [JsonProperty("CRLF_dsdiag")]
            public string dsdiag { get; set; }
            [JsonProperty("CRLF_sdiag_o")]
            public string sdiag_o { get; set; }
            [JsonProperty("CRLF_sdiag_h")]
            public string sdiag_h { get; set; }
            [JsonProperty("CRLF_ct")]
            public string ct { get; set; }
            [JsonProperty("CRLF_cn")]
            public string cn { get; set; }
            [JsonProperty("CRLF_cm")]
            public string cm { get; set; }
            [JsonProperty("CRLF_cstage")]
            public string cstage { get; set; }
            [JsonProperty("CRLF_cdescr")]
            public string cdescr { get; set; }
            [JsonProperty("CRLF_pt")]
            public string pt { get; set; }
            [JsonProperty("CRLF_pn")]
            public string pn { get; set; }
            [JsonProperty("CRLF_pm")]
            public string pm { get; set; }
            [JsonProperty("CRLF_pstage")]
            public string pstage { get; set; }
            [JsonProperty("CRLF_pdescr")]
            public string pdescr { get; set; }
            [JsonProperty("CRLF_ajcc_ed")]
            public string ajcc_ed { get; set; }
            [JsonProperty("CRLF_ostage")]
            public string ostage { get; set; }
            [JsonProperty("CRLF_ostagec")]
            public string ostagec { get; set; }
            [JsonProperty("CRLF_ostagep")]
            public string ostagep { get; set; }
            [JsonProperty("CRLF_dtrt_1st")]
            public string dtrt_1st { get; set; }
            [JsonProperty("CRLF_dop_1st")]
            public string dop_1st { get; set; }
            [JsonProperty("CRLF_dop_mds")]
            public string dop_mds { get; set; }
            [JsonProperty("CRLF_optype_o")]
            public string optype_o { get; set; }
            [JsonProperty("CRLF_optype_h")]
            public string optype_h { get; set; }
            [JsonProperty("CRLF_misurgery")]
            public string misurgery { get; set; }
            [JsonProperty("CRLF_smargin")]
            public string smargin { get; set; }
            [JsonProperty("CRLF_smargin_d")]
            public string smargin_d { get; set; }
            [JsonProperty("CRLF_opln_o")]
            public string opln_o { get; set; }
            [JsonProperty("CRLF_opln_h")]
            public string opln_h { get; set; }
            [JsonProperty("CRLF_opother_o")]
            public string opother_o { get; set; }
            [JsonProperty("CRLF_opother_h")]
            public string opother_h { get; set; }
            [JsonProperty("CRLF_noop")]
            public string noop { get; set; }
            [JsonProperty("CRLF_rtsumm")]
            public string rtsumm { get; set; }
            [JsonProperty("CRLF_rtmodal")]
            public string rtmodal { get; set; }
            [JsonProperty("CRLF_drt_1st")]
            public string drt_1st { get; set; }
            [JsonProperty("CRLF_drt_end")]
            public string drt_end { get; set; }
            [JsonProperty("CRLF_srs")]
            public string srs { get; set; }
            [JsonProperty("CRLF_sls")]
            public string sls { get; set; }
            [JsonProperty("CRLF_rtstatus")]
            public string rtstatus { get; set; }
            [JsonProperty("CRLF_ebrt")]
            public string ebrt { get; set; }
            [JsonProperty("CRLF_rth")]
            public string rth { get; set; }
            [JsonProperty("CRLF_rth_dose")]
            public string rth_dose { get; set; }
            [JsonProperty("CRLF_rth_nf")]
            public string rth_nf { get; set; }
            [JsonProperty("CRLF_rtl")]
            public string rtl { get; set; }
            [JsonProperty("CRLF_rtl_dose")]
            public string rtl_dose { get; set; }
            [JsonProperty("CRLF_rtl_nf")]
            public string rtl_nf { get; set; }
            [JsonProperty("CRLF_ort_modal")]
            public string ort_modal { get; set; }
            [JsonProperty("CRLF_ort_tech")]
            public string ort_tech { get; set; }
            [JsonProperty("CRLF_ort")]
            public string ort { get; set; }
            [JsonProperty("CRLF_ort_dose")]
            public string ort_dose { get; set; }
            [JsonProperty("CRLF_ort_nf")]
            public string ort_nf { get; set; }
            [JsonProperty("CRLF_dsyt")]
            public string dsyt { get; set; }
            [JsonProperty("CRLF_chem_o")]
            public string chem_o { get; set; }
            [JsonProperty("CRLF_chem_h")]
            public string chem_h { get; set; }
            [JsonProperty("CRLF_dchem")]
            public string dchem { get; set; }
            [JsonProperty("CRLF_horm_o")]
            public string horm_o { get; set; }
            [JsonProperty("CRLF_horm_h")]
            public string horm_h { get; set; }
            [JsonProperty("CRLF_dhorm")]
            public string dhorm { get; set; }
            [JsonProperty("CRLF_immu_o")]
            public string immu_o { get; set; }
            [JsonProperty("CRLF_immu_h")]
            public string immu_h { get; set; }
            [JsonProperty("CRLF_dimmu")]
            public string dimmu { get; set; }
            [JsonProperty("CRLF_htep_h")]
            public string htep_h { get; set; }
            [JsonProperty("CRLF_dhtep")]
            public string dhtep { get; set; }
            [JsonProperty("CRLF_target_o")]
            public string target_o { get; set; }
            [JsonProperty("CRLF_target_h")]
            public string target_h { get; set; }
            [JsonProperty("CRLF_dtarget")]
            public string dtarget { get; set; }
            [JsonProperty("CRLF_palli_h")]
            public string palli_h { get; set; }
            [JsonProperty("CRLF_other")]
            public string other { get; set; }
            [JsonProperty("CRLF_dother")]
            public string dother { get; set; }
            [JsonProperty("CRLF_drecur")]
            public string drecur { get; set; }
            [JsonProperty("CRLF_recur")]
            public string recur { get; set; }
            [JsonProperty("CRLF_dlast")]
            public string dlast { get; set; }
            [JsonProperty("CRLF_vstatus")]
            public string vstatus { get; set; }
            [JsonProperty("CRLF_height")]
            public string height { get; set; }
            [JsonProperty("CRLF_weight")]
            public string weight { get; set; }
            [JsonProperty("CRLF_smoking")]
            public string smoking { get; set; }
            [JsonProperty("CRLF_btchew")]
            public string btchew { get; set; }
            [JsonProperty("CRLF_drinking")]
            public string drinking { get; set; }
            [JsonProperty("CRLF_ps")]
            public string ps { get; set; }
            [JsonProperty("CRLF_ssf1")]
            public string ssf1 { get; set; }
            [JsonProperty("CRLF_ssf2")]
            public string ssf2 { get; set; }
            [JsonProperty("CRLF_ssf3")]
            public string ssf3 { get; set; }
            [JsonProperty("CRLF_ssf4")]
            public string ssf4 { get; set; }
            [JsonProperty("CRLF_ssf5")]
            public string ssf5 { get; set; }
            [JsonProperty("CRLF_ssf6")]
            public string ssf6 { get; set; }
            [JsonProperty("CRLF_ssf7")]
            public string ssf7 { get; set; }
            [JsonProperty("CRLF_ssf8")]
            public string ssf8 { get; set; }
            [JsonProperty("CRLF_ssf9")]
            public string ssf9 { get; set; }
            [JsonProperty("CRLF_ssf10")]
            public string ssf10 { get; set; }
        }
        //LABD_cs
        public class LABD
        {
            [JsonProperty("LABD_h1")]
            public string LABDH1 { get; set; }

            [JsonProperty("LABD_h2")]
            public string LABDH2 { get; set; }

            [JsonProperty("LABD_h3")]
            public string LABDH3 { get; set; }

            [JsonProperty("LABD_h4")]
            public string LABDH4 { get; set; }

            [JsonProperty("LABD_h5")]
            public string LABDH5 { get; set; }

            [JsonProperty("LABD_h6")]
            public string LABDH6 { get; set; }

            [JsonProperty("LABD_h7")]
            public string LABDH7 { get; set; }

            [JsonProperty("LABD_h8")]
            public string LABDH8 { get; set; }

            [JsonProperty("LABD_h9")]
            public string LABDH9 { get; set; }

            [JsonProperty("LABD_h10")]
            public string LABDH10 { get; set; }

            [JsonProperty("LABD_h11")]
            public string LABDH11 { get; set; }

            [JsonProperty("LABD_h12")]
            public string LABDH12 { get; set; }

            [JsonProperty("LABD_h13")]
            public string LABDH13 { get; set; }

            [JsonProperty("LABD_h14")]
            public string LABDH14 { get; set; }

            [JsonProperty("LABD_h15")]
            public string LABDH15 { get; set; }

            [JsonProperty("LABD_h19")]
            public string LABDH19 { get; set; }

            [JsonProperty("LABD_h20")]
            public string LABDH20 { get; set; }

            [JsonProperty("LABD_h22")]
            public string LABDH22 { get; set; }

            [JsonProperty("LABD_r1")]
            public string LABDR1 { get; set; }

            [JsonProperty("LABD_r2")]
            public string LABDR2 { get; set; }

            [JsonProperty("LABD_r3")]
            public string LABDR3 { get; set; }

            [JsonProperty("LABD_r4")]
            public string LABDR4 { get; set; }

            [JsonProperty("LABD_r5")]
            public string LABDR5 { get; set; }

            [JsonProperty("LABD_r6_1")]
            public string LABDR61 { get; set; }

            [JsonProperty("LABD_r6_2")]
            public string LABDR62 { get; set; }

            [JsonProperty("LABD_r7")]
            public string LABDR7 { get; set; }

            [JsonProperty("LABD_r8_1")]
            public string LABDR81 { get; set; }

            [JsonProperty("LABD_r10")]
            public string LABDR10 { get; set; }

            [JsonProperty("LABD_r12")]
            public string LABDR12 { get; set; }

            [JsonProperty("LABD_gender")]
            public string LABDGender { get; set; }
        }
        //LABM_cs
        public class LABM
        {
            [JsonProperty("LABM_h1")]
            public string LABMH1 { get; set; }

            [JsonProperty("LABM_h2")]
            public string LABMH2 { get; set; }

            [JsonProperty("LABM_h3")]
            public string LABMH3 { get; set; }

            [JsonProperty("LABM_h4")]
            public string LABMH4 { get; set; }

            [JsonProperty("LABM_h5")]
            public string LABMH5 { get; set; }

            [JsonProperty("LABM_h6")]
            public string LABMH6 { get; set; }

            [JsonProperty("LABM_h7")]
            public string LABMH7 { get; set; }

            [JsonProperty("LABM_h8")]
            public string LABMH8 { get; set; }

            [JsonProperty("LABM_h9")]
            public string LABMH9 { get; set; }

            [JsonProperty("LABM_h10")]
            public string LABMH10 { get; set; }

            [JsonProperty("LABM_h11")]
            public string LABMH11 { get; set; }

            [JsonProperty("LABM_h12")]
            public string LABMH12 { get; set; }

            [JsonProperty("LABM_h13")]
            public string LABMH13 { get; set; }

            [JsonProperty("LABM_h14")]
            public string LABMH14 { get; set; }

            [JsonProperty("LABM_h17")]
            public string LABMH17 { get; set; }

            [JsonProperty("LABM_h18")]
            public string LABMH18 { get; set; }

            [JsonProperty("LABM_h22")]
            public string LABMH22 { get; set; }

            [JsonProperty("LABM_h23")]
            public string LABMH23 { get; set; }

            [JsonProperty("LABM_h25")]
            public string LABMH25 { get; set; }

            [JsonProperty("LABM_r1")]
            public string LABMR1 { get; set; }

            [JsonProperty("LABM_r2")]
            public string LABMR2 { get; set; }

            [JsonProperty("LABM_r3")]
            public string LABMR3 { get; set; }

            [JsonProperty("LABM_r4")]
            public string LABMR4 { get; set; }

            [JsonProperty("LABM_r5")]
            public string LABMR5 { get; set; }

            [JsonProperty("LABM_r6_1")]
            public string LABMR61 { get; set; }

            [JsonProperty("LABM_r6_2")]
            public string LABMR62 { get; set; }

            [JsonProperty("LABM_r7")]
            public string LABMR7 { get; set; }

            [JsonProperty("LABM_r8_1")]
            public string LABMR81 { get; set; }

            [JsonProperty("LABM_r10")]
            public string LABMR10 { get; set; }

            [JsonProperty("LABM_r12")]
            public string LABMR12 { get; set; }

            [JsonProperty("LABM_gender")]
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
        //TOTFA_cs
        public class TOTFA
        {
            [JsonProperty("TOTFA_t2")]
            public int TOTFAT2 { get; set; }

            [JsonProperty("TOTFA_t3")]
            public string TOTFAT3 { get; set; }

            [JsonProperty("TOTFA_t5")]
            public int TOTFAT5 { get; set; }

            [JsonProperty("TOTFA_t6")]
            public string TOTFAT6 { get; set; }

            [JsonProperty("TOTFA_d1")]
            public string TOTFAD1 { get; set; }

            [JsonProperty("TOTFA_d2")]
            public int TOTFAD2 { get; set; }

            [JsonProperty("TOTFA_d4")]
            public string TOTFAD4 { get; set; }

            [JsonProperty("TOTFA_d5")]
            public string TOTFAD5 { get; set; }

            [JsonProperty("TOTFA_d6")]
            public string TOTFAD6 { get; set; }

            [JsonProperty("TOTFA_d7")]
            public string TOTFAD7 { get; set; }

            [JsonProperty("TOTFA_d8")]
            public string TOTFAD8 { get; set; }

            [JsonProperty("TOTFA_d9")]
            public string TOTFAD9 { get; set; }

            [JsonProperty("TOTFA_d10")]
            public string TOTFAD10 { get; set; }

            [JsonProperty("TOTFA_d11")]
            public string TOTFAD11 { get; set; }

            [JsonProperty("TOTFA_d3")]
            public string TOTFAD3 { get; set; }

            [JsonProperty("TOTFA_d19")]
            public string TOTFAD19 { get; set; }

            [JsonProperty("TOTFA_d20")]
            public string TOTFAD20 { get; set; }

            [JsonProperty("TOTFA_d21")]
            public string TOTFAD21 { get; set; }

            [JsonProperty("TOTFA_d22")]
            public string TOTFAD22 { get; set; }

            [JsonProperty("TOTFA_d23")]
            public string TOTFAD23 { get; set; }

            [JsonProperty("TOTFA_d24")]
            public string TOTFAD24 { get; set; }

            [JsonProperty("TOTFA_d25")]
            public string TOTFAD25 { get; set; }

            [JsonProperty("TOTFA_d26")]
            public string TOTFAD26 { get; set; }

            [JsonProperty("TOTFA_d27")]
            public int? TOTFAD27 { get; set; }

            [JsonProperty("TOTFA_d28")]
            public int TOTFAD28 { get; set; }

            [JsonProperty("TOTFA_gender")]
            public string TOTFAGender { get; set; }

            [JsonProperty("TOTFA_p1")]
            public double TOTFAP1 { get; set; }

            [JsonProperty("TOTFA_p2")]
            public double? TOTFAP2 { get; set; }

            [JsonProperty("TOTFA_p3")]
            public int TOTFAP3 { get; set; }

            [JsonProperty("TOTFA_p4")]
            public string TOTFAP4 { get; set; }

            [JsonProperty("TOTFA_p5")]
            public double? TOTFAP5 { get; set; }

            [JsonProperty("TOTFA_p6")]
            public string TOTFAP6 { get; set; }

            [JsonProperty("TOTFA_p7")]
            public string TOTFAP7 { get; set; }

            [JsonProperty("TOTFA_p9")]
            public string TOTFAP9 { get; set; }

            [JsonProperty("TOTFA_p10")]
            public double TOTFAP10 { get; set; }

            [JsonProperty("TOTFA_p13")]
            public int TOTFAP13 { get; set; }

            [JsonProperty("TOTFA_p14")]
            public string TOTFAP14 { get; set; }

            [JsonProperty("TOTFA_p15")]
            public string TOTFAP15 { get; set; }

            [JsonProperty("TOTFA_p17")]
            public string TOTFAP17 { get; set; }
        }
        //TOTFB_cs
        public class TOTFB
        {
            [JsonProperty("TOTFB_t2")]
            public int TOTFBT2 { get; set; }

            [JsonProperty("TOTFB_t3")]
            public string TOTFBT3 { get; set; }

            [JsonProperty("TOTFB_t5")]
            public int TOTFBT5 { get; set; }

            [JsonProperty("TOTFB_t6")]
            public string TOTFBT6 { get; set; }

            [JsonProperty("TOTFB_d1")]
            public int TOTFBD1 { get; set; }

            [JsonProperty("TOTFB_d2")]
            public int TOTFBD2 { get; set; }

            [JsonProperty("TOTFB_d3")]
            public string TOTFBD3 { get; set; }

            [JsonProperty("TOTFB_d6")]
            public string TOTFBD6 { get; set; }

            [JsonProperty("TOTFB_d9")]
            public string TOTFBD9 { get; set; }

            [JsonProperty("TOTFB_d10")]
            public string TOTFBD10 { get; set; }

            [JsonProperty("TOTFB_d11")]
            public string TOTFBD11 { get; set; }

            [JsonProperty("TOTFB_d14")]
            public int TOTFBD14 { get; set; }

            [JsonProperty("TOTFB_d15")]
            public string TOTFBD15 { get; set; }

            [JsonProperty("TOTFB_d18")]
            public string TOTFBD18 { get; set; }

            [JsonProperty("TOTFB_d21")]
            public string TOTFBD21 { get; set; }

            [JsonProperty("TOTFB_d24")]
            public string TOTFBD24 { get; set; }

            [JsonProperty("TOTFB_d25")]
            public string TOTFBD25 { get; set; }

            [JsonProperty("TOTFB_d26")]
            public string TOTFBD26 { get; set; }

            [JsonProperty("TOTFB_d27")]
            public string TOTFBD27 { get; set; }

            [JsonProperty("TOTFB_d28")]
            public string TOTFBD28 { get; set; }

            [JsonProperty("TOTFB_d29")]
            public string TOTFBD29 { get; set; }

            [JsonProperty("TOTFB_d45")]
            public string TOTFBD45 { get; set; }

            [JsonProperty("TOTFB_d46")]
            public string TOTFBD46 { get; set; }

            [JsonProperty("TOTFB_d47")]
            public string TOTFBD47 { get; set; }

            [JsonProperty("TOTFB_d48")]
            public string TOTFBD48 { get; set; }

            [JsonProperty("TOTFB_d49")]
            public string TOTFBD49 { get; set; }

            [JsonProperty("TOTFB_gender")]
            public string TOTFBGender { get; set; }

            [JsonProperty("TOTFB_p1")]
            public int TOTFBP1 { get; set; }

            [JsonProperty("TOTFB_p2")]
            public string TOTFBP2 { get; set; }

            [JsonProperty("TOTFB_p3")]
            public string TOTFBP3 { get; set; }

            [JsonProperty("TOTFB_p5")]
            public double? TOTFBP5 { get; set; }

            [JsonProperty("TOTFB_p6")]
            public string TOTFBP6 { get; set; }

            [JsonProperty("TOTFB_p7")]
            public string TOTFBP7 { get; set; }

            [JsonProperty("TOTFB_p8")]
            public string TOTFBP8 { get; set; }

            [JsonProperty("TOTFB_p14")]
            public string TOTFBP14 { get; set; }

            [JsonProperty("TOTFB_p15")]
            public string TOTFBP15 { get; set; }

            [JsonProperty("TOTFB_p16")]
            public double TOTFBP16 { get; set; }
        }
    }
}