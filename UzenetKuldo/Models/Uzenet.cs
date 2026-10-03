using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace UzenetKuldo.Models
{
    [DataContract]
    public class Uzenet : Tablazat
    {

        [DataMember]
        public string Szoveg { get; set; }

        [DataMember]
        public DateTime KüldesiIdo { get; set; }

        [DataMember]
        public string UzenetTipus { get; set; }

        [DataMember]
        public string Telefon { get; set; }

        [DataMember]
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Szoveg: {Szoveg}, KüldesiIdo: {KüldesiIdo}, UzenetTipus: {UzenetTipus}, Telefon: {Telefon}, Email: {Email}";
        }
    }
}