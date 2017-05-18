using System;
using ContinuousPOPC.clustering;

namespace ContinuousPOPC
{
    class Program
    {
        static public Random r = new Random();

        static void Main(string[] args)
        {
            RunExample3();
        }

        private static void RunExample3()
        {
            // scenario 3
            int numExpctedClusters = 13;
            int numFeatures = 50;
            int samplesPerCluser = 300;
            DataSet dataSet = new DataSet(numExpctedClusters, numFeatures, samplesPerCluser);
            popc pop = new popc(dataSet);

            //creates 13 clusters as expected

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
