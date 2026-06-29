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
// Descrição : Janela de créditos com rolagem animada dos nomes dos autores
//             e reprodução de áudio de fundo.
// =============================================================================

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace Trabalho
{
    /// <summary>
    /// Formulário modal que exibe os créditos do projeto com animação de scroll.
    /// </summary>
    public class CreditsForm : Form
    {
        // Importação da API winmm para reprodução do áudio de créditos.
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern int mciSendString(string command, IntPtr buffer, int bufferSize, IntPtr callback);

        private Label lblCredits;
        private System.Windows.Forms.Timer scrollTimer;

        public CreditsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cria os controles visuais e monta o texto com os nomes dos integrantes.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCredits = new Label();
            this.scrollTimer = new System.Windows.Forms.Timer();
            this.SuspendLayout();

            this.BackColor = Color.FromArgb(13, 15, 30);
            this.ClientSize = new Size(600, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreditsForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Créditos";
            this.FormClosing += CreditsForm_FormClosing;
            this.Load += CreditsForm_Load;

            this.lblCredits.AutoSize = true;
            this.lblCredits.Font = new Font("Segoe UI", 16F, FontStyle.Regular);
            this.lblCredits.ForeColor = Color.FromArgb(241, 245, 249);
            this.lblCredits.Name = "lblCredits";
            this.lblCredits.TabIndex = 0;
            this.lblCredits.TextAlign = ContentAlignment.MiddleCenter;
            
            // Texto exibido durante a animação de rolagem.
            string creditsText = 
                "TRABALHO FINAL FPAA\n\n" +
                "Desenvolvido por:\n\n" +
                "João Gabriel Soares Da Silva Franco\n\n" +
                "Luiz Henrique Oliveira Coelho\n\n" +
                "Geovanna Do Nascimento Miranda\n\n" +
                "Caio Martins Bicalho da Costa\n\n" +
                "Gabriel Henrique Machado Magri\n\n" +
                "Gabriel Amorim Gonçalves Silva\n\n\n\n" +
                "Obrigado por usar!";
                
            this.lblCredits.Text = creditsText;

            // Timer controla a velocidade da animação (~33 fps).
            this.scrollTimer.Interval = 30;
            this.scrollTimer.Tick += ScrollTimer_Tick;

            this.Controls.Add(this.lblCredits);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// Posiciona o label abaixo da tela, inicia o áudio e a animação.
        /// </summary>
        private void CreditsForm_Load(object? sender, EventArgs e)
        {
            this.lblCredits.Location = new Point((this.ClientSize.Width - this.lblCredits.Width) / 2, this.ClientSize.Height);
            
            try
            {
                string audioPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "creditos.mp3");
                if (File.Exists(audioPath))
                {
                    mciSendString("close creditsMusic", IntPtr.Zero, 0, IntPtr.Zero);
                    mciSendString($"open \"{audioPath}\" type mpegvideo alias creditsMusic", IntPtr.Zero, 0, IntPtr.Zero);
                    mciSendString("play creditsMusic", IntPtr.Zero, 0, IntPtr.Zero);
                }
            }
            catch { }

            this.scrollTimer.Start();
        }

        /// <summary>
        /// Move o label para cima a cada tick; reinicia quando sai da tela.
        /// </summary>
        private void ScrollTimer_Tick(object? sender, EventArgs e)
        {
            this.lblCredits.Top -= 2;

            if (this.lblCredits.Bottom < 0)
            {
                this.lblCredits.Top = this.ClientSize.Height;
            }
        }

        /// <summary>
        /// Para a animação e encerra a reprodução do áudio ao fechar a janela.
        /// </summary>
        private void CreditsForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            this.scrollTimer.Stop();
            
            try
            {
                mciSendString("stop creditsMusic", IntPtr.Zero, 0, IntPtr.Zero);
                mciSendString("close creditsMusic", IntPtr.Zero, 0, IntPtr.Zero);
            }
            catch { }
        }
    }
}
