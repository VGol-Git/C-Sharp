using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    class Test
    {
        public string Subject { get; set; }
        public Boolean PassedTest { get; set; }

        public Test(string subject, bool passedTest)
        {
            Subject = subject;
            PassedTest = passedTest;
        }

        public Test()
        {
            Subject = "NoSubject";
            PassedTest = false;
        }

        public override string ToString()
        {
            return Subject + ' ' + PassedTest.ToString();
        }
    }
}
