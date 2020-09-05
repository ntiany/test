using System;
using System.Collections.Generic;
using System.Text;

namespace Threads
{
    class NewClass
    {
        void Method()
        {
            System.Threading.Semaphore semaphore = new 
                System.Threading.Semaphore(1, 1);

            semaphore.WaitOne();

            // execute

            semaphore.Release(1);
        }
    }
}
