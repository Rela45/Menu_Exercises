using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



	internal static class Utils
	{
		/// <summary>
		/// Chiede in un Loop un valore all'utente in console, finché non viene inserito un valore int
		/// </summary>
		/// <param name="output">In uscita, l'input dell'utente da console</param>
		public static void ReadLine(out int output)
		{
			string? input = Console.ReadLine();

			while (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out output))
			{
				input = Console.ReadLine();
			}
		}

	/// <summary>
	/// Chiede in un Loop un valore all'utente in console, finché non viene inserito un valore float
	/// </summary>
	/// <param name="output">In uscita, l'input dell'utente da console</param>
	public static void ReadLine(out float output)
	{
		string? input = Console.ReadLine();

		while (string.IsNullOrWhiteSpace(input) || !float.TryParse(input, out output))
		{
			input = Console.ReadLine();
		}
	}
		
		public static void ReadLine(out double output)
		{
			string? input = Console.ReadLine();

			while (string.IsNullOrWhiteSpace(input) || !double.TryParse(input, out output))
			{
				input = Console.ReadLine();
			}
		}

		/// <summary>
		/// Chiede in un Loop una stringa all'utente da console, finché non inserisce una stringa NON null, vuota, o solo spazi
		/// </summary>
		/// <param name="output">In uscita, l'input dell'utente da console</param>
		public static void ReadLine(out string output)
		{
			string? input = Console.ReadLine();
			
			while (string.IsNullOrWhiteSpace(input))
			{
				input = Console.ReadLine();
			}

			output = input.Trim();
		}

		
	}
