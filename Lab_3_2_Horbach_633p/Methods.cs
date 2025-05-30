using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_2_Horbach_633p
{
    internal class Methods
    {
        static double[,] matrix;

        public void Matrix_from_textbox(string text)
        {
            var lines = text.Trim().Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int r_count = lines.Length;
            int c_count = lines[0].Trim().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Length;

            matrix = new double[r_count, c_count];

            for (int i = 0; i < r_count; i++)
            {
                var values = lines[i].Trim().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < c_count; j++)
                {
                    matrix[i, j] = double.Parse(values[j], CultureInfo.InvariantCulture);
                }
            }

        }
        public string Criteria_Wald()
        {
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            double[] minValues = new double[r];
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < r; i++)
            {
                double min = Enumerable.Range(0, c).Select(j => matrix[i, j]).Min();
                minValues[i] = min;
            }

            double maxMin = minValues.Max();
            var strategies = minValues.Select((v, i) => new { v, i })
                                      .Where(x => x.v == maxMin)
                                      .Select(x => x.i + 1)
                                      .ToList();

            result.AppendLine($"A{string.Join(" або А", strategies)}");
            return result.ToString();
        }

        public string Criteria_Maximax()
        {
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            double[] maxValues = new double[r];
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < r; i++)
            {
                double max = Enumerable.Range(0, c).Select(j => matrix[i, j]).Max();
                maxValues[i] = max;
            }

            double maxMax = maxValues.Max();
            var strategies = maxValues.Select((v, i) => new { v, i })
                                      .Where(x => x.v == maxMax)
                                      .Select(x => x.i + 1)
                                      .ToList();
            result.AppendLine($"A{string.Join(" або А", strategies)}");
            return result.ToString();
        }

        public string Criteria_Hurwicz(double a)
        {
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            double[] values = new double[r];
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < r; i++)
            {
                double max = Enumerable.Range(0, c).Select(j => matrix[i, j]).Max();
                double min = Enumerable.Range(0, c).Select(j => matrix[i, j]).Min();
                values[i] = a * max + (1 - a) * min;
            }

            double maxH = values.Max();
            var strategies = values.Select((v, i) => new { v, i })
                                   .Where(x => x.v == maxH)
                                   .Select(x => x.i + 1)
                                   .ToList();
            result.AppendLine($"A{string.Join(" або А", strategies)}");
            return result.ToString();
        }

        public string Criteria_Savage()
        {
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            double[,] regrets = new double[r, c];
            StringBuilder result = new StringBuilder();

            for (int j = 0; j < c; j++)
            {
                double maxCol = Enumerable.Range(0, r).Select(i => matrix[i, j]).Max();
                for (int i = 0; i < r; i++)
                    regrets[i, j] = maxCol - matrix[i, j];
            }

          
            double[] maxRegrets = new double[r];
            for (int i = 0; i < r; i++)
            {
                double max = Enumerable.Range(0, c).Select(j => regrets[i, j]).Max();
                maxRegrets[i] = max;
            }

            double minRegret = maxRegrets.Min();
            var strategies = maxRegrets.Select((v, i) => new { v, i })
                                       .Where(x => x.v == minRegret)
                                       .Select(x => x.i + 1)
                                       .ToList();

            result.AppendLine($"A{string.Join(" або А", strategies)}");
            return result.ToString();
        }

        public string Criteria_Laplace()
        {
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            double[] averages = new double[r];
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < r; i++)
            {
                double avg = Enumerable.Range(0, c).Select(j => matrix[i, j]).Average();
                averages[i] = avg;
            }

            double maxAvg = averages.Max();
            var strategies = averages.Select((v, i) => new { v, i })
                                     .Where(x => x.v == maxAvg)
                                     .Select(x => x.i + 1)
                                     .ToList();


            result.AppendLine($"A{string.Join(" або А", strategies)}");
            return result.ToString();

        }

        public string Criteria_Bayes(double[] p)
        {
            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);
            double[] expected = new double[r];
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < r; i++)
            {
                double sum = 0;
                for (int j = 0; j < c; j++)
                    sum += matrix[i, j] * p[j];
                expected[i] = sum;
            }

            double maxExpected = expected.Max();
            var strategies = expected.Select((v, i) => new { v, i })
                                     .Where(x => x.v == maxExpected)
                                     .Select(x => x.i + 1)
                                     .ToList();

            result.AppendLine($"A{string.Join(" або А", strategies)}");
            return result.ToString();
        }


        public string Get_most_strategies(double a, double[] p)
        {
            var all_strategies = new List<int>();

            // Отримати всі стратегії з кожного критерію
            all_strategies.AddRange(ParseStrategies(Criteria_Wald()));
            all_strategies.AddRange(ParseStrategies(Criteria_Maximax()));
            all_strategies.AddRange(ParseStrategies(Criteria_Hurwicz(a)));
            all_strategies.AddRange(ParseStrategies(Criteria_Savage()));
            all_strategies.AddRange(ParseStrategies(Criteria_Laplace()));
            all_strategies.AddRange(ParseStrategies(Criteria_Bayes(p)));

            // Підрахунок
            var count = all_strategies.GroupBy(x => x)
                                    .Select(g => new { Strategy = g.Key, Count = g.Count() })
                                    .OrderByDescending(x => x.Count)
                                    .ToList();

            int maxCount = count.First().Count;
            var mostFrequent = count.Where(x => x.Count == maxCount)
                                   .Select(x => x.Strategy)
                                   .ToList();

            return $"A{string.Join(" або A", mostFrequent)}";
        }

        // Парсер для витягування номерів стратегій з рядка, наприклад: "A1 або A3"
        private List<int> ParseStrategies(string result)
        {
            var strategies = new List<int>();
            var parts = result.Split(new[] { 'A' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var num = part.Trim().Split(' ')[0];
                if (int.TryParse(num, out int n))
                    strategies.Add(n);
            }

            return strategies;
        }

        public void SaveDetailedProtocolToFile(string filePath, double a, double[] p)
        {
            StringBuilder protocol = new StringBuilder();

            int r = matrix.GetLength(0);
            int c = matrix.GetLength(1);

            //Матриця корисності
            protocol.AppendLine("Згенерований протокол обчислення:");
            protocol.AppendLine("  ");
            protocol.AppendLine("Матриця корисності результатів U:");
            protocol.AppendLine("  ");
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    protocol.Append(matrix[i, j] + " ");
                }
                protocol.AppendLine();
            }

            //Критерій Вальда
            protocol.AppendLine("  ");
            protocol.AppendLine("Критерій Вальда:");
            protocol.AppendLine("  ");
            double[] minValues = new double[r];
            for (int i = 0; i < r; i++)
            {
                double min = Enumerable.Range(0, c).Select(j => matrix[i, j]).Min();
                minValues[i] = min;
                protocol.AppendLine($"min в рядку {i + 1}: {min}");
            }
            double maxMin = minValues.Max();
            protocol.AppendLine($"Максимальний елемент: {maxMin}");
            var wald = Get_strategy_index(minValues, maxMin);
            protocol.AppendLine($"Оптимальні стратегії: A{string.Join(" або A", wald)}");
            protocol.AppendLine("  ");
            protocol.AppendLine("Критерій максимаксу:");
            protocol.AppendLine("  ");
            double[] maxValues = new double[r];
            for (int i = 0; i < r; i++)
            {
                double max = Enumerable.Range(0, c).Select(j => matrix[i, j]).Max();
                maxValues[i] = max;
                protocol.AppendLine($"max в рядку {i + 1}: {max}");
            }
            double maxMax = maxValues.Max();
            protocol.AppendLine($"Максимальний елемент: {maxMax}");
            var maximax = Get_strategy_index(maxValues, maxMax);
            protocol.AppendLine($"Оптимальні стратегії: A{string.Join(" або A", maximax)}");

            //Гурвіц
            protocol.AppendLine("  ");
            protocol.AppendLine("Критерій Гурвіца:");
            protocol.AppendLine($"Коефіцієнт y = {a.ToString(CultureInfo.InvariantCulture)}");
            double[] hurwicz = new double[r];
            for (int i = 0; i < r; i++)
            {
                double min = Enumerable.Range(0, c).Select(j => matrix[i, j]).Min();
                double max = Enumerable.Range(0, c).Select(j => matrix[i, j]).Max();
                protocol.AppendLine($"min в рядку {i + 1}: {min}");
                protocol.AppendLine($"max в рядку {i + 1}: {max}");
                hurwicz[i] = a * min + (1 - a) * max;
                protocol.AppendLine($"s{i + 1} = {a} * {min} + (1 - {a}) * {max} = {hurwicz[i]:0.##}");
            }
            double maxHurwicz = hurwicz.Max();
            protocol.AppendLine($"Максимальний елемент: {maxHurwicz}");
            var hur = Get_strategy_index(hurwicz, maxHurwicz);
            protocol.AppendLine($"Оптимальні стратегії: A{string.Join(" або A", hur)}");

            //Севідж
            protocol.AppendLine("  ");
            protocol.AppendLine("Критерій Севіджа:");
            double[,] regrets = new double[r, c];
            for (int j = 0; j < c; j++)
            {
                double maxCol = Enumerable.Range(0, r).Select(i => matrix[i, j]).Max();
                for (int i = 0; i < r; i++)
                    regrets[i, j] = maxCol - matrix[i, j];
            }
            protocol.AppendLine("Матриця ризиків:");
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                    protocol.Append($"{regrets[i, j]:0.#} ");
                protocol.AppendLine();
            }

            double[] maxRegrets = new double[r];
            for (int i = 0; i < r; i++)
            {
                maxRegrets[i] = Enumerable.Range(0, c).Select(j => regrets[i, j]).Max();
                protocol.AppendLine($"max в рядку {i + 1}: {maxRegrets[i]}");
            }
            double minRegret = maxRegrets.Min();
            protocol.AppendLine($"Мінімальний елемент: {minRegret}");
            var sav = Get_strategy_index(maxRegrets, minRegret);
            protocol.AppendLine($"Оптимальні стратегії: A{string.Join(" або A", sav)}");

            //Байєса
            protocol.AppendLine("  ");
            protocol.AppendLine("Критерій Байєса:");
            protocol.Append("Ймовірності застосування природою своїх стратегій: ");
            for (int i = 0; i < p.Length; i++)
                protocol.Append($"p{i + 1} = {p[i]:0.##}; ");
            protocol.AppendLine();

            double[] bayes = new double[r];
            for (int i = 0; i < r; i++)
            {
                double s = 0;
                for (int j = 0; j < c; j++)
                    s += matrix[i, j] * p[j];
                bayes[i] = s;
                protocol.AppendLine($"s{i + 1} = " + string.Join(" + ", Enumerable.Range(0, c).Select(j => $"{matrix[i, j]} * {p[j]}")) + $" = {s:0.##}");
            }
            double maxBayes = bayes.Max();
            protocol.AppendLine($"Максимальний елемент: {maxBayes}");
            var bay = Get_strategy_index(bayes, maxBayes);
            protocol.AppendLine($"Оптимальні стратегії: A{string.Join(" або A", bay)}");

            //Лапласа
            protocol.AppendLine("  ");
            protocol.AppendLine("Критерій Лапласа:");
            double equalProb = 1.0 / c;
            double[] laplace = new double[r];
            for (int i = 0; i < r; i++)
            {
                laplace[i] = Enumerable.Range(0, c).Sum(j => matrix[i, j] * equalProb);
                protocol.AppendLine($"s{i + 1} = " + string.Join(" + ", Enumerable.Range(0, c).Select(j => $"{matrix[i, j]} * {equalProb:0.##}")) + $" = {laplace[i]:0.##}");
            }
            double maxLap = laplace.Max();
            protocol.AppendLine($"Максимальний елемент: {maxLap}");
            var lap = Get_strategy_index(laplace, maxLap);
            protocol.AppendLine($"Оптимальні стратегії: A{string.Join(" або A", lap)}");

            //Найчастіші стратегії
            var all = new List<int>();
            all.AddRange(wald);
            all.AddRange(maximax);
            all.AddRange(hur);
            all.AddRange(sav);
            all.AddRange(bay);
            all.AddRange(lap);


            var freq = all.GroupBy(x => x).Select(g => new { g.Key, Count = g.Count() }).OrderByDescending(x => x.Count).ToList();
            int maxFreq = freq.First().Count;
            var mostFreq = freq.Where(x => x.Count == maxFreq).Select(x => x.Key).ToList();
            protocol.AppendLine("  ");
            protocol.AppendLine($"Найчастіше були оптимальними стратегії: A{string.Join(" або A", mostFreq)}");

            // Запис у файл
            File.WriteAllText(filePath, protocol.ToString());
        }


        private List<int> Get_strategy_index(double[] array, double target)
        {
            return array.Select((val, idx) => new { val, idx })
                        .Where(x => x.val == target)
                        .Select(x => x.idx + 1)
                        .ToList();
        }


    }
}
