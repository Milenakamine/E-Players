using System.Collections.Generic;
using E_Playes.Models;

namespace E_Playes.Interfaces
{
    public interface INoticia
    {
        //fica da mesma forma que equipe
         void Create(Noticia n);

         List<Noticia> ReadAll();

         void Update(Noticia n);

         void Delete(int IdNoticia);
    }
}