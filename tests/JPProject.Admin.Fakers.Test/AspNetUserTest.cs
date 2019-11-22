﻿using Bogus;
using JPProject.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace JPProject.Admin.Fakers.Test
{
    public class AspNetUserTest : ISystemUser
    {
        private readonly Faker _faker;

        public AspNetUserTest()
        {
            _faker = new Bogus.Faker();
        }
        public string Username { get; } = "TestUser";
        public bool IsAuthenticated() => true;
        public bool IsInRole(string role)
        {
            return _faker.Random.Bool();
        }

        public string UserId { get; } = Guid.NewGuid().ToString();
        public IEnumerable<Claim> GetClaimsIdentity() => new List<Claim>();

        public string GetRemoteIpAddress() => _faker.Internet.Ip();

        public string GetLocalIpAddress() => _faker.Internet.Ip();
    }
}
