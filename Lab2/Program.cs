using System;

namespace Lab2
{
	class Program
	{
		//Общий эпсилон
		static double E = 0.00005;

		//Глобальные переменные для Метода Хорд
		static Func<double, double> F = x => Math.Log10(x) - 0.13f / x;
		static double X0 = 0.13;
		static double Fx0 = F(0.13);

		//Метод Простой Итерации
		static string FixedPointIteration(double xn, int n)
		{
			double xn1 = Math.Pow(10, 0.13f / xn);
			if (Math.Abs(xn - xn1) < E)
				return $"Метод простой итерации вычислил корень { xn1 } за { n } итераций";
			return FixedPointIteration(xn1, n + 1);
		}

		//Метод Хорд
		static string SecantIteration(double xn, int n)
		{
			double fxn = F(xn);
			double xn1 = xn - (fxn / (fxn - Fx0)) * (xn - X0);
			if (Math.Abs(xn - xn1) < E)
				return $"Метод Хорд вычислил корень {xn1} за {n} итераций";
			return SecantIteration(xn1, n + 1);
		}
		
		//Точка входа в программу, основной вывод
		static void Main(string[] args)
		{
			Console.WriteLine(FixedPointIteration(0.13, 0));
			Console.WriteLine(SecantIteration(10, 1));
		}
	}
}
