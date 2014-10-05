using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTAData.Entities
{

/// <summary>
/// Summary description for Committee
/// </summary>
/// 
    [Serializable]
    public class Committee
    {
        [Key]
        public string CommitteeName { get; set; }
        public string Description { get; set; }

        [ForeignKey("CommitteeName")]
        public List<ChairPerson> ChairPersons { get; set; }
        [ForeignKey("CommitteeName")]
        public List<CommitteeFile> AttachedFiles { get; set; }
        [ForeignKey("CommitteeName")]
        public List<CommitteeEntry> Entries { get; set; }

        public Committee()
        {
            //
            // TODO: Add constructor logic here
            //
            Initialize();
        }

        static public Committee Load(string name)
        {
            var filePath = "~/Committee/Data/" + Path.ChangeExtension(name, "xml");
            Committee committee = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Committee));
            try
            {
                using (var stream = File.OpenRead(System.Web.Hosting.HostingEnvironment.MapPath(filePath)))
                {
                    committee = (Committee)serializer.Deserialize(stream);
                }

            }
            catch (Exception ex)
            {
                string e = ex.ToString();
            }

            return committee;
        }

        public void Save()
        {
            var committeeFileName = CommitteeName;//.Replace(" ", String.Empty);
            var filePath = "~/Committee/Data/" + Path.ChangeExtension(committeeFileName, "xml");
            XmlSerializer serializer = new XmlSerializer(typeof(Committee));
            try
            {
                using (var stream = File.OpenWrite(System.Web.Hosting.HostingEnvironment.MapPath(filePath)))
                {
                    serializer.Serialize(stream, this);
                }
            }
            catch
            { }
        }

        private void Initialize()
        {
            //ChairPersons = new List<ChairPerson>();
            //AttachedFiles = new List<CommitteeFile>();
            //Entries = new List<CommitteeEntry>();
        }
    }
}