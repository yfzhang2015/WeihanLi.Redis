﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using WeihanLi.Redis.Internals;

// ReSharper disable once CheckNamespace
namespace WeihanLi.Redis
{
    internal class CommonRedisClient : BaseRedisClient, ICommonRedisClient
    {
        public bool KeyExists(string key, CommandFlags flags = CommandFlags.None) =>
            Wrapper.KeyExists(key, flags);

        public Task<bool> KeyExistsAsync(string key, CommandFlags flags = CommandFlags.None) =>
            Wrapper.KeyExistsAsync(key, flags);

        public bool KeyExpire(string key, TimeSpan? expiresIn, CommandFlags flags = CommandFlags.None) =>
            Wrapper.KeyExpire(key, expiresIn, flags);

        public bool KeyExpire(string key, DateTime? expiry, CommandFlags flags = CommandFlags.None) =>
            Wrapper.KeyExpire(key, expiry, flags);

        public Task<bool> KeyExpireAsync(string key, TimeSpan? expiresIn, CommandFlags flags = CommandFlags.None) => Wrapper.KeyExpireAsync(key, expiresIn, flags);

        public Task<bool> KeyExpireAsync(string key, DateTime? expiry, CommandFlags flags = CommandFlags.None) =>
            Wrapper.KeyExpireAsync(key, expiry, flags);

        public bool KeyDelete(string key, CommandFlags flags = CommandFlags.None) => Wrapper.KeyDelete(key, flags);

        public long KeyDelete(string[] keys, CommandFlags flags = CommandFlags.None) => Wrapper.KeyDelete(keys, flags);

        public Task<bool> KeyDeleteAsync(string key, CommandFlags flags = CommandFlags.None) =>
            Wrapper.KeyDeleteAsync(key, flags);

        public Task<long> KeyDeleteAsync(string[] keys, CommandFlags flags = CommandFlags.None) => Wrapper.KeyDeleteAsync(keys, flags);

        public TimeSpan? KeyTimeToLive(string key, CommandFlags flags = CommandFlags.None) =>
            Wrapper.KeyTimeToLive(key, flags);

        public RedisType KeyType(string key, CommandFlags flags = CommandFlags.None) => Wrapper.KeyType(key, flags);

        public RedisResult ScriptEvaluate<TValue>(string script, string[] keys = null, TValue[] values = null,
            CommandFlags flags = CommandFlags.None) => Wrapper.ScriptEvaluate(script, keys, values, flags);

        public Task<RedisResult> ScriptEvaluateAsync<TValue>(string script, string[] keys = null, TValue[] values = null,
            CommandFlags flags = CommandFlags.None) => Wrapper.ScriptEvaluateAsync(script, keys, values, flags);

        public bool KeyPersist(string key, CommandFlags flags = CommandFlags.None) => Wrapper.KeyPersist(key, flags);

        public Task<bool> KeyPersistAsync(string key, CommandFlags flags = CommandFlags.None) => Wrapper.KeyPersistAsync(key, flags);

        public CommonRedisClient(RedisDataType dataType, ILogger<CommonRedisClient> logger) : base(logger, new RedisWrapper(Helpers.GetCachePrefix(dataType)))
        {
        }
    }
}
