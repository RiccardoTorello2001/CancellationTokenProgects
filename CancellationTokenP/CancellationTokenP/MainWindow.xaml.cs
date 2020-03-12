using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CancellationTokenP
{
	/// <summary>
	/// Logica di interazione per MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		CancellationTokenSource ct = new CancellationTokenSource();
		CancellationTokenSource ct2 = new CancellationTokenSource();
		CancellationTokenSource ct3 = new CancellationTokenSource();

		public MainWindow()
		{
			InitializeComponent();
			
		}

		private void Btn_Start_Click(object sender, RoutedEventArgs e)
		{
			ct = new CancellationTokenSource();
			if (ct2.Token.IsCancellationRequested)
			{
				ct3.Cancel();
			}
			Task.Factory.StartNew(() => DoWork(100, 1000, Lbl_op1, ct));
		}

		private void Btn_stop1_Click(object sender, RoutedEventArgs e)
		{
			if (ct != null)
			{
				ct.Cancel();
				ct = null;
			}
		}

		private void btn_Start2_Click(object sender, RoutedEventArgs e)
		{
			ct2 = new CancellationTokenSource();
			if(ct2.Token.IsCancellationRequested)
			{
				ct2.Cancel();
			}
			int max = Convert.ToInt32(txt_count1.Text);
			Task.Factory.StartNew(() => DoWork(max, 1000, Lbl_op2, ct2));
		}

		private void DoWork(int max, int delay, Label lbl, CancellationTokenSource ct)
		{
			for(int i = 0; i < max; i++)
{
				Dispatcher.Invoke(() => UpdateUI(i, lbl));
				Thread.Sleep(delay);

				if (ct.Token.IsCancellationRequested)
				{
					break;
				}
				Console.ReadLine();
			}
		}

		private void UpdateUI(int i, Label lbl)
		{
			lbl.Content = i.ToString();
		}

		private void Btn_start3_Click(object sender, RoutedEventArgs e)
		{
			ct3 = new CancellationTokenSource();
			if(ct3.Token.IsCancellationRequested)
			{
				ct3.Cancel();
			}
			int max = Convert.ToInt32(txt_count_op3.Text);
			int delay = Convert.ToInt32(txt_ritardo_op3.Text);
			Task.Factory.StartNew(() => DoWork(max, delay, Lbl_op3, ct3));
		}

		private void Btn_stop_ultimidue_Click(object sender, RoutedEventArgs e)
		{
			if (ct2 != null)
			{
				ct2.Cancel();
				ct2 = null;
			}

			if (ct3 != null)
			{
				ct3.Cancel();
				ct3 = null;
			}

		}

		private void Btn_stop_tutti_Click(object sender, RoutedEventArgs e)
		{
			if (ct != null)
			{
				ct.Cancel();
				ct = null;
			}
			if (ct2 != null)
			{
				ct2.Cancel();
				ct2 = null;
			}
			if (ct3 != null)
			{
				ct3.Cancel();
				ct3 = null;
			}
		}
	}
}

