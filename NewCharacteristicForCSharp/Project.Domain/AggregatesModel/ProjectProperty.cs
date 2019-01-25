using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.SeedWork;

namespace Project.Domain.AggregatesModel
{
    public class ProjectProperty: ValueObject
    {
        public ProjectProperty(string _key,string _text,string _value)
        {
            Key = _key;
            Text = _text;
            Value = _value;
        }
        public string Key { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            // Using a yield return statement to return each element one at a time
            yield return Key;
            yield return Text;
            yield return Value;
        }
    }
}
