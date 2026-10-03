using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Calculador de Área de Triângulo ---");
        Console.WriteLine("Informe 3 números maiores que zero:\n");

        decimal[] lados = new decimal[3];

        // Loop para ler e validar os 3 números sem repetir código
        for (int i = 0; i < 3; i++)
        {
            bool numeroValido = false;
            while (!numeroValido)
            {
                Console.Write($"Informe o {i + 1}º número: ");
                string input = Console.ReadLine();

                // Convert.ToDecimal mudado para decimal.TryParse (evita que o programa feche se digitarem letras)
                if (decimal.TryParse(input, out decimal num) && num > 0)
                {
                    lados[i] = Math.Round(num, 1);
                    numeroValido = true;
                }
                else
                {
                    Console.WriteLine("❌ Entrada inválida! Digite apenas números maiores que zero.");
                }
            }
        }

        decimal a = lados[0];
        decimal b = lados[1];
        decimal c = lados[2];

        // Validação geométrica: os lados informados conseguem fechar um triângulo?
        if (a + b > c && a + c > b && b + c > a)
        {
            // Cálculo do Semiperímetro
            decimal semiperimetro = (a + b + c) / 2;

            // Fórmula de Heron: Área = √( s * (s-a) * (s-b) * (s-c) )
            decimal radicando = semiperimetro * (semiperimetro - a) * (semiperimetro - b) * (semiperimetro - c);
            
            // Math.Sqrt precisa de 'double', então convertemos e depois voltamos para 'decimal'
            decimal area = (decimal)Math.Sqrt((double)radicando);
            decimal perimetro = a + b + c;

            Console.WriteLine("\n==============================");
            Console.WriteLine($"🔺 Perímetro do triângulo: {perimetro}");
            Console.WriteLine($"📐 A área do triângulo é: {Math.Round(area, 2)}");
            Console.WriteLine("==============================");
        }
        else
        {
            Console.WriteLine("\n❌ Os números informados não podem formar um triângulo!");
            Console.WriteLine("Regra: A soma de dois lados deve ser sempre maior que o terceiro lado.");
        }
    }
}
