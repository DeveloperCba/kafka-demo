﻿using System.IO.Compression;
using Confluent.Kafka;

namespace Core.Kafka.Serializers;

internal class Serializer<T> : ISerializer<T>
{
    public byte[] Serialize(T data, SerializationContext context)
    {
        var bytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(data);

        using var memoryStream = new MemoryStream();
        using var zipStream = new GZipStream(memoryStream, CompressionMode.Compress, true);
        zipStream.Write(bytes, 0, bytes.Length);
        zipStream.Close();
        var buffer = memoryStream.ToArray();

        return buffer;
    }
}