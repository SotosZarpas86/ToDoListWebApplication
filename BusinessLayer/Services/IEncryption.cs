using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IEncryption
    {
        string EncryptPassword(string plainText);
        string DecryptPassword(string encryptedText);
    }
}
