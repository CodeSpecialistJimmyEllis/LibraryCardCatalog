using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using System.Runtime.Serialization.Formatters;


namespace LibraryCardCatalog
{
    [DataContract]
    public class Book
    {

        [DataMember]
       public string title;
        [DataMember]
        public string author;
        [DataMember]
        public string subject;

        //public string Title { get; set; }
        //public string Author { get; set; }
        //public string Subject { get; set; }




    }
}
