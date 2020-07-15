using System;
using System.Collections.Generic;
using System.IO;
using E_Playes.Interfaces;

namespace E_Playes.Models
{
    public class Noticia : EplayersBase , INoticia
    {
        public int IdNoticia { get; set; }

        public string Titulo { get; set; }

        public string Texto { get; set; }

        public string Imagem { get; set; }

        private const string PATH = "Database/noticia.csv";
        public Noticia()
        {
            CreateFolderAndFile(PATH);
        }


        public void Create(Noticia n)
        {
           string [] linhas = {PrepararLinha(n)};
            File.AppendAllLines(PATH, linhas);
        }

        private string PrepararLinha(Noticia n)
        {

            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }

        public void Delete(int IdNoticias)
        {
           List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == IdNoticias.ToString());

            RewriteCSV(PATH, linhas );
        }

        public List<Noticia> ReadAll()
        {
           List<Noticia> noticias = new List<Noticia>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticia noticia = new Noticia();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Texto = linha [2];
                noticia.Imagem = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
        }

        public void Update(Noticia n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(h => h.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add(PrepararLinha(n));
            RewriteCSV(PATH, linhas );



        }

        
    }
}