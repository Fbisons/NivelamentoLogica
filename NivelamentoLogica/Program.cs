using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;



namespace NivelamentoLogica
{
	class MaiorPrimeiro : Exception
	{
		public MaiorPrimeiro(string message)
		{
		}
	}
	class Program
    {
		/*1)Numeros:
		Criar programa que recebera dois numeros de entrada e retornar o resultado conforme exemplo abaixo:*/
		static void numero()
		{
			Console.WriteLine("Digite um número");
			float a = (float)Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Digite outro número");
			float b = (float)Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Soma:" + (a + b));
			Console.WriteLine("Subtração:" + (a - b));
			Console.WriteLine("Multiplicação:" + (a * b));
			Console.WriteLine("Divisão:" + (a/b));
			Console.WriteLine("Divisão inteira:" + ((int)(a + b)));
			Console.WriteLine("Resto:" + (a % b));
			Console.WriteLine("Potencia:" + (Math.Pow(a, b)));
			Console.ReadLine();
		}

		/*2)Numeros: 
		Criar um programa que receba um texto e retorne se o mesmo pode ser convertido para numero. 
		Caso seja possivel informar se o numero é inteiro ou flutuante.
		Desconsiderar a configuração de cultura (vide dicas), portanto o usuario pode usar . ou , como separador de decimal
		.*/
		static void converter()
        {
			Console.WriteLine("Digite um número");
			string text = Console.ReadLine();
			int number;
			float numero;
			bool successINT = Int32.TryParse(text, out number);
			bool sucessFLOAT = float.TryParse(text, out numero);
			if (successINT) Console.WriteLine("Inteiro");
			else if (sucessFLOAT) Console.WriteLine("Flutuante");
			else Console.WriteLine("Não é um numero valido");
			Console.ReadLine();
		}
		/*3)Texto:
		Criar programa que receba um texto e retorne o tamanho dele seguido de seu conteudo em caixa alta e caixa baixa.
	
		Entrada: "Isso é UM Teste"		
		Saida: "15 - isso é um teste - ISSO É UM TESTE"*/
		static void text3()
        {
			Console.WriteLine("Digite um TEXTO");
			string text = Console.ReadLine();
			Console.WriteLine(" '{0}' - '{1}' - '{2}' ", text.Length, text.ToLower() , text.ToUpper());
			Console.ReadLine();
		}

		/*4)Texto: 
		Criar um programa que receba dois texto e que retorne a quantidade de ocorrencias do primeiro parametro no segundo parametro.
		Deve ser desconsiderado se é maiuscula ou minuscula, mas deve considerar acentuação, portanto a é diferente de á.
	
		Entrada: A e "A pipa do Vovo não sobre MAIS."
		Saida: 3 ocorrencias*/
		static int NdeOcorrencias(string a, string b)
        {
			int freq = Regex.Matches(b.ToLower(), a.ToLower()).Count;
			return freq;
		}
		static void text4()
        {
			Console.WriteLine("Digite um Texto que deve ser encontrado");
			string text = Console.ReadLine();
			Console.WriteLine("Digite outro Texto para ter o número de ocorrências");
			string text2 = Console.ReadLine();
			Console.WriteLine(text.Length);
			Console.WriteLine(NdeOcorrencias(text, text2));
			Console.ReadLine();
		}

		/*5)Texto: 
		Criar um programa que receba um texto e valida se existe o caracter - no mesmo.
		Caso ocorra, retorne o conteudo após o - sem espaços no inicio e no final. 
		Caso não existe, retorne o mesmo texto com o prefixo sendo a data atual seguida de um -;
	
		Entrada: "teste - texto       " 
		Saida: "texto"*/
		static void text5()
        {
			Console.WriteLine("Digite um Texto");
			string text = Console.ReadLine();
			int index=text.IndexOf('-');
			Console.WriteLine(index);
			if(index== -1)
            {
				DateTime thisDay = DateTime.Today;
				text= thisDay.ToString("g") + " - " +text;
			}
			if (index > 0)
            {
				text = text.Remove(0, index + 1);
				int inicio, fim;
				for (inicio=0; inicio<text.Length; inicio++)
                {
					if (text[inicio] != ' ') break;
                }
				for (fim=(text.Length-1); fim>0; fim--)
                {
					if (text[fim] != ' ') break;
                }

				text = text.Substring(inicio, fim-inicio);
            }
			Console.Write(text);
			Console.ReadLine();

		}

		/*6)Data: 
		Criar um programa que receba um texto e retorne se o mesmo pode ser convertido para data. 
		Utilizar configuração de cultura padrão, portanto o formato da data depende de sua configuração local. 
		No meu exemplo está considerando DD/MM/AAAA que é a configuração padrão em portugues.
	
		Entrada: 01/01/2010		saida: Data válida
		Entrada: 31/02/2010 	saida: Data invalida
		Entrada: Jujubinha 		saida: Data invalida
		Entrada: 0 				saida: Data invalida*/
		static void data6(){
			Console.WriteLine("Digite uma data");
			string data = Console.ReadLine();
			DateTime datav;
			if(DateTime.TryParse(data, out datav)== true) Console.WriteLine("Data válida");
			if (DateTime.TryParse(data, out datav) == false) Console.WriteLine("Data inválida");
			Console.ReadLine();
		}

		/*7)Data: 
		Criar programa para receber uma data e extrair dela o Dia, Mes, Ano, Hora, Minutos e Segundos.
		Entrada: 01/01/2010 15:05:33	
		Saida: Dia 01 do mês 01 do ano 2010, as 15 horas, 05 minutos e 33 segundos.*/
		static void fracionadata(DateTime data)
        {
			Console.WriteLine("Dia '{0}' do mês '{1}' do ano '{2}' , às '{3}' horas, '{4}' minutos e '{5}' segundos.", data.Day.ToString(), data.Month.ToString(), data.Year.ToString(), data.Hour.ToString(), data.Minute.ToString(), data.Second.ToString());
			Console.ReadLine();
		}
		static void teste7()
        {
			fracionadata(DateTime.Now);
        }
		
		/*8)Data: 
		Criar um programa que receberá duas datas e validará se a primeira é maior que a segunda, retornando excessão caso seja, e se as mesma são do mesmo dia. 
		Caso seja deve retorna a diferença em horas, minutos e segundos. 
		Caso não seja, deve retornar a diferença na maior unidade. 
		Se for mais de um ano, retornar em anos; menos que ano, mas maior que meses, em meses; menor que meses em dias; menor que dias, zero.
		O retorno deverá ser distinto por unidade.
	
		Entrada: 01/01/2001 10:00:00 e 01/01/2001 10:03:30 
		Saida: 
			Diferença em horas: 0,
			Diferença em minutos: 3.5 
			Diferença em segundos: 180 
		
		Entrada: 01/03/2001 10:00:00 e 30/03/2001 12:00:00 
		Saida: 
			Diferença em dias: 30 dias.	
		
		Entrada: 01/03/2001 10:00:00 e 01/04/2001 12:00:00 
		Saida: 
			Diferença em mes: 1 mes. */

		static void comparedate(DateTime d1, DateTime d2)
        {
			int result = DateTime.Compare(d1, d2);
			if (result>0) throw new MaiorPrimeiro("A primeira data deve ser a mais antiga");
			if (result < 0)
            {
				TimeSpan diff = (d2 - d1);
				//se as mesma são do mesmo dia deve retorna a diferença em horas, minutos e segundos.
				if (diff.TotalDays >= 365)
				{
					Console.WriteLine("Diferença em anos: {0} ano(s).", ((int)(diff.TotalDays / 365)));
				}
				else if (diff.TotalDays >= 30)
				{
					Console.WriteLine("Diferença em meses: {0} mes(es).", ((int)(diff.TotalDays / 30)));
				}
				else if (diff.TotalDays >= 1)
				{
					Console.WriteLine("Diferença em dias: {0} dia(s).", ((int)(diff.TotalDays)));
				}
				else
				{
					Console.WriteLine("Diferença em hora(s): {0} hora(s).", ((int)(diff.TotalHours)));
					Console.WriteLine("Diferença em minuto(s): {0} minutos(s).", ((int)(diff.TotalMinutes)));
					Console.WriteLine("Diferença em Segundo(s): {0} Segundo(s).", ((int)(diff.TotalSeconds)));
				}
			}else if (result == 0) Console.WriteLine("Mesma data e hora");
			Console.ReadLine();
		}
		static void teste8()
        {
			DateTime date1 = new DateTime(2011, 6, 14, 0, 0, 0);
			DateTime date2 = new DateTime(2011, 6, 14, 12, 40, 15);

			try
			{
				comparedate(date1, date2);
			}
			catch (MaiorPrimeiro)
			{
				Console.WriteLine("A primeira data deve ser a mais antiga");
				Console.ReadLine();
			}
			
		}


		/*9)Data:
			Criar um programa que receberá 6 parametros de texto e os mesmos devem ser usados para criar uma nova data no formato DD/MM/AAAA HH:MI:SS.
			Devem ser inseridas todas os tratamentos e informar como retorno o que está errado. 
	
			Entrada: 1, 2,2003,4,5,6 
			Saida: 01/02/2003 04:05:06	
	
			Entrada: 1, 20,2003,4,5,6 
			Saida: O parametro referente ao mês é invalido. 
		*/
		static void criadata()
        {
			Console.WriteLine("Digite os parâmetros da data separados em vírgula no formato: DD,MM,AAAA HH, MI, SS");
			string s = Console.ReadLine();
			string[] subs = s.Split('/', '.', ',');
			foreach (var sub in subs)
			{
				Console.WriteLine($"Substring: {sub}");
			}
			try
            {
				DateTime data = new DateTime(int.Parse(subs[2]), int.Parse(subs[1]), int.Parse(subs[0]), int.Parse(subs[3]), int.Parse(subs[4]), int.Parse(subs[5]));
				Console.WriteLine(data);
			}
            catch
			{
				if(int.Parse(subs[1])>12 || int.Parse(subs[1])<1) Console.WriteLine("O parametro referente ao mês é invalido.");
				if (int.Parse(subs[2]) > 9999 || int.Parse(subs[2]) < 1) Console.WriteLine("O parametro referente ao ano é invalido.");
				if (int.Parse(subs[3]) > 23 || int.Parse(subs[3]) < 0) Console.WriteLine("O parametro referente à hora é invalido.");
				if (int.Parse(subs[4]) > 59 || int.Parse(subs[4]) < 0) Console.WriteLine("O parametro referente aos minutos é invalido.");
				if (int.Parse(subs[5]) > 59 || int.Parse(subs[5]) < 0) Console.WriteLine("O parametro referente aos segundos é invalido.");
				/*if (int.Parse(subs[1]) == 2 && int.Parse(subs[0]) >29) Console.WriteLine("O parametro referente aos dias é invalido.");
				else if (int.Parse(subs[1]) == 2 && int.Parse(subs[0]) == 29 && DateTime.IsLeapYear(int.Parse(subs[2]))==false) Console.WriteLine("O parametro referente aos dias é invalido.");
				else if (int.Parse(subs[1]) == 4 || int.Parse(subs[1]) == 6 || int.Parse(subs[1]) == 9 || int.Parse(subs[1]) == 11)
				{
					if(int.Parse(subs[0]) > 30) Console.WriteLine("O parametro referente aos dias é invalido.");
				}
				else if(int.Parse(subs[0]) > 31) Console.WriteLine("O parametro referente aos dias é invalido.");/*/
				if (DateTime.DaysInMonth(int.Parse(subs[2]), int.Parse(subs[1]))== int.Parse(subs[0])) Console.WriteLine("O parametro referente aos dias é invalido."); ;
			}
			Console.ReadLine();
		}
		static void Main(string[] args)
        {
			
		}
    }
}
