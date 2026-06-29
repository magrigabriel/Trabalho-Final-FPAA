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
// Descrição : Lógica da interface gráfica principal. Gerencia cenários de
//             entrada, validação dos dados, execução do algoritmo LCS e
//             exibição dos resultados formatados.
// =============================================================================

using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Trabalho
{
    /// <summary>
    /// Formulário principal da aplicação. Permite informar de 1 a 10 cenários,
    /// cada um com as sequências de Helena e Marcos, e exibe as LCS encontradas.
    /// </summary>
    public partial class MainForm : Form
    {
        // Paleta de cores utilizada nos componentes visuais da interface.
        private static readonly Color BG_DEEP    = Color.FromArgb(13, 15, 30);
        private static readonly Color BG_CARD    = Color.FromArgb(22, 25, 48);
        private static readonly Color BG_INPUT   = Color.FromArgb(30, 34, 60);
        private static readonly Color PRIMARY    = Color.FromArgb(99, 102, 241);
        private static readonly Color PRIMARY_LT = Color.FromArgb(129, 140, 248);
        private static readonly Color ACCENT     = Color.FromArgb(34, 211, 238);
        private static readonly Color TEXT_MAIN  = Color.FromArgb(241, 245, 249);
        private static readonly Color TEXT_DIM   = Color.FromArgb(148, 163, 184);
        private static readonly Color ERROR_RED  = Color.FromArgb(239, 68, 68);
        private static readonly Color SUCCESS    = Color.FromArgb(16, 185, 129);

        // Lista que mantém os pares de TextBox (Helena/Marcos) de cada cenário ativo.
        private readonly List<(TextBox helena, TextBox marcos)> _scenarioInputs = new();

        // Importação da API winmm para reprodução de efeito sonoro ao executar.
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern int mciSendString(string command, IntPtr buffer, int bufferSize, IntPtr callback);

        public MainForm()
        {
            InitializeComponent();
            SetupEvents();
        }

        /// <summary>
        /// Registra os handlers de eventos dos controles da interface.
        /// </summary>
        private void SetupEvents()
        {
            this.nudCenarios.ValueChanged += NudCenarios_ValueChanged;
            this.btnExecutar.Click += BtnExecutar_Click;
            this.btnLimpar.Click += BtnLimpar_Click;
            this.btnCreditos.Click += BtnCreditos_Click;
            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            CenterActionButtons();
            AddScenarioCard(1);
            ShowWelcomeMessage();
        }

        private void MainForm_Resize(object? sender, EventArgs e)
        {
            CenterActionButtons();
            UpdateCardWidths();
        }

        private void CenterActionButtons()
        {
            if (pnlActions == null || btnExecutar == null || btnLimpar == null || btnCreditos == null) return;

            int gap = 20;
            int totalWidth = btnExecutar.Width + gap + btnLimpar.Width + gap + btnCreditos.Width;
            int startX = (pnlActions.Width - totalWidth) / 2;
            int centerY = (pnlActions.Height - btnExecutar.Height) / 2;

            btnExecutar.Location = new Point(startX, centerY);
            btnLimpar.Location = new Point(startX + btnExecutar.Width + gap, centerY);
            btnCreditos.Location = new Point(btnLimpar.Right + gap, centerY);
        }

        private void UpdateCardWidths()
        {
            int cardWidth = GetCardWidth();
            foreach (Control c in pnlInput.Controls)
            {
                if (c is Panel) c.Width = cardWidth;
            }
        }

        private int GetCardWidth()
        {
            int scrollbar = SystemInformation.VerticalScrollBarWidth;
            return pnlInput.ClientSize.Width - 30 - scrollbar;
        }

        /// <summary>
        /// Ajusta dinamicamente a quantidade de cartões de cenário (1 a 10)
        /// conforme o valor selecionado pelo usuário.
        /// </summary>
        private void NudCenarios_ValueChanged(object? sender, EventArgs e)
        {
            int newCount = (int)nudCenarios.Value;
            int currentCount = _scenarioInputs.Count;

            pnlInput.SuspendLayout();

            if (newCount > currentCount)
            {
                // Adiciona novos cartões quando o usuário aumenta a quantidade.
                for (int i = currentCount + 1; i <= newCount; i++)
                    AddScenarioCard(i);
            }
            else if (newCount < currentCount)
            {
                // Remove cartões excedentes quando o usuário diminui a quantidade.
                for (int i = currentCount; i > newCount; i--)
                    RemoveLastScenarioCard();
            }

            pnlInput.ResumeLayout(true);
        }

        private void AddScenarioCard(int number)
        {
            int padding = 15;
            int cardWidth = GetCardWidth();
            int cardHeight = 148;
            int gap = 10;

            int yOffset = padding;
            if (pnlInput.Controls.Count > 0)
            {
                Control last = pnlInput.Controls[pnlInput.Controls.Count - 1];
                yOffset = last.Bottom + gap;
            }

            Panel card = CreateScenarioCard(number, cardWidth);
            card.Location = new Point(padding, yOffset);
            card.Size = new Size(cardWidth, cardHeight);
            card.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            pnlInput.Controls.Add(card);
        }

        private void RemoveLastScenarioCard()
        {
            if (pnlInput.Controls.Count > 0)
            {
                int idx = pnlInput.Controls.Count - 1;
                Control card = pnlInput.Controls[idx];
                pnlInput.Controls.RemoveAt(idx);
                card.Dispose();
            }
            if (_scenarioInputs.Count > 0)
                _scenarioInputs.RemoveAt(_scenarioInputs.Count - 1);
        }

        /// <summary>
        /// Cria um cartão visual com campos de entrada para Helena e Marcos,
        /// incluindo contador de caracteres (máximo 80) e validação visual.
        /// </summary>
        private Panel CreateScenarioCard(int number, int cardWidth)
        {
            Panel card = new Panel { BackColor = BG_CARD };

            card.Controls.Add(new Panel
            {
                Dock = DockStyle.Left,
                Width = 3,
                BackColor = PRIMARY
            });

            card.Controls.Add(new Label
            {
                Text = $"Cen\u00E1rio {number}",
                Font = new Font("Segoe UI Semibold", 13f, FontStyle.Bold),
                ForeColor = PRIMARY_LT,
                Location = new Point(18, 8),
                AutoSize = true
            });

            Label lblHelena = new Label
            {
                Name = $"lblHelena{number}",
                Text = "Helena  (0/80)",
                Font = new Font("Segoe UI", 10f),
                ForeColor = ACCENT,
                Location = new Point(18, 38),
                AutoSize = true
            };
            card.Controls.Add(lblHelena);

            TextBox txtHelena = new TextBox
            {
                Name = $"txtHelena{number}",
                BackColor = BG_INPUT,
                ForeColor = TEXT_MAIN,
                Font = new Font("Consolas", 11f),
                BorderStyle = BorderStyle.FixedSingle,
                MaxLength = 80,
                Location = new Point(18, 60),
                Size = new Size(cardWidth - 40, 26),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            txtHelena.TextChanged += (s, e) =>
                lblHelena.Text = $"Helena  ({txtHelena.Text.Length}/80)";
            card.Controls.Add(txtHelena);

            Label lblMarcos = new Label
            {
                Name = $"lblMarcos{number}",
                Text = "Marcos  (0/80)",
                Font = new Font("Segoe UI", 10f),
                ForeColor = ACCENT,
                Location = new Point(18, 92),
                AutoSize = true
            };
            card.Controls.Add(lblMarcos);

            TextBox txtMarcos = new TextBox
            {
                Name = $"txtMarcos{number}",
                BackColor = BG_INPUT,
                ForeColor = TEXT_MAIN,
                Font = new Font("Consolas", 11f),
                BorderStyle = BorderStyle.FixedSingle,
                MaxLength = 80,
                Location = new Point(18, 114),
                Size = new Size(cardWidth - 40, 26),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };
            txtMarcos.TextChanged += (s, e) =>
                lblMarcos.Text = $"Marcos  ({txtMarcos.Text.Length}/80)";
            card.Controls.Add(txtMarcos);

            _scenarioInputs.Add((txtHelena, txtMarcos));
            return card;
        }

        private void PlayExecuteSound()
        {
            try
            {
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "faaah.mp3");
                if (File.Exists(audioPath))
                {
                    mciSendString("close executeSfx", IntPtr.Zero, 0, IntPtr.Zero);
                    mciSendString($"open \"{audioPath}\" type mpegvideo alias executeSfx", IntPtr.Zero, 0, IntPtr.Zero);
                    mciSendString("play executeSfx", IntPtr.Zero, 0, IntPtr.Zero);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Processa todos os cenários: valida entradas, normaliza sequências,
        /// chama o algoritmo LCS e exibe os resultados na área de texto.
        /// </summary>
        private void BtnExecutar_Click(object? sender, EventArgs e)
        {
            PlayExecuteSound();
            rtbResultados.Clear();

            if (_scenarioInputs.Count == 0)
            {
                AppendText("\u26A0  Nenhum cen\u00E1rio configurado.\n", ERROR_RED);
                return;
            }

            var validacaoQtd = ValidacaoEntrada.ValidarQuantidadeCenarios(_scenarioInputs.Count);
            if (!validacaoQtd.Valida)
            {
                AppendText($"\u26A0  {validacaoQtd.MensagemErro}\n", ERROR_RED);
                return;
            }

            for (int i = 0; i < _scenarioInputs.Count; i++)
            {
                var (txtHelena, txtMarcos) = _scenarioInputs[i];

                if (i > 0)
                    AppendText("\n", TEXT_MAIN);

                var validacaoHelena = ValidacaoEntrada.ValidarSequencia(txtHelena.Text, "Helena");
                if (!validacaoHelena.Valida)
                {
                    AppendText($"\u26A0  Cen\u00E1rio {i + 1} — {validacaoHelena.MensagemErro}\n\n", ERROR_RED);
                    continue;
                }

                var validacaoMarcos = ValidacaoEntrada.ValidarSequencia(txtMarcos.Text, "Marcos");
                if (!validacaoMarcos.Valida)
                {
                    AppendText($"\u26A0  Cen\u00E1rio {i + 1} — {validacaoMarcos.MensagemErro}\n\n", ERROR_RED);
                    continue;
                }

                string seqHelena = validacaoHelena.ValorNormalizado;
                string seqMarcos = validacaoMarcos.ValorNormalizado;

                AppendText($"\u2500\u2500 Cen\u00E1rio {i + 1} ", PRIMARY, "Segoe UI Semibold", 12f);
                AppendText(new string('\u2500', 36) + "\n", Color.FromArgb(50, 55, 85));
                AppendText($"  Helena: \"{seqHelena}\"\n", TEXT_DIM);
                AppendText($"  Marcos: \"{seqMarcos}\"\n\n", TEXT_DIM);

                if (rbSomentePd.Checked)
                    ExibirResultadoSomentePd(seqHelena, seqMarcos);
                else
                    ExibirResultadoPdBacktracking(seqHelena, seqMarcos);

                AppendText("\n", TEXT_MAIN);
            }

            rtbResultados.SelectionStart = 0;
            rtbResultados.ScrollToCaret();
        }

        /// <summary>
        /// Executa o Arquivo 1 (somente PD) e exibe apenas o tamanho da LCS.
        /// </summary>
        private void ExibirResultadoSomentePd(string seqHelena, string seqMarcos)
        {
            AppendText("  Modo: Somente Programa\u00E7\u00E3o Din\u00E2mica\n", ACCENT, "Segoe UI Semibold", 10.5f);
            AppendText($"  Arquivo: {LcsProgramacaoDinamica.NomeArquivoEntrega}\n\n", TEXT_DIM);

            int tamanhoLcs = LcsProgramacaoDinamica.ProcessarCenario(seqHelena, seqMarcos);

            if (tamanhoLcs == 0)
            {
                AppendText("  Tamanho da LCS: 0\n", TEXT_DIM, "Segoe UI Semibold", 11f);
            }
            else
            {
                AppendText($"  Tamanho da LCS: {tamanhoLcs}\n", SUCCESS, "Segoe UI Semibold", 11f);
            }

            AppendText("\n", TEXT_MAIN);
            AppendText("  \u2139  Limita\u00E7\u00E3o do modo Somente PD\n", PRIMARY_LT, "Segoe UI Semibold", 10.5f);
            AppendText("  A Programa\u00E7\u00E3o Din\u00E2mica, sozinha, s\u00F3 preenche a matriz\n", TEXT_DIM);
            AppendText("  com o comprimento m\u00E1ximo \u2014 ela n\u00E3o guarda nem reconstr\u00F3i\n", TEXT_DIM);
            AppendText("  as letras das subsequ\u00EAncias.\n\n", TEXT_DIM);
            AppendText("  Por isso n\u00E3o \u00E9 poss\u00EDvel listar as LCS usando apenas PD.\n", TEXT_MAIN);
            AppendText("  Para ver todas as subsequ\u00EAncias, selecione\n", TEXT_MAIN);
            AppendText("  \"PD + Backtracking\" e execute novamente.\n", ACCENT, "Segoe UI Semibold", 10.5f);
        }

        /// <summary>
        /// Executa o Arquivo 2 (PD + Backtracking) e exibe todas as LCS encontradas.
        /// </summary>
        private void ExibirResultadoPdBacktracking(string seqHelena, string seqMarcos)
        {
            AppendText("  Modo: Programa\u00E7\u00E3o Din\u00E2mica + Backtracking\n", ACCENT, "Segoe UI Semibold", 10.5f);
            AppendText($"  Arquivo: {LcsProgramacaoDinamicaBacktracking.NomeArquivoEntrega}\n\n", TEXT_DIM);

            List<string> results = LcsProgramacaoDinamicaBacktracking.ProcessarCenario(seqHelena, seqMarcos);

            if (results.Count == 0)
            {
                AppendText("  Nenhuma subsequ\u00EAncia comum encontrada.\n", TEXT_DIM);
            }
            else
            {
                int lcsLen = results[0].Length;
                AppendText($"  Tamanho da LCS: {lcsLen}    ", ACCENT);
                AppendText($"Encontradas: {results.Count}\n\n", ACCENT);

                string saidaFormatada = LcsProgramacaoDinamicaBacktracking.FormatarSaidaCenario(results);
                foreach (string linha in saidaFormatada.Split('\n'))
                {
                    if (string.IsNullOrEmpty(linha))
                    {
                        AppendText("\n", TEXT_MAIN);
                        continue;
                    }

                    AppendText("    \u25B8 ", PRIMARY_LT);
                    AppendText($"{linha}\n", TEXT_MAIN);
                }
            }
        }

        /// <summary>
        /// Restaura a interface ao estado inicial: 1 cenário vazio e mensagem de boas-vindas.
        /// </summary>
        private void BtnLimpar_Click(object? sender, EventArgs e)
        {
            nudCenarios.ValueChanged -= NudCenarios_ValueChanged;

            pnlInput.SuspendLayout();
            pnlInput.Controls.Clear();
            _scenarioInputs.Clear();
            nudCenarios.Value = 1;
            pnlInput.ResumeLayout();

            nudCenarios.ValueChanged += NudCenarios_ValueChanged;
            AddScenarioCard(1);
            ShowWelcomeMessage();
        }

        private void BtnCreditos_Click(object? sender, EventArgs e)
        {
            using (var creditsForm = new CreditsForm())
            {
                creditsForm.ShowDialog(this);
            }
        }

        private void ShowWelcomeMessage()
        {
            rtbResultados.Clear();
            AppendText("Bem-vindo ao LCS\n\n", PRIMARY, "Segoe UI Semibold", 13f);
            AppendText("  1.  Escolha o modo de execu\u00E7\u00E3o (Somente PD ou PD + Backtracking)\n", TEXT_MAIN);
            AppendText("  2.  Ajuste a quantidade de cen\u00E1rios no canto superior direito\n", TEXT_MAIN);
            AppendText("  3.  Preencha as sequ\u00EAncias de Helena e Marcos\n", TEXT_MAIN);
            AppendText("  4.  Clique em Executar LCS\n\n", TEXT_MAIN);
            AppendText("  Arquivo 1: LcsProgramacaoDinamica.cs  \u00B7  retorna o tamanho\n", TEXT_DIM);
            AppendText("  Arquivo 2: LcsProgramacaoDinamicaBacktracking.cs  \u00B7  retorna todas as LCS\n\n", TEXT_DIM);
            AppendText("  Letras a-z (mai\u00FAsculas convertidas) \u00B7 1 a 80 caracteres \u00B7 1 a 10 cen\u00E1rios\n", TEXT_DIM);
        }

        /// <summary>
        /// Escreve texto colorido no RichTextBox de resultados, com fonte opcional.
        /// </summary>
        private void AppendText(string text, Color color, string? fontFamily = null, float? fontSize = null)
        {
            rtbResultados.SelectionStart = rtbResultados.TextLength;
            rtbResultados.SelectionLength = 0;
            rtbResultados.SelectionColor = color;

            if (fontFamily != null || fontSize != null)
            {
                string family = fontFamily ?? rtbResultados.Font.FontFamily.Name;
                float size = fontSize ?? rtbResultados.Font.Size;
                rtbResultados.SelectionFont = new Font(family, size);
            }

            rtbResultados.AppendText(text);
        }
    }
}
