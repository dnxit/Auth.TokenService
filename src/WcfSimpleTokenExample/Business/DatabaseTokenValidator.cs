﻿using System;
using System.Linq;
using WcfSimpleTokenExample.Database;
using WcfSimpleTokenExample.Interfaces;

namespace WcfSimpleTokenExample.Business
{
    public class DatabaseTokenValidator : ITokenValidator
    {
        // Todo: Set this from a web.config appSettting value
        public static double DefaultSecondsUntilTokenExpires = 1800;

        private readonly BasicTokenDbContext _DbContext;

        public DatabaseTokenValidator(BasicTokenDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public bool IsValid(string tokentext)
        {
            Token = _DbContext.Tokens.SingleOrDefault(t => t.Text == tokentext);
            return Token != null && !IsExpired(Token);
        }

        internal bool IsExpired(Token token)
        {
            var span = DateTime.Now - token.CreateDate;
            return span.TotalSeconds > DefaultSecondsUntilTokenExpires;
        }

        public Token Token { get; set; }
    }
}