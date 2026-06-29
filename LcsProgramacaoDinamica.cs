// =============================================================================

// ARQUIVO 1 DE ENTREGA — Somente Programação Dinâmica

// =============================================================================

// Trabalho Final - Fundamentos de Projeto e Análise de Algoritmos (FPAA)

// Pontifícia Universidade Católica de Minas Gerais - Campus Contagem

// -----------------------------------------------------------------------------

// Título    : LCS — Longest Common Subsequence (Subsequência Comum Mais Longa)

// Versão    : 1.0

// Data      : Junho/2026

// -----------------------------------------------------------------------------

// Autores:

//   - Gabriel Henrique Machado Magri

//   - Caio Martins Bicalho da Costa

//   - Gabriel Amorim Gonçalves Silva

//   - Geovanna do Nascimento Miranda

//   - João Gabriel Soares da Silva Franco

//   - Luiz Henrique Oliveira Coelho

// -----------------------------------------------------------------------------

// Descrição : Solução utilizando SOMENTE Programação Dinâmica.

//             Constrói a matriz LCS e retorna o comprimento máximo da

//             subsequência comum. Não reconstrói as strings (sem backtracking).

//

//             Este arquivo corresponde ao item 1 da entrega do roteiro.

// =============================================================================



namespace Trabalho

{

    /// <summary>

    /// Implementação exclusiva de Programação Dinâmica para o problema LCS.

    /// Calcula apenas o tamanho da subsequência comum mais longa.

    /// </summary>

    public static class LcsProgramacaoDinamica

    {

        /// <summary>Nome deste arquivo para referência na entrega (.zip).</summary>

        public const string NomeArquivoEntrega = "LcsProgramacaoDinamica.cs";



        /// <summary>

        /// Constrói e retorna a matriz de Programação Dinâmica.

        /// Dimensão: (M+1) x (N+1), onde M = |Helena| e N = |Marcos|.

        /// </summary>

        public static int[,] ConstruirMatrizLcs(string textoHelena, string textoMarcos)

        {

            int M = textoHelena.Length;

            int N = textoMarcos.Length;



            // Linha 0 e coluna 0 permanecem zeradas (caso base: sequência vazia).

            int[,] LCS = new int[M + 1, N + 1];



            for (int i = 1; i <= M; i++)

            {

                for (int j = 1; j <= N; j++)

                {

                    if (textoHelena[i - 1] == textoMarcos[j - 1])

                        // Caracteres iguais: estende a LCS vinda da diagonal.

                        LCS[i, j] = LCS[i - 1, j - 1] + 1;

                    else

                        // Caracteres diferentes: mantém o maior valor entre cima e esquerda.

                        LCS[i, j] = Math.Max(LCS[i - 1, j], LCS[i, j - 1]);

                }

            }



            return LCS;

        }



        /// <summary>

        /// Lê o tamanho máximo da LCS no canto inferior direito da matriz.

        /// </summary>

        public static int ObterTamanhoLcs(int[,] matrizLcs, int tamanhoHelena, int tamanhoMarcos)

        {

            return matrizLcs[tamanhoHelena, tamanhoMarcos];

        }



        /// <summary>

        /// Processa um cenário usando apenas PD: retorna o comprimento da LCS.

        /// </summary>

        public static int ProcessarCenario(string textoHelena, string textoMarcos)

        {

            int[,] matrizLcs = ConstruirMatrizLcs(textoHelena, textoMarcos);

            return ObterTamanhoLcs(matrizLcs, textoHelena.Length, textoMarcos.Length);

        }

    }

}


