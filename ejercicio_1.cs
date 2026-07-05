public class Ejercicio_1
	{
		public static void Main(string[] args)
		{
			Console.WriteLine(ValidarComprobanteElectronico("B123-00032123"));
			Console.WriteLine(ValidarComprobanteElectronico("F001-00001234"));

			Console.WriteLine(ValidarComprobanteElectronico("A121-32121"));
			Console.WriteLine(ValidarComprobanteElectronico("B12-00012345"));
			Console.WriteLine(ValidarComprobanteElectronico("F123-ABCD1234"));

			Console.WriteLine(ValidarComprobanteElectronico("FA01-ABCD1234"));
			Console.WriteLine(ValidarComprobanteElectronico("B123-1234"));
		}

			public static bool ValidarComprobanteElectronico(string numero)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(numero))
					return false;

				string[] partes = numero.Split('-');

				if (partes.Length != 2)
					return false;

				string serie = partes[0];
				string correlativo = partes[1];

				// Validar longitud de la serie
				if (serie.Length != 4){
					Console.WriteLine("Error: La Longitud de la serie es errónea. Debe tener 4 caracteres");
					return false;
				}
					
				// Validar primer carácter (B o F)
				if (serie[0] != 'B' && serie[0] != 'F'){
					Console.WriteLine("Error: El primer caracter de la serie debe ser B o F");
					return false;
				}
					
				// Validar que los siguientes 3 caracteres sean números
				for (int i = 1; i < 4; i++)
				{
					if (!char.IsDigit(serie[i])){
						Console.WriteLine("Error: Los caracteres que van despues del primer caracter deben ser números");
						return false;
					}
				}

				// Validar correlativo
				if (correlativo.Length != 8){
					Console.WriteLine("Error: El correlativo que va despues del guión NO tiene 8 caracteres");
					return false;
				}

				foreach (char c in correlativo)
				{
					if (!char.IsDigit(c)){
						Console.WriteLine("Error: Se encontró caracteres que NO son dígitos en el correlativo");
						return false;
					}	
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
	}