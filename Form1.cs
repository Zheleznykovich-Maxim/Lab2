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
            if (int.TryParse(txtNa.Text, out int N_a) &&
               int.TryParse(txtNThreads.Text, out int N_threads) &&
               int.TryParse(txtK.Text, out int K) &&
               int.TryParse(txtDeltaThreads.Text, out int Delta_threads) &&
               int.TryParse(txtDeltaK.Text, out int Delta_K))
            {   
                Form Form2 = new Form2(N_threads, Delta_threads, Delta_K, K, N_a);
                Form2.Show();
            }
            else
            {
                MessageBox.Show("����������, ������� ���������� �������� ����������.");
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
                        // �������� �������� ������� (� ���)
                        var clockSpeed = Convert.ToDouble(queryObj["MaxClockSpeed"]) / 1000.0;
                        processorInfo.ClockSpeed = clockSpeed;

                        // �������� ���������� ���� ����������
                        processorInfo.CoreCount = Convert.ToInt32(queryObj["NumberOfCores"]);
                    }
                }
            }
            catch (ManagementException ex)
            {
                // ��������� ����������, ���� ���-�� ����� �� ��� ��� ������� WMI
                Console.WriteLine($"������ ��� ��������� ���������� � ����������: {ex.Message}");
            }

            return processorInfo;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // ������� ���������� � ����������
            var processorInfo = GetProcessorInfo();
            clockFreq.Text = $"{processorInfo.ClockSpeed.ToString()} ���";
            countCore.Text = processorInfo.CoreCount.ToString();
            txtNThreads.Text = 4.ToString(); // �������� �� ���� �������� ����������
            txtDeltaThreads.Text = 1.ToString();
            txtDeltaK.Text = 10.ToString();
            txtK.Text = 100.ToString();
            txtNa.Text = 1000.ToString();
        }
    }
    public class ProcessorInfo
    {
        public double ClockSpeed { get; set; }
        public int CoreCount { get; set; }
    }
}