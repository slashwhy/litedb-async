using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LiteDB.Async
{
    public partial class LiteCollectionAsync<T>
    {
        #region Find

        /// <summary>
        /// Find documents inside a collection using predicate expression.
        /// </summary>
        public Task<IEnumerable<T>> FindAsync(BsonExpression predicate, int skip = 0, int limit = int.MaxValue)
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<IEnumerable<T>>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.Find(predicate, skip, limit));
            });
            return tcs.Task;
        }

        /// <summary>
        /// Find documents inside a collection using query definition.
        /// </summary>
        public Task<IEnumerable<T>> FindAsync(Query query, int skip = 0, int limit = int.MaxValue)
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<IEnumerable<T>>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.Find(query, skip, limit));
            });
            return tcs.Task;
        }

        /// <summary>
        /// Find documents inside a collection using predicate expression.
        /// </summary>
        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, int skip = 0, int limit = int.MaxValue)
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<IEnumerable<T>>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.Find(predicate, skip, limit));
            });
            return tcs.Task;
        }

        #endregion

        #region FindById + One + All

        /// <summary>
        /// Find a document using Document Id. Returns null if not found.
        /// </summary>
        public Task<T> FindByIdAsync(BsonValue id)
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<T>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.FindById(id));
            });
            return tcs.Task;
        }

        /// <summary>
        /// Find the first document using predicate expression. Returns null if not found
        /// </summary>
        public Task<T> FindOneAsync(BsonExpression predicate)
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<T>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.FindOne(predicate));
            });
            return tcs.Task;
        }

        /// <summary>
        /// Find the first document using predicate expression. Returns null if not found
        /// </summary>
        public Task<T> FindOneAsync(string predicate, BsonDocument parameters)
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<T>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.FindOne(predicate, parameters));
            });
            return tcs.Task;
        }

        /// <summary>
        /// Find the first document using predicate expression. Returns null if not found
        /// </summary>
        public Task<T> FindOneAsync(BsonExpression predicate, params BsonValue[] args)
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<T>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.FindOne(predicate, args));
            });
            return tcs.Task;
        }

        /// <summary>
        /// Find the first document using predicate expression. Returns null if not found
        /// </summary>
        public Task<T> FindOneAsync(Expression<Func<T, bool>> predicate)
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<T>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.FindOne(predicate));
            });
            return tcs.Task;
        }

        /// <summary>
        /// Find the first document using defined query structure. Returns null if not found
        /// </summary>
        public Task<T> FindOneAsync(Query query)
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<T>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.FindOne(query));
            });
            return tcs.Task;
        }

        /// <summary>
        /// Returns all documents inside collection order by _id index.
        /// </summary>
        public Task<IEnumerable<T>> FindAllAsync()
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<IEnumerable<T>>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.FindAll());
            });
            return tcs.Task;
        }

        #endregion
    }
}
