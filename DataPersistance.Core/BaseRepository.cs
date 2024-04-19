using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Core;
using Domain.Core.Specification;

namespace DataPersistance.Core
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entity
    {
        protected IContext Context;

        protected BaseRepository(IContext c)
        {
            Context = c;
        }

        public virtual T Add(T item)
        {
            T t = Context.Add(item);
            Context.SaveChanges();
            return t;
        }

        public virtual void Remove(T item)
        {
           Context.Delete(item);
            Context.SaveChanges();
        }

        public virtual void Remove(Guid id)
        {

            var persisted = GetById(id);
            if (persisted == null)
                throw new Exception(string.Format("Illegal parameter id:{0}", id));
            Remove(persisted);
        }

        public virtual void Update(T item)
        {
            if(item ==null) return;
            Remove(item.Id);
            Add(item);
            Context.SaveChanges();
        }

        public virtual T GetById(Guid id)
        {
            return (id != Guid.Empty) ? GetAll().FirstOrDefault(i => i.Id == id) : default(T);
        }

        public virtual T GetByName(string name)
        {
            return (name != string.Empty) ? GetAll().FirstOrDefault(i => i.Name == name) : default(T);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Query();
        }

        public T FirstOrDefaultMatching(ISpecification<T> specification)
        {
            return AllMatching(specification).FirstOrDefault();
        }

        public virtual IEnumerable<T> AllMatching(ISpecification<T> specification)
        {
            return Query().Where(specification.SatisfiedBy());
        }

        public virtual IEnumerable<T> GetPaged<TKProperty>(int pageIndex, int pageCount,
            Expression<Func<T, TKProperty>> orderByExpression, bool ascending)
        {
            var set = Query();

            if (@ascending)
            {
                return set.OrderBy(orderByExpression)
                    .Skip(pageCount * pageIndex)
                    .Take(pageCount).AsEnumerable();
            }

            return set.OrderByDescending(orderByExpression)
                .Skip(pageCount * pageIndex)
                .Take(pageCount).AsEnumerable();
        }

        public virtual IEnumerable<T> GetFiltered(Expression<Func<T, bool>> filter)
        {
            return Query().Where(filter).AsEnumerable();
        }

        public IQueryable<T> CreateSet()
        {
            return Context.CreateSet<T>();
        }

        public IUnitOfWork BeginTransaction()
        {
            return Context.BeginTransaction();
        }

        public bool AnyMatching(ISpecification<T> specification)
        {
            return Query().Any(specification.SatisfiedBy());
        }

        public T Get(ISpecification<T> specification)
        {
            return Query().SingleOrDefault(specification.SatisfiedBy().Compile());
        }

        protected virtual IQueryable<T> Query()
        {
            return Context.CreateSet<T>().Where(EntitySpecification<T>.IsNotRemoveEntity().SatisfiedBy());
        }
    }
}