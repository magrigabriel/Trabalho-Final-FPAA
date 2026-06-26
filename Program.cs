//Autores do Grupo:

//Gabriel Henrique Machado Magri;
//Caio Martins Bicalho da Costa;
//Gabriel Amorim Gonçalves Silva;
//Geovanna do Nascimento Miranda;
//João Gabriel Soares da Silva Franco;
// Luiz Henrique Oliveira Coelho

//VERSÃO 2.0 - Interface Windows Forms (GTA San Andreas Theme)

namespace Trabalho
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
