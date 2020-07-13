using System.Collections.Generic;
using E_Playes.Models;

namespace E_Playes.Interfaces
{
    public interface IEquipe
    {
         void Create(Equipe e);

         List<Equipe> ReadAll();

         void Update(Equipe e);

         void Delete(int IdEquipe);
    }
}