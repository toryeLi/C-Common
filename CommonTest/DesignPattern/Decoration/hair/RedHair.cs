using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPattern.Decoration;

namespace DesignPattern.Decoration.hair
{
   public class RedHair:AbstractDecoration
    {
        public RedHair(IFunction function):base(function) {
           
        }
        public string decribe()
        {
            return base.decribe()+"红色的头发";
        }
    }
}
