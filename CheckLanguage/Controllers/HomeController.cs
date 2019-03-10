using CheckLanguage.Infrastructure;
using CheckLanguage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace CheckLanguage.Controllers
{

    public class HomeController : Controller
    {

        [HttpGet]
        public ViewResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Index(TextToCheck textToCheck, FrequencyOfLetters frequencyOfLetters, Frequencies freq)
        {
            textToCheck.TextLength = textToCheck.Text.Length;
            textToCheck.Text = textToCheck.Text.ToLower();

            // Counting instances of letters in the text
            textToCheck = textToCheck.MakeFrequency(textToCheck);

            textToCheck = freq.ComparingLanguage(textToCheck, freq);
            
            return View("Score", textToCheck);
        }

        [HttpPost]
        public async Task<IActionResult> CheckFromFile (IFormFile file, TextToCheck textToCheck, Frequencies freq)
        {
            if (file == null || file.Length == 0)
                return Content("Nie wybrano pliku");
            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            string text = await file.ReadAsStringAsync();

            string extension = Path.GetExtension(path);

            if (extension != ".txt")
            {
                return (View("Error"));
            }

            textToCheck.Text = text.ToLower();
            textToCheck.TextLength = textToCheck.Text.Length;

            // Counting instances of letters in the text
            textToCheck = textToCheck.MakeFrequency(textToCheck);

            textToCheck = freq.ComparingLanguage(textToCheck, freq);

            return View("Score", textToCheck);
        }

        public IActionResult Frequencies(Frequencies freq)
        {
            // Deserialize and load frequenceies language from json file
            var frequencies = freq.DeserializeJson();

            int i = 0;
            foreach (var item in frequencies.frequencies)
            {
                for (i = 0; i < 26; i++)
                {
                    item.Frequency[i] = item.Frequency[i] * 100;
                }
            }
            return View("Frequencies", frequencies);
        }

        public IActionResult About()
        {
            return View();
        }

    }
}