using System.Speech.Synthesis;

namespace SistemaSenhas;

public partial class Form1 : Form
{
    private Queue<string> filaSenhas = new Queue<string>();
        private int contador = 0;
    public Form1()
    {
        InitializeComponent();

        // Criar botões e rótulo na mão
        var btnGerar = new Button { Text = "Gerar Senha", Top = 20, Left = 20 };
        var btnChamar = new Button { Text = "Chamar Senha", Top = 60, Left = 20 };
        var lblSenha = new Label { Name = "lblSenha", Text = "A000", Top = 100, Left = 20, Font = new System.Drawing.Font("Arial", 24) };

            btnGerar.Click += (s, e) =>
            {
                contador++;
                var senha = "A" + contador.ToString("D3");
                filaSenhas.Enqueue(senha);
                MessageBox.Show("Sua senha é: " + senha);
            };

            btnChamar.Click += (s, e) =>
            {
                if (filaSenhas.Count > 0)
                {
                    var senha = filaSenhas.Dequeue();
                    lblSenha.Text = senha;

                    var synth = new SpeechSynthesizer();
                    synth.SpeakAsync($"Senha {senha}, por favor dirigir-se ao guichê 1");
                }
                else
                {
                    MessageBox.Show("Nenhuma senha na fila.");
                }
            };

            this.Controls.Add(btnGerar);
            this.Controls.Add(btnChamar);
            this.Controls.Add(lblSenha);
    }
}
