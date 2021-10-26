using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;

namespace UdemyNLayerProject.Core.UnitOfWorks
{
   public interface IUnitOfWork
    {
        //veritabanıyla ilgili işlemler olduğu için IProduct ile ICategory'yi almalıyım
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }


        Task CommitAsync();

        void Commit(); 
    }
}
