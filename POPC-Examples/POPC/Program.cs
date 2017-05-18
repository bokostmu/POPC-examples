using System;
using ContinuousPOPC.clustering;

namespace ContinuousPOPC
{
    class Program
    {
        static public Random r = new Random();

        static void Main(string[] args)
        {
            RunExample1();
            RunExample2();
            RunExample3();
        }

        private static void RunExample1()
        {
            int numExpctedClusters = 7;
            int numFeatures = 100;
            int samples = 200;
            DataSet dataSet = new DataSet(numExpctedClusters, numFeatures, samples, 1);
            popc pop = new popc(dataSet);

            if(pop.clusters.Count != numExpctedClusters)
            {
                throw new Exception("theory not confirmed");
            }
        }

        private static void RunExample2()
        {
            int numExpctedClusters = 7;
            int numFeatures = 100;
            int samples = 200;
            DataSet dataSet = new DataSet(numExpctedClusters, numFeatures, samples, 2);
            popc pop = new popc(dataSet);

            if (pop.clusters.Count != numExpctedClusters)
            {
                throw new Exception("theory not confirmed");
            }
        }

        private static void RunExample3()
        {
            // scenario 3
            int numExpctedClusters = 13;
            int numFeatures = 50;
            int samplesPerCluser = 300;
            DataSet dataSet = new DataSet(numExpctedClusters, numFeatures, samplesPerCluser, 3);
            popc pop = new popc(dataSet);

            //creates 13 clusters as expected
            if(pop.clusters.Count != numExpctedClusters)
            {
                throw new Exception("theory not confirmed");
            }

            // results close expected 13
            double vPOPC = popc.ComputeEval(pop.clusters, pop.countsAll);

            if (Math.Abs(vPOPC - numExpctedClusters) > 0.1)
            {
                throw new Exception("theory not confirmed");
            }

            // pretend we know correct number of clusters
            kmeans km = new kmeans(dataSet, pop.clusters.Count);
            // even with knowledge of amount of correct clusters
            // we get score close to 0 due to k-means clusters
            // concentrates on noisy features and does not find
            // ideal clusters, hence score close to 0
            double vKMEANS = popc.ComputeEval(km.clusters, pop.countsAll);

            if (Math.Abs(vKMEANS - 0.0) > 0.1)
            {
                throw new Exception("theory not confirmed");
            }
        }
    }
}
