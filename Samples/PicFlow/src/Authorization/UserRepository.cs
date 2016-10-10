using System.Linq;
using System.Threading.Tasks;
using FP.DevSpace2016.PicFlow.Contracts.Dbo;
using Marten;

namespace FP.DevSpace2016.PicFlow.Authorization
{
    public class UserRepository
    {
        private readonly IDocumentStore _store;

        public UserRepository(string connectionString)
        {
            _store = DocumentStore.For(connectionString);
           
        }

        public async Task<UserInfo> CheckUser(string username, string passwordhash)
        {
            using (var session = _store.OpenSession())
            {
                var existingUser = await session.Query<User>().Where(x => x.UserName == username && x.PasswordHash == passwordhash).FirstOrDefaultAsync();
                if (existingUser == null)
                {
                    return new UserInfo();
                }
                return new UserInfo
                {
                    Id = existingUser.Id,
                    User = $"{existingUser.FirstName} {existingUser.LastName}",
                    IsValid = true
                };
            }
        }
    }
}
