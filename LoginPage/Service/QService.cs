using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPage.Models;

namespace LoginPage.Service
{
    public class QService
    {
        public List<Q> Qs { get; set; }

        public QService() 
        {
            this.Qs = new List<Q>();
            FillList();
        }

        private void FillList()
        {
            Qs.Add(new Q { QTitle = "What year did the movie Titanic come out?",AnsCorrect = "1997", A1 = "1800",A2 =  "1992",A3 = "2003", PlayerId =1, SubjectId = 2,StatusId = 1 });
            Qs.Add(new Q { QTitle = "How Many Minutes are in a basketball game?", AnsCorrect = "48", A1 = "43",A2 =  "50",A3 = "60", PlayerId =1, SubjectId = 1,StatusId = 1 });
            Qs.Add(new Q { QTitle = "Whats is the capital of China?", AnsCorrect = "Beijing", A1 = "Bangkok",A2 =  "Tel Aviv",A3 = "China", PlayerId =1, SubjectId = 3,StatusId = 1 });
            Qs.Add(new Q { QTitle = "How many Harry Potter books ae there?", AnsCorrect = "7", A1 = "5",A2 =  "8",A3 = "12", PlayerId =1, SubjectId = 4,StatusId = 1 });
            Qs.Add(new Q { QTitle = "What year did Hitler come to power?", AnsCorrect = "1933", A1 = "1939",A2 =  "1942",A3 = "2022", PlayerId =1, SubjectId = 5,StatusId = 1 });
        }

        public List<Q> GetUserQuestion(int id)
        {
            return Qs.Where(x=> x.PlayerId == id).ToList();
        }
    }
}
