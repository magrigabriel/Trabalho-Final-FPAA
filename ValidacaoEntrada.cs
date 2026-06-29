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
// Descrição : Validação centralizada das entradas conforme o roteiro:
//             D de 1 a 10, sequências de 1 a 80 letras minúsculas (a-z).
// =============================================================================

namespace Trabalho
{
    /// <summary>
    /// Resultado de uma validação de sequência ou cenário.
    /// </summary>
    public readonly struct ResultadoValidacao
    {
        public bool Valida { get; init; }
        public string MensagemErro { get; init; }
        public string ValorNormalizado { get; init; }

        public static ResultadoValidacao Ok(string valorNormalizado) =>
            new() { Valida = true, ValorNormalizado = valorNormalizado, MensagemErro = string.Empty };

        public static ResultadoValidacao Erro(string mensagem) =>
            new() { Valida = false, MensagemErro = mensagem, ValorNormalizado = string.Empty };
    }

    /// <summary>
    /// Regras de validação exigidas pelo roteiro do trabalho.
    /// </summary>
    public static class ValidacaoEntrada
    {
        public const int MinimoCenarios = 1;
        public const int MaximoCenarios = 10;
        public const int TamanhoMinimoSequencia = 1;
        public const int TamanhoMaximoSequencia = 80;

        /// <summary>
        /// Verifica se a quantidade de cenários está entre 1 e 10 (inclusive).
        /// </summary>
        public static ResultadoValidacao ValidarQuantidadeCenarios(int quantidade)
        {
            if (quantidade < MinimoCenarios || quantidade > MaximoCenarios)
            {
                return ResultadoValidacao.Erro(
                    $"Quantidade de cenários inválida: {quantidade}. Informe um valor entre {MinimoCenarios} e {MaximoCenarios}.");
            }

            return ResultadoValidacao.Ok(quantidade.ToString());
        }

        /// <summary>
        /// Valida e normaliza uma sequência de eventos (Helena ou Marcos).
        /// Aceita letras a-z e A-Z (convertidas para minúsculas).
        /// Rejeita vazio, caracteres inválidos e sequências com mais de 80 letras.
        /// </summary>
        public static ResultadoValidacao ValidarSequencia(string? texto, string nomeCampo)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return ResultadoValidacao.Erro(
                    $"O campo {nomeCampo} está vazio. Informe uma sequência de {TamanhoMinimoSequencia} a {TamanhoMaximoSequencia} letras (a-z).");
            }

            string normalizada = texto.Trim().ToLowerInvariant();

            if (normalizada.Length < TamanhoMinimoSequencia)
            {
                return ResultadoValidacao.Erro(
                    $"O campo {nomeCampo} deve ter pelo menos {TamanhoMinimoSequencia} letra.");
            }

            if (normalizada.Length > TamanhoMaximoSequencia)
            {
                return ResultadoValidacao.Erro(
                    $"O campo {nomeCampo} excede {TamanhoMaximoSequencia} caracteres (informados: {normalizada.Length}).");
            }

            for (int i = 0; i < normalizada.Length; i++)
            {
                char c = normalizada[i];
                if (c < 'a' || c > 'z')
                {
                    return ResultadoValidacao.Erro(
                        $"O campo {nomeCampo} contém caractere inválido '{c}' na posição {i + 1}. Use apenas letras de 'a' a 'z'.");
                }
            }

            return ResultadoValidacao.Ok(normalizada);
        }
    }
}
