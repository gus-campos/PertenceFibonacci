
IEnumerable<int> fibonacciIter() {

    /* 
    Gerador de números da sequência de Fobonacci.
    Evita o cálculo da sequência completa para cada novo elemento
    desejado.
    */

    // Inicializando primeiros 2 elementos
    int antepenultimo=0, penultimo=1;
    // Declarando variável para novo elemento
    int novo;
    
    // Primeiro gerar os primeiros 2 elementos
    yield return 0;
    yield return 1;

    // Continuamente gerar valores seguintes, conforme for necessário
    while (true)
    {
        // O novo valor será a soma dos dois anteriores
        novo = antepenultimo + penultimo;

        // Gerar novo valor
        yield return novo;

        // Deslocar valores para próxima iteração
        antepenultimo = penultimo;
        penultimo = novo;
    }
}

bool pertenceFibonacci(int numeroTeste) {

    /*
    Verifica se um número teste faz parte da sequência de fibonacci,
    ao compará-lo até com número da sequência, até que se encontre um
    igual, ou maior.
    */

    // Para cada número gerado da sequência de fibonacci
    foreach (int nFib in fibonacciIter())  {
    
        // Se tiver passado do número teste, não pertence
        if (numeroTeste < nFib)
            return false;
        
        // Se for igual a um número de fibonacci, pertence
        else if (numeroTeste == nFib)
            return true;
    }

    // No C# é preciso garantir que todos caminhos retornem algum valor
    return false;
}

// ================ Programa principal ================

// Variáveis auxiliares
int numeroTeste;
bool valorLido = false;

// Tentar ler um número do teclado até conseguir
while (!valorLido) {

    // Tentando ler um número do input
    Console.WriteLine("Por favor insira um número:");
    valorLido = int.TryParse(Console.ReadLine(), out numeroTeste);
    
    // Se conseguir ler
    if (valorLido) {

        // Verificar se pertence à sequência e imprimir o resultado
        if (pertenceFibonacci(numeroTeste))
            Console.WriteLine("O número {0} pertence à sequência de fibonacci.", numeroTeste);
        else   
            Console.WriteLine("O número {0} NÃO pertence à sequência de fibonacci.", numeroTeste);

        // Terminar execução do laço de repetição
        break;
    }
}