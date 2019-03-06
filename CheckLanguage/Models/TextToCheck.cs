using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CheckLanguage.Models
{
    public class TextToCheck
    {
        public string Text { get; set; }
        public double TextLength { get; set; }
        public double[] Frequency { get; set; } = new double[27];
        public double[] Distance { get; set; } = new double[6];
        public string WonLanguage { get; set; }
        public ICollection<FrequencyOfLetters> Frequencies { get; set; }

        public TextToCheck MakeFrequency(TextToCheck textToCheck)
        {
            foreach (char c in textToCheck.Text)
            {
                if (c >= 97 && c <= 122)
                {
                    textToCheck.Frequency[c - 97]++;
                }
                else
                {
                    textToCheck.Frequency[26]++;
                }
            }

            return textToCheck;
        }
    }
}
