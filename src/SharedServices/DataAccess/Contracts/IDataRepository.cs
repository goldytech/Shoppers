namespace SharedServices.DataAccess.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel;

    public interface IDataRepository<TEntity, in TKey> where TEntity : DomainBase
    {
        /// <summary>
        /// Returns the Entity By its key.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<TEntity> GetByIdAsync(TKey id);

        Task<IQueryable<TEntity>> GetAllAsync();

        Task Insert(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TKey id);
    }
}