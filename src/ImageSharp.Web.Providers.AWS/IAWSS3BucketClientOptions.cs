// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

namespace SixLabors.ImageSharp.Web;

/// <summary>
/// Provides a common interface for AWS S3 Bucket Client Options.
/// </summary>
internal interface IAWSS3BucketClientOptions
{
    /// <summary>
    /// Gets the AWS region endpoint (us-east-1/us-west-1/ap-southeast-2).
    /// </summary>
    string? Region { get; init; }

    /// <summary>
    /// Gets the AWS bucket name.
    /// </summary>
    string BucketName { get; init; }

    /// <summary>
    /// Gets the AWS key - Can be used to override keys provided by the environment.
    /// If deploying inside an EC2 instance AWS keys will already be available via environment
    /// variables and don't need to be specified. Follow AWS best security practices on  <see href="https://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html"/>.
    /// </summary>
    string? AccessKey { get; init; }

    /// <summary>
    /// Gets the AWS endpoint - used to override the default service endpoint.
    /// If deploying inside an EC2 instance AWS keys will already be available via environment
    /// variables and don't need to be specified. Follow AWS best security practices on  <see href="https://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html"/>.
    /// </summary>
    string? AccessSecret { get; init; }

    /// <summary>
    /// Gets the AWS endpoint - used for testing to over region endpoint allowing it
    /// to be set to localhost.
    /// </summary>
    string? Endpoint { get; init; }

    /// <summary>
    /// Gets a value indicating whether the S3 accelerate endpoint is used.
    /// The feature must be enabled on the bucket. Follow AWS instruction on <see href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/transfer-acceleration.html"/>.
    /// </summary>
    bool UseAccelerateEndpoint { get; init; }

    /// <summary>
    /// Gets a value indicating the timeout for the S3 client.
    /// If the value is set, the value is assigned to the Timeout property of the HttpWebRequest/HttpClient object used to send requests.
    /// </summary>
    TimeSpan? Timeout { get; init; }
}
