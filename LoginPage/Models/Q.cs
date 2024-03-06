using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage.Models
{
    public class Q
    {
        public int Qid { get; set; }
        public string QTitle { get; set; }
        public string AnsCorrect { get; set; }
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public int PlayerId { get; set; }
        public int SubjectId { get; set; }
        public int StatusId { get; set; }
        public virtual Player Player { get; set; }
        public virtual StatusQ Status { get; set; }
        public virtual SubjectQ Subject { get; set; }
    }
}
