using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public struct ParameterInfo
    {
        public ParameterInfo(string name, Type type)
            : this()
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public Type Type { get; }
    }

    class MethodInformation
    {
        public MethodInformation(string className, string methodName, List<ParameterInfo> parameters)
        {
            ClassName = className;
            MethodName = methodName;
            Parameters = parameters;

            StartTime = DateTime.Now;
            FinishTime = DateTime.Now;

           
        }
       

        public string ClassName { get; }
        public string MethodName { get; }
        public List<ParameterInfo> Parameters { get; }
        public DateTime StartTime { get; }
        public DateTime FinishTime { get; private set; }


       
    }
}

