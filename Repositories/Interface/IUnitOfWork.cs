using System;
using FamilyApp.Repositories.Registry;

namespace FamilyApp.Interfaces
{
    public partial interface IUnitOfWork : IDisposable
    {
       DBRegistry DBReg { get; }
        // uvm ..

        int SaveChanges();

        // uvm ..
    }
}