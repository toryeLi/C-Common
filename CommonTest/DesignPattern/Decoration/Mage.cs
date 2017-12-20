using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decoration
{
    public class Mage : IFunction
    {
        public string decribe()
        {
            return "我的职业是法师";
        }
    }
}
