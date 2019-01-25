using System;
using System.Collections.Generic;
using System.Text;

namespace shawn.module
{
    [Serializable]
    public class student
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
    }
}
