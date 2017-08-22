using NoteManager.Infrastructure.Utils;
using NoteManager.Model.Base;

namespace NoteManager.Model
{
    public class User : EntityBase, IDeletable
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }

        #region Methods

        public virtual void EncryptPassword()
        {
            Password = Cryptography.Encrypt(Password);
        }

        public virtual void DecryptPassword()
        {
            Password = Cryptography.Decrypt(Password);
        }

        #endregion
    }
}