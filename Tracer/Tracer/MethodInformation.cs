using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace Tracer
{
    internal class MethodInformation
    {
        private List<MethodInformation> childList;
        private Stopwatch StopWatching;
        private MethodBase methodBase;

        internal MethodInformation(MethodBase MBase)
        {
            childList = new List<MethodInformation>();
            methodBase = MBase;
            StopWatching = Stopwatch.StartNew();
        }

        internal void AddChild(MethodInformation methodinfo)
        {
            childList.Add(methodinfo);
        }

        internal string Name => methodBase.Name;
        internal string Class => methodBase.DeclaringType.Name;
        internal int ParametrsCount => methodBase.GetParameters().Length;
        internal long ExecTime => StopWatching.ElapsedMilliseconds;


        internal void StopTraceMethod()
        {
            StopWatching.Stop();
        }
    }
}

