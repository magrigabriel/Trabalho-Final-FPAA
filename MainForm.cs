using System.Drawing;
using System.Windows.Forms;

namespace Trabalho
{
    public partial class MainForm : Form
    {
        // ═══════════════════════════════════════════════════════
        // Paleta de cores — GTA San Andreas
        // ═══════════════════════════════════════════════════════
        private static readonly Color BG_DARK = Color.FromArgb(12, 12, 12);
        private static readonly Color BG_PANEL = Color.FromArgb(24, 24, 28);
        private static readonly Color ORANGE = Color.FromArgb(240, 150, 15);
        private static readonly Color GOLD = Color.FromArgb(245, 197, 24);
        private static readonly Color TEXT_LIGHT = Color.FromArgb(230, 230, 230);
        private static readonly Color TEXT_DIM = Color.FromArgb(160, 160, 160);
        private static readonly Color INPUT_BG = Color.FromArgb(38, 38, 42);
        private static readonly Color TAB_BG = Color.FromArgb(35, 35, 40);
        private static readonly Color ERROR_RED = Color.FromArgb(220, 50, 50);

        // Lista de referências aos TextBoxes de cada cenário
        private readonly List<(TextBox helena, TextBox marcos)> _scenarioInputs = new();

        // ═══════════════════════════════════════════════════════
        // Construtor
        // ═══════════════════════════════════════════════════════
        public MainForm()
        {
            InitializeComponent();
            SetupEvents();
            SetupInitialState();
        }

        private void SetupEvents()
        {
            this.btnConfirmar.Click += BtnConfirmar_Click;
            this.btnExecutar.Click += BtnExecutar_Click;
            this.btnLimpar.Click += BtnLimpar_Click;
            this.tabCenarios.DrawItem += TabCenarios_DrawItem;
            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;
        }

        private void SetupInitialState()
        {
            tabCenarios.Visible = false;
            btnExecutar.Enabled = false;
            btnLimpar.Enabled = false;
            ShowWelcomeMessage();
        }

        // ═══════════════════════════════════════════════════════
        // Mensagem de boas-vindas
        // ═══════════════════════════════════════════════════════
        private void ShowWelcomeMessage()
        {
            rtbResultados.Clear();
            AppendColoredText("★ BEM-VINDO AO LCS ★\n\n", ORANGE, "Impact", 16f);
            AppendColoredText("  1.  Selecione a quantidade de cenários (1 a 10)\n", TEXT_LIGHT);
            AppendColoredText("  2.  Clique em CONFIRMAR\n", TEXT_LIGHT);
            AppendColoredText("  3.  Preencha as sequências da Helena e do Marcos\n", TEXT_LIGHT);
            AppendColoredText("  4.  Clique em ★ EXECUTAR LCS ★\n\n", TEXT_LIGHT);
            AppendColoredText("  As sequências devem ter de 1 a 80 caracteres (letras minúsculas).\n", TEXT_DIM);
            AppendColoredText("  O algoritmo encontrará todas as subsequências comuns mais longas.\n", TEXT_DIM);
        }

        // ═══════════════════════════════════════════════════════
        // Eventos de layout
        // ═══════════════════════════════════════════════════════
        private void MainForm_Load(object? sender, EventArgs e)
        {
            CenterActionButtons();
        }

        private void MainForm_Resize(object? sender, EventArgs e)
        {
            CenterActionButtons();
        }

        private void CenterActionButtons()
        {
            if (pnlActions == null || btnExecutar == null || btnLimpar == null) return;

            int gap = 25;
            int totalWidth = btnExecutar.Width + gap + btnLimpar.Width;
            int startX = (pnlActions.Width - totalWidth) / 2;
            int centerY = (pnlActions.Height - btnExecutar.Height) / 2;

            btnExecutar.Location = new Point(startX, centerY);
            btnLimpar.Location = new Point(startX + btnExecutar.Width + gap, centerY);
        }

        // ═══════════════════════════════════════════════════════
        // CONFIRMAR — Gera as abas de cenários
        // ═══════════════════════════════════════════════════════
        private void BtnConfirmar_Click(object? sender, EventArgs e)
        {
            int count = (int)nudCenarios.Value;

            tabCenarios.TabPages.Clear();
            _scenarioInputs.Clear();

            for (int i = 1; i <= count; i++)
            {
                tabCenarios.TabPages.Add(CreateScenarioTab(i));
            }

            tabCenarios.Visible = true;
            btnExecutar.Enabled = true;
            btnLimpar.Enabled = true;
            tabCenarios.Invalidate();
        }

        private TabPage CreateScenarioTab(int number)
        {
            TabPage page = new TabPage($"CENÁRIO {number}");
            page.BackColor = BG_PANEL;
            page.Padding = new Padding(20);

            // ── Label Helena ──
            Label lblHelena = new Label
            {
                Name = $"lblHelena{number}",
                Text = $"SEQUÊNCIA {number} DA HELENA:  (0/80)",
                Font = new Font("Impact", 14f),
                ForeColor = ORANGE,
                Location = new Point(25, 25),
                AutoSize = true
            };

            // ── TextBox Helena ──
            TextBox txtHelena = new TextBox
            {
                Name = $"txtHelena{number}",
                BackColor = INPUT_BG,
                ForeColor = TEXT_LIGHT,
                Font = new Font("Consolas", 12f),
                BorderStyle = BorderStyle.FixedSingle,
                MaxLength = 80,
                Location = new Point(25, 60),
                Size = new Size(870, 30),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            txtHelena.TextChanged += (s, e) =>
            {
                lblHelena.Text = $"SEQUÊNCIA {number} DA HELENA:  ({txtHelena.Text.Length}/80)";
            };

            // ── Label Marcos ──
            Label lblMarcos = new Label
            {
                Name = $"lblMarcos{number}",
                Text = $"SEQUÊNCIA {number} DO MARCOS:  (0/80)",
                Font = new Font("Impact", 14f),
                ForeColor = ORANGE,
                Location = new Point(25, 115),
                AutoSize = true
            };

            // ── TextBox Marcos ──
            TextBox txtMarcos = new TextBox
            {
                Name = $"txtMarcos{number}",
                BackColor = INPUT_BG,
                ForeColor = TEXT_LIGHT,
                Font = new Font("Consolas", 12f),
                BorderStyle = BorderStyle.FixedSingle,
                MaxLength = 80,
                Location = new Point(25, 150),
                Size = new Size(870, 30),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            txtMarcos.TextChanged += (s, e) =>
            {
                lblMarcos.Text = $"SEQUÊNCIA {number} DO MARCOS:  ({txtMarcos.Text.Length}/80)";
            };

            page.Controls.AddRange(new Control[] { lblHelena, txtHelena, lblMarcos, txtMarcos });
            _scenarioInputs.Add((txtHelena, txtMarcos));
            return page;
        }

        // ═══════════════════════════════════════════════════════
        // EXECUTAR LCS — Processa todos os cenários
        // ═══════════════════════════════════════════════════════
        private void BtnExecutar_Click(object? sender, EventArgs e)
        {
            rtbResultados.Clear();

            if (_scenarioInputs.Count == 0)
            {
                AppendColoredText("⚠  Nenhum cenário configurado. Clique em CONFIRMAR primeiro.\n", ERROR_RED);
                return;
            }

            for (int i = 0; i < _scenarioInputs.Count; i++)
            {
                var (txtHelena, txtMarcos) = _scenarioInputs[i];

                // Validação
                if (string.IsNullOrWhiteSpace(txtHelena.Text) || string.IsNullOrWhiteSpace(txtMarcos.Text))
                {
                    AppendColoredText($"⚠  CENÁRIO {i + 1}: Preencha ambas as sequências!\n\n", ERROR_RED);
                    continue;
                }

                // Prepara as sequências (lowercase, trunca em 80)
                string seqHelena = txtHelena.Text.ToLower();
                string seqMarcos = txtMarcos.Text.ToLower();
                if (seqHelena.Length > 80) seqHelena = seqHelena.Substring(0, 80);
                if (seqMarcos.Length > 80) seqMarcos = seqMarcos.Substring(0, 80);

                // Cabeçalho do cenário
                AppendColoredText("════════════════════════════════════════════\n", GOLD);
                AppendColoredText($"  ★  CENÁRIO {i + 1}  ★\n", ORANGE, "Impact", 13f);
                AppendColoredText("════════════════════════════════════════════\n", GOLD);
                AppendColoredText($"  Helena: \"{seqHelena}\"\n", TEXT_DIM);
                AppendColoredText($"  Marcos: \"{seqMarcos}\"\n\n", TEXT_DIM);

                // Executa o algoritmo LCS
                List<string> results = LcsAlgorithm.MatrizParaLCS(seqHelena, seqMarcos);

                // Verifica resultados
                if (results.Count == 0 || (results.Count == 1 && results[0] == ""))
                {
                    AppendColoredText("  Nenhuma subsequência comum encontrada.\n\n", TEXT_LIGHT);
                }
                else
                {
                    int lcsLength = results[0].Length;
                    AppendColoredText($"  Tamanho da LCS: {lcsLength}\n", GOLD);
                    AppendColoredText($"  Subsequências encontradas: {results.Count}\n\n", GOLD);

                    foreach (string palavra in results)
                    {
                        AppendColoredText($"    ► {palavra}\n", TEXT_LIGHT);
                    }
                }

                AppendColoredText("\n", TEXT_LIGHT);
            }

            // Auto-scroll para o topo
            rtbResultados.SelectionStart = 0;
            rtbResultados.ScrollToCaret();
        }

        // ═══════════════════════════════════════════════════════
        // LIMPAR — Reseta tudo
        // ═══════════════════════════════════════════════════════
        private void BtnLimpar_Click(object? sender, EventArgs e)
        {
            tabCenarios.TabPages.Clear();
            _scenarioInputs.Clear();
            tabCenarios.Visible = false;
            btnExecutar.Enabled = false;
            btnLimpar.Enabled = false;
            nudCenarios.Value = 1;
            ShowWelcomeMessage();
        }

        // ═══════════════════════════════════════════════════════
        // Custom draw — Abas estilo GTA SA
        // ═══════════════════════════════════════════════════════
        private void TabCenarios_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (tabCenarios.TabPages.Count == 0) return;

            TabPage page = tabCenarios.TabPages[e.Index];
            bool isSelected = (e.Index == tabCenarios.SelectedIndex);

            Color bgColor = isSelected ? ORANGE : TAB_BG;
            Color textColor = isSelected ? BG_DARK : TEXT_LIGHT;

            using (SolidBrush bgBrush = new SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }

            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (Font tabFont = new Font("Impact", 11f))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(page.Text, tabFont, textBrush, e.Bounds, sf);
            }

            // Borda inferior laranja na aba selecionada
            if (isSelected)
            {
                using (Pen pen = new Pen(GOLD, 3f))
                {
                    e.Graphics.DrawLine(pen,
                        e.Bounds.Left, e.Bounds.Bottom - 1,
                        e.Bounds.Right, e.Bounds.Bottom - 1);
                }
            }
        }

        // ═══════════════════════════════════════════════════════
        // Helper — Texto colorido no RichTextBox
        // ═══════════════════════════════════════════════════════
        private void AppendColoredText(string text, Color color, string? fontFamily = null, float? fontSize = null)
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
