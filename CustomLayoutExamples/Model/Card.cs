using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLayoutExamples.Model
{
    [DebuggerDisplay("Value={Value}")]
    public record class Card
    {
        public Card(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
    }
}
