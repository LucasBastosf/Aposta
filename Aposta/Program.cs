
class Program
{
    const int LoteriaNumeroMaior = 60;
    const int NumeroPorBilheteJogado = 6;
    const decimal PreçoPorApostaJogado = 5M;

    static void Main()
    {
        Console.WriteLine("Bem-vindo à Loteria!");
        while (JogarNovamente())
        {
            InputsUsuario();
        }
    }

    static bool JogarNovamente()
    {
        Console.Write("Deseja Jogar na Loteria (s/n): ");
        string resposta = Console.ReadLine();
        return (resposta.ToLower() == "s");
    }

    static void InputsUsuario()
    {
        Console.Write("Qual é seu nome?: ");
        string nome = Console.ReadLine();
        Console.Write("Cada bilhete de loteria custa 5 reais. Quanto você deseja investir?: ");
        decimal investimentoTotal = decimal.Parse(Console.ReadLine());

        if (investimentoTotal < PreçoPorApostaJogado)
        {
            Console.WriteLine("Investimento mínimo é de 5 reais.");
            return;
        }

        int qtdApostas = (int)(investimentoTotal / PreçoPorApostaJogado);
        decimal troco = investimentoTotal - (qtdApostas * PreçoPorApostaJogado);

        Console.WriteLine($"Você comprou {qtdApostas} bilhetes por {PreçoPorApostaJogado:C} cada.");
        Console.WriteLine($"Troco gasto: {troco:C}");

        for (int i = 0; i < qtdApostas; i++)
        {
            List<int> numerosApostados = GerarNumerosLoteria();
            Console.WriteLine($"Bilhete {i + 1} - Números apostados: {string.Join(", ", numerosApostados)}");
            VerificarGanhador(numerosApostados);
        }
    }

    static List<int> GerarNumerosLoteria()
    {
        Random random = new Random();
        List<int> numeros = new List<int>();

        while (numeros.Count < NumeroPorBilheteJogado)
        {
            int numero = random.Next(1, LoteriaNumeroMaior + 1);
            if (!numeros.Contains(numero))
            {
                numeros.Add(numero);
            }
        }

        numeros.Sort();
        return numeros;
    }

    static void VerificarGanhador(List<int> numerosApostados)
    {
        List<int> numerosSorteados = GerarNumerosLoteria();

        int numerosCorretos = numerosApostados.Intersect(numerosSorteados).Count();

        Console.WriteLine("Números sorteados pela loteria: " + string.Join(", ", numerosSorteados));

        if (numerosCorretos == PreçoPorApostaJogado)
        {
            Console.WriteLine("Parabéns, você ganhou a loteria!");
        }
        else
        {
            Console.WriteLine($"Números corretos: {numerosCorretos}");
        }
    }
}
