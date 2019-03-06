using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CheckLanguage.Models;
using Newtonsoft.Json;

namespace CheckLanguage.Models
{
    public class Frequencies
    {
        public IList<FrequencyOfLetters> frequencies { get; set; }

        public Frequencies DeserializeJson()
        {
            var webClient = new WebClient() { Encoding = Encoding.UTF8 };
            var json = webClient.DownloadString(@"F:\Developer\Projects\CheckLanguage\CheckLanguage\wwwroot\json\frequencies.json");
            var frequencies = JsonConvert.DeserializeObject<Frequencies>(json);

            return frequencies;
        }

        public TextToCheck ComparingLanguage(TextToCheck textToCheck, Frequencies freq)
        {
            var frequencies = freq.DeserializeJson();

            List<int> FreqId = new List<int>();
            List<string> LangName = new List<string>();
            List<double[]> Freq = new List<double[]>();

            foreach (var item in frequencies.frequencies)
            {
                FreqId.Add(item.FrequencyId);
                LangName.Add(item.LanguageName);
                Freq.Add(item.Frequency);
            }

            // Comparison frequencies of text with frequencies language
            int a = 0;
            int i = 0;

            for (a = 0; a < 6; a++)
            {
                double[] TempText = new double[27];

                for (i = 0; i < 26; i++)
                {
                    TempText[i] = textToCheck.Frequency[i] / textToCheck.TextLength;
                    TempText[i] = TempText[i] - Freq[a][i];
                    if (TempText[i] < 0) TempText[i] = -TempText[i];
                    textToCheck.Distance[a] = textToCheck.Distance[a] + TempText[i];
                }
            }

            double Language = textToCheck.Distance.Min();
            int WhichLanguage = Array.IndexOf(textToCheck.Distance, Language);
            textToCheck.WonLanguage = LangName[WhichLanguage];

            return textToCheck;
        }
    }
}
