


namespace Trabalho
{
    public static class LcsAlgorithm
    {
        public static List<string> MatrizParaLCS(string textoHelena, string textoMarcos)
        {
            int M = textoHelena.Length;
            int N = textoMarcos.Length;

            int[,] LCS = new int[M + 1, N + 1];

            for (int i = 1; i <= M; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    if (textoHelena[i - 1] == textoMarcos[j - 1])
                    {
                        LCS[i, j] = LCS[i - 1, j - 1] + 1;
                    }

                    else
                    {
                        LCS[i, j] = Math.Max(LCS[i - 1, j], LCS[i, j - 1]);
                    }
                }
            }

            HashSet<string> respostasDesteCenario = new HashSet<string>();

            FazerBacktracking(M, N, "", LCS, textoHelena, textoMarcos, respostasDesteCenario);

            List<string> listaOrdenada = new List<string>(respostasDesteCenario);
            listaOrdenada.Sort();
            return listaOrdenada;
        }

        private static void FazerBacktracking(int i, int j, string palavraAtual, int[,] matriz, string textoHelena, string textoMarcos, HashSet<string> resultados)
        {
            if (i == 0 || j == 0)
            {
                resultados.Add(palavraAtual); // guarda na mochila
                return; // retorna para encerrar esse "clone"
            }

            if (textoHelena[i - 1] == textoMarcos[j - 1])
            {
                string novaPalavra = textoHelena[i - 1] + palavraAtual;
                FazerBacktracking(i - 1, j - 1, novaPalavra, matriz, textoHelena, textoMarcos, resultados);
            }
            else
            {
                if (matriz[i - 1, j] >= matriz[i, j - 1])
                {
                    FazerBacktracking(i - 1, j, palavraAtual, matriz, textoHelena, textoMarcos, resultados);
                }

                if (matriz[i, j - 1] >= matriz[i - 1, j])
                {
                    FazerBacktracking(i, j - 1, palavraAtual, matriz, textoHelena, textoMarcos, resultados);
                }
            }
        }
    }
}
