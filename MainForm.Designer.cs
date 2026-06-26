namespace Trabalho
{
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

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlSeparator1 = new System.Windows.Forms.Panel();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.lblCenarios = new System.Windows.Forms.Label();
            this.nudCenarios = new System.Windows.Forms.NumericUpDown();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.tabCenarios = new System.Windows.Forms.TabControl();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.pnlResultados = new System.Windows.Forms.Panel();
            this.lblResultados = new System.Windows.Forms.Label();
            this.rtbResultados = new System.Windows.Forms.RichTextBox();

            this.pnlHeader.SuspendLayout();
            this.pnlConfig.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCenarios)).BeginInit();
            this.SuspendLayout();

            // ═══════════════════════════════════════════════
            // pnlHeader — Cabeçalho estilo GTA San Andreas
            // ═══════════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(18, 18, 22);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(950, 95);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Impact", 34F, System.Drawing.FontStyle.Regular);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(240, 150, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(950, 58);
            this.lblTitle.Text = "★  LCS  ★";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblSubtitle
            this.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubtitle.Font = new System.Drawing.Font("Impact", 11F, System.Drawing.FontStyle.Regular);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(245, 197, 24);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(950, 28);
            this.lblSubtitle.Text = "LONGEST COMMON SUBSEQUENCE  ·  TRABALHO FINAL FPAA";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ═══════════════════════════════════════════════
            // pnlSeparator1 — Linha laranja decorativa
            // ═══════════════════════════════════════════════
            this.pnlSeparator1.BackColor = System.Drawing.Color.FromArgb(240, 150, 15);
            this.pnlSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeparator1.Name = "pnlSeparator1";
            this.pnlSeparator1.Size = new System.Drawing.Size(950, 3);

            // ═══════════════════════════════════════════════
            // pnlConfig — Painel de configuração
            // ═══════════════════════════════════════════════
            this.pnlConfig.BackColor = System.Drawing.Color.FromArgb(24, 24, 28);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Size = new System.Drawing.Size(950, 58);
            this.pnlConfig.Controls.Add(this.btnConfirmar);
            this.pnlConfig.Controls.Add(this.nudCenarios);
            this.pnlConfig.Controls.Add(this.lblCenarios);

            // lblCenarios
            this.lblCenarios.AutoSize = true;
            this.lblCenarios.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular);
            this.lblCenarios.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.lblCenarios.Location = new System.Drawing.Point(25, 15);
            this.lblCenarios.Name = "lblCenarios";
            this.lblCenarios.Text = "QUANTIDADE DE CENÁRIOS:";

            // nudCenarios
            this.nudCenarios.BackColor = System.Drawing.Color.FromArgb(38, 38, 42);
            this.nudCenarios.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular);
            this.nudCenarios.ForeColor = System.Drawing.Color.FromArgb(240, 150, 15);
            this.nudCenarios.Location = new System.Drawing.Point(310, 11);
            this.nudCenarios.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudCenarios.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudCenarios.Name = "nudCenarios";
            this.nudCenarios.Size = new System.Drawing.Size(65, 35);
            this.nudCenarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudCenarios.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnConfirmar
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(240, 150, 15);
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(245, 197, 24);
            this.btnConfirmar.FlatAppearance.BorderSize = 2;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(200, 120, 10);
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 180, 40);
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular);
            this.btnConfirmar.ForeColor = System.Drawing.Color.FromArgb(12, 12, 12);
            this.btnConfirmar.Location = new System.Drawing.Point(395, 9);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(170, 40);
            this.btnConfirmar.Text = "CONFIRMAR";

            // ═══════════════════════════════════════════════
            // tabCenarios — Abas de cenários (owner-draw)
            // ═══════════════════════════════════════════════
            this.tabCenarios.BackColor = System.Drawing.Color.FromArgb(24, 24, 28);
            this.tabCenarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCenarios.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabCenarios.Font = new System.Drawing.Font("Impact", 11F, System.Drawing.FontStyle.Regular);
            this.tabCenarios.ItemSize = new System.Drawing.Size(130, 34);
            this.tabCenarios.Name = "tabCenarios";
            this.tabCenarios.Padding = new System.Drawing.Point(12, 6);
            this.tabCenarios.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;

            // ═══════════════════════════════════════════════
            // pnlActions — Botões de ação
            // ═══════════════════════════════════════════════
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(20, 20, 24);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(950, 62);
            this.pnlActions.Controls.Add(this.btnLimpar);
            this.pnlActions.Controls.Add(this.btnExecutar);

            // btnExecutar
            this.btnExecutar.BackColor = System.Drawing.Color.FromArgb(240, 150, 15);
            this.btnExecutar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExecutar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(245, 197, 24);
            this.btnExecutar.FlatAppearance.BorderSize = 2;
            this.btnExecutar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(200, 120, 10);
            this.btnExecutar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(255, 180, 40);
            this.btnExecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecutar.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular);
            this.btnExecutar.ForeColor = System.Drawing.Color.FromArgb(12, 12, 12);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(270, 46);
            this.btnExecutar.Text = "★  EXECUTAR LCS  ★";

            // btnLimpar
            this.btnLimpar.BackColor = System.Drawing.Color.FromArgb(50, 50, 55);
            this.btnLimpar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(240, 150, 15);
            this.btnLimpar.FlatAppearance.BorderSize = 1;
            this.btnLimpar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(80, 40, 10);
            this.btnLimpar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(70, 70, 75);
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular);
            this.btnLimpar.ForeColor = System.Drawing.Color.FromArgb(240, 150, 15);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(150, 46);
            this.btnLimpar.Text = "LIMPAR";

            // ═══════════════════════════════════════════════
            // pnlResultados — Painel de resultados
            // ═══════════════════════════════════════════════
            this.pnlResultados.BackColor = System.Drawing.Color.FromArgb(15, 15, 18);
            this.pnlResultados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResultados.Name = "pnlResultados";
            this.pnlResultados.Size = new System.Drawing.Size(950, 255);
            this.pnlResultados.Controls.Add(this.rtbResultados);
            this.pnlResultados.Controls.Add(this.lblResultados);

            // lblResultados
            this.lblResultados.BackColor = System.Drawing.Color.FromArgb(24, 24, 28);
            this.lblResultados.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResultados.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular);
            this.lblResultados.ForeColor = System.Drawing.Color.FromArgb(240, 150, 15);
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(950, 36);
            this.lblResultados.Text = "★  RESULTADOS  ★";
            this.lblResultados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // rtbResultados
            this.rtbResultados.BackColor = System.Drawing.Color.FromArgb(15, 15, 18);
            this.rtbResultados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbResultados.Font = new System.Drawing.Font("Consolas", 11F);
            this.rtbResultados.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.rtbResultados.Name = "rtbResultados";
            this.rtbResultados.ReadOnly = true;
            this.rtbResultados.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;

            // ═══════════════════════════════════════════════
            // MainForm
            // ═══════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(12, 12, 12);
            this.ClientSize = new System.Drawing.Size(950, 750);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LCS — Trabalho Final FPAA";

            // Ordem de adição define layout de Dock:
            // (último adicionado = processado primeiro no layout)
            this.Controls.Add(this.tabCenarios);      // Dock.Fill   → espaço restante
            this.Controls.Add(this.pnlActions);        // Dock.Bottom → acima dos resultados
            this.Controls.Add(this.pnlResultados);     // Dock.Bottom → fundo da tela
            this.Controls.Add(this.pnlConfig);         // Dock.Top    → abaixo do separador
            this.Controls.Add(this.pnlSeparator1);     // Dock.Top    → abaixo do cabeçalho
            this.Controls.Add(this.pnlHeader);         // Dock.Top    → topo da tela

            this.pnlHeader.ResumeLayout(false);
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCenarios)).EndInit();
            this.ResumeLayout(false);
        }

        // ═══════════════════════════════════════════════
        // Declaração dos controles
        // ═══════════════════════════════════════════════
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlSeparator1;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Label lblCenarios;
        private System.Windows.Forms.NumericUpDown nudCenarios;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TabControl tabCenarios;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Panel pnlResultados;
        private System.Windows.Forms.Label lblResultados;
        private System.Windows.Forms.RichTextBox rtbResultados;
    }
}
