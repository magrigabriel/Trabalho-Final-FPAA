// =============================================================================

// ARQUIVO 2 DE ENTREGA — Programação Dinâmica + Backtracking

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

// Descrição : Solução completa que combina Programação Dinâmica e Backtracking.

//             Reutiliza a matriz de LcsProgramacaoDinamica.cs (Arquivo 1) e,

//             em seguida, percorre a matriz de trás para frente para recuperar

//             TODAS as subsequências comuns mais longas, sem repetição e em

//             ordem alfabética.

//

//             Este arquivo corresponde ao item 2 da entrega do roteiro.

// =============================================================================



namespace Trabalho

{

    /// <summary>

    /// Implementação completa: PD (matriz) + Backtracking (reconstrução das strings).

    /// </summary>

    public static class LcsProgramacaoDinamicaBacktracking

    {

        /// <summary>Nome deste arquivo para referência na entrega (.zip).</summary>

        public const string NomeArquivoEntrega = "LcsProgramacaoDinamicaBacktracking.cs";



        /// <summary>

        /// Processa um cenário: constrói a matriz via PD e extrai todas as LCS via backtracking.

        /// </summary>

        public static List<string> ProcessarCenario(string textoHelena, string textoMarcos)

        {

            // Fase 1: delega a construção da matriz ao Arquivo 1 (somente PD).

            int[,] matrizLcs = LcsProgramacaoDinamica.ConstruirMatrizLcs(textoHelena, textoMarcos);



            // Fase 2: backtracking — reconstrói todas as subsequências ótimas.

            return ExtrairTodasLcs(textoHelena, textoMarcos, matrizLcs);

        }



        /// <summary>

        /// Executa o backtracking a partir da posição (M, N) — canto inferior direito da matriz.

        /// </summary>

        public static List<string> ExtrairTodasLcs(

            string textoHelena,

            string textoMarcos,

            int[,] matrizLcs)

        {

            int M = textoHelena.Length;

            int N = textoMarcos.Length;

            int tamanhoMaximo = matrizLcs[M, N];



            if (tamanhoMaximo == 0)

                return new List<string>();



            // HashSet evita duplicatas quando caminhos distintos geram a mesma LCS.

            HashSet<string> resultadosBrutos = new HashSet<string>();



            // Inicia a recursão no canto inferior direito da matriz (M, N).

            FazerBacktracking(M, N, "", matrizLcs, textoHelena, textoMarcos, resultadosBrutos);



            // Mantém apenas subsequências de comprimento máximo (descarta strings parciais).

            HashSet<string> apenasMaximas = new HashSet<string>(

                resultadosBrutos.Where(s => s.Length == tamanhoMaximo));



            return FiltrarEOrdenar(apenasMaximas);

        }



        /// <summary>

        /// Percorre a matriz de trás para frente (de M,N até 0,0).

        /// Em empate de valores, explora ambos os caminhos.

        /// </summary>

        private static void FazerBacktracking(

            int i,

            int j,

            string palavraAtual,

            int[,] matriz,

            string textoHelena,

            string textoMarcos,

            HashSet<string> resultados)

        {

            // Caso base: atingiu a borda da matriz — subsequência completa encontrada.

            if (i == 0 || j == 0)

            {

                resultados.Add(palavraAtual);

                return;

            }



            if (textoHelena[i - 1] == textoMarcos[j - 1])

            {

                // Caractere comum: insere no início (percurso é de trás para frente).

                string novaPalavra = textoHelena[i - 1] + palavraAtual;

                FazerBacktracking(i - 1, j - 1, novaPalavra, matriz, textoHelena, textoMarcos, resultados);

                return;

            }



            int valorAcima = matriz[i - 1, j];

            int valorEsquerda = matriz[i, j - 1];



            // Em empate, explora ambos os caminhos para encontrar todas as LCS.

            if (valorAcima >= valorEsquerda)

                FazerBacktracking(i - 1, j, palavraAtual, matriz, textoHelena, textoMarcos, resultados);



            if (valorEsquerda >= valorAcima)

                FazerBacktracking(i, j - 1, palavraAtual, matriz, textoHelena, textoMarcos, resultados);

        }



        /// <summary>

        /// Garante saída sem repetições e em ordem alfabética (lexicográfica).

        /// </summary>

        private static List<string> FiltrarEOrdenar(HashSet<string> resultados)

        {

            List<string> listaOrdenada = new List<string>(resultados);

            listaOrdenada.Sort(StringComparer.Ordinal);

            return listaOrdenada;

        }



        /// <summary>

        /// Formata a saída de um cenário: uma LCS por linha,

        /// com linha em branco entre cada subsequência (conforme roteiro).

        /// </summary>

        public static string FormatarSaidaCenario(List<string> lcsOrdenadas)

        {

            if (lcsOrdenadas.Count == 0)

                return string.Empty;



            return string.Join("\n\n", lcsOrdenadas) + "\n";

        }



        /// <summary>

        /// Formata vários cenários com linha em branco entre cada bloco de saída.

        /// </summary>

        public static string FormatarSaidaMultiplosCenarios(IEnumerable<string> blocosPorCenario)

        {

            var blocosValidos = blocosPorCenario

                .Where(b => !string.IsNullOrWhiteSpace(b))

                .ToList();



            if (blocosValidos.Count == 0)

                return string.Empty;



            return string.Join("\n", blocosValidos);

        }

    }

}


