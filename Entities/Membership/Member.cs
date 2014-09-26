using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTAData.Entities
{
    /// <summary>
    /// Summary description for Mebmer
    /// </summary>
    /// 
    [Serializable]
    public class Member
    {
        public string MembershipId { get; set; }
        public string MemberId { get; set; }
        public PersonName Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Member()
        {
            //
            // TODO: Add constructor logic here
            //
            Initialize();
        }

        public Member(object obj)
        {
            var valuesByProp = obj as Dictionary<string, object>;
            if (valuesByProp == null)
            {
                Initialize();
                return;
            }

            Type type = typeof(Member);
            foreach (var pair in valuesByProp)
            {
                var property = type.GetProperty(pair.Key);
                if (property != null)
                {
                    object value = null;
                    if (property.PropertyType == typeof(string))
                        value = pair.Value;
                    else
                        value = Activator.CreateInstance(property.PropertyType, pair.Value);
                    property.SetValue(this, value);
                }
            }
        }

        private void Initialize()
        {
            MemberId = Guid.NewGuid().ToString();
            Name = new PersonName();
        }
    }
}