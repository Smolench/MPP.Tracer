using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    class ThreadInformation
    {
        private readonly Stack<MethodInformation> calledMethod;
        public List<MethodInformation> childList { get; }        

        internal ThreadInformation()
        {
            calledMethod = new Stack<MethodInformation>();
            childList = new List<MethodInformation>();            
        }

        internal long ExecuteTime => childList.Sum((method) => method.ExecTime);


        internal void StartTraceMethod(MethodInformation methodinfo)
        {
            if (calledMethod.Count == 0)
            {
                childList.Add(methodinfo);
            }
            else
            {
                MethodInformation lastMethod = calledMethod.Peek();
                lastMethod.AddChild(methodinfo);
            }
        }

        internal void StopTraceMethod()
        {
            MethodInformation lastMethod = calledMethod.Pop();
            lastMethod.StopTraceMethod();
        }
    }
}
