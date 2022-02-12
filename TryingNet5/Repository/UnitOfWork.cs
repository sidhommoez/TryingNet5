using System;
using TryingNet5.data;
using TryingNet5.IRepository;

namespace TryingNet5.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;

        public UnitOfWork(DataBaseContext context,
         IGenericRepository<Country> countries,
         IGenericRepository<Hotel> hotels)
        {
            _context = context;
            _countries = countries;
            _hotels = hotels;
        }
        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);

        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
