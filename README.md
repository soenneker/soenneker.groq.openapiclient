[![](https://img.shields.io/nuget/v/soenneker.groq.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.groq.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.groq.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.groq.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.groq.openapiclient/build-and-test.yml?style=for-the-badge&label=build)](https://github.com/soenneker/soenneker.groq.openapiclient/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.groq.openapiclient/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.groq.openapiclient/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.groq.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.groq.openapiclient/)

# Soenneker.Groq.OpenApiClient

A strongly typed, Kiota-generated .NET client for Groq's OpenAI-compatible API. It exposes request builders and models for chat completions, responses, audio, embeddings, files, batches, reranking, models, and fine-tuning operations.

## Installation

```bash
dotnet add package Soenneker.Groq.OpenApiClient
```

## Create the client directly

```csharp
using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Groq.OpenApiClient;

using var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", apiKey);

var authentication = new AnonymousAuthenticationProvider();
using var adapter = new HttpClientRequestAdapter(authentication, httpClient: httpClient);
var client = new GroqOpenApiClient(adapter);
```

The generated client defaults to `https://api.groq.com`. Set `adapter.BaseUrl` before constructing `GroqOpenApiClient` when using a proxy or alternate endpoint.

## List available models

```csharp
var result = await client.Openai.V1.Models.GetAsync(
    cancellationToken: cancellationToken);

foreach (var model in result?.Data ?? [])
{
    Console.WriteLine(model.Id);
}
```

Endpoints follow Kiota's request-builder hierarchy. For example, chat completions are available at `client.Openai.V1.Chat.Completions`, while fine-tuning operations are under `client.V1.Fine_tunings`.

For dependency-injection setup and managed HTTP-client reuse, use `Soenneker.Groq.OpenApiClientUtil`, which composes this generated client with `Soenneker.Groq.HttpClients`.

This repository contains generated source. Add application-specific behavior in separate partial-class files or wrapper services because regeneration can replace generated files.
