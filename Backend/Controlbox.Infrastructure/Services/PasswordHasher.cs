// <copyright file="PasswordHasher.cs" company="Controlbox">
// Copyright (c) Controlbox. All rights reserved.
// </copyright>

namespace Controlbox.Infrastructure.Services
{
    using System;
    using System.Security.Cryptography;
    using Controlbox.Application.Common.Interfaces;
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;

    /// <summary>
    /// Provides password hashing and verification.
    /// </summary>
    public class PasswordHasher : IPasswordHasher
    {
        /// <inheritdoc/>
        public string Hash(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }

        /// <inheritdoc/>
        public bool Check(string password, string hashedPassword)
        {
            var parts = hashedPassword.Split('.');
            if (parts.Length != 2)
            {
                return false;
            }

            var salt = Convert.FromBase64String(parts[0]);
            var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hash == parts[1];
        }
    }
}
