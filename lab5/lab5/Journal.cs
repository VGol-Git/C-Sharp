using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Uni
{
    class Journal
    {
         private List<JournalEntry> ListOfAllEntry = new List<JournalEntry>();
        //public void NewListEntry(object subject, EventArgs e)
        //{
        //    var me = (StudentsChangedEventArgs<string>)e;
        //    JournalEntry newListEntry = new JournalEntry(me.CollectionName, me.KindOfEvent, me.PropName, me.ElementKey.ToString());
        //    ListOfAllEntry.Add(newListEntry);
        //}

        //public void NewListEntry2(object subject, EventArgs e)
        //{
        //    var me = (PropertyChangedEventArgs)e;
        //    JournalEntry newListEntry = new JournalEntry("", Action.Property, me.PropertyName.ToString(), "");
        //    ListOfAllEntry.Add(newListEntry);
        //}
        public void NewListEntry(object subject, EventArgs e)
        {
            if (e is StudentsChangedEventArgs<string> eventS)
            {
                JournalEntry newListEntry = new JournalEntry(eventS.CollectionName, eventS.KindOfEvent, eventS.PropName, eventS.ElementKey.ToString());
                ListOfAllEntry.Add(newListEntry);
            }
            else if (e is PropertyChangedEventArgs eventP)
            {
                JournalEntry newListEntry = new JournalEntry("", Action.Property, eventP.PropertyName.ToString(), "");
                ListOfAllEntry.Add(newListEntry);
            }
        }

        public override string ToString()
        {
            string entryNames = "";
            foreach (JournalEntry item in ListOfAllEntry)
            {
                entryNames += item.ToString() + "\n";
            }
            return entryNames;
        }



    }
}
