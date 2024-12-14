using ConsoleAppSentimentAnalytic;
using Microsoft.ML;
using Microsoft.ML.Data;

var dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "yelp_labelled.txt");
var mlContext = new MLContext();
var dataView = mlContext.Data.LoadFromTextFile<SentimentData>(dataPath, hasHeader: false);
var splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
var estimator = mlContext.Transforms.Text
    .FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
    .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label",
        featureColumnName: "Features"));

Console.WriteLine("=============== Create and Train the Model ===============");
var model = estimator.Fit(splitDataView.TrainSet);
Console.WriteLine("=============== End of training ===============");
Console.WriteLine();

Console.WriteLine("=============== Evaluating Model accuracy with Test data===============");
var predictions = model.Transform(splitDataView.TestSet);
var metrics = mlContext.BinaryClassification.Evaluate(predictions, "Label");

Console.WriteLine();
Console.WriteLine("Model quality metrics evaluation");
Console.WriteLine("--------------------------------");
Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2}");
Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
Console.WriteLine("=============== End of model evaluation ===============");

var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "ModelSentiment.zip");
mlContext.Model.Save(model, dataView.Schema, modelPath);
Console.WriteLine("Finished");
