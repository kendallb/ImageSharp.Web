// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

using System.Text;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Web.Caching;
using SixLabors.ImageSharp.Web.Commands;

namespace SixLabors.ImageSharp.Web.Benchmarks.Caching
{
    /// <summary>
    /// Original implementation of cache key creation.
    /// </summary>
    public class CacheKeyBaseline : ICacheKey
    {
        /// <inheritdoc/>
        public string Create(HttpContext context, CommandCollection commands)
        {
            var sb = new StringBuilder(context.Request.Host.ToString());

            string pathBase = context.Request.PathBase.ToString();
            if (!string.IsNullOrWhiteSpace(pathBase))
            {
                sb.AppendFormat("{0}/", pathBase);
            }

            string path = context.Request.Path.ToString();
            if (!string.IsNullOrWhiteSpace(path))
            {
                sb.Append(path);
            }

            sb.Append(QueryString.Create(commands));

            return sb.ToString().ToLowerInvariant();
        }
    }
}
