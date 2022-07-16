using ERP.Framework.Shared;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;

using System;
using System.Linq;
using System.Security.Cryptography;
 

namespace ERP.Common;

public class Security : ISecurity
{
    /* =======================
    * HASHED PASSWORD FORMATS
    * =======================
    * 
    * Version 3:
    * PBKDF2 with HMAC-SHA256, 128-bit salt, 256-bit subkey, 10000 iterations.
    * Format: { 0x01, prf (UInt32), iter count (UInt32), salt length (UInt32), salt, subkey }
    * (All UInt32s are stored big-endian.)
    */

    public string HashPassword(string password)
    {
        var prf = KeyDerivationPrf.HMACSHA256;
        var rng = RandomNumberGenerator.Create();
        const int iterCount = 10000;
        const int saltSize = 128 / 8;
        const int numBytesRequested = 256 / 8;

        // Produce a version 3 (see comment above) text hash.
        var salt = new byte[saltSize];
        rng.GetBytes(salt);
        var subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

        var outputBytes = new byte[13 + salt.Length + subkey.Length];
        outputBytes[0] = 0x01; // format marker
        WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
        WriteNetworkByteOrder(outputBytes, 5, iterCount);
        WriteNetworkByteOrder(outputBytes, 9, saltSize);
        Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
        Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
        return Convert.ToBase64String(outputBytes);
    }

    public bool VerifyHashedPassword(string hashedPassword, string providedPassword)
    {
        var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

        // Wrong version
        if (decodedHashedPassword[0] != 0x01)
            return false;

        // Read header information
        var prf = (KeyDerivationPrf)ReadNetworkByteOrder(decodedHashedPassword, 1);
        var iterCount = (int)ReadNetworkByteOrder(decodedHashedPassword, 5);
        var saltLength = (int)ReadNetworkByteOrder(decodedHashedPassword, 9);

        // Read the salt: must be >= 128 bits
        if (saltLength < 128 / 8)
        {
            return false;
        }
        var salt = new byte[saltLength];
        Buffer.BlockCopy(decodedHashedPassword, 13, salt, 0, salt.Length);

        // Read the subkey (the rest of the payload): must be >= 128 bits
        var subkeyLength = decodedHashedPassword.Length - 13 - salt.Length;
        if (subkeyLength < 128 / 8)
        {
            return false;
        }
        var expectedSubkey = new byte[subkeyLength];
        Buffer.BlockCopy(decodedHashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

        // Hash the incoming password and verify it
        var actualSubkey = KeyDerivation.Pbkdf2(providedPassword, salt, prf, iterCount, subkeyLength);
        return actualSubkey.SequenceEqual(expectedSubkey);
    }

    private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
    {
        buffer[offset + 0] = (byte)(value >> 24);
        buffer[offset + 1] = (byte)(value >> 16);
        buffer[offset + 2] = (byte)(value >> 8);
        buffer[offset + 3] = (byte)(value >> 0);
    }

    private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
    {
        return ((uint)(buffer[offset + 0]) << 24)
            | ((uint)(buffer[offset + 1]) << 16)
            | ((uint)(buffer[offset + 2]) << 8)
            | ((uint)(buffer[offset + 3]));
    }
}
