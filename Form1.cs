using System;
using System.Linq;
using System.Windows.Forms;

namespace Typograf
{
    public partial class Form1 : Form
    {
        string result = String.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text))
            {
                string text = textBox1.Text;

                result = Punctuation(text);
                result = PlusMinus(result);
                result = TechnicalSpecs(result);
                result = WhiteSpace(result);
                result = YUX(result);
                result = Russia(result);

                textBox1.Text = result;
            }
            else
            {
                MessageBox.Show("Вы ничего не ввели");
            }
        }
        public string WhiteSpace(string words)
        {
            string result = words;
            while(result.Contains("  "))
            {
                result = result.Replace("  ", " ");
            }
            return result;
        }
        public string Punctuation(string words)
        {
            string[] punctuation = new string[] { ",", ".", ":", ";", "!", "?"};
            string[] open = new string[] {"(", "«" };
            string[] close = new string[] { ")", "»" };
            string result = words;

            foreach(string c in punctuation)
            {
                if (result.Contains(" " + c))
                {
                    result = result.Replace(" " + c, c);
                }
                if (result.Contains(c))
                {
                    result = result.Replace(c, c + " ");
                }
            }

            if (result.Contains("—"))
            {
                result = result.Replace("—", " — ");
            }

            foreach(string c in open)
            {
                if (result.Contains(c))
                {
                    result = result.Replace(c, " " + c);
                }
                if (result.Contains(c + " "))
                {
                    result = result.Replace(c + " ", c);
                }
            }
            foreach (string c in close)
            {
                if (result.Contains(" " + c))
                {
                    result = result.Replace(" " + c, c);
                }
                if (result.Contains(c))
                {
                    result = result.Replace(c, c + " ");
                }
            }
            return result;
        }
        public string PlusMinus(string words)
        {
            string result = words;
            while (result.Contains("(+,−)"))
            {
                result = result.Replace("(+,−)", "±");
            }
            return result;
        }
        public string TechnicalSpecs(string words)
        {
            string result = words;
            for (int i = 0; i < words.Length; i++)
            {
                if (i + 2 < words.Length && IsNumeric(result[i].ToString()) && IsUnit(result[i + 2].ToString()))
                {
                    result = result.Remove(i + 1, 1);
                    result = result.Insert(i + 1, '\u00A0'.ToString());
                }
            }
            return result;
        }

        public bool IsNumeric(string word)
        {
            double num;
            return double.TryParse(word, out num);
        }

        public bool IsUnit(string word)
        {
            string[] units = new string[] { "м", "см", "мм", "км", "кг", "г", "А", "мА", "кА", "В", "мВ", "кВ", "Вт", "мВт", "кВт", "Дж", "кДж", "ебар", "Па", "кПа", "бар", "мбар", "мм рт. ст.", "об/мин", "рад/с", "%" };
            return units.Contains(word);
        }
        public string YUX(string words)
        {
            string result = words;
            while (result.Contains(" х"))
            {
                result = result.Replace(" х", " йух");
            }
            return result;
        }
        public string Russia(string words)
        {
            string result = words;
            while (result.Contains("рашка"))
            {
                result = result.Replace("рашка", "Великая Россия");
            }
            return result;
        }
    }
}
