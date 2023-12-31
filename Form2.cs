﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lab2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(int n_threads, int delta_threads, int delta_K, int k, int n_a)
        {
            InitializeComponent();
            N_threads = n_threads;
            Delta_threads = delta_threads;
            Delta_K = delta_K;
            K = k;
            N_a = n_a;
        }

        public int N_threads { get; }
        public int Delta_threads { get; }
        public int Delta_K { get; }
        public int K { get; }
        public int N_a { get; }

        private Chart chart;

        private void InitializeChart()
        {
            // Создаем новый график
            chart = new Chart();
            chart.Dock = DockStyle.Fill;

            // Создаем область графика для графика 1
            ChartArea chartArea1 = new ChartArea("ChartArea1");
            chartArea1.AxisX.Title = "Количество потоков";
            chartArea1.AxisY.Title = "Время выполнения (мс)";

            // Создаем область графика для графика 2
            ChartArea chartArea2 = new ChartArea("ChartArea2");
            chartArea2.AxisX.Title = "Параметр сложности K";
            chartArea2.AxisY.Title = "Время выполнения (мс)";

            // Добавляем области графика
            chart.ChartAreas.Add(chartArea1);
            chart.ChartAreas.Add(chartArea2);

            // Добавляем график на форму
            this.Controls.Add(chart);

            DrawChartWithMultithreading(N_threads, Delta_threads, Delta_K, K, N_a);
        }

        public void DrawChartWithMultithreading(int N_threads, int Delta_threads, int Delta_K, int K, int N_a)
        {
            try
            {
                // Создаем график 1: Ось OX - количество потоков, Ось OY - время выполнения расчетов
                Series series1 = new Series("График 1");
                series1.ChartType = SeriesChartType.Line;
                series1.ChartArea = "ChartArea1"; // Указываем область для этой серии
                series1.Color = Color.Blue;
                series1.BorderWidth = 2;
                for (int i = 1; i <= N_threads; i++)
                {
                    double elapsedTime = MeasureCalculationTime(i, K);
                    series1.Points.AddXY(i, elapsedTime);
                }

                chart.Series.Add(series1);

                // Создаем график 2: Ось OX - Параметр сложности K, Ось OY - время выполнения расчетов
                Series series2 = new Series("График 2");
                series2.ChartType = SeriesChartType.Line;
                series2.ChartArea = "ChartArea2"; // Указываем область для этой серии
                series2.Color = Color.Blue;
                series2.BorderWidth = 2;
                double Max_K = K; // Максимальное значение K

                for (double currentK = 1.0; currentK <= Max_K; currentK += Delta_K)
                {
                    double elapsedTime = MeasureCalculationTime(N_threads, currentK);
                    series2.Points.AddXY(currentK, elapsedTime);
                }

                chart.Series.Add(series2);

                // Создаем график 3: Ось OX - количество потоков, Ось OY - время выполнения расчетов (с многопоточностью)
                Series series3 = new Series("График 1 (Multithreaded)");
                series3.Color = Color.Red;
                series3.ChartType = SeriesChartType.Line;
                series3.ChartArea = "ChartArea1"; // Указываем область для этой серии
                series3.BorderWidth = 2;
                for (int i = 1; i <= N_threads; i++)
                {
                    double elapsedTime = MeasureMultithreadedCalculationTime(i, K);
                    series3.Points.AddXY(i, elapsedTime);
                }

                chart.Series.Add(series3);

                // Создаем график 4: Ось OX - Параметр сложности K, Ось OY - время выполнения расчетов (с многопоточностью)
                Series series4 = new Series("График 2 (Multithreaded)");
                series4.Color = Color.Red;
                series4.ChartType = SeriesChartType.Line;
                series4.ChartArea = "ChartArea2"; // Указываем область для этой серии
                series4.BorderWidth = 2;
                for (double currentK = 1.0; currentK <= Max_K; currentK += Delta_K)
                {
                    double elapsedTime = MeasureMultithreadedCalculationTime(N_threads, currentK);
                    series4.Points.AddXY(currentK, elapsedTime);
                }

                chart.Series.Add(series4);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private double MeasureCalculationTime(int N_threads, double K)
        {
            // Создаем массив случайных чисел
            double[] a = GenerateRandomArray(N_a);

            // Создаем объект Stopwatch для измерения времени выполнения
            Stopwatch stopwatch = new Stopwatch();

            // Запускаем таймер
            stopwatch.Start();

            // В ыполняем расчеты
            double[] b = new double[N_a];
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < K; j++)
                {
                    b[i] += (int)Math.Pow(a[i], 1.789);
                }
            }

            // Останавливаем таймер
            stopwatch.Stop();

            // Получаем время выполнения в миллисекундах
            double elapsedTime = stopwatch.ElapsedMilliseconds;

            return elapsedTime;
        }

        private double MeasureMultithreadedCalculationTime(int N_threads, double K)
        {
            // Создаем массив случайных чисел
            double[] a = GenerateRandomArray(N_a);

            // Создаем объект Stopwatch для измерения времени выполнения
            Stopwatch stopwatch = new Stopwatch();

            // Запускаем таймер
            stopwatch.Start();

            double[] b = new double[N_a];
            Thread[] threads = new Thread[N_threads];

            // Разделяем массив a на сегменты для каждого потока
            int segmentSize = N_a / N_threads;
            for (int i = 0; i < N_threads; i++)
            {
                int startIndex = i * segmentSize;
                int endIndex = (i == N_threads - 1) ? N_a : (i + 1) * segmentSize;

                threads[i] = new Thread(() =>
                {
                    for (int j = startIndex; j < endIndex; j++)
                    {
                        for (int k = 0; k < K; k++)
                        {
                            b[j] += Math.Pow(a[j], 1.789);
                        }
                    }
                });

                threads[i].Start();
            }

            // Ждем завершения всех потоков
            foreach (var thread in threads)
            {
                thread.Join();
            }

            // Останавливаем таймер
            stopwatch.Stop();

            // Получаем время выполнения в миллисекундах
            double elapsedTime = stopwatch.ElapsedMilliseconds;

            return elapsedTime;
        }
        private double[] GenerateRandomArray(int N_a)
        {
            Random random = new Random();
            double[] array = new double[N_a];
            for (int i = 0; i < N_a; i++)
            {
                array[i] = random.NextDouble();
            }
            return array;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            InitializeChart();
        }
    }
}
