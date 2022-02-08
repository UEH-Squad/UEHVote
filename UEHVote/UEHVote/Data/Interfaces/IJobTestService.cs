using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UEHVote.Data.Interfaces
{
    public interface IJobTestService
    {
        void FireAndForgetJob();
        void ReccuringJob();
        void DelayedJob();
        void ContinuationJob();
    }
}
