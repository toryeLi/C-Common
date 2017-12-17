using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Common.ExpressionDemo.Visitor;
using Model.Test;

namespace CommonTest
{
    public class ExpressionVistorTest
    {
        public static void Show()
        {
            {
                Expression<Func<PeopleModel, bool>> lambda = x => x.Age > 5 && x.Id > 5;
                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
               string sql= vistor.Condition();
            }
        }
    }
}
