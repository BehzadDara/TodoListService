using System.Security.Cryptography;
using System.Text;

namespace TodoList;

public static class MethodHelper
{
    public static string ComputeSHA512Hash(string input)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashBytes = SHA512.HashData(inputBytes);

        var sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }
        return sb.ToString();
    }
}
