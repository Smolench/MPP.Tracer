using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public sealed class Tracer : ITracer
    {
        private static volatile Tracer instance;
        private static readonly object SyncRoot = new object();

        public TraceResult traseResult;

        private Tracer()
        {
            this.traseResult = new TraceResult();
        }

        public void StartTrace()
        {
        }

        public void StopTrace()
        {
        }

        public TraceResult GetTraceResult()
        {
            return this.traseResult;
        }

        public static Tracer Instance()
        {
            if (instance == null)
            {
                lock (SyncRoot)
                {
                    if (instance == null)
                        instance = new Tracer();
                }
            }
            return instance;
        }
    }
}

