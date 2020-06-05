﻿using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DAL.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        IUnitOfWorkTransaction BeginTransaction();
        void Commit();
        Task CommitAsync(CancellationToken cancellationToken = default);
        void Commit(IDbContextTransaction transaction);
        Task CommitAsync(IDbContextTransaction transaction, CancellationToken cancellationToken = default);
        TEntity Insert<TEntity>(TEntity entity) where TEntity : class;
        void InsertRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        Task<TEntity> InsertAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        Task InsertRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : class;
        TEntity Update<TEntity>(TEntity entity) where TEntity : class;
        void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        TEntity Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
        IQueryable<TEntity> Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
        IQueryable<TEntity> GetAll<TEntity>(int limit, int offset) where TEntity : class;
        TEntity GetById<TEntity>(Guid id) where TEntity : class;
        Task<TEntity> GetByIdAsync<TEntity>(Guid id) where TEntity : class;
        IQueryable<TEntity> ExecuteQueryCommand<TEntity>(string sql, params object[] parameters) where TEntity : class;
        bool Any<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default) where TEntity : class;
    }
}