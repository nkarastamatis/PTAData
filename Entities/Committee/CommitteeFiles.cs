using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PTAData.Entities
{
    public class CommitteeFile
    {
        
        [Key]
        public string FileName { get; set; }
        public string CommitteeName { get; set; }

        public CommitteeFile()
        {

        }
    }
}
