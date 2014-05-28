using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;

namespace WebSite.Models
{
    public static class Tradutor
    {
        public static string Traduzir(string chave, string idioma)
        {
            StreamReader sr;
            string linha;
            string[] termo;

            if (idioma == "PT")
            {
                Assembly myAssembly = Assembly.GetExecutingAssembly();
                Stream myStream = myAssembly.GetManifestResourceStream("WebSite.Tradutor.pt-br.txt");
                sr = new StreamReader(myStream);
            }
            else
            { 
                Assembly myAssembly = Assembly.GetExecutingAssembly();
                Stream myStream = myAssembly.GetManifestResourceStream("WebSite.Tradutor.en-us.txt");
                sr = new StreamReader(myStream);
            }

            while (sr.Peek() != -1)
            {
                linha = sr.ReadLine();
                termo = linha.Split(';');

                if (termo[0].Equals(chave))
                    return termo[1].ToString();
            }

            return chave;
        }
    }
}