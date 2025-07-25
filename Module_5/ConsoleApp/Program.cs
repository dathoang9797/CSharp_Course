﻿// See https://aka.ms/new-console-template for more information

//Object vs Dynamic
//ADO.net

//Lưu được mọi kiểu dữ liệu

using System;
using ConsoleApp;
using Microsoft.ML;

// object a = 7; //interger
// object b = 7.8; //double
// object c = 7.3f; //float
// object d = 9.75d; //decimal
// object s = "xinh chao"; //string
// object ch = 'A'; //character
// object obj = new PhanSo(); //class

// int x = 7;
// double y = 9;
// Console.WriteLine(x + y);
// Console.WriteLine((int)a + (double)b);
// Console.WriteLine(s);

// object x = 7.3f;
// Console.WriteLine(x.GetType());

//Single == float
//Double == double
// double y = (double)x; //error
// double y = Convert.ToDouble(x);
// Console.WriteLine(y);

// float z = (float)x;
// Console.WriteLine(z);

//Object là kiểu đầu tiên trong C#

//ViewData => Object => In ra kết quả
//ViewBag => Dynamic => Tính toán

//Dynamic
// dynamic a = 7;
// dynamic b = 9.6;
// Console.WriteLine(a + b);

//object
// var listObject = new List<PhanSo>()
// {
//     new PhanSo() { Tu = 1, Mau = 2 },
//     new PhanSo() { Tu = 2, Mau = 4 },
//     new PhanSo() { Tu = 4, Mau = 3 },
//     new PhanSo() { Tu = 5, Mau = 5 },
//     new PhanSo() { Tu = 7, Mau = 4 }
// };

// object listPhanSo = listObject;
//Ép kiểu
// foreach (var item in (List<PhanSo>)listPhanSo)
// {
//     Console.WriteLine(item);
// }
//
// Console.WriteLine("===========================");
// dynamic listPhanSo2 = listObject;
// foreach (var item in listPhanSo2)
// {
//     Console.WriteLine(item);
// }
//
// object title = "Web App Store";
//
// Console.WriteLine(title);
//
// dynamic title2 ="Web App Store";
// Console.WriteLine(title2);

// var a = 7;
// Console.WriteLine(a);
// Console.WriteLine(a.GetType());
// int b;
// b = 99;

// var c;
// object d;
// d = 77;
// 
// dynamic e;
// e = 200;
//
// var f = b;

// var Tong(int a, int b)
// {
//     return a + b;
// }

// object Tong(int a, int b)
// {
//     return a + b;
// }
//
// void Print(object x)
// {
//     Console.WriteLine(x);
// }

// int[] arr = {3,7,8,4,1,5};
// foreach (int item in arr)
// {
//     Console.WriteLine(item);
// }
//
// foreach (var item in arr)
// {
//     Console.WriteLine(item);
// }

// List<PhanSo> listObject = new List<PhanSo>()
// {
//     new PhanSo() { Tu = 1, Mau = 2 },
//     new PhanSo() { Tu = 2, Mau = 4 },
//     new PhanSo() { Tu = 4, Mau = 3 },
//     new PhanSo() { Tu = 5, Mau = 5 },
//     new PhanSo() { Tu = 7, Mau = 4 }
// };
//
// foreach (var item in listObject)
// {
//     Console.WriteLine(item.Tu);
//     Console.WriteLine(item.Mau);
// }
//
// dynamic listPhanSo = listObject;
//
// foreach (var item in listPhanSo)
// {
//     Console.WriteLine(item.Tu);
//     Console.WriteLine(item.Mau);
// }

// var trainDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "taxi-fare-train.csv");
// var testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "taxi-fare-test.csv");
// var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");
//
// var mlContext = new MLContext();
// var dataView = mlContext.Data.LoadFromTextFile<TaxiTrip>(trainDataPath, hasHeader: true, separatorChar: ',');
// var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: "FareAmount")
//     .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "VendorIdEncoded",
//         inputColumnName: "VendorId"))
//     .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "RateCodeEncoded",
//         inputColumnName: "RateCode"))
//     .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "PaymentTypeEncoded",
//         inputColumnName: "PaymentType"))
//     .Append(mlContext.Transforms.Concatenate("Features", "VendorIdEncoded", "RateCodeEncoded", "PassengerCount",
//         "TripDistance", "PaymentTypeEncoded"))
//     .Append(mlContext.Regression.Trainers.FastTree());
//
// var model = pipeline.Fit(dataView);
// var dataViewTest = mlContext.Data.LoadFromTextFile<TaxiTrip>(testDataPath, hasHeader: true, separatorChar: ',');
// var predictions = model.Transform(dataViewTest);
// var metrics = mlContext.Regression.Evaluate(predictions, "Label", "Score");
//
// Console.WriteLine();
// Console.WriteLine($"*************************************************");
// Console.WriteLine($"*       Model quality metrics evaluation         ");
// Console.WriteLine($"*------------------------------------------------");
//
// Console.WriteLine($"*       RSquared Score:      {metrics.RSquared:0.##}");
// Console.WriteLine($"*       Root Mean Squared Error:      {metrics.RootMeanSquaredError:0.##}");
//
// mlContext.Model.Save(model, dataView.Schema, modelPath);

var time = DateTime.UtcNow;
Console.WriteLine(time);