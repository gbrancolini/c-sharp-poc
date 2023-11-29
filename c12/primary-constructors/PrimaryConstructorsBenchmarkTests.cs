using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primary_constructors
{
    [MemoryDiagnoser]
    public class PrimaryConstructorsBenchmarkTests
    {
        int n = 10000;
        double dy = 233.4;
        double dx = 212.4;
        string parameter1 = " laksjdflakjflajksdlfjasd";
        string parameter2 = "asdfasdfasdfasdfawrfvr";

        //Initializing property in scruct
        [Benchmark]
        public void InitializeDistanceStructLegacyTest()
        {
            for(int i =0; i<n; i++)
            {
                DistanceStructLegacy distanceStructLegacy = new DistanceStructLegacy(dy, dx);
            }
        }

        [Benchmark]
        public void InitializeDistanceInitPropertiesTest()
        {
            for (int i = 0; i < n; i++)
            {
                DistanceStructInitProperties distanceStructInitProperties = new DistanceStructInitProperties(dy, dx);
            }
        }

        [Benchmark]
        public void InitializeBasicClassLegacy()
        {
            for (int i = 0; i < n; i++)
            {
                BasicClassLegacy basicClassLegacy = new BasicClassLegacy(parameter1, parameter2);
            }
        }

        [Benchmark]
        public void InitializeBasicClassPrimaryConstructor()
        {
            for (int i = 0; i < n; i++)
            {
                BasicClassPrimaryConstructor basicClassLegacy = new BasicClassPrimaryConstructor(parameter1, parameter2);
            }
        }
    }
}
