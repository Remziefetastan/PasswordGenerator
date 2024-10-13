using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Generate_Click(object sender, EventArgs e)
        {
            int passwordLength = (int)numericUpDown1.Value;
            bool includeNumbers = checkBoxNumbers.Checked;
            bool includeSpecial = checkBoxSpecial.Checked;
            bool includeUppercase = checkBoxUppercase.Checked;
            bool includeLowercase = checkBoxLowercase.Checked;

            string password = GeneratePassword(passwordLength, includeNumbers, includeSpecial, includeUppercase, includeLowercase);
            Txt_Password.Text = password;
        }
        private string GeneratePassword(int length, bool includeNumbers, bool includeSpecial, bool includeUppercase, bool includeLowercase)
        {
            string numbers = "0123456789";
            string specialChars = "!@#$%^&*()+-*/";
            string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";

            StringBuilder characterSet = new StringBuilder();

            if (includeNumbers) characterSet.Append(numbers);
            if (includeSpecial) characterSet.Append(specialChars);
            if (includeUppercase) characterSet.Append(uppercaseChars);
            if (includeLowercase) characterSet.Append(lowercaseChars);

            if (characterSet.Length == 0) return string.Empty;

            Random random = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                password.Append(characterSet[random.Next(characterSet.Length)]);
            }

            return password.ToString();
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Metni kaydet";
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                
                File.WriteAllText(saveFileDialog.FileName, Txt_Password.Text);
                MessageBox.Show("Dosya başarıyla kaydedildi.");
            }
        }
    }
}
