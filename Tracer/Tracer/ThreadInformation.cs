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
        private MethodInformation currentMethod;

        internal ThreadInformation()
        {
            calledMethod = new Stack<MethodInformation>();
            childList = new List<MethodInformation>();
            currentMethod = null;
        }

        public void StartTraceMethod(string className, string methodName, List<ParameterInfo> parameters)
        {
            var method = new MethodInformation(className, methodName, parameters);
            if (currentMethod == null)
            {
                childList.Add(method);
            }
            else
            {
                
                calledMethod.Push(currentMethod);
            }
        }
    }
}
