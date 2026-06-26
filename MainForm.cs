using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Trabalho
{
    public partial class MainForm : Form
    {
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

        private readonly List<(TextBox helena, TextBox marcos)> _scenarioInputs = new();

        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern int mciSendString(string command, IntPtr buffer, int bufferSize, IntPtr callback);

        public MainForm()
        {
            InitializeComponent();
            SetupEvents();
        }

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

        private void NudCenarios_ValueChanged(object? sender, EventArgs e)
        {
            int newCount = (int)nudCenarios.Value;
            int currentCount = _scenarioInputs.Count;

            pnlInput.SuspendLayout();

            if (newCount > currentCount)
            {
                for (int i = currentCount + 1; i <= newCount; i++)
                    AddScenarioCard(i);
            }
            else if (newCount < currentCount)
            {
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

        private void BtnExecutar_Click(object? sender, EventArgs e)
        {
            PlayExecuteSound();
            rtbResultados.Clear();

            if (_scenarioInputs.Count == 0)
            {
                AppendText("\u26A0  Nenhum cen\u00E1rio configurado.\n", ERROR_RED);
                return;
            }

            for (int i = 0; i < _scenarioInputs.Count; i++)
            {
                var (txtHelena, txtMarcos) = _scenarioInputs[i];

                if (string.IsNullOrWhiteSpace(txtHelena.Text) || string.IsNullOrWhiteSpace(txtMarcos.Text))
                {
                    AppendText($"\u26A0  Cen\u00E1rio {i + 1}: preencha ambas as sequ\u00EAncias.\n\n", ERROR_RED);
                    continue;
                }

                string seqHelena = txtHelena.Text.ToLower();
                string seqMarcos = txtMarcos.Text.ToLower();
                if (seqHelena.Length > 80) seqHelena = seqHelena.Substring(0, 80);
                if (seqMarcos.Length > 80) seqMarcos = seqMarcos.Substring(0, 80);

                AppendText($"\u2500\u2500 Cen\u00E1rio {i + 1} ", PRIMARY, "Segoe UI Semibold", 12f);
                AppendText(new string('\u2500', 36) + "\n", Color.FromArgb(50, 55, 85));
                AppendText($"  Helena: \"{seqHelena}\"\n", TEXT_DIM);
                AppendText($"  Marcos: \"{seqMarcos}\"\n\n", TEXT_DIM);

                List<string> results = LcsAlgorithm.MatrizParaLCS(seqHelena, seqMarcos);

                if (results.Count == 0 || (results.Count == 1 && results[0] == ""))
                {
                    AppendText("  Nenhuma subsequ\u00EAncia comum encontrada.\n\n", TEXT_DIM);
                }
                else
                {
                    int lcsLen = results[0].Length;
                    AppendText($"  Tamanho da LCS: {lcsLen}    ", ACCENT);
                    AppendText($"Encontradas: {results.Count}\n\n", ACCENT);

                    foreach (string palavra in results)
                    {
                        AppendText("    \u25B8 ", PRIMARY_LT);
                        AppendText($"{palavra}\n", TEXT_MAIN);
                    }
                }
                AppendText("\n", TEXT_MAIN);
            }

            rtbResultados.SelectionStart = 0;
            rtbResultados.ScrollToCaret();
        }

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
            AppendText("  1.  Ajuste a quantidade de cen\u00E1rios no canto superior direito\n", TEXT_MAIN);
            AppendText("  2.  Preencha as sequ\u00EAncias de Helena e Marcos\n", TEXT_MAIN);
            AppendText("  3.  Clique em Executar LCS\n\n", TEXT_MAIN);
            AppendText("  Letras min\u00FAsculas \u00B7 1 a 80 caracteres por sequ\u00EAncia\n", TEXT_DIM);
        }

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
