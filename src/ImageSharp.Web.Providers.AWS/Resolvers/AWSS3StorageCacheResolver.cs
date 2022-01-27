// Copyright (c) Six Labors.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;

namespace SixLabors.ImageSharp.Web.Resolvers.AWS
{
    /// <summary>
    /// Provides means to manage image buffers within the <see cref="AWSS3StorageCacheResolver"/>.
    /// </summary>
    public class AWSS3StorageCacheResolver : IImageCacheResolver
    {
        private readonly IAmazonS3 amazonS3;
        private readonly string bucketName;
        private readonly string imagePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="AWSS3StorageCacheResolver"/> class.
        /// </summary>
        /// <param name="amazonS3">Amazon S3 Client</param>
        /// <param name="bucketName">Bucket Name for where the files are</param>
        /// <param name="imagePath">S3 Key</param>
        public AWSS3StorageCacheResolver(IAmazonS3 amazonS3, string bucketName, string imagePath)
        {
            this.amazonS3 = amazonS3;
            this.bucketName = bucketName;
            this.imagePath = imagePath;
        }

        /// <inheritdoc/>
        public async Task<ImageCacheMetadata> GetMetaDataAsync()
        {
            GetObjectMetadataResponse metadataResponse = await this.amazonS3.GetObjectMetadataAsync(this.bucketName, this.imagePath);
            var dict = new Dictionary<string, string>();

            ICollection<string> keys = metadataResponse.Metadata.Keys;
            foreach (string key in keys)
            {
                string k = key.Substring(11).ToUpper();
                dict.Add(k, metadataResponse.Metadata[key]);
            }

            return ImageCacheMetadata.FromDictionary(dict);
        }

        /// <inheritdoc/>
        public async Task<Stream> OpenReadAsync()
        {
            GetObjectResponse s3Object = await this.amazonS3.GetObjectAsync(this.bucketName, this.imagePath);
            return s3Object.ResponseStream;
        }
    }
}
