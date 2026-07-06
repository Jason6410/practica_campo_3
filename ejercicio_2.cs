public class Program
	{
		public static void Main(string[] args)
		{
			DateTime fechaCreacion = new DateTime(2023, 10, 10, 14, 0, 0);
        	DateTime fechaResolucion = new DateTime(2023, 10, 11, 10, 0, 0);

			double horasLaborales = CalcularHorasLaborales(fechaCreacion, fechaResolucion);

			Console.WriteLine(fechaCreacion);
			Console.WriteLine(fechaResolucion);
			Console.WriteLine($"Horas laborales: {horasLaborales}");
	
			if (horasLaborales <= 8)
			{
				Console.WriteLine("Estado SLA: Cumplido");
			}
			else
			{
				Console.WriteLine($"Estado SLA: Incumplido: {horasLaborales - 8} horas de más");
			}
		}

		public static double CalcularHorasLaborales(DateTime fechaCreacion, DateTime fechaResolucion)
		{
			double horas = 0;
			DateTime actual = fechaCreacion;

			while (actual < fechaResolucion)
			{
				// Excluir sábado y domingo
				if (actual.DayOfWeek != DayOfWeek.Saturday && actual.DayOfWeek != DayOfWeek.Sunday)
				{
					// Horario laboral: 09:00 - 17:00
					if (actual.Hour >= 9 && actual.Hour < 17)
					{
						horas++;
					}
				}
				actual = actual.AddHours(1);
			}
			return horas;
		}
	}