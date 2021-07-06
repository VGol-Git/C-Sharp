using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    class JournalEntry
    {
        public string CollectionName { get; set; }
        public Action ActType { get; set; }
        public string PropName { get; set; }
        public string KeyTxt { get; set; }
        public JournalEntry(string Name, Action Type, string Prop, string Key)
        {
            this.CollectionName = Name;
            this.ActType = Type;
            this.PropName = Prop;
            this.KeyTxt = Key;
        }
        public override string ToString()
        {
            return this.CollectionName + "\n" + this.ActType.ToString() + "\n" + this.PropName + "\n" + this.KeyTxt + "\n" + "\n";
        }


    }
}
