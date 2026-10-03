using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace UzenetKuldo.Models
{
    [DataContract]
    public class Tablazat
    {
        [DataMember]
        public int Id { get; set; }
    }
}