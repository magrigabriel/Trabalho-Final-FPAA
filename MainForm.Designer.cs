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
// Descrição : Definição visual dos componentes da janela principal (layout,
//             cores, tamanhos e posicionamento dos controles WinForms).
// =============================================================================

namespace Trabalho
{
    /// <summary>
    /// Parte parcial do MainForm responsável pela inicialização dos controles visuais.
    /// </summary>
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Configura e instancia todos os painéis, labels, botões e campos da interface.
        /// </summary>
        private void InitializeComponent()
        {
            // --- Controles do cabeçalho (título e seletor de cenários) ---
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblCenariosLabel = new System.Windows.Forms.Label();
            this.nudCenarios = new System.Windows.Forms.NumericUpDown();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.pnlModoExecucao = new System.Windows.Forms.Panel();
            this.lblModoExecucao = new System.Windows.Forms.Label();
            this.rbSomentePd = new System.Windows.Forms.RadioButton();
            this.rbPdBacktracking = new System.Windows.Forms.RadioButton();
            this.pnlInput = new System.Windows.Forms.Panel();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnCreditos = new System.Windows.Forms.Button();
            this.pnlSepActions = new System.Windows.Forms.Panel();
            this.pnlResultados = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.rtbResultados = new System.Windows.Forms.RichTextBox();

            this.pnlHeader.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenarios)).BeginInit();
            this.SuspendLayout();

            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(17, 19, 38);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(950, 72);
            this.pnlHeader.Controls.Add(this.nudCenarios);
            this.pnlHeader.Controls.Add(this.lblCenariosLabel);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);

            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(950, 42);
            this.lblTitle.Text = "LCS";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblSubtitle.Location = new System.Drawing.Point(15, 48);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Text = "Longest Common Subsequence  \u00B7  Trabalho Final FPAA";

            this.lblCenariosLabel.AutoSize = true;
            this.lblCenariosLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCenariosLabel.ForeColor = System.Drawing.Color.FromArgb(210, 215, 225);
            this.lblCenariosLabel.Location = new System.Drawing.Point(757, 48);
            this.lblCenariosLabel.Name = "lblCenariosLabel";
            this.lblCenariosLabel.Text = "Cen\u00E1rios:";
            this.lblCenariosLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            // Seletor numérico: permite de 1 a 10 cenários (conforme roteiro).
            this.nudCenarios.BackColor = System.Drawing.Color.FromArgb(30, 34, 60);
            this.nudCenarios.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.nudCenarios.ForeColor = System.Drawing.Color.FromArgb(129, 140, 248);
            this.nudCenarios.Location = new System.Drawing.Point(870, 44);
            this.nudCenarios.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudCenarios.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCenarios.Name = "nudCenarios";
            this.nudCenarios.Size = new System.Drawing.Size(62, 27);
            this.nudCenarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCenarios.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCenarios.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

            this.pnlSeparator.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(950, 2);

            // Seletor de modo: Arquivo 1 (somente PD) ou Arquivo 2 (PD + Backtracking).
            this.pnlModoExecucao.BackColor = System.Drawing.Color.FromArgb(17, 19, 38);
            this.pnlModoExecucao.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlModoExecucao.Name = "pnlModoExecucao";
            this.pnlModoExecucao.Size = new System.Drawing.Size(950, 44);
            this.pnlModoExecucao.Controls.Add(this.rbPdBacktracking);
            this.pnlModoExecucao.Controls.Add(this.rbSomentePd);
            this.pnlModoExecucao.Controls.Add(this.lblModoExecucao);

            this.lblModoExecucao.AutoSize = true;
            this.lblModoExecucao.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblModoExecucao.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblModoExecucao.Location = new System.Drawing.Point(15, 12);
            this.lblModoExecucao.Name = "lblModoExecucao";
            this.lblModoExecucao.Text = "Modo de execu\u00E7\u00E3o:";

            this.rbSomentePd.AutoSize = true;
            this.rbSomentePd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbSomentePd.ForeColor = System.Drawing.Color.FromArgb(210, 215, 225);
            this.rbSomentePd.Location = new System.Drawing.Point(155, 10);
            this.rbSomentePd.Name = "rbSomentePd";
            this.rbSomentePd.Size = new System.Drawing.Size(320, 23);
            this.rbSomentePd.TabStop = true;
            this.rbSomentePd.Text = "Somente PD  (LcsProgramacaoDinamica.cs)";
            this.rbSomentePd.UseVisualStyleBackColor = true;

            this.rbPdBacktracking.AutoSize = true;
            this.rbPdBacktracking.Checked = true;
            this.rbPdBacktracking.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbPdBacktracking.ForeColor = System.Drawing.Color.FromArgb(129, 140, 248);
            this.rbPdBacktracking.Location = new System.Drawing.Point(490, 10);
            this.rbPdBacktracking.Name = "rbPdBacktracking";
            this.rbPdBacktracking.Size = new System.Drawing.Size(420, 23);
            this.rbPdBacktracking.TabStop = true;
            this.rbPdBacktracking.Text = "PD + Backtracking  (LcsProgramacaoDinamicaBacktracking.cs)";
            this.rbPdBacktracking.UseVisualStyleBackColor = true;

            this.pnlInput.AutoScroll = true;
            this.pnlInput.BackColor = System.Drawing.Color.FromArgb(13, 15, 30);
            this.pnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInput.Name = "pnlInput";

            this.pnlSepActions.BackColor = System.Drawing.Color.FromArgb(40, 44, 75);
            this.pnlSepActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSepActions.Name = "pnlSepActions";
            this.pnlSepActions.Size = new System.Drawing.Size(950, 1);

            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(17, 19, 38);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(950, 58);
            this.pnlActions.Controls.Add(this.btnLimpar);
            this.pnlActions.Controls.Add(this.btnExecutar);
            this.pnlActions.Controls.Add(this.btnCreditos);

            this.btnExecutar.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.btnExecutar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExecutar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(129, 140, 248);
            this.btnExecutar.FlatAppearance.BorderSize = 1;
            this.btnExecutar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(79, 70, 229);
            this.btnExecutar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(129, 140, 248);
            this.btnExecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecutar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnExecutar.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(220, 42);
            this.btnExecutar.Text = "Executar LCS";

            this.btnLimpar.BackColor = System.Drawing.Color.FromArgb(30, 35, 58);
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 75, 105);
            this.btnLimpar.FlatAppearance.BorderSize = 1;
            this.btnLimpar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(45, 50, 80);
            this.btnLimpar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 45, 72);
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnLimpar.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(130, 42);
            this.btnLimpar.Text = "Limpar";

            this.btnCreditos.BackColor = System.Drawing.Color.FromArgb(30, 35, 58);
            this.btnCreditos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreditos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(70, 75, 105);
            this.btnCreditos.FlatAppearance.BorderSize = 1;
            this.btnCreditos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(45, 50, 80);
            this.btnCreditos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(40, 45, 72);
            this.btnCreditos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreditos.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.btnCreditos.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.btnCreditos.Name = "btnCreditos";
            this.btnCreditos.Size = new System.Drawing.Size(130, 42);
            this.btnCreditos.Text = "Créditos";

            this.pnlResultados.BackColor = System.Drawing.Color.FromArgb(13, 15, 30);
            this.pnlResultados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResultados.Name = "pnlResultados";
            this.pnlResultados.Size = new System.Drawing.Size(950, 250);
            this.pnlResultados.Controls.Add(this.rtbResultados);
            this.pnlResultados.Controls.Add(this.lblResultados);

            this.lblResultados.BackColor = System.Drawing.Color.FromArgb(22, 25, 48);
            this.lblResultados.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultados.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblResultados.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblResultados.Size = new System.Drawing.Size(950, 34);
            this.lblResultados.Text = "Resultados";
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.rtbResultados.BackColor = System.Drawing.Color.FromArgb(13, 15, 30);
            this.rtbResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbResultados.Font = new System.Drawing.Font("Consolas", 10.5F);
            this.rtbResultados.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.rtbResultados.Name = "rtbResultados";
            this.rtbResultados.ReadOnly = true;
            this.rtbResultados.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 15, 30);
            this.ClientSize = new System.Drawing.Size(950, 750);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(750, 550);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LCS \u2014 Trabalho Final FPAA";

            // --- Montagem final: ordem dos Dock determina o layout da janela ---
            this.Controls.Add(this.pnlInput);         // Dock.Fill
            this.Controls.Add(this.pnlSepActions);    // Dock.Bottom
            this.Controls.Add(this.pnlActions);       // Dock.Bottom
            this.Controls.Add(this.pnlResultados);    // Dock.Bottom
            this.Controls.Add(this.pnlModoExecucao);  // Dock.Top
            this.Controls.Add(this.pnlSeparator);     // Dock.Top
            this.Controls.Add(this.pnlHeader);        // Dock.Top

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCenarios)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblCenariosLabel;
        private System.Windows.Forms.NumericUpDown nudCenarios;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.Panel pnlModoExecucao;
        private System.Windows.Forms.Label lblModoExecucao;
        private System.Windows.Forms.RadioButton rbSomentePd;
        private System.Windows.Forms.RadioButton rbPdBacktracking;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Panel pnlSepActions;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnCreditos;
        private System.Windows.Forms.Panel pnlResultados;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.RichTextBox rtbResultados;
    }
}
