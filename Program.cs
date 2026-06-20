//Autores do Grupo:

//Gabriel Henrique Machado Magri;
//Caio Martins Bicalho da Costa;
//Gabriel Amorim Gonçalves Silva;
//Geovanna do Nascimento Miranda;
//João Gabriel Soares da Silva Franco;
// Luiz Henrique Oliveira Coelho

//VERSÃO 1.0 - 20/06

using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Trabalho
{
    class Program
    {
        static void Main(string[] args)
        {
            int D = 0;
            do
            {
                //recebe a quantidade de cenarios
                Console.WriteLine("Digite a quantidade de cénarios de 1 a 10");
                D = int.Parse(Console.ReadLine());
            } while (D < 1 || D > 10); //se for menor que 1 e maior que 10, irá repetir

            // Cria os vetores com a quantidade de cenarios que será digitado. 
            string[] SequenciaHelena = new string[D]; 
            string[] SequenciaMarcos = new string[D]; 
            //chama a função para receber 
            RecebeDados(D, SequenciaHelena, SequenciaMarcos);

            // chama a função para o algoritmo LCS
            for (int i = 0; i < D; i++)
            {
                Console.WriteLine($"\nProcessando Cenário {i + 1}...");
                MatrizParaLCS(SequenciaHelena[i], SequenciaMarcos[i]);
            }

        }


        public static void RecebeDados(int D, string[] sequenciaHelena, string[] SequenciaMarcos)
        {
            Console.WriteLine("=======================================================");
            Console.WriteLine("Digite a sequencia dos cenarios, deve ser de 1 a 80 caracteres de letras minusculas, caso passe da quantidade permitida, será considerado apenas os 80 primeiros");
            Console.WriteLine("=======================================================");
            for (int i = 0; i < D; i++)
            {

                Console.WriteLine($"Digite a sequencia {i + 1} da Helena");
                sequenciaHelena[i] = Console.ReadLine().ToLower();
                Console.WriteLine("=======================================================");
                Console.WriteLine($"Digite a sequencia {i + 1} do Marcos");
                SequenciaMarcos[i] = Console.ReadLine().ToLower();
                Console.WriteLine("=======================================================");

                //Se a sequencia for maior que o permitido, será descartada o excedente
                if (sequenciaHelena[i].Length > 80)
                {
                    sequenciaHelena[i] = sequenciaHelena[i].Substring(0, 80);
                }

                if (SequenciaMarcos[i].Length > 80)
                {
                    SequenciaMarcos[i] = SequenciaMarcos[i].Substring(0, 80);
                }
            }
        }

        // a função recebe as palavras que serão avaliadas
        public static void MatrizParaLCS(string textoHelena, string textoMarcos)
        {
            // o tamanho de cada palavra
            int M = textoHelena.Length;
            int N = textoMarcos.Length;

            // a matriz com um valor a mais, pois a linha zero e coluna zero não será preenchida
            int[,] LCS = new int[M + 1, N + 1];

            // Comeco com o indice 1, por que a linha zero e coluna zero deve permanecer zero
            for (int i = 1; i <= M; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    //verifico se as letras são iguais, se for, eu coloco na matriz o seguinte calculo, conforme manda o algoritmo.
                    if (textoHelena[i - 1] == textoMarcos[j - 1])
                    {
                        LCS[i, j] = LCS[i - 1, j - 1] + 1;
                    }

                    //se não forem iguais, coloco o maior valor anterior o indice que estou.
                    else
                    {
                        LCS[i, j] = Math.Max(LCS[i - 1, j], LCS[i, j - 1]);
                    }
                }
            }

            //crio o Hashset, que basicamente verifica se já existe alguma palavra igual, se existir, ele não adiciona.
            HashSet<string> respostasDesteCenario = new HashSet<string>();

            //chamo o algoritmo que irá voltar para descobrir quais palavras são.
            FazerBacktracking(M, N, "", LCS, textoHelena, textoMarcos, respostasDesteCenario);

            //com o Backtracking que chamei anteriormente pronto, ordei as palavras
            List<string> listaOrdenada = new List<string>(respostasDesteCenario);
            listaOrdenada.Sort(); 

            // imprime todas as palavras da lista
            foreach (string palavra in listaOrdenada)
            {
                Console.WriteLine(palavra);
                // imprime uma linha em branco
                Console.WriteLine();
            }

            // imprime uma linha em branco
            Console.WriteLine();

            
        }


        //inicia o backtracking, ele recebe o indice i e j, a palavra atual, a matriz, o texto de ambos e o resultado, por ser uma chamada recursiva, ele recebe somente daquele estado, até chegar no caso base.
        public static void FazerBacktracking(int i, int j, string palavraAtual, int[,] matriz, string textoHelena, string textoMarcos, HashSet<string> resultados)
        {
            // 1. Caso Base: Bateu na parede da margem de zeros e encerra.
            if (i == 0 || j == 0)
            {
                resultados.Add(palavraAtual); // guarda na mochila
                return; // retorna para encerrar esse "clone"
            }

            // se for letras Iguais
            if (textoHelena[i - 1] == textoMarcos[j - 1])
            {
                // adiciona a letra no começo da string e dá o passo na diagonal (i-1, j-1)
                string novaPalavra = textoHelena[i - 1] + palavraAtual;
                //recursivo do passo na diagonal
                FazerBacktracking(i - 1, j - 1, novaPalavra, matriz, textoHelena, textoMarcos, resultados);
            }
            // Letras Diferentes - A Encruzilhada
            else
            {
                // a comparaçao é entre o vizinho de cima e o vizinho da esquerda
                if (matriz[i - 1, j] >= matriz[i, j - 1])
                {
                    // Se o de cima for maior ou se houver empate, ele vai pra cima
                    //chama recursiva novamente
                    FazerBacktracking(i - 1, j, palavraAtual, matriz, textoHelena, textoMarcos, resultados);
                }

                if (matriz[i, j - 1] >= matriz[i - 1, j])
                {
                    // se o da esquerda for maior ou se houver empate, ele vai para a esquerda
                    // Repare que em caso de empate (onde cima == esquerda), os dois IFs serão verdadeiros 
                    FazerBacktracking(i, j - 1, palavraAtual, matriz, textoHelena, textoMarcos, resultados);
                }
            }
        }
    }
}
