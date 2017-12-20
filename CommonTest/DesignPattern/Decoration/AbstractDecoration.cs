using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Decoration
{
   public  class AbstractDecoration : IFunction
    {
        private IFunction fun;
        public AbstractDecoration(IFunction function) {
            this.fun = function;
        }
        public string decribe()
        {
            return fun.decribe();
        }
    }
}
