using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

namespace Tracer
{
    public class TraceCollection
    {
        internal ConcurrentDictionary<long, ThreadInformation> ThreadMethods;

        public TraceCollection()
        {
            ThreadMethods = new ConcurrentDictionary<long, ThreadInformation>();
        }

        public void StartTraceMethod(long threadId, MethodBase methodBaseInfo)
        {
            ThreadInformation threadInfo = ThreadMethods.GetOrAdd(threadId, new ThreadInformation());
            threadInfo.StartTraceMethod(new MethodInformation(methodBaseInfo));
        }

        public void StopTraceMethod(long threadId, MethodBase methodBaseInfo)
        {
            ThreadInformation threadInfo;
            if (!ThreadMethods.TryGetValue(threadId, out threadInfo))
            {
                throw new ArgumentException("There is no thread with id = " + threadId);
            }
            threadInfo.StopTraceMethod();
        }

    }
}
