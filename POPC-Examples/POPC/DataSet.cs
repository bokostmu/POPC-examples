using System;
using System.Collections.Generic;

namespace ContinuousPOPC
{
    public class DataSet
    {
        public List<DataRow> rows;

        public DataSet(int numExpectedClusters, int numFeatures, int samplesPerCluser)
        {
            Random r = new Random();
            rows = new List<DataRow>();

            for (int i = 0; i < numExpectedClusters; i++)
            {
                double[] probs = new double[numFeatures];
                for (int k = 0; k < numFeatures; k++)
                {
                    if (k < numExpectedClusters)
                    {
                        if (k == i)
                        {
                            probs[k] = 1.0;
                        }
                        else
                        {
                            probs[k] = 0.0;
                        }
                    }
                    else
                    {
                        probs[k] = 0.5;
                    }
                }

                for (int j = 0; j < samplesPerCluser; j++)
                {
                    bool[] feats = new bool[numFeatures];

                    for (int k = 0; k < numFeatures; k++)
                    {
                        feats[k] = r.NextDouble() < probs[k];
                    }
                    DataRow dr = new DataRow();
                    dr.features = feats;
                    rows.Add(dr);
                }
            }
        }
    }
}
