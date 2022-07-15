using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FHIR_json.Models
{
    public class FHIRModel
    {

    }
    //Bundle起
    public class Bundle
    {
        public string resourceType { get; set; } = "Bundle";
        public string type { get; set; } = "transaction";
        public List<entry> entry { get; set; }
    }
    public class entry
    {
        public string fullUrl { get; set; }
        public dynamic resource { get; set; }
        public request request { get; set; }
    }
    public class request
    {
        public string method { get; set; }
        public string url { get; set; }
        public string ifNoneExist { get; set; }
    }

    //Bundle尾




    //Condition起

    public class onsetAge
    {
        public string unit { get; set; }
        public string system { get; set; }
        public string code { get; set; }
        public double value { get; set; }

    }
    public class subject
    {
        public string reference { get; set; }
    }
    public class identifier
    {
        public string reference { get; set; }
        public string value { get; set; }
        public string system { get; set; }
    }

    public class category
    {
        public string text { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<coding> coding { get; set; } //1

    }

    public class coding
    {
        public string code { get; set; }
        public string system { get; set; }
        //0221_new
        public string display { get; set; }
        public bool userSelected { get; set; }


    }
    public class extension
    {
        public string url { get; set; }
        public string valueDateTime { get; set; }
        public List<extension1> extension1 { get; set; } //1
        public valueReference valueReference { get; set; } //1
    }

    //public class valueReference
    //{


    //}
    public class code
    {
        public string text { get; set; }
        public List<coding> coding { get; set; } //2-1

    }
    public class bodySite
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }//2

    }
    public class evidence
    {
        public List<code> code { get; set; }

    }

    public class stage
    {
        public summary summary { get; set; }


    }
    public class summary
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }

    }
    //Condition尾

    //procedure起
    public class reasonCode
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }

    }
    public class outcome
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }

    }
    public class note
    {
        public string text { get; set; }

    }

    public class statusReason
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }

    }
    public class focalDevice
    {
        //public string text { get; set; }
        public manipulated manipulated { get; set; }
        public action action { get; set; }


    }
    public class manipulated
    {
        public string display { get; set; }

    }
    public class action
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }

    }
    public class performedPeriod
    {
        public string start { get; set; }
        public string end { get; set; }

    }
    public class followUp
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }

    }
    public class extension1
    {
        public string url { get; set; }
        public valueCodeableConcept valueCodeableConcept { get; set; }
        public valueReference valueReference { get; set; }
        public valueQuantity valueQuantity { get; set; }
        public int? valueUnsignedInt { get; set; }

    }
    public class valueCodeableConcept
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }

    }
    public class valueReference
    {
        public string display { get; set; }
        public string reference { get; set; }


    }
    public class valueQuantity//改
    {
        public string system { get; set; }
        public double value { get; set; }
        public string code { get; set; }
        public string unit { get; set; }


    }

    //procedure尾

    //
    public class address
    {
        public string postalCode { get; set; }
    }

    //



    //patient起
    public class Patient
    {
        public string resourceType { get; set; } = "Patient";
        public string id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string birthDate { get; set; }
        public List<identifier> identifier { get; set; }
        public bool deceasedBoolean { get; set; }
        public List<address> address { get; set; }

        //new
        public string deceasedDateTime { get; set; }


    }
    //public class address_Patient
    //{
    //    public string postalCode { get; set; }
    //}
    //public class identifier_Patient
    //{
    //    public string value { get; set; }
    //}

    //patient尾

    //ChargeItem起
    public class ChargeItem
    {
        public string resourceType { get; set; } = "ChargeItem";
        public string id { get; set; }
        public string status { get; set; }
        public subject subject { get; set; }
        public code code { get; set; }

        //新增
        public string enteredDate { get; set; }
        public string occurrenceDateTime { get; set; }


    }

    //ChargeItem尾

    //Condition起 大
    public class Condition
    {
        public string resourceType { get; set; } = "Condition";
        public string id { get; set; }
        public string recordedDate { get; set; }

        public onsetAge onsetAge { get; set; }
        public string onsetString { get; set; }
        public subject subject { get; set; }
        public List<identifier> identifier { get; set; }
        public List<category> category { get; set; }
        public List<extension> extension { get; set; }//找不到
        public code code { get; set; }
        public List<bodySite> bodySite { get; set; }
        public List<evidence> evidence { get; set; }
        public List<stage> stage { get; set; }

        //new
        public encounter encounter { get; set; }

        //0708更新
        public note note { get; set; }


    }
    //Condition尾 大

    

    //Organization
    public class Organization
    {
        public string resourceType { get; set; } = "Organization";
        public string id { get; set; }
        public List<identifier> identifier { get; set; }




    }
    //Organization

    //Procedure起 大
    public class Procedure
    {
        public string resourceType { get; set; } = "Procedure";
        public string id { get; set; }
        public string status { get; set; }
        public string performedDateTime { get; set; }
        public subject subject { get; set; }
        public List<reasonCode> reasonCode { get; set; }
        public code code { get; set; }
        public category category { get; set; }
        public outcome outcome { get; set; }
        public List<note> note { get; set; }
        public statusReason statusReason { get; set; }
        public List<focalDevice> focalDevice { get; set; }
        public performedPeriod performedPeriod { get; set; }
        public List<followUp> followUp { get; set; }
        public List<extension> extension { get; set; }

        //新增
        public encounter encounter { get; set; }
        //0322
        public List<identifier> identifier { get; set; }




    }
    //新增
    public class encounter
    {
        public string reference { get; set; }
    }

    //Procedure尾 大

    //MedicationAdministration起
    public class MedicationAdministration
    {
        public string resourceType { get; set; } = "MedicationAdministration";
        public string id { get; set; }
        public string status { get; set; }//string
        public subject subject { get; set; }
        public List<reasonCode> reasonCode { get; set; }
        public category category { get; set; }
        public medicationCodeableConcept medicationCodeableConcept { get; set; } //隸屬於medication(1...1)
        public string effectiveDateTime { get; set; }
    }


    public class medicationCodeableConcept
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }

    }
    //MedicationAdministration尾

    //Observation起
    public class Observation
    {
        public string resourceType { get; set; } = "Observation";
        public string id { get; set; }
        public string status { get; set; }
        public subject subject { get; set; }
        public code code { get; set; }
        public List<hasMember> hasMember { get; set; }
        public List<focus> focus { get; set; }
        public List<category> category { get; set; }
        public string effectiveDateTime { get; set; }
        public method method { get; set; }
        public List<component> component { get; set; }
        public valueCodeableConcept valueCodeableConcept { get; set; }
        public valueQuantity valueQuantity { get; set; }
        //0715_new
        public string valueString { get; set; }
        public List<note> note { get; set; }


        //new
        public encounter encounter { get; set; }
        public string issued { get; set; }
        public List<identifier> identifier { get; set; }
        public List<referenceRange> referenceRange { get; set; }
        public List<interpretation> interpretation { get; set; }

        //0221_new
        public List<performer> performer { get; set; }
        //0322_新增
        public List<partOf> partOf { get; set; }



    }
   
    //0322_新增
    public class partOf
    {
        public string reference { get; set; }

        //public identifier identifier { get; set; }

    }
  
    //new
    public class interpretation
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }
    }
    public class referenceRange
    {
        public string text { get; set; }
    }
    public class method
    {
        public List<coding> coding { get; set; }
        public string text { get; set; }
    }
    public class component
    {
        public code code { get; set; }
        public valueQuantity valueQuantity { get; set; }
        public valueCodeableConcept valueCodeableConcept { get; set; }
    }
    //public class valueQuantity
    //{
    //    public string system { get; set; }
    //    public string code { get; set; }
    //    public string unit { get; set; }
    //    public string value { get; set; }
    //}
    //public class valueCodeableConcept
    //{
    //    public List<coding> coding { get; set; }
    //}
    public class focus
    {
        public string reference { get; set; }
    }
    public class hasMember
    {
        public string reference { get; set; }
    }
    //Observation尾


    //Encounter 大
    public class Encounter
    {
        public string resourceType { get; set; } = "Encounter";
        public string id { get; set; }
        public string status { get; set; }

        public List<type> type { get; set; }
        public @class @class { get; set; }
        public List<identifier> identifier { get; set; }

        //new2
        public subject subject { get; set; }
        public serviceType serviceType { get; set; }
        public period period { get; set; }
        public List<reasonCode> reasonCode { get; set; }
        public hospitalization hospitalization { get; set; }




    }
    //Encounter 大
    //新增
    public class hospitalization
    {
        public dischargeDisposition dischargeDisposition { get; set; }


    }
    //新增
    public class dischargeDisposition
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }


    }
    //新增
    public class type
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }


    }

    //新增
    public class @class
    {
        public string system { get; set; }
        public string code { get; set; }
        public string display { get; set; }


    }
    //new
    public class serviceType
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }

    }
    //new
    public class period
    {
        public string start { get; set; }//datetime
        public string end { get; set; }//datetime
    }

    //new
    public class MedicationRequest
    {
        public string resourceType { get; set; } = "MedicationRequest";
        public string id { get; set; }
        public string status { get; set; }//string
        public string intent { get; set; }

        public subject subject { get; set; }

        public encounter encounter { get; set; }
        public dispenseRequest dispenseRequest { get; set; }
        public List<category> category { get; set; }
        public medicationCodeableConcept medicationCodeableConcept { get; set; }
        public List<dosageInstruction> dosageInstruction { get; set; }
        public List<reasonCode> reasonCode { get; set; }
        public List<identifier> identifier { get; set; }
        public performerType performerType { get; set; }

    }
    //new
    public class performerType
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }
    }
    //new
    public class dispenseRequest
    {
        public expectedSupplyDuration expectedSupplyDuration { get; set; }
        public quantity quantity { get; set; }
        public validityPeriod validityPeriod { get; set; }


    }
    //new
    public class expectedSupplyDuration
    {
        public string unit { get; set; }
        public string system { get; set; }
        public string code { get; set; }
        public double value { get; set; }


    }
    //new
    public class dosageInstruction
    {
        public List<doseAndRate> doseAndRate { get; set; }
        public timing timing { get; set; }
        public site site { get; set; }



    }
    //new
    public class doseAndRate
    {
        public doseQuantity doseQuantity { get; set; }
    }
    //new
    public class doseQuantity
    {
        public double value { get; set; }
    }
    //new
    public class timing
    {
        public code code { get; set; }

    }
    //new
    public class site
    {
        public List<coding> coding { get; set; }

    }
    //new
    public class quantity
    {
        public double value { get; set; }

    }
    public class validityPeriod
    {
        public string start { get; set; }//datetime
        public string end { get; set; }//datetime

    }

    //0221_new
    public class Specimen
    {
        public string resourceType { get; set; } = "Specimen";

        public string id { get; set; }
        public string status { get; set; }
        public string receivedTime { get; set; }
        public collection collection { get; set; }
        public type type { get; set; }
        public subject subject { get; set; }
        public List<note> note { get; set; }
        public accessionIdentifier accessionIdentifier { get; set; } //EXCEL

    }
    public class collection
    {
        public string collectedDateTime { get; set; }
        public quantity quantity { get; set; }
        public collector collector { get; set; }
    }
    public class collector
    {
        public string display { get; set; }
    }
    public class Consent
    {
        public string resourceType { get; set; } = "Consent";

        public string id { get; set; }
        public string dateTime { get; set; }
        public string status { get; set; }
        public List<category> category { get; set; }
        public scope scope { get; set; }
        public patient patient { get; set; } //1
        public policyRule policyRule { get; set; } //1


    }
    public class scope
    {
        public string text { get; set; }
        public List<coding> coding { get; set; }


    }
    public class patient
    {
        public string reference { get; set; }
    }
    public class policyRule
    {
        public List<coding> coding { get; set; }
    }


    public class performer
    {
        public string reference { get; set; }
    }
    public class accessionIdentifier
    {
        public string value { get; set; }
    }

    public class composition
    {

    }
}