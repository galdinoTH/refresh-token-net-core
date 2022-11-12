using System;
using System.Collections.Generic;

namespace RefreshToken.Core.Extensions;

public static class MathExtensions
{
    public static double WeightedAverage<T>(this IEnumerable<T> records,  double value, Func<T, double> weight)
    {
        if (records == null)
            throw new ArgumentNullException(nameof(records), $"{nameof(records)} é nulo.");

        int count = 0;
        double valueSum = 0;
        double weightSum = 0;

        foreach (var record in records)
        {
            count++;
            double recordWeight = weight(record);

            valueSum += value * recordWeight;
            weightSum += recordWeight;
        }

        if (count == 0)
            throw new ArgumentException($"{nameof(records)} é vazio.");

        if (count == 1)
            return value;

        if (weightSum != 0)
            return valueSum / weightSum;
        else
            throw new DivideByZeroException($"Divisão de {valueSum} por zero.");
    }

    public static long ToTonne(this long number) => number / 1000;
    public static long ToKilos(this long number) => number * 1000;
}
