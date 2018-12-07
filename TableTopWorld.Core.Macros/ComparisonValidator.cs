using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableTopWorld.Core.EntityFramework;
namespace TableTopWorld.Core.Macros
{
    public class ComparisonValidator:IEntityValidator<IComparable>
    {
        public enum ComparisonMode
        {
            Smaller = 0b00000001,
            Equal   = 0b00000010,
            Greater = 0b00000100
        }
        public object ComparisonValue;
        public string Validate(IComparable value)
        {
            int compRes = value.CompareTo(ComparisonValue);
            throw new NotImplementedException();
            //wip

        }
    }
}
