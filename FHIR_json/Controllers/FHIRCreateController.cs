﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FHIR_json.Models;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Policy;
using System.Security.Cryptography;

namespace FHIR_json.Controllers
{
    public class FHIRCreateController : ApiController
    {
        #region 變數
        //變數--------------------------------------------------------------------------------------------------------------------
        //FHIR變數
        //CRLF頭
        //Bundle Bun = new Bundle();
        Patient Pat = new Patient();
        Patient Pat1 = new Patient();
        //Patient Pat2 = new Patient();
        Organization OG = new Organization();
        //Practitioner Pra = new Practitioner();
        //Location Loc = new Location();
        //Medication Med = new Medication();
        //Composition Comp = new Composition();
        //Encounter Enc = new Encounter();
        Observation Obs = new Observation();
        Observation TS = new Observation();
        Observation pni = new Observation();
        Observation lvi = new Observation();
        Observation nexam = new Observation();
        Observation nposit = new Observation();
        Observation clinical_T = new Observation();//臨床T 
        Observation clinical_N = new Observation();//臨床N
        Observation clinical_M = new Observation();//臨床M
        Observation CG_clinical = new Observation();//CG_臨床
        Observation pathology_T = new Observation();//病理T
        Observation pathology_N = new Observation();//病理N
        Observation pathology_M = new Observation();//病理M
        Observation CG_pathology = new Observation();//CG_病理
        Observation CG_OtherC = new Observation();
        Observation CG_OtherP = new Observation();
        Observation height = new Observation();
        Observation weight = new Observation();
        Observation smoke = new Observation();
        Observation btchew = new Observation();
        Observation drinking = new Observation();
        Observation ps = new Observation();
        Observation ssf1 = new Observation();
        Observation ssf2 = new Observation();
        Observation ssf3 = new Observation();
        Observation ssf4 = new Observation();
        Observation ssf5 = new Observation();
        Observation ssf6 = new Observation();
        Observation ssf7 = new Observation();
        Observation ssf8 = new Observation();
        Observation ssf9 = new Observation();
        Observation ssf10 = new Observation();
        Condition Con = new Condition();
        Condition SCC = new Condition();
        Procedure Pro = new Procedure();
        Procedure diag = new Procedure();
        Procedure P1 = new Procedure();
        Procedure P2 = new Procedure();
        Procedure P3 = new Procedure();
        Procedure Radio1 = new Procedure();
        Procedure M1 = new Procedure();
        ChargeItem Cha = new ChargeItem();
        MedicationAdministration Med = new MedicationAdministration();
        Procedure m2 = new Procedure();
        Procedure m3 = new Procedure();
        Procedure m4 = new Procedure();
        Procedure m5 = new Procedure();
        ChargeItem m6 = new ChargeItem();
        Procedure m7 = new Procedure();
        //CRLF尾

        //TOTFA頭
        Encounter fa_en = new Encounter();
        Observation med_day = new Observation();
        Observation med_type = new Observation();
        Organization fa = new Organization();
        Patient pt = new Patient();
        MedicationRequest fa_med = new MedicationRequest();
        Condition fa_c1 = new Condition();
        Condition fa_c2 = new Condition();
        Condition fa_c3 = new Condition();
        Condition fa_c4 = new Condition();
        Condition fa_c5 = new Condition();
        ChargeItem fa_ct = new ChargeItem();
        Procedure fa_p1 = new Procedure();//TOTFA
        Procedure fa_p2 = new Procedure();//TOTFA
        Procedure fa_p3 = new Procedure();//TOTFA
        Procedure fa_p4 = new Procedure();//TOTFA
                                          //TOTFA尾

        //TOTFB頭
        Encounter fb_en = new Encounter();
        Observation fb_e_bed = new Observation();
        Observation fb_s_bed = new Observation();
        Organization fb = new Organization();
        Patient fb_pt = new Patient();
        Condition fb_c1 = new Condition();
        Condition fb_c2 = new Condition();
        Condition fb_c3 = new Condition();
        Condition fb_c4 = new Condition();
        Condition fb_c5 = new Condition();
        ChargeItem fb_ct = new ChargeItem();
        Procedure fb_p1 = new Procedure();//TOTFB
        Procedure fb_p2 = new Procedure();//TOTFB
        Procedure fb_p3 = new Procedure();//TOTFB
        Procedure fb_p4 = new Procedure();//TOTFB
        Procedure fb_p5 = new Procedure();//TOTFB
        MedicationRequest fb_med = new MedicationRequest();
        //TOTFB尾
        //LABD頭
        Encounter labd_en = new Encounter();
        //改
        Procedure labd_h = new Procedure();
        Observation labd_B = new Observation();
        Organization labd = new Organization();
        Patient labd_pt = new Patient();
        //LABM
        Organization labm = new Organization();
        Patient labm_pt = new Patient();
        ChargeItem labm_ct = new ChargeItem();
        //LABD尾
        //LABM頭
        Encounter labm_en = new Encounter();
        Procedure labm_h = new Procedure();
        Observation labm_B = new Observation();
        //LABM尾

        //0221_new
        //spe_JSON
        Consent Consent = new Consent();
        Patient CPat = new Patient();
        Organization sp_og = new Organization();
        Specimen Sp = new Specimen();
        Observation sp_age = new Observation();
        Observation sp_height = new Observation();
        Observation sp_weight = new Observation();

        //spe_JSON


        //Coverage Cov = new Coverage();
        //MedicationRequest MedReq = new MedicationRequest();

        List<Patient> patlist = new List<Patient>();
        List<Organization> orglist = new List<Organization>();
        // List<Practitioner> pralist = new List<Practitioner>();
        //List<Location> loclist = new List<Location>();
        //List<Medication> medlist = new List<Medication>();
        //List<Composition> complist = new List<Composition>();
        //List<Encounter> enclist = new List<Encounter>();
        List<Observation> obslist = new List<Observation>();
        List<Condition> conlist = new List<Condition>();
        List<Procedure> prolist = new List<Procedure>();
        List<ChargeItem> chalist = new List<ChargeItem>();
        List<MedicationAdministration> medlist = new List<MedicationAdministration>();
        List<Encounter> enclist = new List<Encounter>();
        List<MedicationRequest> medrequestlist = new List<MedicationRequest>();
        //0221_new
        List<Consent> consentlist = new List<Consent>();
        List<Specimen> spelist = new List<Specimen>();

        Bundle bundle = new Bundle();
        #endregion 變數結束

        //List<Coverage> covlist = new List<Coverage>();
        //List<MedicationRequest> medreqlist = new List<MedicationRequest>();
        // GET: FHIR_NHI_Path
        //public Bundle Index()
        //{
        //    return bundle;
        //}
        //讀檔分類Resource
        [HttpPost]
        public async Task<dynamic> LABM_JSON(List<OriginalJson.LABM> Labm_tags)
        {
            //開始分類
            //int fhir_id = 0;//FHIR流水號
            foreach (var Labm_tag in Labm_tags)
            {
                //organization
                labm = new Organization();
                labm.id = Sha1Hash(Labm_tag.LABMH2);
                labm.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value = Labm_tag.LABMH2
                    }
                };
                orglist.Add(labm);

                //Patient
                labm_pt = new Patient();
                labm_pt.id = Sha1Hash(Labm_tag.LABMH9);
                labm_pt.birthDate = Labm_tag.LABMH10;
                //labm_pt.birthDate = Labm_tag.LABMH10;
                labm_pt.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=Labm_tag.LABMH9
                    }
                };
                patlist.Add(labm_pt);

                //ChargeItem
                labm_ct = new ChargeItem();
                labm_ct.id = Sha1Hash($"labm_ct-{Labm_tag.LABMH2}-{Labm_tag.LABMH4}-{Labm_tag.LABMH5}-{Labm_tag.LABMH6}-{Labm_tag.LABMH7}-{Labm_tag.LABMH8}-{Labm_tag.LABMH18}-{Labm_tag.LABMR1}"); labm_ct.enteredDate = Labm_tag.LABMH4;
                labm_ct.subject = new subject { reference = $"Patient/{labm_pt.id}" };//? 94
                labm_ct.status = "billed";
                labm_ct.code = new code
                {
                    coding = new List<coding>
                        {
                            new coding
                            {
                                code = Labm_tag.LABMH5
                            }
                        }
                };
                labm_ct.occurrenceDateTime = DateTime.Parse(Labm_tag.LABMH6).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                //start = DateTime.Parse(Labm_tag.LABMH11).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                chalist.Add(labm_ct);
                //enc
                labm_en = new Encounter();
                labm_en.id = Sha1Hash($"labm_en-{Labm_tag.LABMH2}-{Labm_tag.LABMH4}-{Labm_tag.LABMH5}-{Labm_tag.LABMH6}-{Labm_tag.LABMH7}-{Labm_tag.LABMH8}-{Labm_tag.LABMH18}-{Labm_tag.LABMR1}"); labm_en.status = "finished";
                labm_en.type = new List<type>
                {
                    new type
                    {

                      text = "報告類別",
                      coding=new List<coding>
                      {
                          new coding
                          {
                              code=Labm_tag.LABMH1
                          }
                      }

                    },
                    new type
                    {

                      text = "案件分類",
                      coding=new List<coding>
                      {
                          new coding
                          {
                              code=Labm_tag.LABMH7
                          }
                      }

                    },
                };
                labm_en.@class = new @class
                {
                    system = "http://terminology.hl7.org/ValueSet/v3-ActEncounterCode",
                    code = "OBSENC",
                    display = "observation encounter"
                };

                labm_en.subject = new subject { reference = $"Patient/{labm_pt.id}" };//?94
                labm_en.serviceType = new serviceType
                {
                    text = "醫事類別",
                    coding = new List<coding>
                        {
                            new coding
                            {
                                code=Labm_tag.LABMH3
                            }
                        }
                };

                labm_en.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=Labm_tag.LABMH8
                    }
                };
                if (Labm_tag.LABMH11 != null)
                {
                    labm_en.period = new period
                    {
                        start = DateTime.Parse(Labm_tag.LABMH11).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        end = DateTime.Parse(Labm_tag.LABMH12).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                    };
                }
                else if (Labm_tag.LABMH13 != null)
                {
                    labm_en.period = new period
                    {
                        start = DateTime.Parse(Labm_tag.LABMH13).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        end = DateTime.Parse(Labm_tag.LABMH14).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                    };
                }
                enclist.Add(labm_en);
                //obeser
                labm_h = new Procedure();
                labm_h.id = Sha1Hash($"labm_h-{Labm_tag.LABMH2}-{Labm_tag.LABMH4}-{Labm_tag.LABMH5}-{Labm_tag.LABMH6}-{Labm_tag.LABMH7}-{Labm_tag.LABMH8}-{Labm_tag.LABMH18}-{Labm_tag.LABMR1}"); 
                labm_h.status = "preparation";
                labm_h.subject = new subject { reference = $"Patient/{labm_pt.id}" };//?94
                labm_h.encounter = new encounter { reference = $"Encounter/{labm_en.id}" };//?91
                labm_h.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=Labm_tag.LABMH17
                    }
                };
                labm_h.code = new code
                {
                    text = "醫令代碼",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=Labm_tag.LABMH18
                        }
                    }
                };
                //labm_h.performedDateTime = DateTime.Parse(Labm_tag.LABMH22).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                //labm_h.performedPeriod.start = Labm_tag.LABMH23;
                //labm_h.performedPeriod.end = Labm_tag.LABMH23;
                labm_h.performedPeriod = new performedPeriod
                {
                    start = DateTime.Parse(Labm_tag.LABMH23).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    end = DateTime.Parse(Labm_tag.LABMH23).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                };
                labm_h.category = new category
                {
                   
                        text="檢體採檢方法/來源/類別",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=Labm_tag.LABMH25
                            }
                        }
                   
                };
                prolist.Add(labm_h);

                labm_B = new Observation();
                labm_B.partOf = new List<partOf>
                { 
                    new partOf
                    {
                        reference = $"Procedure/{labm_h.id}" 
                        
                    }
                };
                labm_B.id = Sha1Hash($"labm_B-{Labm_tag.LABMH2}-{Labm_tag.LABMH4}-{Labm_tag.LABMH5}-{Labm_tag.LABMH6}-{Labm_tag.LABMH7}-{Labm_tag.LABMH8}-{Labm_tag.LABMH18}-{Labm_tag.LABMR1}"); 
                labm_B.status = "final";
                labm_B.subject = new subject { reference = $"Patient/{labm_pt.id}" };//?94
                labm_B.encounter = new encounter { reference = $"Encounter/{labm_en.id}" };//?91
                labm_B.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=Labm_tag.LABMR1
                    }
                };
                labm_B.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=Labm_tag.LABMR2 ?? "未知"
                        }
                    }
                };
                labm_B.method = new method
                {
                    coding = new List<coding>
                        {
                            new coding
                            {
                               code=Labm_tag.LABMR3
                            }
                        }
                };
                //labm_B.valueQuantity = new valueQuantity
                //{
                //    value = Convert.ToDouble(Labm_tag.LABMR4),
                //    unit = Labm_tag.LABMR5
                //};

                //0715_新
                labm_B.valueString = Labm_tag.LABMR4;
                labm_B.note = new List<note>
                {
                    new note
                    {
                        text = Labm_tag.LABMR5
                    }
                };
                
                labm_B.referenceRange = new List<referenceRange>
                {
                    new referenceRange
                    {
                        text = Labm_tag.LABMR61
                    },
                    new referenceRange
                    {
                        text = Labm_tag.LABMR62
                    }
                };
                //0715_新_到這

                labm_B.interpretation = new List<interpretation>
                {
                    new interpretation
                    {
                        text="報告結果",
                        coding = new List<coding>
                        {
                            new coding
                            {
                               code=Labm_tag.LABMR7
                            }
                        }
                    },
                    new interpretation
                    {
                        text="病理發現及診斷",
                        coding = new List<coding>
                        {
                            new coding
                            {
                               code=Labm_tag.LABMR81
                            }
                        }
                    },
                    new interpretation
                    {
                        text="檢驗（查）結果值註記",
                        coding = new List<coding>
                        {
                            new coding
                            {
                               code=Labm_tag.LABMR12
                            }
                        }
                    },
                };
                labm_B.effectiveDateTime = DateTime.Parse(Labm_tag.LABMR10).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                obslist.Add(labm_B);
            }
            bundle.entry = new List<entry>();
            var bundle_distinct = PatOrg_Distinct();
            var response_json_ditsint = await GetandShare_Block(bundle_distinct);
            var response_json_ditsinthapi = await GetandSharehapi_Block(bundle_distinct);
            var jsonobs = ObservationJSON();
            var jsonorg = OrganizationJSON();
            var jsonpro = ProcedureJSON();
            var jsonchar = ChargeItemJSON();
            //var jsonmed = MedicationAdministrationJSON();
            //var jsoncon = ConditionJSON();
            var jsonpat = PatientJSON();
            var jsonenc = EncounterJSON();
            var bundlejson = BundleJSON_labm();
            //var bundlehapijson = await GetandSharehapi_Block(bundlejson);
            var bundleIBMjson = await GetandShare_Block(bundlejson);
            //return await GetandShare_Block(bundlejson);
            return await GetandSharehapi_Block(bundlejson);
        }

        [HttpPost]
        public async Task<dynamic> LABD_JSON(List<OriginalJson.LABD> Labd_tags) //Bundle
        {
            //開始分類
            int fhir_id = 0;//FHIR流水號
            foreach (var Labd_tag in Labd_tags)
            {
                //organization
                labd = new Organization();
                labd.id = Sha1Hash(Labd_tag.LABDH2);
                labd.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value = Labd_tag.LABDH2
                    }
                };
                orglist.Add(labd);

                //Patient
                labd_pt = new Patient();
                labd_pt.id = Sha1Hash(Labd_tag.LABDH9);
                labd_pt.birthDate = Labd_tag.LABDH10;
                //labd_pt.birthDate = Labd_tag.LABDH10;
                labd_pt.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=Labd_tag.LABDH9
                    }
                };
                labd_pt.gender = Labd_tag.LABDGender;
                patlist.Add(labd_pt);
                //enc
                labd_en = new Encounter();
                labd_en.id = Sha1Hash($"labd_en-{Labd_tag.LABDH2}-{Labd_tag.LABDH4}-{Labd_tag.LABDH6}-{Labd_tag.LABDH7}-{Labd_tag.LABDH15}-{Labd_tag.LABDR1}");
                labd_en.status = "finished";
                labd_en.type = new List<type>
                {
                    new type
                    {

                      text = "報告類別",
                      coding=new List<coding>
                        {
                            new coding
                            {
                                code=Labd_tag.LABDH1
                            }
                        }
                    }
                };
                labd_en.@class = new @class
                {
                    system = "http://terminology.hl7.org/ValueSet/v3-ActEncounterCode",
                    code = "OBSENC",
                    display = "observation encounter"
                };
                labd_en.subject = new subject { reference = $"Patient/{labd_pt.id}" };//88
                labd_en.serviceType = new serviceType
                {
                    text = "醫事類別",
                    coding = new List<coding>
                        {
                            new coding
                            {
                                code=Labd_tag.LABDH3
                            }
                        }
                };
                labd_en.reasonCode = new List<reasonCode>
                {
                    new reasonCode
                    {
                        text = "就醫類別",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=Labd_tag.LABDH6
                            }
                        }
                    }

                };
                labd_en.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=Labd_tag.LABDH7
                    }
                };
                if (Labd_tag.LABDH11.Length != 0)
                {
                    labd_en.period = new period
                    {
                        start = Labd_tag.LABDH11,
                        end = Labd_tag.LABDH12
                    };
                }
                else if (Labd_tag.LABDH13.Length != 0)
                {
                    labd_en.period = new period
                    {
                        start = Labd_tag.LABDH13,
                        end = Labd_tag.LABDH14
                    };
                }
                enclist.Add(labd_en);
                //obeser
                //改
                labd_h = new Procedure();
                labd_h.id = Sha1Hash($"labd_h-{Labd_tag.LABDH2}-{Labd_tag.LABDH4}-{Labd_tag.LABDH6}-{Labd_tag.LABDH7}-{Labd_tag.LABDH15}-{Labd_tag.LABDR1}");
                labd_h.status = "preparation";
                labd_h.subject = new subject { reference = $"Patient/{labd_pt.id}" };//?88
                labd_h.encounter = new encounter { reference = $"Encounter/{labd_en.id}" };//?86
                labd_h.code = new code
                {
                    text = "醫令代碼",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=Labd_tag.LABDH15
                        }
                    }
                };
                //labd_h.performedDateTime = Labd_tag.LABDH19;
                labd_h.performedPeriod = new performedPeriod
                {
                    start = Labd_tag.LABDH20,
                    end = Labd_tag.LABDH20
                };
                labd_h.category = new category
                {

                    text = "檢體採檢方法/來源/類別",
                    coding = new List<coding>
                        {
                            new coding
                            {
                                code=Labd_tag.LABDH22
                            }
                        }
                };
                prolist.Add(labd_h);

                labd_B = new Observation();
                labd_B.partOf = new List<partOf>
                {
                    new partOf
                    {
                        reference = $"Procedure/{labd_h.id}"

                    }
                };
                labd_B.id = Sha1Hash($"labd_B-{Labd_tag.LABDH2}-{Labd_tag.LABDH4}-{Labd_tag.LABDH6}-{Labd_tag.LABDH7}-{Labd_tag.LABDH15}-{Labd_tag.LABDR1}");
                labd_B.status = "final";
                labd_B.subject = new subject { reference = $"Patient/{labd_pt.id}" };//?88
                labd_B.encounter = new encounter { reference = $"Encounter/{labd_en.id}" };//?86
                labd_B.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=Labd_tag.LABDR1
                    }
                };
                labd_B.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=Labd_tag.LABDR2 ??"未知"
                        }
                    }
                };
                labd_B.method = new method
                {
                    coding = new List<coding>
                        {
                            new coding
                            {
                                code=Labd_tag.LABDR3
                            }
                        }
                };
                labd_B.valueString = Labd_tag.LABDR4;
                labd_B.note = new List<note>
                {
                    new note
                    {
                        text=Labd_tag.LABDR5
                    }
                };
                labd_B.referenceRange = new List<referenceRange>
                {
                    new referenceRange
                    {
                        text=Labd_tag.LABDR61
                    },
                    new referenceRange
                    {
                        text=Labd_tag.LABDR62
                    }
                };
                labd_B.interpretation = new List<interpretation>
                {
                    new interpretation
                    {
                        text= "報告結果",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=Labd_tag.LABDR7
                            }
                        }
                    },
                    new interpretation
                    {
                        text= "病理發現及診斷",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=Labd_tag.LABDR81
                            }
                        }
                    },
                    new interpretation
                    {
                        text= "檢驗（查）結果值註記",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=Labd_tag.LABDR12
                            }
                        }
                    }

                };
                labd_B.effectiveDateTime = Labd_tag.LABDR10;
                obslist.Add(labd_B);
            }
            bundle.entry = new List<entry>();
            var bundle_distinct = PatOrg_Distinct();
            var response_json_ditsint = await GetandShare_Block(bundle_distinct);
            var response_json_ditsinthapi = await GetandSharehapi_Block(bundle_distinct);
            var jsonobs = ObservationJSON();
            var jsonorg = OrganizationJSON();
            var jsonpro = ProcedureJSON();
            //var jsonchar = ChargeItemJSON();
            //var jsonmed = MedicationAdministrationJSON();
            //var jsoncon = ConditionJSON();
            var jsonpat = PatientJSON();
            var jsonenc = EncounterJSON();
            var bundlejson = BundleJSON_LABD_JSON();
            //var bundlehapijson = await GetandSharehapi_Block(bundlejson);
            var bundleIBMjson = await GetandShare_Block(bundlejson);
            //return await GetandShare_Block(bundlejson);
            return await GetandSharehapi_Block(bundlejson);
        }

        [HttpPost]
        public async Task<dynamic> TOTFA_JSON(List<OriginalJson.TOTFA> TOTFA_tags)
        {
            //StreamReader r = new StreamReader(@"C:\Users\huang\source\repos\GroundhogTeam\NHIRDB_system\WebApplication3\ReadJSON\totfae_merge_col.json");
            //StreamReader r = new StreamReader(@"D:\信華專區\newNHIRDB_system\NHIRDB_system\WebApplication3\ReadJSON\totfae_merge_col.json");
            //StreamReader r = new StreamReader(@"C:\Users\pin-hua\source\repos\GroundhogTeam\NHIRDB_system\WebApplication3\ReadJSON\totfae_merge_col.json");
            //string jsonString = r.ReadToEnd();
            //var TOTFA_tags = JsonConvert.DeserializeObject<List<OriginalJson.TOTFA>>(jsonString);//將JSON格式轉換成物件
            //ViewBag.TOTFA_tags = TOTFA_tags;
            //開始分類
            int fhir_id = 0;//FHIR流水號
            foreach (var TOTFA_tag in TOTFA_tags)
            {
                //organization
                fa = new Organization();
                fa.id = Sha1Hash(TOTFA_tag.TOTFAT2.ToString());
                fa.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value = TOTFA_tag.TOTFAT2.ToString()
                    }
                };
                orglist.Add(fa);

                //Patient
                pt = new Patient();
                pt.id = Sha1Hash(TOTFA_tag.TOTFAD3);
                pt.birthDate = TOTFA_tag.TOTFAD11;
                pt.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=TOTFA_tag.TOTFAD3
                    }
                };
                pt.gender = TOTFA_tag.TOTFAGender;
                patlist.Add(pt);
                //enc
                fa_en = new Encounter();
                fa_en.id = Sha1Hash($"fa_en-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                fa_en.status = "finished";
                fa_en.type = new List<type>
                {
                    new type
                    {
                        text = "案件分類",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=TOTFA_tag.TOTFAD1.ToString()
                            }
                        }

                    }
                };
                fa_en.@class = new @class
                {
                    system = "http://terminology.hl7.org/ValueSet/v3-ActEncounterCode",
                    code = "AMB",
                    display = "ambulatory"
                };
                fa_en.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=TOTFA_tag.TOTFAD2.ToString()
                    }
                };
                fa_en.subject = new subject { reference = $"Patient/{pt.id}" };//?
                fa_en.serviceType = new serviceType
                {
                    text = "就醫科別",
                    coding = new List<coding>
                        {
                            new coding
                            {
                                code=TOTFA_tag.TOTFAD8.ToString()
                            }
                        }
                };
                fa_en.period = new period
                {
                    start = DateTime.Parse(TOTFA_tag.TOTFAD9).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    end = DateTime.Parse(TOTFA_tag.TOTFAD10).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                };

                enclist.Add(fa_en);

                //obeser 刪除
                //med_day = new Observation();
                //med_day.id = Sha1Hash($"med_day-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                //med_day.status = "final";
                //med_day.subject = new subject { reference = $"Patient/{pt.id}" };//?
                //med_day.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//?
                //med_day.code = new code
                //{
                //    text = "給藥日份"
                //};
                //med_day.valueCodeableConcept = new valueCodeableConcept
                //{
                //    coding = new List<coding>
                //    {
                //        new coding
                //        {
                //            code=TOTFA_tag.TOTFAD27.ToString()
                //        }
                //    }
                //};
                //obslist.Add(med_day);

                //刪除
                //med_type = new Observation();
                //med_type.id = Sha1Hash($"med_type-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                //med_type.status = "final";
                //med_type.subject = new subject { reference = $"Patient/{pt.id}" };//?
                //med_type.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//?
                //med_type.code = new code
                //{
                //    text = "處方調劑方式"
                //};
                //med_type.valueCodeableConcept = new valueCodeableConcept
                //{
                //    coding = new List<coding>
                //    {
                //        new coding
                //        {
                //            code=TOTFA_tag.TOTFAD28.ToString()
                //        }
                //    }
                //};

                //obslist.Add(med_type);
                //ChargeItem
                fa_ct = new ChargeItem();
                fa_ct.id = Sha1Hash($"fa_ct-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                fa_ct.enteredDate = TOTFA_tag.TOTFAT3;
                fa_ct.subject = new subject { reference = $"Patient/{pt.id}" };//? 57
                fa_ct.status = "billed";
                fa_ct.code = new code
                {
                    coding = new List<coding>
                        {
                            new coding
                            {
                                code = TOTFA_tag.TOTFAT5.ToString()
                            }
                        }
                };
                fa_ct.occurrenceDateTime = TOTFA_tag.TOTFAT6;
                chalist.Add(fa_ct);

                //procedure
                fa_p1 = new Procedure();
                fa_p1.id = Sha1Hash($"fa_p1-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                fa_p1.status = "completed";
                fa_p1.subject = new subject { reference = $"Patient/{pt.id}" };//57??
                fa_p1.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//52??
                                                                                        //fa_c1.code.text = "特定治療項目代號(一)";
                fa_p1.code = new code
                {
                    text = "特定治療項目代號(一)",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAD4
                        }
                    }
                };
                prolist.Add(fa_p1);

                fa_p2 = new Procedure();
                fa_p2.id = Sha1Hash($"fa_p2-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                fa_p2.status = "completed";
                fa_p2.subject = new subject { reference = $"Patient/{pt.id}" };//57??
                fa_p2.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//52??
                                                                                        //fa_c2.code.text = "特定治療項目代號(二)";
                fa_p2.code = new code
                {
                    text = "特定治療項目代號(二)",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAD5
                        }
                    }
                };
                prolist.Add(fa_p2);

                fa_p3 = new Procedure();
                fa_p3.id = Sha1Hash($"fa_p3-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                fa_p3.status = "completed";
                fa_p3.subject = new subject { reference = $"Patient/{pt.id}" };//57??
                fa_p3.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//52??
                                                                                        //fa_c3.code.text = "特定治療項目代號(三)";
                fa_p3.code = new code
                {
                    text = "特定治療項目代號(三)",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAD6
                        }
                    }

                };
                prolist.Add(fa_p3);

                fa_p4 = new Procedure();
                fa_p4.id = Sha1Hash($"fa_p4-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                fa_p4.status = "completed";
                fa_p4.subject = new subject { reference = $"Patient/{pt.id}" };//57??
                fa_p4.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//52??
                                                                                        //fa_c4.code.text = "特定治療項目代號(四)";
                fa_p4.code = new code
                {
                    text = "特定治療項目代號(四)",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAD7
                        }
                    }
                };
                prolist.Add(fa_p4);

                P1 = new Procedure();
                P1.id = Sha1Hash($"P1-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                P1.status = "completed";
                P1.subject = new subject { reference = $"Patient/{pt.id}" };//57??
                P1.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };// 52??
                                                                                     //P1.code.text = "主手術(處置)代碼";
                P1.code = new code
                {
                    text = "主手術(處置)代碼",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAD24
                        }
                    }

                };
                prolist.Add(P1);

                P2 = new Procedure();
                P2.id = Sha1Hash($"P2-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                P2.status = "completed";
                P2.subject = new subject { reference = $"Patient/{pt.id}" };//57??
                P2.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//52??
                                                                                     //P2.code.text = "次手術(處置)代碼(一)";
                P2.code = new code
                {
                    text = "次手術(處置)代碼(一)",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAD25
                        }
                    }
                };
                prolist.Add(P2);

                P3 = new Procedure();
                P3.id = Sha1Hash($"P3-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                P3.status = "completed";
                P3.subject = new subject { reference = $"Patient/{pt.id}" };//57??
                P3.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//52??
                                                                                     //P3.code.text = "次手術(處置)代碼(二)";
                P3.code = new code
                {
                    text = "次手術(處置)代碼(二)",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAD26
                        }
                    }
                };

                prolist.Add(P3);


                //medicationrequest
                fa_med = new MedicationRequest();
                fa_med.id = Sha1Hash($"fa_med-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                fa_med.status = "completed";
                fa_med.intent = "order";
                fa_med.subject = new subject { reference = $"Patient/{pt.id}" };//57
                fa_med.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//?52
                                                                                         //fa_med.dispenseRequest.expectedSupplyDuration.unit = "days";
                if (TOTFA_tag.TOTFAP14 == null || TOTFA_tag.TOTFAP15 == null)
                {
                    fa_med.dispenseRequest = new dispenseRequest
                    {
                        expectedSupplyDuration = new expectedSupplyDuration
                        {
                            unit = "days",
                            system = "http://unitsofmeasure.org",
                            code = "d",
                            value = TOTFA_tag.TOTFAP1
                        },
                        quantity = new quantity
                        {
                            value = TOTFA_tag.TOTFAP10
                        },
                        validityPeriod = new validityPeriod
                        {
                            start = DateTime.Parse(TOTFA_tag.TOTFAP14).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                            end = DateTime.Parse(TOTFA_tag.TOTFAP15).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                        }

                    };
                }
                else if (TOTFA_tag.TOTFAP14 != null || TOTFA_tag.TOTFAP15 != null)
                {
                    fa_med.dispenseRequest = new dispenseRequest
                    {
                        expectedSupplyDuration = new expectedSupplyDuration
                        {
                            unit = "days",
                            system = "http://unitsofmeasure.org",
                            code = "d",
                            value = TOTFA_tag.TOTFAP1
                        },
                        quantity = new quantity
                        {
                            value = TOTFA_tag.TOTFAP10
                        },
                        validityPeriod = new validityPeriod
                        {
                            start = DateTime.Parse(TOTFA_tag.TOTFAP14).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                            end = DateTime.Parse(TOTFA_tag.TOTFAP15).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                        }

                    };
                }

                fa_med.category = new List<category>
                {
                    new category
                    {
                        text = "醫令調劑方式",
                        coding = new List<coding>
                        {
                            new coding
                            {
                                code = TOTFA_tag.TOTFAP2.ToString()//資料格式不同
    }
}
                    },
                     new category
                     {
                         text = "醫令類別",
                         coding = new List<coding>
                         {
                            new coding
                            {
                                code = TOTFA_tag.TOTFAP3.ToString()//資料格式不同
                            }
                        }

                     },
                     new category
                     {
                         text = "慢性病連續處方箋、同一療程及排程檢查案件註記",
                         coding = new List<coding>
                        {
                            new coding
                            {
                                code = TOTFA_tag.TOTFAP17
                            }
                        }
                     }

                };
                fa_med.medicationCodeableConcept = new medicationCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAP4

                        }
                    }
                };

                fa_med.dosageInstruction = new List<dosageInstruction>
                {
                    new dosageInstruction
                    {
                        doseAndRate = new List<doseAndRate>
                        {
                            new doseAndRate
                            {
                                doseQuantity = new doseQuantity
                                {
                                   value =  Convert.ToDouble(TOTFA_tag.TOTFAP5)//資料格式不同
                                }
                            }
                        },
                         timing = new timing
                         {
                            code = new code
                            {
                                coding = new List<coding>
                                {
                                    new coding
                                    {
                                        code = TOTFA_tag.TOTFAP7
                                    }
                                }
                            }
                         },
                          site = new site
                        {


                            coding = new List<coding>

                            {

                                new coding

                                {

                                    code = TOTFA_tag.TOTFAP9

                                }

                            }

                        }
                    }
                };
                fa_med.reasonCode = new List<reasonCode>
                {
                    new reasonCode
                    {
                        text = "診療之部位",
                        coding = new List<coding>
                        {
                            new coding
                            {
                                code = TOTFA_tag.TOTFAP6
                            }
                        }
                    }
                };
                fa_med.identifier = new List<identifier>
                {
                    new identifier
                    {

                                value = TOTFA_tag.TOTFAP13.ToString()//資料格式不同

                    }
                };
                fa_med.category = new List<category>
                {
                    new category
                    {
                        text="慢性病連續處方箋、同一療程及排程檢查案件註記"
                    }
                };
                medrequestlist.Add(fa_med);


                //condition_fa_c1
                fa_c1 = new Condition();
                fa_c1.id = Sha1Hash($"fa_c1-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                fa_c1.subject = new subject { reference = $"Patient/{pt.id}" };//57
                fa_c1.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//?52
                                                                                        //fa_c1.code.text = "主診斷代碼";
                fa_c1.code = new code
                {
                    text = "主診斷代碼"
                };
                //fa_c1.code.coding[0].code = TOTFA_tag.TOTFAD19;
                fa_c1.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAD19
                        }
                    }
                };

                //condition_fa_c2
                fa_c2 = new Condition();
                fa_c2.id = Sha1Hash($"fa_c2-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                fa_c2.subject = new subject { reference = $"Patient/{pt.id}" };//? 57
                fa_c2.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//?52
                                                                                        //fa_c2.code.text = "次診斷代碼(一)";
                fa_c2.code = new code
                {
                    text = "次診斷代碼(一)"
                };
                //fa_c2.code.coding[0].code = TOTFA_tag.TOTFAD20;
                fa_c2.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAD20
                        }
                    }
                };

                //condition_fa_c3
                fa_c3 = new Condition();
                fa_c3.id = Sha1Hash($"fa_c3-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                fa_c3.subject = new subject { reference = $"Patient/{pt.id}" };//57
                fa_c3.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//?52
                                                                                        //fa_c2.code.text = "次診斷代碼(二)";
                fa_c3.code = new code
                {
                    text = "次診斷代碼(二)"
                };
                //fa_c2.code.coding[0].code = TOTFA_tag.TOTFAD21;
                fa_c3.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAD21
                        }
                    }
                };

                //condition_fa_c4
                fa_c4 = new Condition();
                fa_c4.id = Sha1Hash($"fa_c4-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                fa_c4.subject = new subject { reference = $"Patient/{pt.id}" };//57
                fa_c4.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//?52
                                                                                        //fa_c4.code.text = "次診斷代碼(三)";
                fa_c4.code = new code
                {
                    text = "次診斷代碼(三)"
                };
                //fa_c4.code.coding[0].code = TOTFA_tag.TOTFAD22;
                fa_c4.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAD22
                        }
                    }
                };

                //condition_fa_c5
                fa_c5 = new Condition();
                fa_c5.id = Sha1Hash($"fa_c5-{TOTFA_tag.TOTFAT2}-{TOTFA_tag.TOTFAT3}-{TOTFA_tag.TOTFAD1}-{TOTFA_tag.TOTFAD2}-{TOTFA_tag.TOTFAP13}");
                fa_c5.subject = new subject { reference = $"Patient/{pt.id}" };//57
                fa_c5.encounter = new encounter { reference = $"Encounter/{fa_en.id}" };//?52
                                                                                        //fa_c5.code.text = "次診斷代碼(四)";
                fa_c5.code = new code
                {
                    text = "次診斷代碼(四)"
                };
                //fa_c5.code.coding[0].code = TOTFA_tag.TOTFAD23;
                fa_c5.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFA_tag.TOTFAD23
                        }
                    }
                };



            }
            bundle.entry = new List<entry>();
            var bundle_distinct = PatOrg_Distinct();
            var response_json_ditsint = await GetandShare_Block(bundle_distinct);
            var response_json_ditsinthapi = await GetandSharehapi_Block(bundle_distinct);
            var jsonobs = ObservationJSON();
            var jsonorg = OrganizationJSON();
            var jsonpro = ProcedureJSON();
            var jsonchar = ChargeItemJSON();
            //var jsonmed = MedicationAdministrationJSON();
            var jsoncon = ConditionJSON();
            var jsonpat = PatientJSON();
            var jsonenc = EncounterJSON();
            var jsonmedrequest = MedicationRequestJSON();
            //var bundlejson = BundleJSON();
            var bundlejson = BundleJSON_totfa();
            //var bundlehapijson = await GetandSharehapi_Block(bundlejson);
            var bundleIBMjson = await GetandShare_Block(bundlejson);
            //return await GetandShare_Block(bundlejson);
            return await GetandSharehapi_Block(bundlejson);
        }

        [HttpPost]
        public async Task<dynamic> TOTFB_JSON(List<OriginalJson.TOTFB> TOTFB_tags)
        {
            //開始分類
            int fhir_id = 0;//FHIR流水號
            foreach (var TOTFB_tag in TOTFB_tags)
            {
                //organization
                fb = new Organization();
                fb.id = Sha1Hash(TOTFB_tag.TOTFBT2.ToString());
                fb.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value = TOTFB_tag.TOTFBT2.ToString()
                    }
                };
                orglist.Add(fb);

                //Patient
                fb_pt = new Patient();
                fb_pt.id = Sha1Hash(TOTFB_tag.TOTFBD3);
                fb_pt.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=TOTFB_tag.TOTFBD3
                    }
                };
                fb_pt.birthDate = TOTFB_tag.TOTFBD6;
                patlist.Add(fb_pt);
                //enc
                fb_en = new Encounter();
                fb_en.id = Sha1Hash($"fb_en-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_en.status = "finished";
                fb_en.type = new List<type>
                {
                    new type
                    {

                      text = "案件分類",
                      coding=new List<coding>
                        {
                            new coding
                            {
                                code=TOTFB_tag.TOTFBD1.ToString()
                            }
                        }
                    },
                    new type
                    {
                        text = "Tw-DRG碼",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=TOTFB_tag.TOTFBD18
                            }
                        }
                    },
                    new type
                    {
                        text = "DRGs碼",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=TOTFB_tag.TOTFBD21
                            }
                        }
                    }
                };
                fb_en.@class = new @class
                {
                    system = "http://terminology.hl7.org/ValueSet/v3-ActEncounterCode",
                    code = "IMP",
                    display = "inpatient encounter"
                };
                fb_en.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=TOTFB_tag.TOTFBD2.ToString()
                    }
                };
                fb_en.subject = new subject { reference = $"Patient/{fb_pt.id}" };//?
                fb_en.serviceType = new serviceType
                {
                    text = "就醫科別",
                    coding = new List<coding>
                        {
                            new coding
                            {
                                code=TOTFB_tag.TOTFBD9
                            }
                        }
                };
                fb_en.period = new period
                {
                    start = DateTime.Parse(TOTFB_tag.TOTFBD10).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    end = DateTime.Parse(TOTFB_tag.TOTFBD11).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                };
                fb_en.hospitalization = new hospitalization
                {
                    dischargeDisposition = new dischargeDisposition
                    {
                        text = "轉歸代碼",
                        coding = new List<coding>
                        {
                            new coding
                            {
                                code=TOTFB_tag.TOTFBD24
                            }

                        }
                    }
                };
                enclist.Add(fb_en);

                //obeser
                fb_e_bed = new Observation();
                fb_e_bed.id = Sha1Hash($"fb_e_bed-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_e_bed.status = "final";
                fb_e_bed.subject = new subject { reference = $"Patient/{fb_pt.id}" };//?
                fb_e_bed.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//?
                fb_e_bed.code = new code
                {
                    text = "急性病床天數"
                };
                fb_e_bed.valueQuantity = new valueQuantity
                {
                    unit = "days",
                    system = "http://unitsofmeasure.org",
                    code = "d",
                    value = TOTFB_tag.TOTFBD14
                };
                obslist.Add(fb_e_bed);

                fb_s_bed = new Observation();
                fb_s_bed.id = Sha1Hash($"fb_s_bed-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_s_bed.status = "final";
                fb_s_bed.subject = new subject { reference = $"Patient/{fb_pt.id}" };//?
                fb_s_bed.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//?
                fb_s_bed.code = new code
                {
                    text = "慢性病床天數"
                };
                fb_s_bed.valueQuantity = new valueQuantity
                {
                    unit = "days",
                    system = "http://unitsofmeasure.org",
                    code = "d",
                    value = Convert.ToDouble(TOTFB_tag.TOTFBD15)
                };

                obslist.Add(fb_s_bed);
                //ChargeItem
                fb_ct = new ChargeItem();
                fb_ct.id = Sha1Hash($"fb_ct-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_ct.enteredDate = TOTFB_tag.TOTFBT3;
                //fb_ct.enteredDate = DateTime.Parse(TOTFB_tag.TOTFBT3).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                fb_ct.subject = new subject { reference = $"Patient/{fb_pt.id}" };//? 72
                fb_ct.status = "billed";
                //fb_ct.code.coding[0].code = TOTFB_tag.TOTFBT5
                fb_ct.code = new code
                {
                    coding = new List<coding>
                        {
                            new coding
                            {
                                code = TOTFB_tag.TOTFBT5.ToString()
                            }
                        }
                };
                fb_ct.occurrenceDateTime = DateTime.Parse(TOTFB_tag.TOTFBT6).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"); //TOTFB_tag.TOTFBT6;
                chalist.Add(fb_ct);

                //procedure
                fb_p1 = new Procedure();
                fb_p1.id = Sha1Hash($"fb_p1-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_p1.status = "completed";
                fb_p1.subject = new subject { reference = $"Patient/{fb_pt.id}" };//72
                fb_p1.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//71
                fb_p1.code = new code
                {
                    text = "主手術(處置)代碼",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFB_tag.TOTFBD45
                        }
                    }
                };
                prolist.Add(fb_p1);

                fb_p2 = new Procedure();
                fb_p2.id = Sha1Hash($"fb_p2-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_p2.status = "completed";
                fb_p2.subject = new subject { reference = $"Patient/{fb_pt.id}" };//72
                fb_p2.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//71
                fb_p2.code = new code
                {
                    text = "次手術(處置)代碼一",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFB_tag.TOTFBD46
                        }
                    }
                };
                prolist.Add(fb_p2);

                fb_p3 = new Procedure();
                fb_p3.id = Sha1Hash($"fb_p3-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_p3.status = "completed";
                fb_p3.subject = new subject { reference = $"Patient/{fb_pt.id}" };//72
                fb_p3.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//71
                fb_p3.code = new code
                {
                    text = "次手術(處置)代碼二",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFB_tag.TOTFBD47
                        }
                    }
                };
                prolist.Add(fb_p3);

                fb_p4 = new Procedure();
                fb_p4.id = Sha1Hash($"fb_p4-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_p4.status = "completed";
                fb_p4.subject = new subject { reference = $"Patient/{fb_pt.id}" };//72
                fb_p4.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//71
                fb_p4.code = new code
                {
                    text = "次手術(處置)代碼三",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFB_tag.TOTFBD48
                        }
                    }
                };
                prolist.Add(fb_p4);

                fb_p5 = new Procedure();
                fb_p5.id = Sha1Hash($"fb_p5-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_p5.status = "completed";
                fb_p5.subject = new subject { reference = $"Patient/{fb_pt.id}" };//72
                fb_p5.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//71
                fb_p5.code = new code
                {
                    text = "次手術(處置)代碼四",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFB_tag.TOTFBD49
                        }
                    }
                };
                prolist.Add(fb_p5);


                // Medcation---------------------------------//
                fb_med = new MedicationRequest();
                fb_med.id = Sha1Hash($"fb_med-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_med.status = "completed";
                fb_med.intent = "order";
                fb_med.subject = new subject { reference = $"Patient/{fb_pt.id}" };//72
                fb_med.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//71
                                                                                         //fb_med.identifier[0].value = TOTFB_tag.TOTFBP1.ToString();
                fb_med.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value = TOTFB_tag.TOTFBP1.ToString()
                    }
                };
                fb_med.category = new List<category>
                {
                    new category
                    {
                        text = "醫令類別",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code = TOTFB_tag.TOTFBP2.ToString()
                            }
                        }
                    }
                };
                fb_med.medicationCodeableConcept = new medicationCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFB_tag.TOTFBP3.ToString()
                        }
                    }
                };
                //fb_med.dosageInstruction[0].doseAndRate[0].doseQuantity[0].value = Convert.ToDouble(TOTFB_tag.TOTFBP5);
                fb_med.dosageInstruction = new List<dosageInstruction>
                {
                    new dosageInstruction
                    {
                        doseAndRate=new List<doseAndRate>
                        {
                            new doseAndRate
                            {
                                doseQuantity=new doseQuantity
                                {
                                    value = Convert.ToDouble(TOTFB_tag.TOTFBP5)
                                }
                            }
                        },
                        timing=new timing
                        {
                            code=new code
                            {
                                coding=new List<coding>
                                {
                                    new coding
                                    {
                                        code= TOTFB_tag.TOTFBP6
                                    }
                                }
                            }
                        },
                        site=new site
                        {
                            coding=new List<coding>
                            {
                                new coding
                                {
                                    code = TOTFB_tag.TOTFBP7
                                }
                            }
                        }
                    }
                };
                fb_med.performerType = new performerType
                {
                    text = "會診科別",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFB_tag.TOTFBP8
                        }
                    }
                };
                fb_med.dispenseRequest = new dispenseRequest
                {
                    validityPeriod = new validityPeriod
                    {
                        start = DateTime.Parse(TOTFB_tag.TOTFBP14).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        end = DateTime.Parse(TOTFB_tag.TOTFBP15).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                    },
                    quantity = new quantity
                    {
                        value = Convert.ToDouble(TOTFB_tag.TOTFBP16)
                    }
                };
                medrequestlist.Add(fb_med);


                //condition_fb_c1
                fb_c1 = new Condition();
                fb_c1.id = Sha1Hash($"fb_c1-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_c1.subject = new subject { reference = $"Patient/{fb_pt.id}" };//72
                fb_c1.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//71
                fb_c1.code = new code
                {
                    text = "主診斷",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFB_tag.TOTFBD25
                        }
                    }
                };
                conlist.Add(fb_c1);

                //condition_fb_c2
                fb_c2 = new Condition();
                fb_c2.id = Sha1Hash($"fb_c2-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_c2.subject = new subject { reference = $"Patient/{fb_pt.id}" };//72
                fb_c2.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//71
                                                                                        //fb_c2.code.text = "次診斷代碼(一)";
                fb_c2.code = new code
                {
                    text = "次診斷代碼(一)",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFB_tag.TOTFBD26
                        }
                    }
                };
                conlist.Add(fb_c2);

                //condition_fb_c3
                fb_c3 = new Condition();
                fb_c3.id = Sha1Hash($"fb_c3-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_c3.subject = new subject { reference = $"Patient/{fb_pt.id}" };//72
                fb_c3.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//71
                                                                                        //fb_c3.code.text = "次診斷代碼(二)";
                fb_c3.code = new code
                {
                    text = "次診斷代碼(二)",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFB_tag.TOTFBD27
                        }
                    }
                };
                conlist.Add(fb_c3);

                //condition_fb_c4
                fb_c4 = new Condition();
                fb_c4.id = Sha1Hash($"fb_c4-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_c4.subject = new subject { reference = $"Patient/{fb_pt.id}" };//72
                fb_c4.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//71
                                                                                        //fb_c4.code.text = "次診斷代碼(三)";
                fb_c4.code = new code
                {
                    text = "次診斷代碼(三)",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFB_tag.TOTFBD28
                        }
                    }
                };
                conlist.Add(fb_c4);

                //condition_fb_c5
                fb_c5 = new Condition();
                fb_c5.id = Sha1Hash($"fb_c5-{TOTFB_tag.TOTFBT2}-{TOTFB_tag.TOTFBT3}-{TOTFB_tag.TOTFBD1}-{TOTFB_tag.TOTFBD2}-{TOTFB_tag.TOTFBP1}");
                fb_c5.subject = new subject { reference = $"Patient/{fb_pt.id}" };//72
                fb_c5.encounter = new encounter { reference = $"Encounter/{fb_en.id}" };//71
                                                                                        //fb_c5.code.text = "次診斷代碼(四)";
                fb_c5.code = new code
                {
                    text = "次診斷代碼(四)",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = TOTFB_tag.TOTFBD29
                        }
                    }
                };
                conlist.Add(fb_c5);

            }
            bundle.entry = new List<entry>();
            var bundle_distinct = PatOrg_Distinct();
            var response_json_ditsint = await GetandShare_Block(bundle_distinct); //先送出pat和enc去server
            var response_json_ditsinthapi = await GetandSharehapi_Block(bundle_distinct);
            var jsonorg = OrganizationJSON();
            var jsonpro = ProcedureJSON();
            var jsonchar = ChargeItemJSON();
            //var jsonmed = MedicationAdministrationJSON();
            var jsoncon = ConditionJSON();
            var jsonpat = PatientJSON();
            var jsonenc = EncounterJSON();
            var jsonmedrequest = MedicationRequestJSON();
            var jsonobs = ObservationJSON();
            var bundlejson = BundleJSON_totfb();
            //var bundlehapijson = await GetandSharehapi_Block(bundlejson);
            var bundleIBMjson = await GetandShare_Block(bundlejson);
            //return await GetandShare_Block(bundlejson);
            return await GetandSharehapi_Block(bundlejson);
        }
        [HttpPost]
        public async Task<dynamic> spe_JSON(List<OriginalJson.spe> spe_tags)
        {
            //ViewBag.spe_tags = spe_tags;
            //開始分類
            //int fhir_id = 0;//FHIR流水號
            foreach (var spe_tag in spe_tags)
            {
                //Patient
                CPat = new Patient();
                CPat.id = Sha1Hash(spe_tag.biobankid.ToString());
                CPat.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=spe_tag.biobankid.ToString()
                    }
                };
                CPat.gender = spe_tag.gender;
                patlist.Add(CPat);


                //organization
                sp_og = new Organization();
                sp_og.id = Sha1Hash(spe_tag.org);
                sp_og.identifier = new List<identifier>
                {
                    new identifier
                    {
                       value = spe_tag.org
                    }
                };
                orglist.Add(sp_og);

                //Specimen
                Sp = new Specimen();
                Sp.id = Sha1Hash($"Sp-{spe_tag.biobankid}-{spe_tag.speid}");
                Sp.accessionIdentifier = new accessionIdentifier
                {
                    value = spe_tag.speid
                };
                Sp.status = "available";
                Sp.receivedTime = spe_tag.indate;
                Sp.collection = new collection
                {
                    collectedDateTime = spe_tag.takedate
                };
                Sp.type = new type
                {
                    text = "檢體類別",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = spe_tag.specategory
                        }
                    }
                };
                Sp.subject = new subject { reference = $"Patient/{CPat.id}" };//?
                Sp.collection = new collection
                {

                    quantity = new quantity
                    {

                        value = spe_tag.tube

                    },
                    collector = new collector
                    {

                        display = spe_tag.practitioner

                    }

                };
                Sp.note = new List<note>
                {
                    new note
                    {
                        text=spe_tag.diseasecategory
                    }
                };
                spelist.Add(Sp);





                //Consent
                Consent = new Consent();
                Consent.id = Sha1Hash($"Consent-{spe_tag.biobankid}-{spe_tag.speid}");
                Consent.dateTime = spe_tag.agreedate;
                Consent.status = "active";
                Consent.category = new List<category>
                {
                     new category
                        {
                         coding = new List<coding>
                         {
                             new coding
                             {
                                 code = "59284-0",
                                 system = "http://loinc.org",
                                 display = "Patient Consent"
                             }
                         }
                     }
                };
                Consent.scope = new scope
                {

                    coding = new List<coding>
                         {
                             new coding
                             {
                                 code = "patient-privacy",
                                 system = "http://terminology.hl7.org/CodeSystem/consentscope",
                                 display = "Privacy Consent"
                             }
                         }

                };
                Consent.patient = new patient { reference = $"Patient/{CPat.id}" };//?
                Consent.policyRule = new policyRule
                {

                    coding = new List<coding>
                         {
                             new coding
                             {
                                 code = "OPTIN",
                                 system = "http://terminology.hl7.org/CodeSystem/v3-ActCode"
                             }
                         }

                };
                consentlist.Add(Consent);

                //obeser
                sp_age = new Observation();
                sp_age.id = Sha1Hash($"sp_age-{spe_tag.biobankid}-{spe_tag.speid}");
                sp_age.status = "final";
                sp_age.subject = new subject { reference = $"Patient/{CPat.id}" };//559
                sp_age.performer = new List<performer> { new performer { reference = $"Organization/{sp_og.id}" } };//562
                sp_age.valueQuantity = new valueQuantity
                {
                    value = spe_tag.age
                };
                sp_age.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            system="http://loinc.org",
                            code="29553-5"
                        }
                    }
                };
                obslist.Add(sp_age);
                //
                sp_height = new Observation();
                sp_height.id = Sha1Hash($"sp_height-{spe_tag.biobankid}-{spe_tag.speid}");
                sp_height.status = "final";
                sp_height.subject = new subject { reference = $"Patient/{CPat.id}" };//559
                sp_height.performer = new List<performer> { new performer { reference = $"Organization/{sp_og.id}" } };//562
                sp_height.valueQuantity = new valueQuantity
                {
                    value = spe_tag.heigh,
                    system = "http://unitsofmeasure.org",
                    code = "cm",
                    unit = "cm"
                };
                sp_height.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            system="http://loinc.org",
                            code="8302-2"
                        }
                    }
                };
                obslist.Add(sp_height);
                //
                sp_weight = new Observation();
                sp_weight.id = Sha1Hash($"sp_weight-{spe_tag.biobankid}-{spe_tag.speid}");
                sp_weight.status = "final";
                sp_weight.subject = new subject { reference = $"Patient/{CPat.id}" };//559
                sp_weight.performer = new List<performer> { new performer { reference = $"Organization/{sp_og.id}" } };//562
                sp_weight.valueQuantity = new valueQuantity
                {
                    value = spe_tag.weight,
                    system = "http://unitsofmeasure.org",
                    code = "kg",
                    unit = "kg"
                };
                sp_weight.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            system="http://loinc.org",
                            code="29463-7"
                        }
                    }
                };
                obslist.Add(sp_weight);

            }
            bundle.entry = new List<entry>();
            var bundle_distinct = PatOrg_Distinct();
            var response_json_ditsint = await GetandShare_Block(bundle_distinct);
            var response_json_ditsinthapi = await GetandSharehapi_Block(bundle_distinct);
            var jsonobs = ObservationJSON();
            var jsonorg = OrganizationJSON();
            //var jsonpro = ProcedureJSON();
            //var jsonchar = ChargeItemJSON();
            //var jsonmed = MedicationAdministrationJSON();
            //var jsoncon = ConditionJSON();
            var jsonpat = PatientJSON();
            var jsonspet = SpecimenJSON();
            var jsonconsent = ConsentJSON();
            var bundlejson = BundleJSON_spe_JSON();
            //var bundlehapijson = await GetandSharehapi_Block(bundlejson);
            var bundleIBMjson = await GetandShare_Block(bundlejson);
            //return await GetandShare_Block(bundlejson);
            return await GetandSharehapi_Block(bundlejson);
        }


        [HttpPost]
        public async Task<dynamic> CRLF_JSON(List<OriginalJson.CRLF> CRLF_tags)
        {
            //string jsonString = r.ReadToEnd();
            //var CRLF_tags = JsonConvert.DeserializeObject<List<OriginalJson.CRLF>>(jsonString);//將JSON格式轉換成物件
            //ViewBag.CRLF_tags = CRLF_tags;
            //開始分類
            int fhir_id = 0;//FHIR流水號
            foreach (var CRLF_tag in CRLF_tags)
            {
                //org
                OG = new Organization();
                OG.id = Sha1Hash(CRLF_tag.hospid);
                //OG.identifier[0].value = CRLF_tag.hospid;
                OG.identifier = new List<identifier>
                {
                    new identifier
                    {

                        value = CRLF_tag.hospid

                    }
                };
                orglist.Add(OG);


                //Patient
                Pat = new Patient();
                Pat.id = Sha1Hash(CRLF_tag.id);
                Pat.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value=CRLF_tag.id
                    },
                    new identifier
                    {
                        value = "Cancer Patient",
                        system="https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                }
               ;
                Pat.gender = CRLF_tag.sex;
                Pat.birthDate = CRLF_tag.dbirth;
                Pat.address = new List<address>
                {
                    new address
                    {
                        postalCode = CRLF_tag.resid
                    }
                };
                Pat.deceasedBoolean = Boolean.Parse(CRLF_tag.vstatus);
                patlist.Add(Pat);

                //Procedure
                //diag
                diag = new Procedure();
                diag.id = Sha1Hash($"diag-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                diag.status = "completed";
                diag.subject = new subject { reference = $"Patient/{Pat.id}" };//?
                                                                               //diag.performedDateTime = CRLF_tag.dsdiag;
                if (CRLF_tag.dsdiag == null)
                {
                    //diag.performedDateTime = CRLF_tag.dsdiag;
                    diag.performedDateTime = DateTime.Parse(CRLF_tag.dsdiag).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                }
                else if (CRLF_tag.dsdiag != null)
                {
                    //diag.performedDateTime = CRLF_tag.dsdiag;
                    diag.performedDateTime = DateTime.Parse(CRLF_tag.dsdiag).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");


                }
                diag.reasonCode = new List<reasonCode>
                {
                    new reasonCode
                    {
                        text = "外院診斷性及分期性手術處置",
                        coding = new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.sdiag_o
                            }
                        }
                    }
                };
                diag.code = new code
                {
                    text = "申報醫院診斷性及分期性手術處置",
                    coding = new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.sdiag_h
                            }
                        }
                };
                prolist.Add(diag);



                //P1
                P1 = new Procedure();
                P1.id = Sha1Hash($"P1-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                P1.identifier = new List<identifier>
                {
                    new identifier
                    {

                        value = "Cancer-Related Surgical Procedure",
                        system = "https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                P1.status = "completed";
                P1.subject = new subject { reference = $"Patient/{Pat.id}" };
                if (CRLF_tag.dop_mds == null)
                {
                    //P1.performedDateTime = CRLF_tag.dop_mds;
                    P1.performedDateTime = DateTime.Parse(CRLF_tag.dop_mds).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                }
                else if (CRLF_tag.dop_mds != null)
                {
                    //P1.performedDateTime = CRLF_tag.dop_mds;
                    P1.performedDateTime = DateTime.Parse(CRLF_tag.dop_mds).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                }
                P1.reasonCode = new List<reasonCode>
                {
                    new reasonCode
                    {
                        text = "外院原發部位手術方式",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.optype_o
                            }
                        }
                    }
                };
                P1.code = new code
                {
                    text = "申報醫院原發部位手術方式",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.optype_h
                        }
                    }
                };
                P1.category = new category
                {                    
                    coding = new List<coding>
                    {
                        new coding
                        {
                            userSelected=false,
                            display="Surgical procedure",
                            code="387713003",
                            system = "http://snomed.info/sct"
                        },
                        new coding
                        {
                            userSelected=true,
                            display="微創手術",
                            code=CRLF_tag.misurgery
                        }
                    }
                };
                P1.outcome = new outcome
                {
                    text = "原發部位手術邊緣",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.smargin
                        }
                     }
                };
                P1.note = new List<note>
                {
                    new note
                    {
                        text = CRLF_tag.smargin_d
                    }
                };
                P1.statusReason = new statusReason
                {
                    text = "原發部位未手術原因",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.noop
                        }
                    }
                };
                prolist.Add(P1);



                //P2
                P2 = new Procedure();
                P2.id = Sha1Hash($"P2-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                P2.identifier = new List<identifier>
                {
                    new identifier
                    {

                        value = "Cancer-Related Surgical Procedure",
                        system = "https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                P2.status = "completed";
                P2.subject = new subject { reference = $"Patient/{Pat.id}" };//?
                P2.reasonCode = new List<reasonCode>
                {
                    new reasonCode
                    {
                        text = "外院區域淋巴結手術範圍",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.opln_o
                            }
                        }
                    }
                };
                P2.code = new code
                {
                    text = "申報醫院區域淋巴結手術範圍",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.opln_h
                        }
                    }
                };
                prolist.Add(P2);




                //P3
                P3 = new Procedure();
                P3.id = Sha1Hash($"P3-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                P3.identifier = new List<identifier>
                {
                    new identifier
                    {

                        value = "Cancer-Related Surgical Procedure",
                        system = "https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                P3.status = "completed";
                P3.subject = new subject { reference = $"Patient/{Pat.id}" };//?
                P3.reasonCode = new List<reasonCode>
                {
                    new reasonCode
                    {
                        text = "外院其他部位手術方式",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.opother_o
                            }
                        }
                    }
                };
                P3.code = new code
                {
                    text = "申報醫院其他部位手術方式",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.opother_h
                        }
                    }
                };
                prolist.Add(P3);



                //Radio1
                Radio1 = new Procedure();
                Radio1.id = Sha1Hash($"Radio1-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                Radio1.identifier = new List<identifier>
                {
                    new identifier
                    {

                        value = "Radiotherapy Course Summary",
                        system = "https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                Radio1.status = "completed";
                Radio1.subject = new subject { reference = $"Patient/{Pat.id}" };//?
                Radio1.outcome = new outcome
                {
                    text = "放射治療臨床標靶體積摘要",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.rtsumm
                        }
                    }
                };
                Radio1.focalDevice = new List<focalDevice>
                {
                    new focalDevice
                    {
                        manipulated=new manipulated
                        {
                            display = "放射治療儀器"
                        },
                        action=new action
                        {
                            text = "放射治療儀器",
                            coding=new List<coding>
                            {
                                new coding
                                {
                                    code = CRLF_tag.rtmodal
                                }
                            }
                        }
                    },
                    new focalDevice
                    {
                        manipulated=new manipulated
                        {
                            display = "其他放射治療儀器"
                        },
                        action=new action
                        {
                            text = "其他放射治療儀器",
                            coding=new List<coding>
                            {
                                new coding
                                {
                                    code = CRLF_tag.ort_modal
                                }
                            }
                        }
                    }
                };
                //Radio1.performedPeriod = new performedPeriod
                //{
                //    //start = CRLF_tag.drt_1st,
                //    start = DateTime.Parse(CRLF_tag.drt_1st).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                //    end = DateTime.Parse(CRLF_tag.drt_end).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")

                //    //end = CRLF_tag.drt_end
                //};



                if (CRLF_tag.drt_1st == null || CRLF_tag.drt_end == null)
                    Radio1.performedPeriod = new performedPeriod
                    {
                        //start = CRLF_tag.dsyt,
                        //end = CRLF_tag.dchem
                        start = DateTime.Parse(CRLF_tag.drt_1st).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        end = DateTime.Parse(CRLF_tag.drt_end).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")

                    };
                else if (CRLF_tag.drt_1st != null || CRLF_tag.drt_end != null)
                    Radio1.performedPeriod = new performedPeriod
                    {
                        //start = CRLF_tag.dsyt,
                        //end = CRLF_tag.dchem
                        start = DateTime.Parse(CRLF_tag.drt_1st).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        end = DateTime.Parse(CRLF_tag.drt_end).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                    };








                Radio1.code = new code
                {                    
                    coding = new List<coding>
                    {
                        new coding
                        {
                            display="Radiotherapy Course of Treatment (regime/therapy)",
                            userSelected=false,
                            code = "USCRS-33529"
                        },
                        new coding
                        {
                            display="放射治療與手術順序",
                            userSelected=true,
                            code = CRLF_tag.rtstatus
                        }
                    }
                };

                Radio1.statusReason = new statusReason
                {
                    text = "放射治療執行狀態",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.rtstatus
                        }
                    }
                };
                Radio1.extension = new List<extension>
                {
                    new extension//0
                    {
                        url = "http://hl7.org/fhir/us/mcode/StructureDefinition/mcode-radiotherapy-modality-and-technique",
                        extension1=new List<extension1>
                        {
                            new extension1//00
                            {
                                url = "http://hl7.org/fhir/us/mcode/StructureDefinition/mcode-radiotherapy-modality",
                                valueCodeableConcept= new valueCodeableConcept
                                {
                                    text = "體外放射治療技術",
                                    coding=new List<coding>
                                    {
                                        new coding
                                        {
                                            code = CRLF_tag.ebrt
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new extension//1
                    {
                        url = "http://hl7.org/fhir/us/mcode/StructureDefinition/mcode-radiotherapy-dose-delivered-to-volume",
                        extension1=new List<extension1>//*1
                        {
                            new extension1//10
                            {
                                url = "volume",
                                valueReference=new valueReference
                                {
                                    display = "最高放射劑量臨床標靶體積",
                                    reference = CRLF_tag.rth
                                }
                            },
                            new extension1//11
                            {
                                url = "totalDoseDelivered",
                                valueQuantity=new valueQuantity
                                    {
                                        system = "最高放射劑量臨床標靶體積劑量",
                                        value = Convert.ToDouble(CRLF_tag.rth_dose)
                                    }
                            },
                            new extension1//12
                            {
                                url = "fractionsDelivered",
                                valueUnsignedInt= Convert.ToInt32(CRLF_tag.rth_nf)
                            }

                        }
                    },
                    new extension//*2
                    {
                        url = "http://hl7.org/fhir/us/mcode/StructureDefinition/mcode-radiotherapy-dose-delivered-to-volume",
                        extension1=new List<extension1>
                        {
                            new extension1//20
                            {
                                url = "volume",
                                valueReference=new valueReference
                                {
                                    display = "較低放射劑量臨床標靶體積",
                                    reference = CRLF_tag.rtl
                                }
                            },
                            new extension1//21
                            {
                                url = "totalDoseDelivered",
                                valueQuantity=new valueQuantity
                                {
                                    system = "較低放射劑量臨床標靶體積劑量",
                                    value = Convert.ToDouble(CRLF_tag.rtl_dose)
                                }
                            },
                            new extension1//22
                            {
                                url = "fractionsDelivered",
                                valueUnsignedInt=Convert.ToInt32(CRLF_tag.rtl_nf)
                            }
                        }
                    },
                    new extension//*3
                    {
                        url = "http://hl7.org/fhir/us/mcode/StructureDefinition/mcode-radiotherapy-modality-and-technique",
                        extension1=new List<extension1>
                        {
                            new extension1//30
                            {
                                url = "http://hl7.org/fhir/us/mcode/StructureDefinition/mcode-radiotherapy-modality",
                                valueCodeableConcept=new valueCodeableConcept
                                {
                                    text = "其他放射治療技術",
                                    coding=new List<coding>
                                    {
                                        new coding
                                        {
                                            code = CRLF_tag.ort_tech
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new extension//*4
                    {
                        url = "http://hl7.org/fhir/us/mcode/StructureDefinition/mcode-radiotherapy-dose-delivered-to-volume",
                        extension1=new List<extension1>
                        {
                            new extension1//40
                            {
                                url = "volume",
                                valueReference =new valueReference
                                {
                                    display = "其他放射治療臨床標靶體積",
                                    reference = CRLF_tag.ort
                                }
                            },
                            new extension1//41
                            {
                                url = "totalDoseDelivered",
                                valueQuantity=new valueQuantity
                                {
                                    system = "其他放射治療臨床標靶體積劑量",
                                    value = Convert.ToDouble(CRLF_tag.ort_dose)
                                }
                            },
                            new extension1//42
                            {
                                url = "fractionsDelivered",
                                valueUnsignedInt= Convert.ToInt32(CRLF_tag.ort_nf)
                            }
                        }

                    }
                };
                prolist.Add(Radio1);
                var json = JsonConvert.SerializeObject(Radio1);


                //M1
                M1 = new Procedure();
                M1.id = Sha1Hash($"M1-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                M1.status = "completed";
                M1.subject = new subject { reference = $"Patient/{Pat.id}" };//?
                if (CRLF_tag.dsyt == null || CRLF_tag.dchem == null)
                    M1.performedPeriod = new performedPeriod
                    {
                        //start = CRLF_tag.dsyt,
                        //end = CRLF_tag.dchem
                        start = DateTime.Parse(CRLF_tag.dsyt).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        end = DateTime.Parse(CRLF_tag.dchem).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")

                    };
                else if (CRLF_tag.dchem != null || CRLF_tag.dsyt != null)
                    M1.performedPeriod = new performedPeriod
                    {
                        //start = CRLF_tag.dsyt,
                        //end = CRLF_tag.dchem
                        start = DateTime.Parse(CRLF_tag.dsyt).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        end = DateTime.Parse(CRLF_tag.dchem).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")
                    };

                M1.reasonCode = new List<reasonCode>
                {
                    new reasonCode
                    {
                        text = "外院化學治療",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.chem_o
                            }
                        }
                    }
                };
                M1.code = new code
                {
                    text = "申報醫院化學治療",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.chem_h
                        }
                    }
                };
                prolist.Add(M1);



                //m4
                m4 = new Procedure();
                m4.id = Sha1Hash($"m4-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                m4.status = "completed";
                m4.subject = new subject { reference = $"Patient/{Pat.id}" };//?
                m4.code = new code
                {
                    text = "骨髓/幹細胞移植或內分泌處置",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.htep_h
                        }
                    }
                };

                //m4.performedDateTime = CRLF_tag.dhtep;
                m4.performedDateTime = DateTime.Parse(CRLF_tag.dhtep).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                prolist.Add(m4);


                //m7
                m7 = new Procedure();
                m7.id = Sha1Hash($"m7-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                m7.status = "completed";
                m7.subject = new subject { reference = $"Patient/{Pat.id}" };//?
                m7.code = new code
                {
                    text = "其他治療",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.other
                        }
                    }
                };
                //m7.performedDateTime = CRLF_tag.dother;
                m7.performedDateTime = DateTime.Parse(CRLF_tag.dother).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                prolist.Add(m7);

                //condition_Con
                Con = new Condition();
                Con.id = Sha1Hash($"Con-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                Con.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value = "Primary Cancer Condition",
                        system="https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                Con.subject = new subject { reference = $"Patient/{Pat.id}" };
                Con.onsetAge = new onsetAge
                {
                    unit = "years",
                    system = "http://unitsofmeasure.org",
                    code = "a",
                    value = Convert.ToDouble(CRLF_tag.age)
                };

                //Con.onsetString = CRLF_tag.sequence;

                Sp.note = new List<note>
                {
                    new note
                    {
                        text=CRLF_tag.sequence
                    }
                };

                Con.category = new List<category>
                {
                    new category
                    {
                        text = "個案分類",
                         coding = new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.@class
                            }
                        }
                    },
                    new category
                    {
                        text = "診斷狀態分類",
                         coding = new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.class_d
                            }
                        }
                    },
                    new category
                    {
                        text = "治療狀態分類",
                        coding = new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.class_t
                            }
                        }
                    }
                };
                Con.recordedDate = CRLF_tag.dcont;
                Con.extension = new List<extension>
                {
                    new extension
                    {
                        url = "http://hl7.org/fhir/StructureDefinition/condition-assertedDate",
                        valueDateTime =  CRLF_tag.didiag
            }
                };
                Con.bodySite = new List<bodySite>
                {
                    new bodySite
                    {
                        text = "原發部位",
                         coding = new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.site
                            }
                        }
                    },
                    new bodySite
                    {
                        text = "側性",
                         coding = new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.lateral
                            }
                        }
                    }
                };
                Con.evidence = new List<evidence>
                {
                    new evidence
                    {
                        code = new List<code>
                        {
                            new code
                            {
                                text = "組織類型",
                                coding=new List<coding>
                                {
                                    new coding
                                    {
                                        code = CRLF_tag.hist

                                    }
                                }
                            },
                             new code
                            {
                                text = "性態碼",
                                coding=new List<coding>
                                {
                                    new coding
                                    {
                                        code = CRLF_tag.behavior

                                    }
                                }
                            }
                        }
                    }
                };
                Con.stage = new List<stage>
                {
                    new stage
                    {
                        summary = new summary
                        {
                            text = "臨床分級/分化",
                            coding=new List<coding>
                            {
                                new coding
                                {
                                    code = CRLF_tag.grade_c

                                }
                            }
                        }
                    },
                    new stage
                    {
                        summary = new summary
                        {
                           text = "病理分級/分化",
                           coding=new List<coding>
                            {
                                new coding
                                {
                                    code = CRLF_tag.grade_p

                                }
                            }
                        }
                    }
                };
                conlist.Add(Con);


                //condition-SCC
                SCC = new Condition();
                SCC.id = Sha1Hash($"SCC-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                SCC.recordedDate = CRLF_tag.drecur;
                SCC.identifier = new List<identifier>
                {
                    new identifier
                    {

                        value = "Secondary Cancer Condition",
                        system = "https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                SCC.subject = new subject { reference = $"Patient/{Pat.id}" };
                SCC.extension = new List<extension>
                {
                    new extension
                    {
                        url = "http://hl7.org/fhir/StructureDefinition/condition-related",
                        valueReference = new valueReference
                        {
                            reference = $"Condition/{Con.id}"
                        }
                    }
                };
                SCC.code = new code
                {
                    text = "首次復發型式",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.recur
                        }
                    }
                };
                conlist.Add(SCC);

                //chargeitem
                m6 = new ChargeItem();
                m6.id = Sha1Hash($"m6-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                m6.status = "billed";
                m6.subject = new subject { reference = $"Patient/{Pat.id}" };
                m6.code = new code
                {
                    text = "申報醫院緩和照護",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.palli_h
                        }
                    }
                };
                chalist.Add(m6);
                //chalist.add(m6)之後

                //Procedure-m2
                m2 = new Procedure();
                m2.id = Sha1Hash($"m2-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                m2.status = "completed";
                m2.subject = new subject { reference = $"Patient/{Pat.id}" };
                m2.reasonCode = new List<reasonCode>
                {
                    new reasonCode
                    {
                         text = "外院荷爾蒙/類固醇治療",
                         coding = new List<coding>
                         {
                            new coding
                            {
                                code = CRLF_tag.horm_o
                            }
                         }
                    }
                };
                m2.code = new code
                {
                    text = "申報醫院荷爾蒙/類固醇治療",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.horm_h
                        }
                    }
                };
                //m2.performedDateTime = CRLF_tag.dhorm;
                m2.performedDateTime = DateTime.Parse(CRLF_tag.dhorm).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                prolist.Add(m2);


                //Procedure-m3
                m3 = new Procedure();
                m3.id = Sha1Hash($"m3-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                m3.status = "completed";
                m3.subject = new subject { reference = $"Patient/{Pat.id}" };
                m3.reasonCode = new List<reasonCode>
                {
                    new reasonCode
                    {
                       text = "外院免疫治療",
                        coding = new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.immu_o
                            }
                        }
                    }
                };
                m3.code = new code
                {
                    text = "申報醫院免疫治療",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.immu_h
                        }
                    }
                };
                //m3.performedDateTime = CRLF_tag.dimmu;
                m3.performedDateTime = DateTime.Parse(CRLF_tag.dimmu).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                prolist.Add(m3);


                //Procedure-m5
                m5 = new Procedure();
                m5.id = Sha1Hash($"m5-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                m5.status = "completed";
                m5.subject = new subject { reference = $"Patient/{Pat.id}" };
                m5.reasonCode = new List<reasonCode>
                {
                    new reasonCode
                    {
                        text = "外院標靶治療",
                        coding = new List<coding>
                        {
                            new coding
                            {
                                code = CRLF_tag.target_o
                            }
                        }
                    }
                };
                m5.code = new code
                {
                    text = "申報醫院標靶治療",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.target_h
                        }
                    }
                };
                //m5.performedDateTime = CRLF_tag.dtarget;
                m5.performedDateTime = DateTime.Parse(CRLF_tag.dtarget).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

                prolist.Add(m5);

                //Observation
                TS = new Observation();
                TS.id = Sha1Hash($"TS-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                TS.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value = "Tumor Size",
                        system="https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                TS.subject = new subject { reference = $"Patient/{Pat.id}" };
                TS.status = "final";
                TS.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            system="http://loinc.org",
                            code="21889-1"
                        }
                    }
                };
                TS.method = new method
                {
                    coding = new List<coding>
                        {
                            new coding
                            {
                                code=CRLF_tag.confirm

                            }
                        },
                    text = "癌症確診方式"
                };
                if (CRLF_tag.dmconf == null)
                {
                    TS.effectiveDateTime = CRLF_tag.dmconf;
                }
                else if (CRLF_tag.dmconf != null)
                {
                    TS.effectiveDateTime = CRLF_tag.dmconf;

                }
                TS.component = new List<component>
                {
                    new component
                    {
                        code = new code
                        {
                            coding= new List<coding>
                            {
                                new coding
                                {
                                    code="33729-5",
                                    system="http://loinc.org"
                                }
                            },
                            text="腫瘤大小"
                        },
                        valueQuantity = new valueQuantity
                        {
                            system="http://hl7.org/fhir/us/mcode/ValueSet/mcode-tumor-size-units-vs",
                            code="mm",
                            unit="mm",
                            value=Convert.ToDouble(CRLF_tag.size)
                        }
                    }
                };
                obslist.Add(TS);
                //
                pni = new Observation();
                pni.id = Sha1Hash($"pni-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                pni.subject = new subject { reference = $"Patient/{Pat.id}" };
                pni.status = "final";
                pni.code = new code
                {
                    text = "神經侵襲"
                };
                pni.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.pni
                        }
                    }
                };
                obslist.Add(pni);

                lvi = new Observation();
                lvi.id = Sha1Hash($"lvi-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                lvi.subject = new subject { reference = $"Patient/{Pat.id}" };
                lvi.status = "final";
                lvi.code = new code
                {
                    text = "淋巴管或血管侵犯"
                };
                lvi.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.lvi
                        }
                    }
                };
                obslist.Add(lvi);

                nexam = new Observation();
                nexam.id = Sha1Hash($"nexam-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                nexam.status = "final";
                nexam.subject = new subject { reference = $"Patient/{Pat.id}" };
                nexam.code = new code
                {
                    text = "區域淋巴結檢查數目"
                };
                nexam.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.nexam
                        }
                    }
                };
                obslist.Add(nexam);

                nposit = new Observation();
                nposit.id = Sha1Hash($"nposit-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                nposit.status = "final";
                nposit.subject = new subject { reference = $"Patient/{Pat.id}" };
                nposit.code = new code
                {
                    text = "區域淋巴結侵犯數目"
                };
                nposit.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.nposit
                        }
                    }
                };
                obslist.Add(nposit);

                clinical_T = new Observation();
                clinical_T.id = Sha1Hash($"clinical_T-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                clinical_T.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value = "Primary Tumor(T) Category",
                        system="https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                clinical_T.status = "final";
                clinical_T.subject = new subject { reference = $"Patient/{Pat.id}" };
                clinical_T.focus = new List<focus> { new focus { reference = $"Condition/{Con.id}" } };
                clinical_T.code = new code
                {
                    text = "臨床T",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code="21905-5"
                        }
                    }
                };
                clinical_T.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.ct
                        }
                    }
                };
                clinical_T.category = new List<category>
                {
                    new category
                    {
                        text="AJCC癌症分期版本與章節",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=CRLF_tag.ajcc_ed
                            }
                        }
                    }
                };
                obslist.Add(clinical_T);

                clinical_N = new Observation();
                clinical_N.id = Sha1Hash($"clinical_N-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                clinical_N.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value = "Regional Nodes(N) Category",
                        system="https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                clinical_N.status = "final";
                clinical_N.subject = new subject { reference = $"Patient/{Pat.id}" };
                clinical_N.focus = new List<focus> { new focus { reference = $"Condition/{Con.id}" } };
                clinical_N.code = new code
                {
                    text = "臨床N",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code="21906-3"
                        }
                    }
                };
                clinical_N.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.cn
                        }
                    }
                };
                clinical_N.category = new List<category>
                {
                    new category
                    {
                        text="AJCC癌症分期版本與章節",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=CRLF_tag.ajcc_ed
                            }
                        }
                    }
                };
                obslist.Add(clinical_N);

                clinical_M = new Observation();
                clinical_M.id = Sha1Hash($"clinical_M-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                clinical_M.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value = "Distant Metastases(M) Category",
                        system="https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                clinical_M.status = "final";
                clinical_M.subject = new subject { reference = $"Patient/{Pat.id}" };
                clinical_M.focus = new List<focus> { new focus { reference = $"Condition/{Con.id}" } };
                clinical_M.code = new code
                {
                    text = "臨床M",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code="21907-1"
                        }
                    }
                };
                clinical_M.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.cm
                        }
                    }
                };
                clinical_M.category = new List<category>
                {
                    new category
                    {
                        text="AJCC癌症分期版本與章節",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=CRLF_tag.ajcc_ed
                            }
                        }
                    }
                };
                obslist.Add(clinical_M);

                CG_clinical = new Observation();
                CG_clinical.id = Sha1Hash($"CG_clinical-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                CG_clinical.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value = "Stage Group",
                        system="https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                CG_clinical.status = "final";
                CG_clinical.subject = new subject { reference = $"Patient/{Pat.id}" };
                CG_clinical.focus = new List<focus> { new focus { reference = $"Condition/{Con.id}" } };
                CG_clinical.hasMember = new List<hasMember>
                {
                    new hasMember
                    {
                        reference=$"Observation/{clinical_T.id}"
                    },
                    new hasMember
                    {
                        reference=$"Observation/{clinical_N.id}"
                    },
                    new hasMember
                    {
                        reference=$"Observation/{clinical_M.id}"
                    }
                };
                CG_clinical.code = new code
                {
                    text = "臨床期別組合"
                };
                CG_clinical.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.cstage
                        }
                    }
                };

                CG_clinical.component = new List<component>
                {
                    new component
                    {
                        code = new code
                        {
                            text="臨床分期字根/字首"
                        },
                        valueCodeableConcept = new valueCodeableConcept
                        {
                            coding=new List<coding>
                            {
                                new coding
                                {
                                    code=CRLF_tag.cdescr
                                }
                            }
                        }
                    }
                };
                obslist.Add(CG_clinical);

                pathology_T = new Observation();
                pathology_T.id = Sha1Hash($"pathology_T-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                pathology_T.identifier = new List<identifier>
                {
                    new identifier
                    {
                        value = "Primary Tumor(T) Category",
                        system="https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                pathology_T.status = "final";
                pathology_T.subject = new subject { reference = $"Patient/{Pat.id}" };
                pathology_T.focus = new List<focus> { new focus { reference = $"Condition/{Con.id}" } };
                pathology_T.code = new code
                {
                    text = "病理T",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code="21899-0"
                        }
                    }
                };
                pathology_T.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.pt
                        }
                    }
                };
                pathology_T.category = new List<category>
                {
                    new category
                    {
                        text="AJCC癌症分期版本與章節",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=CRLF_tag.ajcc_ed
                            }
                        }
                    }
                };
                obslist.Add(pathology_T);

                pathology_N = new Observation();
                pathology_N.id = Sha1Hash($"pathology_N-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                pathology_N.identifier = new List<identifier>
                {
                    new identifier
                    {

                        value = "Regional Nodes(N) Category",
                        system = "https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                pathology_N.status = "final";
                pathology_N.subject = new subject { reference = $"Patient/{Pat.id}" };
                pathology_N.focus = new List<focus> { new focus { reference = $"Condition/{Con.id}" } };
                pathology_N.code = new code
                {
                    text = "病理N",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code="21900-6"
                        }
                    }
                };
                pathology_N.valueCodeableConcept = new valueCodeableConcept
                {

                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.pn
                        }
                    }
                };
                pathology_N.category = new List<category>
                {
                    new category
                    {
                        text="AJCC癌症分期版本與章節",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=CRLF_tag.ajcc_ed
                            }
                        }
                    }
                };
                obslist.Add(pathology_N);

                pathology_M = new Observation();
                pathology_M.id = Sha1Hash($"pathology_M-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                pathology_M.identifier = new List<identifier>
                {
                    new identifier
                    {

                        value = "Distant Metastases(M) Category",
                        system = "https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                pathology_M.status = "final";
                pathology_M.subject = new subject { reference = $"Patient/{Pat.id}" };
                pathology_M.focus = new List<focus> { new focus { reference = $"Condition/{Con.id}" } };
                pathology_M.code = new code
                {
                    text = "病理M",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code="21901-4"
                        }
                    }
                };
                pathology_M.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.pm
                        }
                    }
                };
                pathology_M.category = new List<category>
                {
                    new category
                    {
                        text="AJCC癌症分期版本與章節",
                        coding=new List<coding>
                        {
                            new coding
                            {
                                code=CRLF_tag.ajcc_ed
                            }
                        }
                    }
                };
                obslist.Add(pathology_M);

                CG_pathology = new Observation();
                CG_pathology.id = Sha1Hash($"CG_pathology-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                CG_pathology.identifier = new List<identifier>
                {
                    new identifier
                    {

                        value = "Stage Group",
                        system = "https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                CG_pathology.status = "final";
                CG_pathology.focus = new List<focus> { new focus { reference = $"Condition/{Con.id}" } };
                CG_pathology.subject = new subject { reference = $"Patient/{Pat.id}" };
                CG_pathology.hasMember = new List<hasMember>
                {
                    new hasMember
                    {
                        reference = $"Observation/{pathology_T.id}"
                    },
                    new hasMember
                    {
                        reference = $"Observation/{pathology_N.id}"
                    },
                    new hasMember
                    {
                        reference = $"Observation/{pathology_M.id}"
                    }

                };
                CG_pathology.code = new code
                {
                    text = "病理期別組合"
                };
                CG_pathology.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.pstage
                        }
                    }
                };
                //
                CG_pathology.component = new List<component>
                {
                    new component
                    {
                        code = new code
                        {
                             text="病理分期字根/字首"
                        },
                        valueCodeableConcept = new valueCodeableConcept
                        {
                            coding=new List<coding>
                            {
                                new coding
                                {
                                    code=CRLF_tag.pdescr
                                }
                            }
                        }
                    }
                };
                obslist.Add(CG_pathology);

                CG_OtherC = new Observation();
                CG_OtherC.id = Sha1Hash($"CG_OtherC-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                CG_OtherC.identifier = new List<identifier>
                {
                    new identifier
                    {

                        value = "Stage Group",
                        system = "https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                CG_OtherC.code = new code
                {
                    text = "其他分期系統",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.ostage
                        }
                    }
                };
                CG_OtherC.status = "final";
                CG_OtherC.subject = new subject { reference = $"Patient/{Pat.id}" };
                CG_OtherC.valueCodeableConcept = new valueCodeableConcept
                {
                    text = "其他分期系統期別(臨床分期)",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.ostagec
                        }
                    }
                };
                obslist.Add(CG_OtherC);

                CG_OtherP = new Observation();
                CG_OtherP.id = Sha1Hash($"CG_OtherP-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                CG_OtherP.identifier = new List<identifier>
                {
                    new identifier
                    {

                        value = "Stage Group",
                        system = "https://build.fhir.org/ig/HL7/fhir-mCODE-ig/"
                    }
                };
                CG_OtherP.code = new code
                {
                    text = "其他分期系統",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.ostage
                        }
                    }
                };
                CG_OtherP.status = "final";
                CG_OtherP.subject = new subject { reference = $"Patient/{Pat.id}" };
                CG_OtherP.valueCodeableConcept = new valueCodeableConcept
                {
                    text = "其他分期系統期別(病理分期)",
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.ostagep
                        }
                    }
                };
                obslist.Add(CG_OtherP);


                height = new Observation();
                height.id = Sha1Hash($"height-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                height.status = "final";
                height.subject = new subject { reference = $"Patient/{Pat.id}" };
                height.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            system="http://loinc.org",
                            code="8302-2"
                        }
                    }
                };
                height.valueQuantity = new valueQuantity
                {
                    system = "http://unitsofmeasure.org",
                    code = "cm",
                    unit = "cm",
                    value = Convert.ToDouble(CRLF_tag.height)
                };
                obslist.Add(height);

                weight = new Observation();
                weight.id = Sha1Hash($"weight-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                weight.status = "final";
                weight.subject = new subject { reference = $"Patient/{Pat.id}" };
                weight.code = new code
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            system="http://loinc.org",
                            code="29463-7"
                        }
                    }
                };
                weight.valueQuantity = new valueQuantity
                {
                    system = "http://unitsofmeasure.org",
                    code = "kg",
                    unit = "kg",
                    value = Convert.ToDouble(CRLF_tag.weight)
                };
                obslist.Add(weight);

                smoke = new Observation();
                smoke.id = Sha1Hash($"smoke-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                smoke.status = "final";
                smoke.subject = new subject { reference = $"Patient/{Pat.id}" };
                smoke.code = new code
                {
                    text = "吸菸行為"
                };
                smoke.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code=CRLF_tag.smoking
                        }
                    }
                };
                obslist.Add(smoke);

                //Observation-btchew
                btchew = new Observation();
                btchew.id = Sha1Hash($"btchew-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                btchew.status = "final";
                btchew.subject = new subject { reference = $"Patient/{Pat.id}" };
                btchew.code = new code
                {
                    text = "嚼檳榔行為"
                };
                btchew.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.btchew
                        }
                    }
                };
                obslist.Add(btchew);

                //Observation-drinking
                drinking = new Observation();
                drinking.id = Sha1Hash($"drinking-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                drinking.status = "final";
                drinking.subject = new subject { reference = $"Patient/{Pat.id}" };
                drinking.code = new code
                {
                    text = "喝酒行為"
                };
                //btchew.valueCodeableConcept[0].coding[0].code = CRLF_tag.btchew;
                drinking.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.drinking
                        }
                    }
                };
                obslist.Add(drinking);

                //Observation-drinking
                ps = new Observation();
                ps.id = Sha1Hash($"ps-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                ps.status = "final";
                ps.subject = new subject { reference = $"Patient/{Pat.id}" };
                //btchew.code[0].text = "嚼檳榔行為";
                ps.code = new code
                {
                    text = "首次治療前生活功能狀態評估"
                };
                ps.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.ps
                        }
                    }
                };
                obslist.Add(ps);

                //Observation-ssf1
                ssf1 = new Observation();
                ssf1.id = Sha1Hash($"ssf1-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                ssf1.status = "final";
                ssf1.subject = new subject { reference = $"Patient/{Pat.id}" };
                ssf1.code = new code
                {
                    text = "癌症部位特定因子 1"
                };
                ssf1.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.ssf1
                        }
                    }
                };
                obslist.Add(ssf1);


                //Observation-ssf2
                ssf2 = new Observation();
                ssf2.id = Sha1Hash($"ssf2-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                ssf2.status = "final";
                ssf2.subject = new subject { reference = $"Patient/{Pat.id}" };
                ssf2.code = new code
                {
                    text = "癌症部位特定因子 2"
                };
                ssf2.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.ssf2
                        }
                    }
                };
                obslist.Add(ssf2);


                //Observation-ssf3
                ssf3 = new Observation();
                ssf3.id = Sha1Hash($"ssf3-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                ssf3.status = "final";
                ssf3.subject = new subject { reference = $"Patient/{Pat.id}" };
                ssf3.code = new code
                {
                    text = "癌症部位特定因子 3"
                };
                ssf3.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.ssf3
                        }
                    }
                };
                obslist.Add(ssf3);


                //Observation-ssf4
                ssf4 = new Observation();
                ssf4.id = Sha1Hash($"ssf4-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                ssf4.status = "final";
                ssf4.subject = new subject { reference = $"Patient/{Pat.id}" };
                ssf4.code = new code
                {
                    text = "癌症部位特定因子 4"
                };
                ssf4.valueCodeableConcept = new valueCodeableConcept
                {

                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.ssf4
                        }
                    }
                };
                obslist.Add(ssf4);


                //Observation-ssf5
                ssf5 = new Observation();
                ssf5.id = Sha1Hash($"ssf5-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                ssf5.status = "final";
                ssf5.code = new code
                {
                    text = "癌症部位特定因子 5"
                };
                //ssf5.valueCodeableConcept[0].coding[0].code = CRLF_tag.ssf5;
                ssf5.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.ssf5
                        }
                    }
                };
                obslist.Add(ssf5);

                //ssf6-ssf10
                ssf6 = new Observation();
                ssf6.id = Sha1Hash($"ssf6-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                ssf6.status = "final";
                ssf6.subject = new subject { reference = $"Patient/{Pat.id}" };//???
                ssf6.code = new code
                {
                    text = "癌症部位特定因子 6"
                };
                ssf6.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.ssf6
                        }
                    }
                };
                obslist.Add(ssf6);

                ssf7 = new Observation();
                ssf7.id = Sha1Hash($"ssf7-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                ssf7.status = "final";
                ssf7.subject = new subject { reference = $"Patient/{Pat.id}" };//???
                ssf7.code = new code
                {
                    text = "癌症部位特定因子 7"
                };
                ssf7.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.ssf7
                        }
                    }
                };
                obslist.Add(ssf7);

                ssf8 = new Observation();
                ssf8.id = Sha1Hash($"ssf8-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                ssf8.status = "final";
                ssf8.subject = new subject { reference = $"Patient/{Pat.id}" };//???
                ssf8.code = new code
                {
                    text = "癌症部位特定因子 8"
                };
                ssf8.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.ssf8
                        }
                    }
                };
                obslist.Add(ssf8);

                ssf9 = new Observation();
                ssf9.id = Sha1Hash($"ssf9-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                ssf9.status = "final";
                ssf9.subject = new subject { reference = $"Patient/{Pat.id}" };//???
                ssf9.code = new code
                {
                    text = "癌症部位特定因子 9"
                };
                ssf9.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.ssf9
                        }
                    }
                };
                obslist.Add(ssf9);

                ssf10 = new Observation();
                ssf10.id = Sha1Hash($"ssf10-{CRLF_tag.hospid}-{CRLF_tag.id}-{CRLF_tag.dcont}");
                ssf10.status = "final";
                ssf10.subject = new subject { reference = $"Patient/{Pat.id}" };//???
                ssf10.code = new code
                {
                    text = "癌症部位特定因子 10"
                };
                ssf10.valueCodeableConcept = new valueCodeableConcept
                {
                    coding = new List<coding>
                    {
                        new coding
                        {
                            code = CRLF_tag.ssf10
                        }
                    }
                };
                obslist.Add(ssf10);
            }

            bundle.entry = new List<entry>();
            var bundle_distinct = PatOrg_Distinct();
            var response_json_ditsint = await GetandShare_Block(bundle_distinct);
            var response_json_ditsinthapi = await GetandSharehapi_Block(bundle_distinct);
            var jsonobs = ObservationJSON();
            var jsonorg = OrganizationJSON();
            var jsonpro = ProcedureJSON();
            var jsonchar = ChargeItemJSON();
            var jsonmed = MedicationAdministrationJSON();
            var jsoncon = ConditionJSON();
            var jsonpat = PatientJSON();
            var bundlejson = BundleJSON_CRLF();
            //var bundlehapijson = await GetandSharehapi_Block(bundlejson);
            var bundleIBMjson = await GetandShare_Block(bundlejson);
            //return await GetandShare_Block(bundlejson);
            return await GetandSharehapi_Block(bundlejson);

        }

        [HttpPost]
        public async Task<dynamic> GetandShare_Block(string bundlejson)
        {
            //var json = JsonConvert.SerializeObject(Post_data);
            var data = new StringContent(bundlejson, Encoding.UTF8, "application/json");

            //var url = "http://localhost:12904/api/Geth/" + Request_Url;
            var url = ConfigurationManager.AppSettings.Get("FHIRAPI");
            var Username = ConfigurationManager.AppSettings.Get("Username");
            var Password = ConfigurationManager.AppSettings.Get("Password");

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpClient client = new HttpClient();

            //specify to use TLS 1.2 as default connection
            var byteArray = Encoding.ASCII.GetBytes($"{Username}:{Password}");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            //POST資料
            var response = await client.PostAsync(url, data);
            return JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
        }

        [HttpPost]
        public async Task<dynamic> GetandSharehapi_Block(string bundlejson)
        {
            //var json = JsonConvert.SerializeObject(Post_data);
            var data = new StringContent(bundlejson, Encoding.UTF8, "application/json");

            //var url = "http://localhost:12904/api/Geth/" + Request_Url;
            var url = ConfigurationManager.AppSettings.Get("FHIR_hapi_API");
            //var Username = ConfigurationManager.AppSettings.Get("Username");
            //var Password = ConfigurationManager.AppSettings.Get("Password");

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpClient client = new HttpClient();

            //specify to use TLS 1.2 as default connection
            //var byteArray = Encoding.ASCII.GetBytes($"{Username}:{Password}");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            //POST資料
            var response = await client.PostAsync(url, data);
            return JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// 去除Patient Organization 重複的identifier
        /// </summary>
        /// <returns></returns>
        public string PatOrg_Distinct() 
        {
            //去除重複值
            //var pat_distinct_list = patlist.GroupBy(g => g.identifier[0].value).Select(s => s.First()).ToList();
            //var org_distinct_list = orglist.GroupBy(g => g.identifier[0].value).Select(s => s.First()).ToList();
            //var enc_distinct_list = enclist.GroupBy(g => g.identifier[0].value).Select(s => s.First()).ToList();
            var pat_distinct_list = patlist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            var org_distinct_list = orglist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            var enc_distinct_list = enclist.GroupBy(g => g.id).Select(s => s.First()).ToList();

            //建立新bundle 先將Patient Organization傳送到fhir server
            var bundle_distinct = new Bundle();
            bundle_distinct.entry = new List<entry>();
            //Organization
            foreach (var res in org_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        ifNoneExist = "identifier=" + res.identifier[0].value
                        
                    }
                };
                bundle_distinct.entry.Add(entry);
            }
            //Patient
            foreach (var res in pat_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        ifNoneExist = "identifier=" + res.identifier[0].value
                    }
                };
                bundle_distinct.entry.Add(entry);
            }
            //Encounter
            foreach (var res in enc_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        //ifNoneExist = "identifier=" + res.identifier[0].value

                    }
                };
                bundle_distinct.entry.Add(entry);
            }

            var bundlejson = JsonConvert.SerializeObject(bundle_distinct, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return bundlejson;
        }

        //轉成json格式
        public string OrganizationJSON()
        {
            //去除重複id
            var org_distinct_list = orglist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            //Organization
            foreach (var res in org_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        ifNoneExist = "identifier=" + res.identifier[0].value

                    }
                };
                bundle.entry.Add(entry);
            }

            //foreach (var res in orglist)
            //{
            //    var entry = new entry
            //    {
            //        fullUrl = $"{res.resourceType}/{res.id}",
            //        resource = res,
            //        request = new request
            //        {
            //            method = "PUT",
            //            url = $"{res.resourceType}/{res.id}",
            //            ifNoneExist = "identifier=" + res.identifier[0].value  //ifNoneExist
            //        }
            //    };
            //    bundle.entry.Add(entry);
            //}

            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return bundlejson;
        }

        public string ObservationJSON()
        {
            //去除重複id
            var obs_distinct_list = obslist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            //Organization
            foreach (var res in obs_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        //ifNoneExist = "identifier=" + res.identifier[0].value

                    }
                };
                bundle.entry.Add(entry);
            }

            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });

            return bundlejson;
        }
        public string ProcedureJSON()
        {

            //去除重複id
            var Pro_distinct_list = prolist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            //Organization
            foreach (var res in Pro_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        //ifNoneExist = "identifier=" + res.identifier[0].value

                    }
                };
                bundle.entry.Add(entry);
            }

            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return bundlejson;

        }
        public string ChargeItemJSON()
        {

            //去除重複id
            var cha_distinct_list = chalist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            //Organization
            foreach (var res in cha_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        //ifNoneExist = "identifier=" + res.identifier[0].value

                    }
                };
                bundle.entry.Add(entry);
            }

            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return bundlejson;

        }
        public string MedicationAdministrationJSON()
        {
            //去除重複id
            var med_distinct_list = medlist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            //Organization
            foreach (var res in med_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        //ifNoneExist = "identifier=" + res.identifier[0].value

                    }
                };
                bundle.entry.Add(entry);
            }

            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return bundlejson;

        }
        public string ConditionJSON()
        {
            //去除重複id
            var con_distinct_list = conlist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            //Organization
            foreach (var res in con_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        //ifNoneExist = "identifier=" + res.identifier[0].value

                    }
                };
                bundle.entry.Add(entry);
            }

            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return bundlejson;

        }
        public string PatientJSON()
        {
            //去除重複值id
            var pat_distinct_list = patlist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            foreach (var res in pat_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        ifNoneExist = "identifier=" + res.identifier[0].value
                    }
                };
                bundle.entry.Add(entry);
            }
                //foreach (var res in patlist)
                //{
                //    var entry = new entry
                //    {
                //        fullUrl = $"{res.resourceType}/{res.id}",
                //        resource = res,
                //        request = new request
                //        {
                //            method = "PUT",
                //            url = $"{res.resourceType}/{res.id}",
                //            ifNoneExist = "identifier=" + res.identifier[0].value
                //        }
                //    };
                //    bundle.entry.Add(entry);
                //}

                var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            return bundlejson;

        }
        public string MedicationRequestJSON()
        {
            //去除重複id
            var medrequest_distinct_list = medrequestlist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            //Organization
            foreach (var res in medrequest_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        //ifNoneExist = "identifier=" + res.identifier[0].value

                    }
                };
                bundle.entry.Add(entry);
            }

            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return bundlejson;

        }
        public string EncounterJSON()
        {
            //去除重複id
            var enc_distinct_list = enclist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            //Organization
            foreach (var res in enc_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        //ifNoneExist = "identifier=" + res.identifier[0].value

                    }
                };
                bundle.entry.Add(entry);
            }

            //foreach (var res in enclist)
            //{
            //    var entry = new entry
            //    {
            //        fullUrl = $"{res.resourceType}/{res.id}",
            //        resource = res,
            //        request = new request
            //        {
            //            method = "PUT",
            //            url = $"{res.resourceType}/{res.id}",
            //            //ifNoneExist = "identifier="+res.identifier[0].value
            //        }
            //    };
            //    bundle.entry.Add(entry);
            //}

            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return bundlejson;

        }
        public string SpecimenJSON()
        {
            //去除重複id
            var spe_distinct_list = spelist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            //Organization
            foreach (var res in spe_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        //ifNoneExist = "identifier=" + res.identifier[0].value

                    }
                };
                bundle.entry.Add(entry);
            }


            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return bundlejson;

        }
        public string ConsentJSON()
        {
            //去除重複id
            var consent_distinct_list = consentlist.GroupBy(g => g.id).Select(s => s.First()).ToList();
            //Organization
            foreach (var res in consent_distinct_list)
            {
                var entry = new entry
                {
                    fullUrl = $"{res.resourceType}/{res.id}",
                    resource = res,
                    request = new request
                    {
                        method = "PUT",
                        url = $"{res.resourceType}/{res.id}",
                        //ifNoneExist = "identifier=" + res.identifier[0].value

                    }
                };
                bundle.entry.Add(entry);
            }

            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return bundlejson;

        }
        public string BundleJSON_labm()
        {
            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
            //bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\[{}]", String.Empty);
            //bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\[{}]", String.Empty);
            //bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\{}", String.Empty);
            //bundlejson = Regex.Replace(bundlejson, @",,", ",");
            //bundlejson = Regex.Replace(bundlejson, "_", "");
            bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\[{}]", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\[{}]", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\{}", String.Empty);

            //var bundlejson = JsonConvert.SerializeObject(bundle, Formatting.Indented, new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore
            //    //MissingMemberHandling = MissingMemberHandling.Ignore
            //});
            //var bundlejson = JsonConvert.SerializeObject(bundle);

            return bundlejson;

        }

        public string BundleJSON_totfa()
        {
            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
            //bundlejson = Regex.Replace(bundlejson, @"\""(\w *)\"":\""\""", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\{}", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\{}", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\[{}]", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\[{}]", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\{}", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\{},", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\""\""", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\[{}]", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\{},", String.Empty);
            bundlejson = Regex.Replace(bundlejson, "_", "");



            //var bundlejson = JsonConvert.SerializeObject(bundle, Formatting.Indented, new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore
            //    //MissingMemberHandling = MissingMemberHandling.Ignore
            //});
            //var bundlejson = JsonConvert.SerializeObject(bundle);

            return bundlejson;

        }

        public string BundleJSON_totfb()
        {
            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });

            bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\[{}]", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\[{}]", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\{}", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\{}", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\{}", String.Empty);
            bundlejson = Regex.Replace(bundlejson, "_", "");
            //bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\{},", String.Empty);



            //var bundlejson = JsonConvert.SerializeObject(bundle, Formatting.Indented, new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore
            //    //MissingMemberHandling = MissingMemberHandling.Ignore
            //});
            //var bundlejson = JsonConvert.SerializeObject(bundle);

            return bundlejson;

        }
        //
        
        public string BundleJSON_spe_JSON()
        {
            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
            bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\[{}]", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\[{}]", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\{}", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @",,", ",");
            bundlejson = Regex.Replace(bundlejson, "_", "");

            return bundlejson;

        }
        public string BundleJSON_LABD_JSON()
        {
            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
            //原本的

            //bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\{}", String.Empty);
            //bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\[{}]", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\[{}]", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\[{}]", String.Empty);
            bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\{}", String.Empty);
            //bundlejson = Regex.Replace(bundlejson, @"  ", String.Empty);



            //bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\[{}]", String.Empty);
            //bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\[{}]", String.Empty);
            //bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\{}", String.Empty);
            //bundlejson = Regex.Replace(bundlejson, @",,", ",");
            //bundlejson = Regex.Replace(bundlejson, "_", "");

            return bundlejson;

        }
        public string BundleJSON_CRLF()
        {
            var bundlejson = JsonConvert.SerializeObject(bundle, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Include
            });

            bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\{}", String.Empty);
            bundlejson = Regex.Replace(bundlejson, "extension1", "extension");
            bundlejson = Regex.Replace(bundlejson, "_", "");
            //bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\{}", String.Empty);
            //bundlejson = Regex.Replace(bundlejson, @"\""(\w*)\"":\{}", String.Empty);
            //bundlejson = Regex.Replace(bundlejson, @",\""(\w*)\"":\{}", String.Empty);




            //var bundlejson = JsonConvert.SerializeObject(bundle, Formatting.Indented, new JsonSerializerSettings
            //{
            //    NullValueHandling = NullValueHandling.Ignore
            //    //MissingMemberHandling = MissingMemberHandling.Ignore
            //});
            //var bundlejson = JsonConvert.SerializeObject(bundle);

            return bundlejson;

        }

        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="content">待加密的字串</param>
        /// <param name="encode">編碼方式</param>
        /// <returns></returns>
        public static String Sha1Hash(String content)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();//建立SHA1物件
                byte[] bytes_in = Encoding.UTF8.GetBytes(content);//將待加密字串轉為byte型別
                byte[] bytes_out = sha1.ComputeHash(bytes_in);//Hash運算
                sha1.Dispose();//釋放當前例項使用的所有資源
                String result = BitConverter.ToString(bytes_out);//將運算結果轉為string型別
                result = result.Replace("-", "").ToUpper();//替換並轉為大寫
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
