using System.Threading.Tasks;
using System.Collections.Generic;

namespace LiteDB.Async
{
    public partial class LiteCollectionAsync<T>
    {
        /// <summary>
        /// Insert or Update a document in this collection.
        /// </summary>
        public Task<bool> UpsertAsync(T entity)
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<bool>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.Upsert(entity));
            });
            return tcs.Task;
        }

        /// <summary>
        /// Insert or Update all documents
        /// </summary>
        public Task<int> UpsertAsync(IEnumerable<T> entities)
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<int>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.Upsert(entities));
            });
            return tcs.Task;
        }

        /// <summary>
        /// Insert or Update a document in this collection.
        /// </summary>
        public Task<bool> UpsertAsync(BsonValue id, T entity)
        {
            VerifyNoClosedTransaction();
            var tcs = new TaskCompletionSource<bool>();
            Database.Enqueue(tcs, () => {
                tcs.SetResult(UnderlyingCollection.Upsert(id, entity));
            });
            return tcs.Task;
        }
    }
}