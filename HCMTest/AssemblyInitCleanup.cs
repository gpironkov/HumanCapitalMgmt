using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMTest
{
    [TestClass]
    public class AssemblyInitCleanup
    {
        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext tc)
        {
            tc.WriteLine("In HCMTest.AssemblyInitCleanup.AssemblyInitialize() method");
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        { 
            // it runs after all tests have run in this assembly
        }
    }
}
