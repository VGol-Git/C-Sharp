using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uni
{
    class StudentsChangedEventArgs<TKey> : EventArgs
    {
        public string CollectionName { get; set; }
        public Action KindOfEvent { get; set; }
        public string PropName { get; set; }
        public TKey ElementKey { get; set; }
        public StudentsChangedEventArgs(string Name, Action Kind, string Prop, TKey Key)
        {
            this.CollectionName = Name;
            this.KindOfEvent = Kind;
            this.PropName = Prop;
            this.ElementKey = Key;
        }
        public override string ToString()
        {
            return this.CollectionName + "\n" + this.KindOfEvent.ToString() + "\n" + this.PropName + "\n" + this.ElementKey.ToString() + "\n" + "\n";
        }
    }
}
