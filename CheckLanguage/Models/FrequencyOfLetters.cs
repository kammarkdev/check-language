using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheckLanguage.Models
{
    public class FrequencyOfLetters
    {
        public int FrequencyId { get; set; }
        public string LanguageName { get; set; }
        public double[] Frequency { get; set; }

        public Frequencies Frequencies { get; set; }
    }
}
