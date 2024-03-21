using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Assessment
    {
        public int Id { get; set; }

        public bool isActive { get; set; }
        public string Name { get; set; }

        public int isScorable { get; set; }

        public IList<AssementQuestions> AssementsQue { get; set; }
    }
}
