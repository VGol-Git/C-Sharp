using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Uni
{
    class StudentEnumerator : IEnumerator
    {

        public StudentEnumerator(ArrayList ListExam, ArrayList ListTest)
        {
            this.ListExam = ListExam;
            this.ListTest = ListTest;
        }

        private ArrayList ListExam;
        private ArrayList ListTest;
        int index = 0;
        int indexInExam = -1;
        public object Current
        {
            get
            {
                return ListExam[indexInExam];
            }
        }

        public bool MoveNext()
        {
            for (int i = indexInExam + 1; i < ListExam.Count; i++)
            {
                foreach (var test in ListTest)
                {
                    if (((Test)test).Subject == ((Exam)ListExam[i]).Subject)
                    {
                        //index++;
                        indexInExam = i;
                        return true;
                    }

                }
            }
            return false;
        }

        public void Reset()
        {
            if (ListExam.Count > 0) { index = 0; indexInExam = 0; }
            else { index = -1; indexInExam = -1; }

        }
    }

}
