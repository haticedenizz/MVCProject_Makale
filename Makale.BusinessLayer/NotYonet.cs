using Makale.DataAccessLayer;
using Makale.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale.BusinessLayer
{
    public class NotYonet
    {
        Respository<Note> repo_not = new Respository<Note>();
        public List<Note> NotListesi()
        {
            return repo_not.List();
        }

    }
}
