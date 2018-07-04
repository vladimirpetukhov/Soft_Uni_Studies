using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
    internal class ChangeTracker<T>
        where T : class, new()
    {
        private readonly List<T> allEntities;
        private readonly List<T> added;
        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entitites)
        {

            this.added = new List<T>();
            this.removed = new List<T>();

            this.allEntities = CloneEntitites(entitites);
        }

        public IReadOnlyCollection<T> AllEntities => this.allEntities.AsReadOnly();
        public IReadOnlyCollection<T> Added => this.added.AsReadOnly();
        public IReadOnlyCollection<T> Removed => this.removed.AsReadOnly();
        public void Add(T item) => this.added.Add(item);
        public void Remove(T item) => this.removed.Add(item);
        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            var modifiedEntities = new List<T>();

            var primaryKyes = typeof(T).GetProperties()
                .Where(pi => pi.HasAttribute<KeyAttribute>())
                .ToList();

            foreach (var proxyEntity in this.AllEntities)
            {
                var primaryKeyValues = GetPrimaryKeyValues(primaryKyes, proxyEntity)
                    .ToList();

                var entity = dbSet.Entities
                    .Single(e => GetPrimaryKeyValues(primaryKyes, e).SequenceEqual(primaryKeyValues));

                var isModifed = IsModifed(proxyEntity, entity);
                if (isModifed)
                {
                    modifiedEntities.Add(entity);
                }
            }
            return modifiedEntities;
        }

        private IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKyes, T entity)
        {
            return primaryKyes.Select(pk=> pk.GetValue(entity));
        }

        private bool IsModifed(T proxyEntity, T entity)
        {
            var monitoredProporties = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType));

            var modifiedProporties = monitoredProporties
                .Where(pi => !Equals(pi.GetValue(entity), pi.GetValue(proxyEntity)))
                .ToArray();

            var isModified = modifiedProporties.Any();

            return isModified;
        }

        private List<T> CloneEntitites(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();

            var proportiesToClone = typeof(T).GetProperties()
                .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType))
                .ToArray();

            foreach (var entity in entities)
            {
                var clonedEntity = Activator.CreateInstance<T>();

                foreach (var property in proportiesToClone)
                {
                    var value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);

                }
                clonedEntities.Add(clonedEntity);
            }
            return clonedEntities;
        }
    }
}