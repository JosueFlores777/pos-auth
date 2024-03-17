using Dominio.Especificaciones;
using Dominio.Models;
using Dominio.Repositories;
using Dominio.Repositories.Extenciones;
using Dominio.Repositories.Extensiones;
using Infraestructura.Data;
using Infraestructura.Repositories.Extenciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infraestructura.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly AutenticationContext _dbContext;

        public GenericRepository(AutenticationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPagina<TEntity> ConsultarPaginado(IConsulta ownerParameters, ISpecification<TEntity> busqueda)
        {
         return PagedList<TEntity>.ToPagedList(_dbContext.Set<TEntity>().OrderByDescending(on => on.Id).Where(busqueda.Traer()).AsQueryable(),
               ownerParameters.PageNumber,
               ownerParameters.PageSize);
        }

        public IPagina<TEntity> ConsultarPaginado(IConsulta ownerParameters)
        {
            return PagedList<TEntity>.ToPagedList(_dbContext.Set<TEntity>().OrderBy(on => on.Id),
           ownerParameters.PageNumber,
           ownerParameters.PageSize);
        }

        public TEntity Create(TEntity entity)
        {
             _dbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        public TEntity Delete(int id)
        {
            var entity =  GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            return entity;
        }
        public TEntity Delete(TEntity entity)
        {
            var x =_dbContext.Set<TEntity>().Remove(entity);
            return entity;
        }
        public IEnumerable<TEntity> Filter(Func<TEntity, bool> predicate)
        {
            var respultado= _dbContext.Set<TEntity>().AsNoTracking().Where(predicate);

            return respultado;
        }

        public IEnumerable<TEntity> Filter(ISpecification<TEntity> especificaciones)
        {
            var respultado = _dbContext.Set<TEntity>().AsNoTracking().Where(especificaciones.Traer());

            return respultado;
        }

        public TEntity GetById(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking();
            return includes
                .Aggregate(
                    query.AsQueryable(),
                    (current, include) => current.Include(include)
                )
                .FirstOrDefault(e => e.Id == id);
        }
        public IEnumerable<TEntity> Filter(ISpecification<TEntity> especificacion, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _dbContext.Set<TEntity>().AsNoTracking();
            return includes
                .Aggregate(
                    query.AsQueryable(),
                    (current, include) => current.Include(include)
                )
                .Where(especificacion.Traer());
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public void SaveAll(IList<TEntity> entity)
        {
            foreach (var item in entity) Create(item);
        }

        public TEntity Update(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return entity;
        }

        public IQueryable<TEntity> Set()
        {
            return _dbContext.Set<TEntity>();
        }
    }
}
