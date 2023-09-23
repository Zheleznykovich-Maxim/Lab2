using System.Diagnostics;
using System.Management;
namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (int.TryParse(txtNa.Text, out int N_a) &&
            //   int.TryParse(txtNThreads.Text, out int N_threads) &&
            //   int.TryParse(txtK.Text, out int K) &&
            //   int.TryParse(txtDeltaThreads.Text, out int Delta_threads) &&
            //   int.TryParse(txtDeltaK.Text, out int Delta_K))
            if (true)
            {
                int N_threads = 4; // Замените на ваши значения параметров
                int Delta_threads = 1;
                int Delta_K = 10;
                int K = 100;
                int N_a = 10000;

                // Создаем массив случайных чисел
                double[] a = GenerateRandomArray(N_a);

                // Многопоточные вычисления
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                double[] b = MultithreadedCalculate(a, N_threads, K);

                stopwatch.Stop();
                double elapsedTime = stopwatch.ElapsedMilliseconds;

                // Выводим результаты
                //ResultTextBox.Text = $"Результаты расчетов:\r\n" +
                //                     $"Время выполнения: {elapsedTime} мс\r\n" +
                //                     $"Тактовая частота процессора: {processorInfo.ClockSpeed} ГГц\r\n" +
                //                     $"Количество ядер процессора: {processorInfo.CoreCount}\r\n" +
                //                     $"Результат первого элемента массива b: {b[0]}";
                
                Form Form2 = new Form2(N_threads, Delta_threads, Delta_K, K, N_a);
                Form2.Show();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные значения параметров.");
            }
        }
        public static ProcessorInfo GetProcessorInfo()
        {
            var processorInfo = new ProcessorInfo();

            try
            {
                using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
                {
                    foreach (var queryObj in searcher.Get())
                    {
                        // Получаем тактовую частоту (в ГГц)
                        var clockSpeed = Convert.ToDouble(queryObj["MaxClockSpeed"]) / 1000.0;
                        processorInfo.ClockSpeed = clockSpeed;

                        // Получаем количество ядер процессора
                        processorInfo.CoreCount = Convert.ToInt32(queryObj["NumberOfCores"]);
                    }
                }
            }
            catch (ManagementException ex)
            {
                // Обработка исключений, если что-то пошло не так при запросе WMI
                Console.WriteLine($"Ошибка при получении информации о процессоре: {ex.Message}");
            }

            return processorInfo;
        }
        private double[] GenerateRandomArray(int N_a)
        {
            Random random = new Random();
            double[] a = new double[N_a];
            for (int i = 0; i < N_a; i++)
            {
                a[i] = random.NextDouble();
            }
            return a;
        }
        private double[] MultithreadedCalculate(double[] a, int N_threads, double K)
        {
            double[] b = new double[a.Length];

            Parallel.For(0, a.Length, new ParallelOptions { MaxDegreeOfParallelism = N_threads }, i =>
            {
                for (int j = 0; j < K; j++)
                {
                    b[i] += Math.Pow(a[i], 1.789);
                }
            });

            return b;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Получим информацию о процессоре
            var processorInfo = GetProcessorInfo();
            clockFreq.Text = $"{processorInfo.ClockSpeed.ToString()} ГГц";
            countCore.Text = processorInfo.CoreCount.ToString();
        }
    }
    public class ProcessorInfo
    {
        public double ClockSpeed { get; set; }
        public int CoreCount { get; set; }
    }
}