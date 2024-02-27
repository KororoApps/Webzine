﻿using Webzine.Entity;

namespace Webzine.Repository.Contracts
{
    public interface ICommentaireRepository
    {
        void Add(Commentaire commentaire);
        void Delete(Commentaire commentaire);
        Commentaire Find(int id);
        IEnumerable<Commentaire> FindAll();
    }
}
