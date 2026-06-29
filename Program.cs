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
// Descrição : Ponto de entrada da aplicação. Inicializa o Windows Forms e
//             abre a janela principal (MainForm).
// =============================================================================

namespace Trabalho
{
    /// <summary>
    /// Classe responsável por iniciar a aplicação gráfica.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Método Main — configura o ambiente WinForms e executa o formulário principal.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilita estilos visuais e compatibilidade de texto do Windows Forms.
            ApplicationConfiguration.Initialize();

            // Inicia o loop de mensagens da interface gráfica.
            Application.Run(new MainForm());
        }
    }
}
