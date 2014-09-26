using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;

namespace PTAData.Entities
{

/// <summary>
/// Summary description for Committee
/// </summary>
/// 
    [Serializable]
    public class Committee
    {
        public string CommitteeName { get; set; }
        public string Description { get; set; }
        public List<Member> ChairPersons { get; set; }
        public List<string> AttachedFiles { get; set; }

        public Committee()
        {
            //
            // TODO: Add constructor logic here
            //
            Initialize();
        }

        public Committee(object obj)
        {
            var valuesByProp = obj as Dictionary<string, object>;
            if (valuesByProp == null)
            {
                Initialize();
                return;
            }

            Type type = typeof(Committee);
            foreach (var pair in valuesByProp)
            {
                var property = type.GetProperty(pair.Key);
                if (property != null)
                {
                    object value = null;
                    if (property.PropertyType == typeof(string))
                        value = pair.Value;
                    else if (pair.Value is Array)
                    {
                        foreach (var item in (pair.Value as object[]))
                        {
                            value = Activator.CreateInstance(property.PropertyType.GetGenericArguments()[0], item);
                        }
                    }
                    else
                        value = Activator.CreateInstance(property.PropertyType, pair.Value);
                    property.SetValue(this, value);
                }
            }
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
            ChairPersons = new List<Member>();
            AttachedFiles = new List<string>();
        }
    }
}