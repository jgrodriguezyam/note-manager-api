using NoteManager.Infrastructure.IGenericRepositories;
using NoteManager.Model;

namespace NoteManager.DataAccess.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindUserByPublicKey(string publicKey);
    }
}