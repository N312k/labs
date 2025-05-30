﻿string text = "D:/f.txt";
StreamReader sr = new StreamReader(text);

int n;
n = Convert.ToInt32(sr.ReadLine());

double[,] matrixG = new double[n, n];
for (int i = 0; i < n; i++)
{
    string[] line1 = sr.ReadLine().Split(" ");
    for (int j = 0; j < n; j++)
    {
        matrixG[i, j] = double.Parse(line1[j]);
    }
}

double[] vector = new double[n];
string[] line2 = sr.ReadLine().Split(" ");
for (int i = 0; i < n; i++)
{
    vector[i] = double.Parse(line2[i]);
}

bool Symetric = true;
for (int i = 0; i < n; i++)
{
    for (int j = i + 1; j < n; j++)
    {
        if (matrixG[i, j] != matrixG[j, i]) { Symetric = false; break; }
    }
    if (!Symetric) break;
}

double length = 0;

if (Symetric)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            length += vector[i] * matrixG[i, j] * vector[j];
        }
    }
    length = Math.Sqrt(length);
}
else Console.WriteLine("Матрица метрического тензора не симметрична.");

Console.WriteLine($"Длина вектора: {length}");