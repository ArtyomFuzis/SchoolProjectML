﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace PLTest.Models.ML { 
    public partial class MLModel
    {
        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process. For more information on how to load data, see aka.ms/loaddata.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainPipeline(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"q1", @"q1"),new InputOutputColumnPair(@"q2", @"q2"),new InputOutputColumnPair(@"q3", @"q3"),new InputOutputColumnPair(@"q4", @"q4"),new InputOutputColumnPair(@"q5", @"q5")})      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"q1",@"q2",@"q3",@"q4",@"q5"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:@"res",inputColumnName:@"res"))      
                                    .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(binaryEstimator:mlContext.BinaryClassification.Trainers.FastTree(new FastTreeBinaryTrainer.Options(){NumberOfLeaves=4,MinimumExampleCountPerLeaf=6,NumberOfTrees=4,MaximumBinCountPerFeature=878,FeatureFraction=0.917010946886428,LearningRate=0.341466558514274,LabelColumnName=@"res",FeatureColumnName=@"Features"}),labelColumnName: @"res"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:@"PredictedLabel",inputColumnName:@"PredictedLabel"));

            return pipeline;
        }
    }
}
